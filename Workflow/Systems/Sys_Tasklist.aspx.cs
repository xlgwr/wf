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
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, PageBase.User_Lang);
                bindData();
            }

        }

        private void bindData()
        {
            gridTask.DataSource = new Sys_Task_List().getList("approver = '" + PageBase.User_Name + "' ", strLang);//and appr_location ='" + PageBase.User_Location + "'
            gridTask.DataKeyNames = new string[] { "flow_page", "appr_seq", "appr_type", "form_location","form_guid" };
            gridTask.DataBind();
        }

        protected void gridTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string url = gridTask.DataKeys[e.Row.RowIndex]["flow_page"].ToString();
                string ReqGuid = gridTask.DataKeys[e.Row.RowIndex]["form_guid"].ToString();
                e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'>" + e.Row.Cells[0].Text + "</a>";
            }
        }
    }
}