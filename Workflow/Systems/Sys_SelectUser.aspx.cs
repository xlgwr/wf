using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;
using Workflow.Model;

namespace Workflow.Systems
{
    public partial class Sys_SelectUser : PageBase
    {
        public string ctrlname = "";
        public string selectuser="";
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            selectuser = Request.QueryString["txtselectuser"];
            ctrlname = Request.QueryString["ctrlname"];
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                bindCompany();
            }
        }

        private void bindListDept(string strLocation)
        {
            listDept.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + strLocation + "'");
            listDept.DataTextField = "user_dept";
            listDept.DataValueField = "user_dept";
            listDept.DataBind();
        }

        private void boundUser(string strLocation, string strDept)
        {
            ListBox1.Items.Clear();
            List<Sys_User_Info_Model> listUser = new Sys_User_Info().GetModelList("user_location = '" + strLocation + "' and user_dept = '" + strDept + "'");
            foreach (Sys_User_Info_Model userModel in listUser)
            {
                ListBox1.Items.Add(userModel.user_name);
            }
        }
        private void bindCompany()
        {
            dropCompany.DataSource = new Sys_Code_Mstr().GetModelList("code_cmmt = 'Company' order by code_fldname");
            dropCompany.DataTextField = "code_desc";
            dropCompany.DataValueField = "code_fldname";
            dropCompany.DataBind();
            dropCompany.Items.Insert(0, strLang == "CN" ? "-选择-" : "-Choose-");
        }

        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindListDept(dropCompany.SelectedItem.Text);
            ListBox1.Items.Clear();
        }

        protected void listDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            boundUser(dropCompany.SelectedItem.Text, listDept.SelectedItem.Text);
        }
    }
}