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
namespace Workflow
{
    public partial class FirstLogin : System.Web.UI.Page
    {
        public string strUser = "";
        public string loginPath = HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["initialUser"] == null)
            {
                PageBase.ShowAndRedirectLogin(Page, "Relogin", loginPath);
                return;
            }
            strUser = Session["initialUser"].ToString();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNewPass.Text.Trim() == "" || txtConfirmPass.Text.Trim() == "")
            {
                lblMessage.Text = "Can't be blank!";
                return;
            }
            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                lblMessage.Text = "Entered Passwords are different";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                return;
            }
            if (txtConfirmPass.Text.Length < 6)
            {
                lblMessage.Text = "passphrase at least 6 alphanumeric";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                return;
            }
            Sys_User_Info_Model userModel = new Sys_User_Info_Model();
            userModel.user_name = strUser;
            userModel.user_password = Encryption.DESEncrypt.Encode(txtNewPass.Text.Trim());
            bool isUpdate = new Sys_User_Info().Update(userModel);
          
            if (isUpdate == true)
            {
                Session["OA-UserInfo"] = null;
                Session["initialUser"] = null;
                Session.Abandon();
                Session.Clear();
                PageBase.ShowAndRedirectLogin(Page, "Please Relogin", loginPath);
            }
            else
            {
                PageBase.ShowAndRedirectLogin(Page, "can't find your information in Workflow System", loginPath);
            }
        }
    }
}