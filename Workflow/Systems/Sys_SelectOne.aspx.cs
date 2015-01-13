using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.BLL;
using Workflow.Model;
using Workflow.Common;

namespace Workflow.Systems
{
    public partial class Sys_SelectOne : PageBase
    {
        public string ctrlname = "";
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindListDept(dropCompany.SelectedItem.Text);
        }
        private void bindCompany()
        {
            dropCompany.DataSource = new Sys_Code_Mstr().GetModelList("code_cmmt = 'Company' order by code_fldname");
            dropCompany.DataTextField = "code_desc";
            dropCompany.DataValueField = "code_fldname";
            dropCompany.DataBind();
            dropCompany.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        }


        private void bindListDept(string strLocation)
        {
            listDeptBox.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + strLocation + "'");
            listDeptBox.DataTextField = "user_dept";
            listDeptBox.DataValueField = "user_dept";
            listDeptBox.DataBind();
        }
        private void boundUser(string strLocation, string strDept)
        {
            listUserBox.Items.Clear();
            List<Sys_User_Info_Model> listUser = new Sys_User_Info().GetModelList("user_location = '" + strLocation + "' and user_dept = '" + strDept + "' order by user_name");
            foreach (Sys_User_Info_Model userModel in listUser)
            {
                listUserBox.Items.Add(userModel.user_name);
            }
        }

        protected void listDeptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            boundUser(dropCompany.SelectedItem.Text, listDeptBox.SelectedItem.Text);
        }
    }
}