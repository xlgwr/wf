using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;
using Workflow.Model;
namespace Workflow.MIS_Service_Request
{
    public partial class Form_MIS_Assign : PageBase
    {
        public string ReqNbr;
        public string ReqType;
        public string ReqSeq;
        public string ReqLoc;
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        string AttachAddr = System.Configuration.ConfigurationManager.AppSettings["DispAttach"];
        protected void Page_Load(object sender, EventArgs e)
        {
            ReqGuid = Request["ReqGuid"] == null ? "" : Request["ReqGuid"].ToString().Trim();
            Sys_Form_Mstr_Model formModel = new Sys_Form_Mstr().GetGuidModel(ReqGuid);
            if (formModel != null)
            {
                ReqType = formModel.form_type;
                ReqNbr = formModel.form_nbr;
                ReqSeq = formModel.form_seq.ToString();
                ReqLoc = formModel.form_location;
            }
            else
            {
                ReqType = "";
                ReqNbr = "";
                ReqSeq = "";
                ReqLoc = "";
            }
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                //checkApprove.Checked = true;
                //dropGroup.Enabled = false;
                //dropCompany.Enabled = false;
                //dropMIS.Enabled = false;
                //txtPlanBegin.Enabled = false;
                //txtPlanEnd.Enabled = false;
                panelRelate.Visible = false;
                if (ReqSeq == "36")
                {
                    Panel1.Visible = false;
                    checkApprove.Checked = false;
                    txtPlanBegin.Enabled = true;
                    txtPlanEnd.Enabled = true;
                    dropCompany.Enabled = true;
                    dropMIS.Enabled = true;
                }
                if (ReqType != "" && ReqNbr != "" && ReqSeq != "")
                {
                    Sys_Flow_Mstr flowMstr = new Sys_Flow_Mstr();
                    Sys_Flow_Mstr_Model flowMstrModel = flowMstr.GetModel(ReqLoc, int.Parse(ReqSeq), ReqType);
                    if (flowMstrModel != null)
                    {
                        lblTaskStatus.Text = strLang == "CN" ? flowMstrModel.flow_status_cn.Trim() : flowMstrModel.flow_status_en.Trim();
                    }
                    Cus_MIS_Service_Model mis_service = new Cus_MIS_Service().GetModel(ReqNbr);
                    txtNbr.Text = mis_service.m_svr_nbr;
                    txtLocation.Text = mis_service.m_svr_location;
                    txtApplicant.Text = mis_service.m_svr_user;
                    txtDept.Text = mis_service.m_svr_dept;
                    txtRequestDate.Text = mis_service.m_svr_exp_date == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_exp_date.ToString("MM/dd/yyyy");
                    chkUrgent.Checked = mis_service.m_svr_urgent == "Y" ? true : false;
                    txtType.Text = new Cus_MIS_Type().GetTypeFullName(mis_service.m_svr_type, strLang);
                    txtSubject.Text = mis_service.m_svr_subject;
                    txtDesc.Text = mis_service.m_svr_desc;
                    txtPlanBegin.Text = DateTime.Now.ToString("MM/dd/yyyy");
                    txtPlanEnd.Text = DateTime.Now.AddDays(3).ToString("MM/dd/yyyy");
                    bindCompany(mis_service.m_svr_location);
                    bindMIS(mis_service.m_svr_location);
                    bindGroup(mis_service.m_svr_location);
                    bindHistoryGrid(ReqNbr);
                }
            }
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            attachModel.attach_nbr = ReqNbr;
            attachModel.attach_user = strUser;
            attachModel.attach_time = DateTime.Now;
            attachModel.attach_type = "MIS";
            attachModel.attach_location = strLocation;
            UploadAttach1.AttachModel = attachModel;
        }

        private void bindHistoryGrid(string strNbr)
        {
            List<Sys_Appd_Mstr_Model> listAppd = new Sys_Appd_Mstr().GetModelList("appd_nbr ='" + strNbr + "' order by appd_date");
            historyGrid.DataSource = listAppd;
            historyGrid.DataBind();
        }


        private string getMenuName(string code)
        {
            Cus_MIS_Type_Model typeModel = new Cus_MIS_Type().GetModel(code);
            if (typeModel != null)
            {
                return strLang == "CN" ? typeModel.mis_type_value_cn : typeModel.mis_type_value;
            }
            else
            {
                return "";
            }
        }

