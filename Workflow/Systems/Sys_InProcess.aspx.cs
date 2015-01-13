using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;
using Workflow.Controller;
namespace Workflow.Systems
{
    public partial class Alltask : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                bindData(strUser, strLocation);
            }
        }

        private void bindData(string strUser, string strLocation)
        {
            gridData.DataSource = new Sys_Form_Mstr().GetModelList("form_seq > 10 and form_type <>'CV' and form_applicant = '" + strUser + "' ");//and form_location = '"+strLocation+"'
            gridData.DataKeyNames = new string[] { "form_guid", "form_type","form_nbr","form_seq"};
            gridData.DataBind();
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ReqGuid = gridData.DataKeys[e.Row.RowIndex]["form_guid"].ToString();
                string type = gridData.DataKeys[e.Row.RowIndex]["form_type"].ToString();
                string ReqNbr = gridData.DataKeys[e.Row.RowIndex]["form_nbr"].ToString();
                int ReqSeq =int.Parse(gridData.DataKeys[e.Row.RowIndex]["form_seq"].ToString());
                //if (type.Trim().ToUpper() == "JOB")
                //{
                //    e.Row.Cells[1].Text = "<a target='_self' href='Sys_InProcess_Sub.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>Details</a>";
                //}
                //else
                //{
                //    //e.Row.Cells[0].Text = "<a target='_self' href='Sys_FlowDisplay.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>" + e.Row.Cells[0].Text + "</a>";
                //    e.Row.Cells[1].Text = "No details";
                //}
                LinkButton linknum = (LinkButton)e.Row.Cells[1].FindControl("linkNum");
                Label linksubnum = (Label)e.Row.Cells[1].FindControl("lblSubNum");
                linknum.Text = ReqNbr;
                linknum.ToolTip = ReqNbr;
                if (type.Trim().ToUpper() == "JOB" && ReqSeq<300)
                {
                    linksubnum.Text = "<a target='_self' href='Sys_InProcess_Sub.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>Details</a>";
                    linksubnum.ToolTip = "<a target='_self' href='Sys_InProcess_Sub.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>Details</a>";
                }
                else
                {
                    //e.Row.Cells[0].Text = "<a target='_self' href='Sys_FlowDisplay.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>" + e.Row.Cells[0].Text + "</a>";
                    linksubnum.Text = "No details";
                    linksubnum.ToolTip = "No details";
                }

            }
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            FlowChartDisplay flowDisplay = new FlowChartDisplay();     
            string cur_guid;
            if (e.CommandName == "LinkNum")
            {
                cur_guid = e.CommandArgument.ToString();
                flowDisplay.bindFlowChart(cur_guid, strLang, lblPlace);
                flowDisplay.bindHistoryGrid(cur_guid, historyGrid);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>showDiv()</script>");
            }
        }
    }
}