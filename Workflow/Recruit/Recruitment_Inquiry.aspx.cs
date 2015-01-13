using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;
using System.IO;
using System.Data;


namespace Workflow.Recruit
{
    public partial class Recruitment_Inquiry : PageBase
    {
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string strDept = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            strDept = userInfo != null ? userInfo.UserDepartment.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                bindropCompany();
                binDropDept(dropCompany.SelectedItem.Text);
                bindJobInfo(" job_applicant = '" + strUser + "'");
            }
        }
        private void binDropDept(string Location)
        {

            dropDept.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + Location + "'");
            dropDept.DataTextField = "user_dept";
            dropDept.DataValueField = "user_dept";
            dropDept.DataBind();
            dropDept.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        }
        private void bindropCompany()
        {
            Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
            List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'Company' order by code_fldname");
            if (codeModel != null && codeModel.Count > 0)
            {
                foreach (Sys_Code_Mstr_Model code in codeModel)
                {
                    dropCompany.Items.Add(code.code_desc);
                }
            }
            dropCompany.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        }

        private void bindJobInfo(string strWhere)
        {
            DataSet dsJob = new Cus_Job_Mstr().GetJobList(strWhere);
            jobGrid.DataSource = dsJob;
            jobGrid.DataKeyNames = new string[] { "job_guid", "form_seq" };
            jobGrid.DataBind();
        }
        private bool isRecruiterHead(string strUser, string strLocation)
        {
            Sys_User_Group userGroup = new Sys_User_Group();
            return userGroup.ExistsUserGroupLocation(strUser, "RECRUIT-HR-HEAD", strLocation);
        }
        private bool isDeptManager(string strUser, string strLocation)
        {
            Sys_User_Group userGroup = new Sys_User_Group();
            return userGroup.ExistsUserGroupLocation(strUser, "DEPTMANAGER", strLocation);
        }
        protected void jobGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void jobGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

         
                string url = "Recruitment_Details.aspx";
                string ReqGuid = jobGrid.DataKeys[e.Row.RowIndex]["job_guid"].ToString();
                e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
            }
        }
        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            binDropDept(dropCompany.SelectedItem.Text);
        }
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (isRecruiterHead(strUser, strLocation) == true)
            {
                strWhere = " 1 = 1 and job_location = '" + strLocation + "' ";
            }
            else if (isDeptManager(strUser, strLocation) == true)
            {
                strWhere = " 1 = 1 and job_location = '" + strLocation + "' and job_dept = '" + strDept + "' ";
            }
            else
            {
                strWhere = " 1 = 1 and job_recruiter = '" + strUser + "' ";
            }
            if (txtNbr.Text != "")
            {
                strWhere += " and job_nbr like '%" + PageValidate.SqlTextClear(txtNbr.Text.Trim()) + "%'";
            }
            if (txtTitle.Text != "")
            {
                strWhere += " and job_title like '%" + PageValidate.SqlTextClear(txtTitle.Text.Trim()) + "%'";
            }
            if (dropCompany.SelectedIndex > 0)
            {
                strWhere += " and job_location ='" + dropCompany.SelectedItem.Text.Trim() + "'";
            }
            if (dropDept.SelectedIndex > 0)
            {
                strWhere += " and job_dept ='" + dropDept.SelectedItem.Text.Trim() + "'";
            }
            bindJobInfo(strWhere);
        }
    }
}