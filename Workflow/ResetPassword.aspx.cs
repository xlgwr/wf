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
using System.Drawing;

namespace Workflow
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string strCode = "";
        string loginPath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            loginPath = HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
                   
            strCode = Request["code"] == null ? "" : Request["code"].Trim();
            if (new Sys_Link_Mstr().Exists(strCode)==false)
            {
                PageBase.ShowAndRedirectLogin(Page, "This hyperlink is ineffective", loginPath);
            }
            if (!IsPostBack)
            {
                bindDropDownList();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string userID = txtName.Text.Trim();
            string uPassword = txtPass.Text.Trim();
            string strIret = new SysLogin().ADValidate(dropDomain.SelectedValue.ToString().Trim(), userID, uPassword);
            Sys_User_Info user = new Sys_User_Info();
            if (strIret == "")
            {
                if (user.Exists(userID) == true)
                {
                    UserInfo userInfo = new UserInfo(userID);
                    String firstLoginPass = (user.GetModel(userID, dropDomain.SelectedItem.Text.ToString().Trim())).user_password.Trim();
                    if (firstLoginPass == "")
                    {
                        Session["initialUser"] = userID;
                        Response.Redirect("FirstLogin.aspx");
                    }

                    if (txtNewPass.Text.Trim().Length < 6)
                    {
                        lblMessage.Text = "passphrase at least 6 alphanumeric";
                        return;
                    }
                    else if (txtNewPass.Text.Trim() != txtConfirmPass.Text.Trim())
                    {
                        lblMessage.Text = "Entered Passwords are different";
                        return;
                    }
                    strIret = new Sys_Link_Mstr().ExecResetPwdProc(strCode, userID, dropDomain.SelectedItem.Text.Trim(), "RESETPWD", SysLogin.GetIP4Address(), DESEncrypt.Encode(txtNewPass.Text.Trim()));
                    switch (strIret)
                    {
                        case "0":
                            PageBase.ShowAndRedirectLogin(Page,"Reset passphrase successfully",loginPath);
                            break;
                        case "1":
                            lblMessage.Text = "This hyperlink is ineffective";
                            break;
                        case "2":
                            lblMessage.Text = "This hyperlink is not exists";
                            break;
                        case "99":
                            lblMessage.Text = "Database error";
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    lblMessage.Text = "User not exists in Workflow System!";
                }
            }
            else
            {
                lblMessage.Text = "Invalid domain information:</br>" + strIret;
            }
        }
        private void bindDropDownList()
        {
            List<Sys_Code_Mstr_Model> code_mstr_list = new Sys_Code_Mstr().GetModelList("code_cmmt='LDAP' order by code_fldname");
            dropDomain.DataSource = code_mstr_list;
            dropDomain.DataTextField = "code_desc";
            dropDomain.DataValueField = "code_value";
            dropDomain.DataBind();
            string ip = SysLogin.GetIP4Address();
            try
            {
                string ipprefix = ip.Split('.')[0].ToString().Trim();
                if (new Sys_Code_Mstr().Exists("IP", ipprefix))
                {
                    Sys_Code_Mstr_Model model = new Sys_Code_Mstr().GetModel("IP", ipprefix);
                    ListItem li = this.dropDomain.Items.FindByText(model.code_desc.Trim());
                    li.Selected = true;
                }
            }
            catch
            {

            }
        }

        protected void linkBack_Click(object sender, EventArgs e)
        {
            PageBase.ShowAndRedirectLogin(Page, "url redirect", loginPath);
        }
    }
}