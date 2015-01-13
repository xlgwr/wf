using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;
using System.Data;
using Workflow.Model;
namespace Workflow
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string strDept = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            if (userInfo != null)
            {
                lblUserName.Text = userInfo.UserLoginName;
                lblLocation.Text = userInfo.UserLocation;
                lblDeptName.Text = userInfo.UserDepartment;
                lblUserName.ToolTip = userInfo.UserLoginName;
                lblLocation.ToolTip = userInfo.UserLocation;
                lblDeptName.ToolTip = userInfo.UserDepartment;
                strUser = userInfo.UserLoginName;
                strLocation = userInfo.UserLocation;
                strLang = userInfo.UserLang.Trim().ToUpper();
                strDept = userInfo.UserDepartment;
                PageBase.changeToolTip(Page, strLang);
                //LoadTree(strLang);
            }
            else
            {
                string loginPath = HttpContext.Current.Request.ApplicationPath + "Login.aspx";
                PageBase.ShowAndRedirectLogin(Page, "Session was expired", loginPath);
            }
        }
    }
}