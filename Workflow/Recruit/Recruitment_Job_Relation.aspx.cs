using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;

namespace Workflow.Recruit
{
    public partial class Recruitment_Job_Relation : PageBase
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
                bindropCompany();
                binDropDept(dropCompany.SelectedItem.Text);
            }
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
            else
            {
                dropCompany.Text = strLocation.Trim();
            }
        }
        private void binDropDept(string Location)
        {
            dropDept.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + Location + "'");
            dropDept.DataTextField = "user_dept";
            dropDept.DataValueField = "user_dept";
            dropDept.DataBind();
        }

        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            binDropDept(dropCompany.SelectedItem.Text);
        }

        private void bindJobs(string strLocation, string strDept)
        {
            Cus_Job_Mstr jobMstr = new Cus_Job_Mstr();
            string strWhere = "job_location = '" + strLocation + "'";
            if (strDept != "")
            {
                strWhere += " and job_dept = '" + strDept + "'";
            }
            List<Cus_Job_Mstr_Model> jobMstrList = jobMstr.GetModelList(strWhere);
            foreach (Cus_Job_Mstr_Model job in jobMstrList)
            {
                ListItem item = new ListItem(job.job_nbr.Trim() + "(" + job.job_title.Trim() + ")", job.job_nbr.Trim());
                listJobs.Items.Add(item);
            }
        }

        protected void dropDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindJobs(dropCompany.Text.Trim(), dropDept.Text.Trim());
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ListItem item = listJobs.SelectedItem;

            if (listAdd.Items.Contains(item))
            {
                return;
            }
            else
            {
                listAdd.Items.Add(item);
            }

        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {

        }
    }
}