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
namespace Workflow.Systems
{
    public partial class Tasklist : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName : "";
            strLocation = userInfo != null ? userInfo.UserLocation : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                bindData();
            }

        }

        private void bindData()
        {
            gridTask.DataSource = new Sys_Task_List().getList("approver = '" + strUser + "' ");//and appr_location ='" + strLocation + "'
            gridTask.DataKeyNames = new string[] { "flow_page", "appr_seq", "appr_type", "form_location" };
            gridTask.DataBind();
        }

        protected void gridTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string url = gridTask.DataKeys[e.Row.RowIndex]["flow_page"].ToString();
                string ReqType = gridTask.DataKeys[e.Row.RowIndex]["appr_type"].ToString();
                string ReqNbr = e.Row.Cells[0].Text.Trim();
                string ReqSeq = gridTask.DataKeys[e.Row.RowIndex]["appr_seq"].ToString();
                string ReqLoc = gridTask.DataKeys[e.Row.RowIndex]["form_location"].ToString();
                e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqType=" + ReqType + "&ReqLoc=" + ReqLoc + "&ReqNbr=" + ReqNbr + "&ReqSeq=" + ReqSeq + "'>" + e.Row.Cells[0].Text + "</a>";
            }
        }
    }
}