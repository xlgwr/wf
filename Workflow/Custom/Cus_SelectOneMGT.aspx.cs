using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.BLL;
using Workflow.Model;
using Workflow.Common;

namespace Workflow.Custom
{
    public partial class Cus_SelectOneMGT : PageBase
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
            string location = Request["location"] == null ? "" : Request["location"].ToString().Trim();
            string dept = Request["dept"] == null ? "" :Request["dept"].ToString().Trim();
            if (dept.IndexOf("[]") >= 0)
            {
                dept = dept.Replace("[]", "&");
            }
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                boundUser(location, dept);
                //bindCompany();
            }
        }

        //protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindListDept(dropCompany.SelectedItem.Text);
        //}
        //private void bindCompany()
        //{
        //    dropCompany.DataSource = new Sys_Code_Mstr().GetModelList("code_cmmt = 'Company' order by code_fldname");
        //    dropCompany.DataTextField = "code_desc";
        //    dropCompany.DataValueField = "code_fldname";
        //    dropCompany.DataBind();
        //    dropCompany.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        //}


        //private void bindListDept(string strLocation)
        //{
        //    listDeptBox.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + strLocation + "'");
        //    listDeptBox.DataTextField = "user_dept";
        //    listDeptBox.DataValueField = "user_dept";
        //    listDeptBox.DataBind();
        //}
        private void boundUser(string strLocation, string strDept)
        {
            listUserBox.Items.Clear();
            List<Cus_MGT_Mstr_Model> listUser = new Cus_MGT_Mstr().GetModelList("manage_location = '" + strLocation + "' and manage_dept = '" + strDept + "' order by manage_name");
            foreach (Cus_MGT_Mstr_Model userModel in listUser)
            {
                listUserBox.Items.Add(userModel.manage_name);
            }
        }

        //protected void listDeptBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    boundUser(dropCompany.SelectedItem.Text, listDeptBox.SelectedItem.Text);
        //}
    }
}