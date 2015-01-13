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
    public partial class Form_MIS_Details : PageBase
    {
        public string ReqNbr;
        public string ReqSeq;
        public string ReqLoc;
        public string ReqGuid;
        public string ReqType;
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
                if (ReqNbr != "")
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
                    txtRequestDate.Text = mis_service.m_svr_exp_date == null || mis_service.m_svr_exp_date == DateTime.Parse("1900-1-1") ? "" : mis_service.m_svr_exp_date.ToString("MM/dd/yyyy");
                    chkUrgent.Checked = mis_service.m_svr_urgent == "Y" ? true : false;
                    txtType.Text = new Cus_MIS_Type().GetTypeFullName(mis_service.m_svr_type, strLang);
                    txtSubject.Text = mis_service.m_svr_subject;
                    txtDesc.Text = mis_service.m_svr_desc;
                    txtPlanBegin.Text = mis_service.m_svr_plan_from == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_plan_from.ToString("MM/dd/yyyy");
                    txtPlanEnd.Text = mis_service.m_svr_plan_end == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_plan_end.ToString("MM/dd/yyyy");
                    txtActBegin.Text = mis_service.m_svr_act_from == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_act_from.ToString("MM/dd/yyyy");
                    txtActEnd.Text = mis_service.m_svr_act_end == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_act_end.ToString("MM/dd/yyyy");
                    txtProcessBy.Text = mis_service.m_svr_process_by == null ? "" : mis_service.m_svr_process_by;
                    bindHistoryGrid(ReqNbr);
                    bindAttachGrid(ReqNbr);
                }
            }
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
    }
}