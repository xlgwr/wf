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
    public partial class Top : PageBase
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
                changeToolTip(Page, strLang);
            }
            else
            {
                string loginPath = HttpContext.Current.Request.ApplicationPath + "Login.aspx";
                ShowAndRedirectLogin(Page, "Session was expired", loginPath);
            }
          
        }

        protected void lblLanguage_Click(object sender, EventArgs e)
        {
            Sys_User_Info_Model userModel = new Sys_User_Info_Model();
            userModel.user_name = strUser;
            userModel.user_lang = strLang == "CN" ? "EN" : "CN";
            userModel.user_location = strLocation;
            userModel.user_dept = strDept;
            new Sys_User_Info().UpdateLanguage(userModel);
            new UserInfo(strUser).InitialUserInfo(userModel);
            //changeToolTip(Page, userModel.user_lang);
            //strLang = userModel.user_lang;
            //LoadTree(userModel.user_lang);
            Response.Write("<script>window.parent.location.href='Main.html'</script>");
        }

        protected void lnkLogiout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Clear();
            Session["OA-UserInfo"] = null;
            Session.Abandon();
            Response.Write("<script>window.parent.location.href='Login.aspx'</script>");
        }
    }
}