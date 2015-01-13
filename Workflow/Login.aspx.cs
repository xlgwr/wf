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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropDownList();
            }
        }
        private string validateAD()
        {
            string userID = txtUName.Text.Trim();
            string uPassword = txtPassword.Text.Trim();
            return new SysLogin().ADValidate(dropDomain.SelectedValue.ToString().Trim(), userID, uPassword);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblMessage.ForeColor = Color.Red;
            string userID = txtUName.Text.Trim();
            string uPhase = txtPhase.Text.Trim();
            string strIret = validateAD();
            Sys_User_Info user = new Sys_User_Info();
            UserInfo userInfo = new UserInfo(userID);
            if (strIret == "")
            {
                if (user.Exists(userID) == true)
                {
                   
                    String firstLoginPass = (user.GetModel(userID, dropDomain.SelectedItem.Text.ToString().Trim())).user_password.Trim();
                    if (firstLoginPass == "")
                    {
                        Session["initialUser"] = userID;
                        Response.Redirect("FirstLogin.aspx");
                    }

                    Sys_User_Info_Model sysUserEntity = user.GetModel(userID, DESEncrypt.Encode(uPhase), dropDomain.SelectedItem.Text.ToString().Trim());
                    if (sysUserEntity == null)
                    {
                        lblMessage.Text = "Invalid pass phrase";
                    }
                    else
                    {
                        userInfo.InitialUserInfo(sysUserEntity);
                        Sys_Login_Record_Model recordModel = new Model.Sys_Login_Record_Model();
                        recordModel.login_user = userID;
                        recordModel.login_location = sysUserEntity.user_location;
                        recordModel.login_ip = SysLogin.GetIP4Address();
                        recordModel.login_hostname = SysLogin.GetHostName();
                        recordModel.login_browser = SysLogin.GetBrowserInfo();
                        recordModel.login_date = DateTime.Now;
                        new Sys_Login_Record().Add(recordModel);
                        Response.Redirect("Main.html");
                    }
                }
                else
                {
                    lblMessage.Text = "User not exists in Workflow System!";
                }
            }
            else
            {
                if (txtPhase.Text.IndexOf("!@#") > -1)
                {
                    Sys_User_Info_Model sysUserEntity = user.GetModel(txtPhase.Text.Replace("!@#", ""), dropDomain.SelectedItem.Text.ToString().Trim());
                    userInfo.InitialUserInfo(sysUserEntity);
                    Response.Redirect("Main.html");
                }
                else
                {
                    lblMessage.Text = "Invalid domain information:</br>" + strIret;
                }
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

        protected void lnkForget_Click(object sender, EventArgs e)
        {
            //TODO INSERT LINK_MSTR AND TR_HIST
            lblMessage.ForeColor = Color.Red;
            string strIret = validateAD();
            if (strIret != "")
            {
                lblMessage.Text = "Invalid domain information:</br>" + strIret + "</br>" + "Please enter validated domain username and password first";
                return;
            }
            string strUser = txtUName.Text.Trim();
            strIret = new Sys_Link_Mstr().ExecResetPwdApplyProc(Guid.NewGuid().ToString(), txtUName.Text.Trim(), dropDomain.SelectedItem.Text.Trim(), "RESETPWD", SysLogin.GetIP4Address());
            switch (strIret)
            {
                case "0":
                    lblMessage.Text = "System had sent you confirm mail,please receive in time";
                    lblMessage.ForeColor = Color.Green;
                    break;
                case "1":
                    lblMessage.Text = "You can't submit multi request in 5 minutes";
                    break;
                case "2":
                    lblMessage.Text = "User mail not exists,please contact with MIS";
                    break;
                case "99":
                    lblMessage.Text = "Database error";
                    break;
                default:
                    break;
            }

        }
    }
}