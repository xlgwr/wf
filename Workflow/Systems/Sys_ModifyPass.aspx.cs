using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;
using Encryption;

namespace Workflow.Systems
{
    public partial class Sys_ModifyPass : PageBase
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
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtOldPass.Text.Trim() == "" || txtNewPass.Text.Trim() == "" || txtConfirmPass.Text.Trim() == "")
            {
                lblMessage.Text = strLang == "CN" ? "不能为空!" : "Can't be blank!";
                return;
            }
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                lblMessage.Text = strLang == "CN" ? "新密码两次输入不一致!" : "Entered passwords different!";
                txtOldPass.Text = "";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                return;
            }
            if (txtConfirmPass.Text.Length < 6)
            {
                lblMessage.Text = strLang == "CN" ? "密码长度最少6位!" : "passphrase at least 6 alphanumeric";
                txtOldPass.Text = "";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                return;
            }
            bool oldExists = new Sys_User_Info().Exists(strUser, DESEncrypt.Encode(txtOldPass.Text.Trim()));
            if (oldExists == false)
            {
                lblMessage.Text = strLang == "CN" ? "旧密码输入错误!" : "Old passphrase is wrong!";
                return;
            }
            else
            {
                Sys_User_Info_Model userModel = new Sys_User_Info_Model();
                userModel.user_name = strUser;
                userModel.user_password = DESEncrypt.Encode(txtNewPass.Text.Trim());
                bool isUpdate = new Sys_User_Info().Update(userModel);
                if (isUpdate == true)
                {
                    Session["OA-UserInfo"] = null;
                    string loginPath = HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
                    ShowAndRedirectLogin(Page, "Please Relogin",loginPath);
                }
            }
        }
    }
}