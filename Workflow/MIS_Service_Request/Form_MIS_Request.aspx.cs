using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;
using System.IO;
using Microsoft.VisualBasic;
namespace Workflow.WorkFlowFomrs
{
    public partial class Form_MIS_Request : PageBase
    {
        string ReqType = "MIS";
        string ReqNbr = "";
        string ReqSeq = "";
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        string AttachAddr = System.Configuration.ConfigurationManager.AppSettings["DispAttach"];
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                initialData();
                bindropCompany();
                bindDropTypeParent();
            }
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            attachModel.attach_nbr = txtNbr.Text;
            attachModel.attach_user = strUser;
            attachModel.attach_time = DateTime.Now;
            attachModel.attach_type = "MIS";
            attachModel.attach_location = strLocation;
            UploadAttach1.AttachModel = attachModel;
        }
        public void initialData()
        {
            btnApprve.Visible = false;
            ReqGuid = Request["ReqGuid"] == null ? "" : Request["ReqGuid"].ToString().Trim();
            Sys_Form_Mstr_Model formModel = new Sys_Form_Mstr().GetGuidModel(ReqGuid);
            if (formModel != null)
            {
                ReqType = formModel.form_type;
                ReqNbr = formModel.form_nbr;
                ReqSeq = formModel.form_seq.ToString();
            }
            else
            {
                ReqType = "";
                ReqNbr = "";
                ReqSeq = "";
            }
            if (ReqType != "" && ReqNbr != "" && ReqSeq != "")
            {
                Cus_MIS_Service_Model mis_service = new Cus_MIS_Service().GetModel(ReqNbr);
                txtNbr.Text = mis_service.m_svr_nbr;
                txtRequest.Text = mis_service.m_svr_exp_date == null || mis_service.m_svr_exp_date == DateTime.Parse("1900-1-1") ? "" : mis_service.m_svr_exp_date.ToString("MM/dd/yyyy");
                chkUrgent.Checked = mis_service.m_svr_urgent == "Y" ? true : false;
                txtType.Text = new Cus_MIS_Type().GetTypeFullName(mis_service.m_svr_type,strLang); 
                lblTypeCode.Text = mis_service.m_svr_type.Trim();
                txtSubject.Text = mis_service.m_svr_subject;
                txtDesc.Text = mis_service.m_svr_desc;
                //txtRemark.Text = mis_service.m_svr_remark;
                bindHistoryGrid(ReqNbr);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRequest.Text == "" || DateTime.Parse(txtRequest.Text.Trim() + " 23:59:59") < DateTime.Now)
            {
                Show(Page, "Please enter right expect day", "请输入正确的期望日期", strLang);
                return;
            }
            if (txtType.Text == "" || lblTypeCode.Text == "")
            {
                Show(Page, "Please choose type", "请选择类型", strLang);
                return;
            }
            if (txtSubject.Text == "" || txtDesc.Text == "")
            {
                Show(Page, "Must enter subject and description", "必须输入主题和描述", strLang);
                return;
            }

            string strNbr = txtNbr.Text.Trim();
            DateTime dateRequest = txtRequest.Text != "" ? DateTime.Parse(txtRequest.Text.Trim()) : DateTime.Parse("1900-1-1");
            string strUrgent = chkUrgent.Checked ? "Y" : "N";
            string strSubject = txtSubject.Text.Trim();
            string strDesc = txtDesc.Text.Trim();
            //string strRemark = txtRemark.Text.Trim();
            Cus_MIS_Service_Model mis_service = new Cus_MIS_Service_Model();
            mis_service.m_svr_nbr = strNbr;
            mis_service.m_svr_user = strUser;
            mis_service.m_svr_location = dropCompany.SelectedItem.Text;
            mis_service.m_svr_type = lblTypeCode.Text.Trim();
            mis_service.m_svr_exp_date = dateRequest;
            mis_service.m_svr_subject = strSubject;
            mis_service.m_svr_desc = strDesc;
            //mis_service.m_svr_remark = strRemark;
            mis_service.m_svr_urgent = strUrgent;
            string[] returnArray = new Cus_MIS_Service().SaveMISService(mis_service).Split('|');
            string strIret = returnArray[0].Trim();
            switch (strIret)//todo
            {
                case "0":
                    Show(Page, "Save Successfully", "保存成功", strLang);
                    txtNbr.Text = returnArray[1];
                    btnApprve.Visible = true;
                    break;
                default:
                    break;
            }
        }

        protected void btnApprve_Click(object sender, EventArgs e)
        {
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = strUser;
            approveModel.Location = dropCompany.SelectedItem.Text;
            approveModel.Action = "PASS";
            approveModel.Remark = "";
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_InProcess.aspx",strLang);
                    btnSave.Visible = false;
                    btnApprve.Visible = false;
                    break;
                case "1":
                    Show(Page, "Form flow not exists", "申请流程不存在", strLang);
                    break;
                case "2":
                    Show(Page, "User not exists", "用户不存在", strLang);
                    break;
                case "3":
                    Show(Page, "Have no approve right", "没有审批权限", strLang);
                    break;
                case "78":
                    Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                    break;
                case "77":
                    Show(Page, "Applicant not exists", "申请人不存在", strLang);
                    break;
                case "99":
                    Show(Page, "Document flow approve error", "文档流程审批出错", strLang);
                    break;
                default:
                    break;
            }
        }

        //private void bindTypeMenu()
        //{
        //    Cus_MIS_Type misType = new Cus_MIS_Type();
        //    List<Cus_MIS_Type_Model> parentModel = misType.GetModelList(" mis_type_level = 1 order by mis_type_order");
        //    foreach (Cus_MIS_Type_Model root in parentModel)
        //    {
        //        MenuItem rootitem = new MenuItem();
        //        rootitem.Value = root.mis_type_code;
        //        rootitem.Text = strLang == "CN" ? root.mis_type_value_cn : root.mis_type_value;
        //        TypeMenu.Items.Add(rootitem);
        //        addTypeChildMenu(rootitem);
        //    }
        //}

        private void addTypeChildMenu(MenuItem root)
        {
            Cus_MIS_Type misType = new Cus_MIS_Type();
            string rootvalue = root.Value.Trim();
            List<Cus_MIS_Type_Model> childModel = misType.GetModelList(" mis_type_code like '" + rootvalue + "%' and mis_type_level>1 order by mis_type_order");
            if (childModel != null && childModel.Count > 0)
            {
                foreach (Cus_MIS_Type_Model child in childModel)
                {
                    MenuItem childItem = new MenuItem();
                    childItem.Value = child.mis_type_code;
                    childItem.Text = strLang == "CN" ? child.mis_type_value_cn : child.mis_type_value;
                    root.ChildItems.Add(childItem);
                }
            }
        }

        //protected void TypeMenu_MenuItemClick(object sender, MenuEventArgs e)
        //{

        //    string itemcode = e.Item.Value.Trim();
        //    txtType.Text = getMenuName(itemcode);

        //}

        //private string getMenuName(string code)
        //{
        //    Cus_MIS_Type_Model typeModel = new Cus_MIS_Type().GetModel(code);
        //    lblTypeCode.Text = code;
        //    if (typeModel != null)
        //    {
        //        return strLang == "CN" ? typeModel.mis_type_value_cn : typeModel.mis_type_value;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        private void bindHistoryGrid(string strNbr)
        {
            List<Sys_Appd_Mstr_Model> listAppd = new Sys_Appd_Mstr().GetModelList("appd_nbr ='" + strNbr + "' order by appd_date");
            historyGrid.DataSource = listAppd;
            historyGrid.DataBind();
        }
        private void bindDropTypeParent()
        {
            Cus_MIS_Type misType = new Cus_MIS_Type();
            List<Cus_MIS_Type_Model> parentModel = misType.GetModelList(" mis_type_level = 1 order by mis_type_order");
            foreach (Cus_MIS_Type_Model parent in parentModel)
            {
                ListItem item = new ListItem(strLang == "CN" ? parent.mis_type_value_cn : parent.mis_type_value, parent.mis_type_code);
                dropTypeParent.Items.Add(item);
            }
            dropTypeParent.Items.Insert(0, strLang == "CN" ? "---请选择---" : "---Choose---");
        }

        private void bindropCompany()
        {
            Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
            List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'Company' order by code_fldname");
            if (codeModel != null && codeModel.Count > 0)
            {
                foreach (Sys_Code_Mstr_Model code in codeModel)
                {
                    dropCompany.Items.Add(code.code_desc);
                }
            }
            dropCompany.Text = strLocation.Trim();
        }
        protected void dropTypeParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropTypeChild.Items.Clear();
            Cus_MIS_Type misType = new Cus_MIS_Type();
            List<Cus_MIS_Type_Model> childModel = misType.GetModelList(" mis_type_code like '" + dropTypeParent.SelectedItem.Value.Trim() + "%' and mis_type_level>1 order by mis_type_order");
            if (childModel != null && childModel.Count > 0)
            {
                txtType.Text ="";
                lblTypeCode.Text = "";
                dropTypeChild.Visible = true;
                foreach (Cus_MIS_Type_Model child in childModel)
                {
                    ListItem item = new ListItem(strLang == "CN" ? child.mis_type_value_cn : child.mis_type_value, child.mis_type_code);
                    dropTypeChild.Items.Add(item);
                }
                dropTypeChild.Items.Insert(0, strLang == "CN" ? "---请选择---" : "---Choose---");
            }
            else
            {
                if (dropTypeParent.SelectedIndex == 0)
                {
                    txtType.Text = "";
                    lblTypeCode.Text = "";
                    dropTypeChild.Visible = false;
                }
                else
                {
                    txtType.Text = dropTypeParent.SelectedItem.Text.Trim();
                    lblTypeCode.Text = dropTypeParent.SelectedItem.Value.Trim();
                    dropTypeChild.Visible = false;
                }
            }
        }

        protected void dropTypeChild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropTypeChild.SelectedIndex == 0)
            {
                txtType.Text = "";
                lblTypeCode.Text = "";
            }
            else
            {
                txtType.Text = dropTypeParent.SelectedItem.Text.Trim()+" : "+ dropTypeChild.SelectedItem.Text.Trim();
                lblTypeCode.Text = dropTypeChild.SelectedItem.Value.Trim();
            }
        }

        protected void rdoCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show(Page, "Please carefully  select company code", "请谨慎选择公司代码", strLang);
        }
    }
}