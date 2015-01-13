using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using System.Threading;
using System.Globalization;
using Workflow.BLL;
using Workflow.Model;
using System.Data;
namespace Workflow.Systems
{
    public partial class Sys_Tasklist_001 : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public Sys_Flow_Mstr flowMstr = new Sys_Flow_Mstr();
        public Sys_Form_Mstr formMstr = new Sys_Form_Mstr();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
           
            if (!IsPostBack)
            {
                
                //bindData_PO();
                bindData_MIS();
                bindData_RECRUIT(); 
                changeToolTip(Page, strLang);
            }
        }

        private void bindData_MIS()
        {
            DataTable dt = new Sys_Task_List().getList("approver = '" + strUser + "' and flow_type = 'MIS' ",strLang);
            gridTask_MIS.DataSource = dt;//and appr_location ='" + PageBase.User_Location + "'
            gridTask_MIS.DataKeyNames = new string[] { "flow_page", "appr_seq", "appr_type", "form_location", "form_guid" };
            gridTask_MIS.DataBind();
        }
        private void bindData_RECRUIT()
        {
            DataTable dt = new Sys_Task_List().GetList_RECRUIT("approver = '" + strUser + "' and flow_type = 'CV' ", strLang,"approver = '" + strUser + "' and flow_type = 'JOB' ");
            gridTask_RECRUIT.DataSource = dt;//and appr_location ='" + PageBase.User_Location + "'
            gridTask_RECRUIT.DataKeyNames = new string[] { "job_guid", "flow_type" };
            gridTask_RECRUIT.DataBind();
        }
        private void bindSortData_RECRUIT()
        {
            string sortExpression = this.gridTask_RECRUIT.Attributes["SortExpression"];
            string sortDirection = this.gridTask_RECRUIT.Attributes["SortDirection"];
            DataTable sortDt = new Sys_Task_List().GetList_RECRUIT("approver = '" + strUser + "' and flow_type = 'CV' ", strLang, "approver = '" + strUser + "' and flow_type = 'JOB' ");
            if ((!string.IsNullOrEmpty(sortExpression)) && (!string.IsNullOrEmpty(sortDirection)))
            {
                sortDt.DefaultView.Sort = string.Format("{0} {1}", sortExpression, sortDirection);
            }
            gridTask_RECRUIT.DataSource = sortDt;
            gridTask_RECRUIT.DataBind();
            sortDt.Dispose();
        }
        protected void gridTask_RECRUIT_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExpression = e.SortExpression.ToString();
            string sortDirection = "ASC";
            if (sortExpression == this.gridTask_RECRUIT.Attributes["SortExpression"])
            {
                sortDirection = (this.gridTask_RECRUIT.Attributes["SortDirection"].ToString() == sortDirection ? "DESC" : "ASC");
            }
            this.gridTask_RECRUIT.Attributes["SortExpression"] = sortExpression;
            this.gridTask_RECRUIT.Attributes["SortDirection"] = sortDirection;
            bindSortData_RECRUIT();
        }
        //private void bindData_PO()
        //{
        //    DataTable dt = new Sys_Task_List().getList("approver = '" + strUser + "' and (flow_type = 'APO' or flow_type = 'MPO' or flow_type = 'CO' or flow_type = 'VT') ", strLang);//and appr_location ='" + PageBase.User_Location + "';
        //    gridTask_PO.DataSource = dt;
        //    gridTask_PO.DataKeyNames = new string[] { "flow_page", "appr_seq", "appr_type", "form_location", "form_guid" };
        //    gridTask_PO.DataBind();
        //}

        protected void gridTask_MIS_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string url = gridTask_MIS.DataKeys[e.Row.RowIndex]["flow_page"].ToString();
                string ReqGuid = gridTask_MIS.DataKeys[e.Row.RowIndex]["form_guid"].ToString();
                e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
            }
        }

        protected void gridTask_RECRUIT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string type = gridTask_RECRUIT.DataKeys[e.Row.RowIndex]["flow_type"].ToString().Trim().ToUpper();
                string ReqGuid = gridTask_RECRUIT.DataKeys[e.Row.RowIndex]["job_guid"].ToString();
                string url = "";
                int seq = new Sys_Form_Mstr().GetGuidModel(ReqGuid)==null?0:new Sys_Form_Mstr().GetGuidModel(ReqGuid).form_seq;

                if (type == "JOB"&&seq <300)
                {
                    url = "../Recruit/Recruitment.aspx";

                }
                else if (type == "JOB" && seq ==300)
                {
                    url = "../Recruit/Recruitment_Confirm.aspx";
                }
                else if (type == "JOB" && seq == 400)
                {
                    url = "../Recruit/Recruitment_Close.aspx";
                }
                else if (type == "JOB" && seq == 500)
                {
                    url = "../Recruit/Recruitment_Close_Extend.aspx";
                }
                if (type == "CV")
                {
                    url = "../Recruit/Recruitment_Approve.aspx";
                }
                
                
                e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
            }
        }

        protected void chkMIS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMIS.Checked == true)
            {
                div_mis.Visible = true;
            }
            else
            {
                div_mis.Visible = false;
            }
        }

        protected void chkHR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHR.Checked == true)
            {
                div_RECRUIT.Visible = true;
            }
            else
            {
                div_RECRUIT.Visible = false;
            }
        }

      

        //protected void gridTask_PO_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        string url = gridTask_PO.DataKeys[e.Row.RowIndex]["flow_page"].ToString();
        //        string ReqGuid = gridTask_PO.DataKeys[e.Row.RowIndex]["form_guid"].ToString();
        //        e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
        //    }
        //}
    }
}