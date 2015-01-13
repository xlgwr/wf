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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropDownList();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userID = txtUName.Text.Trim();
            string uPhase = txtPhase.Text.Trim();
            string uPassword = txtPassword.Text.Trim();
            string strIret = new SysLogin().ADValidate(dropDomain.SelectedValue.ToString().Trim(), userID, uPassword);
            Sys_User_Info user= new Sys_User_Info();
            if (strIret == "")
            {
                if(user.Exists(userID)==true)
                {
                UserInfo userInfo = new UserInfo(userID);
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
                    Response.Redirect("Index.aspx");
                }
              }
                else
                {
                     lblMessage.Text="User not exists in Workflow System!";
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

        }
    }
}