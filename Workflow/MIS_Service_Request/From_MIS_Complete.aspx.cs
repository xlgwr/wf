using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.BLL;
using Workflow.Common;
using Workflow.Model;

namespace Workflow.MIS_Service_Request
{
    public partial class From_MIS_Complete : PageBase
    {
        public string ReqNbr;
        public string ReqType;
        public string ReqSeq;
        public string strUser = PageBase.User_Name;
        public string strLocation = PageBase.User_Location;
        public string strLang = PageBase.User_Lang;
        string AttachAddr = System.Configuration.ConfigurationManager.AppSettings["DispAttach"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReqType = Request["ReqType"] == null ? "" : Request["ReqType"].ToString().Trim();
                ReqNbr = Request["ReqNbr"] == null ? "" : Request["ReqNbr"].ToString().Trim();
                ReqSeq = Request["ReqSeq"] == null ? "" : Request["ReqSeq"].ToString().Trim();
                if (ReqType != "" && ReqNbr != "" && ReqSeq != "")
                {
                    Cus_MIS_Service_Model mis_service = new Cus_MIS_Service().GetModel(ReqNbr);
                    txtNbr.Text = mis_service.m_svr_nbr;
                    txtRequestDate.Text = mis_service.m_svr_exp_date == null || mis_service.m_svr_exp_date == DateTime.Parse("1900-1-1") ? "" : mis_service.m_svr_exp_date.ToString("MM/dd/yyyy");
                    chkUrgent.Checked = mis_service.m_svr_urgent == "Y" ? true : false;
                    txtType.Text = getMenuName(mis_service.m_svr_type);
                    txtSubject.Text = mis_service.m_svr_subject;
                    txtDesc.Text = mis_service.m_svr_desc;
                    txtPlanBegin.Text=mis_service.m_svr_plan_from==null?"":mis_service.m_svr_plan_from.ToString("MM/dd/yyyy");
                    txtPlanEnd.Text=mis_service.m_svr_plan_end==null?"":mis_service.m_svr_plan_end.ToString("MM/dd/yyyy");
                    //txtRemark.Text = mis_service.m_svr_remark;
                    bindHistroyGrid(ReqNbr);
                    bindAttachGrid(ReqNbr);
                }
            }
        }

        protected void btnApprve_Click(object sender, EventArgs e)
        {
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = PageBase.User_Name;
            approveModel.Location = PageBase.User_Location;
            approveModel.Action = "PASS";
            approveModel.Remark = txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_Tasklist.aspx");
                    break;
                case "1":
                    Show(Page, "Form flow not exists", "申请流程不存在");
                    break;
                case "2":
                    Show(Page, "User not exists", "用户不存在");
                    break;
                case "3":
                    Show(Page, "Have no approve right", "没有审批权限");
                    break;
                case "78":
                    Show(Page, "Next step approver lost", "下一步骤审批人丢是");
                    break;
                case "77":
                    Show(Page, "Applicant not exists", "申请人不存在");
                    break;
                case "99":
                    Show(Page, "Document flow approve error", "文档流程审批出错");
                    break;
                default:
                    break;
            }
        }
        private void bindHistroyGrid(string strNbr)
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
        private void bindAttachGrid(string strNhr)
        {
            List<Sys_Attach_Mstr_Model> listAttach = new Sys_Attach_Mstr().GetModelList(" attach_nbr = '" + strNhr + "'");//todo add user upload condition because order to defend others delete on other file upload page. 
            attachGrid.DataSource = listAttach;
            attachGrid.DataKeyNames = new string[] { "attach_id", "attach_path" };
            attachGrid.DataBind();
        }

        protected void attachGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = "<a  target='_self' href='" + AttachAddr + attachGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim() + "'>" + e.Row.Cells[0].Text + "</a>";
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (txtRemark.Text == "")
            {
                Show(Page, "Enter reject remark", "输入反对备注");
                return;
            }
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = PageBase.User_Name;
            approveModel.Location = PageBase.User_Location;
            approveModel.Action = "REJECT";
            approveModel.Remark = txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_Tasklist.aspx");
                    break;
                case "1":
                    Show(Page, "Form flow not exists", "申请流程不存在");
                    break;
                case "2":
                    Show(Page, "User not exists", "用户不存在");
                    break;
                case "3":
                    Show(Page, "Have no approve right", "没有审批权限");
                    break;
                case "78":
                    Show(Page, "Next step approver lost", "下一步骤审批人丢是");
                    break;
                case "77":
                    Show(Page, "Applicant not exists", "申请人不存在");
                    break;
                case "99":
                    Show(Page, "Document flow approve error", "文档流程审批出错");
                    break;
                default:
                    break;
            }
        }
    }
}