        protected void btnApprve_Click(object sender, EventArgs e)
        {
            if (extend() == false)
            {
                return;
            }
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = strUser;
            approveModel.Location = ReqLoc;
            approveModel.Action = "PASS";
            approveModel.Remark = txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
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

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (txtRemark.Text == "")
            {
                Show(Page, "Enter reject remark", "输入反对备注", strLang);
                return;
            }
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = strUser;
            approveModel.Location = ReqLoc;
            approveModel.Action = "REJECT";
            approveModel.Remark = txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
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



        private bool extend()
        {
            Cus_MIS_Service mis = new Cus_MIS_Service();
            Cus_MIS_Service_Model misModel = new Cus_MIS_Service_Model();
            Sys_Appr_Mstr apprMstr = new Sys_Appr_Mstr();
            Sys_User_Info userInfo = new Sys_User_Info();
            misModel.m_svr_nbr = txtNbr.Text.Trim();
            if (checkApprove.Checked == false)
            {
                misModel.m_svr_relate = "N";
                if (txtPlanBegin.Text == "" || txtPlanEnd.Text == "")
                {
                    Show(Page, "Please enter begin date and end date", "请输入开始和结束日期", strLang);
                    return false;
                }
                if (DateTime.Parse(txtPlanBegin.Text.Trim()) > DateTime.Parse(txtPlanEnd.Text.Trim()))
                {
                    Show(Page, "Please enter right begin date and end date", "请输入正确的开始和结束日期", strLang);
                    return false;
                }
                if (dropMIS.SelectedIndex == 0 && dropGroup.SelectedIndex == 0)
                {
                    Show(Page, "Please assign person", "请指派人员", strLang);
                    return false;
                }
                apprMstr.Delete(txtNbr.Text.Trim(), 40, "N", "N");
                misModel.m_svr_plan_from = DateTime.Parse(txtPlanBegin.Text);
                misModel.m_svr_plan_end = DateTime.Parse(txtPlanEnd.Text);
                if (dropMIS.SelectedIndex > 0 && dropGroup.SelectedIndex==0)
                {
                    misModel.m_svr_process_by = dropMIS.SelectedItem.Text;
                }
                if (dropMIS.SelectedIndex == 0 && dropGroup.SelectedIndex > 0)
                {
                    misModel.m_svr_process_by = dropGroup.SelectedItem.Text;
                }
                if (dropGroup.SelectedIndex > 0 && dropMIS.SelectedIndex > 0)
                {
                    misModel.m_svr_process_by = dropMIS.SelectedItem.Text + "&" + dropGroup.SelectedItem.Text;
                }
                if (mis.UpdateProcess(misModel) == true)
                {
                    if (dropMIS.SelectedIndex > 0)
                    {
                        Sys_Appr_Mstr_Model apprModel = new Sys_Appr_Mstr_Model();
                        Sys_User_Info_Model userModel = userInfo.GetModel(dropMIS.SelectedItem.Text);
                        apprModel.appr_nbr = txtNbr.Text.Trim();
                        apprModel.appr_type = "MIS";
                        apprModel.appr_user = dropMIS.SelectedItem.Text; ;
                        apprModel.appr_seq = 40;
                        apprModel.appr_parallel = "N";
                        apprModel.appr_now = "N";
                        apprModel.appr_group = "Assign";
                        apprModel.appr_date_in = DateTime.Now;
                        apprModel.appr_level = 1;
                        apprModel.appr_dept = userModel.user_dept;
                        apprModel.appr_location = dropCompany.SelectedItem.Text.Trim();
                        apprModel.appr_appr = "N";
                        if (userModel!=null)
                        {
                            apprMstr.Add(apprModel);
                        }
                        else
                        {
                            apprMstr.Delete(txtNbr.Text.Trim(), 40, "N", "N");
                            return false;
                        }
                    }
                    if (dropGroup.SelectedIndex > 0)
                    {
                        List<Sys_User_Group_Model> users = new Sys_User_Group().GetModelList(" user_location = '" + dropCompany.SelectedItem.Text + "' and user_group = '" + dropGroup.SelectedItem.Text + "'");
                        if (users.Count > 0)
                        {
                            foreach (Sys_User_Group_Model user in users)
                            {
                                Sys_Appr_Mstr_Model apprModel = new Sys_Appr_Mstr_Model();
                                Sys_User_Info_Model userModel = userInfo.GetModel(user.user_name);
                                if (userModel != null)
                                {
                                    apprModel.appr_nbr = txtNbr.Text.Trim();
                                    apprModel.appr_type = "MIS";
                                    apprModel.appr_user = user.user_name;
                                    apprModel.appr_seq = 40;
                                    apprModel.appr_parallel = "N";
                                    apprModel.appr_now = "N";
                                    apprModel.appr_group = "Assign";
                                    apprModel.appr_date_in = DateTime.Now;
                                    apprModel.appr_level = 1;
                                    apprModel.appr_dept = userModel.user_dept;
                                    apprModel.appr_location = user.user_location;
                                    apprModel.appr_appr = "N";
                                    apprMstr.Add(apprModel);
                                }
                                else
                                {
                                    apprMstr.Delete(txtNbr.Text.Trim(), 40, "N", "N");
                                    Show(Page, user.user_name + " is not exists in group", user.user_name + "不在组中", strLang);
                                    return false;
                                }
                            }
                        }
                        else if (dropMIS.SelectedIndex == 0)
                        {
                            Show(Page, "no assign objects", "没有分配的对象", strLang);
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                        return true;
                    }
                    else
                    {
                        if (dropMIS.SelectedIndex == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    apprMstr.Delete(txtNbr.Text.Trim(), 40, "N", "N");
                    return false;
                }
            }
            else
            {
                misModel.m_svr_relate = "Y";
                if (txtRelative.Text == "")
                {
                    Show(Page, "Please select relative approver", "请选择相关审批人", strLang);
                    return false;
                }
                if (mis.UpdateRelative(misModel) == true)
                {
                    string[] approver = txtRelative.Text.Split(';');

                    apprMstr.Delete(txtNbr.Text.Trim(), 34, "N", "N");
                    for (int i = 0; i < approver.Length; i++)
                    {
                        Sys_User_Info_Model userModel = userInfo.GetModel(approver[i]);
                        if (userModel == null)
                        {
                            Show(Page, "Approver" + approver[i] + " not exists", "审批人" + approver[i] + "不存在", strLang);
                            return false;
                        }
                        else
                        {
                            Sys_Appr_Mstr_Model apprModel = new Sys_Appr_Mstr_Model();
                            apprModel.appr_nbr = txtNbr.Text.Trim();
                            apprModel.appr_type = "MIS";
                            apprModel.appr_user = approver[i];
                            apprModel.appr_seq = 34;
                            apprModel.appr_parallel = "Y";
                            apprModel.appr_now = "N";
                            apprModel.appr_group = "Assign";
                            apprModel.appr_date_in = DateTime.Now;
                            apprModel.appr_level = 1;
                            apprModel.appr_dept = userModel.user_dept;
                            apprModel.appr_location = dropCompany.SelectedItem.Text.Trim();
                            apprModel.appr_appr = "N";
                            apprMstr.Add(apprModel);
                        }
                    }
                    return true;
                }
                else
                {
                    apprMstr.Delete(txtNbr.Text.Trim(), 34, "N", "N");
                    return false;
                }
            }

        }



        protected void checkApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (checkApprove.Checked == true)
            {
                dropGroup.Enabled = false;
                txtPlanBegin.Enabled = false;
                txtPlanEnd.Enabled = false;
                dropCompany.Enabled = false;
                dropMIS.Enabled = false;
                panelRelate.Visible = true;
            }
            else
            {
                dropGroup.Enabled = true;
                txtPlanBegin.Enabled = true;
                txtPlanEnd.Enabled = true;
                dropCompany.Enabled = true;
                dropMIS.Enabled = true;
                panelRelate.Visible = false;
            }
        }
        private void bindMIS(string strCompany)
        {
            dropMIS.DataSource = new Sys_User_Info().GetModelList(" user_dept = 'MIS' and user_location ='" + strCompany + "' order by user_name");
            dropMIS.DataTextField = "user_name";
            dropMIS.DataValueField = "user_name";
            dropMIS.DataBind();
            ListItem item = new ListItem(strLang == "CN" ? "==请选择==" : "==Please Choose==");
            dropMIS.Items.Insert(0, item);
        }

        private void bindGroup(string strCompany)
        {
            Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
            dropGroup.DataSource = codeMstr.GetModelList("code_cmmt = 'MIS-ASSIGN' and code_desc = '" + strLocation + "'order by code_fldname");
            dropGroup.DataTextField = "code_value";
            dropGroup.DataValueField = "code_value";
            dropGroup.DataBind();
            ListItem item = new ListItem(strLang == "CN" ? "==请选择==" : "==Please Choose==");
            dropGroup.Items.Insert(0, item);
        }

        private void bindCompany(string strLocation)
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
            dropCompany.Text = strLocation;

        }
        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindMIS(dropCompany.SelectedItem.Text);
            bindGroup(dropCompany.SelectedItem.Text);
        }
    }
}