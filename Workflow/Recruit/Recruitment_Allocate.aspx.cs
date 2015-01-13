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
    public partial class Recruitment_Allocate : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string AttachAddr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                //bindJobs(strLocation, strUser);
                bindCV(strLocation);
                bindropCompany();
                binDropDept(dropCompany.SelectedItem.Text);
                bindJobs("", "", "");
            }
        }

        private void bindJobs(string strLocation, string strRecruter,string strDept)
        {
            dropJobs.Items.Clear();
            Cus_Job_Mstr jobMstr = new Cus_Job_Mstr();
            List<Cus_Job_Mstr_Model> listjobMstr = jobMstr.GetModelList(" job_location = '" + strLocation + "' and job_seq >=0 and job_dept = '"+strDept+"'order by job_nbr ");
            foreach (Cus_Job_Mstr_Model job in listjobMstr)
            {
                dropJobs.Items.Add(job.job_nbr+"--"+job.job_dept + "--" + job.job_title);
            }
            dropJobs.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (dropJobs.SelectedIndex == 0)
            {
                PageBase.Show(Page, "please choose job number", "请选择职位编号", strLang);
                return;
            }

            for (int i = 0; i < cvGrid.Rows.Count; i++)
            {
                //如果某一行的CheckBox被选中，则执行删除操作
                CheckBox chk = (CheckBox)(cvGrid.Rows[i].Cells[0].FindControl("chkCheck"));
                if (chk.Checked == true)
                {
                    string guid = cvGrid.DataKeys[i]["log_guid"].ToString();
                    string iret = new Cus_CV_Det().ExecCVAllocate(dropJobs.SelectedItem.Text.Trim(), strUser, guid);
                }
            }
            bindCV(strLocation);
        }
        private void bindCV(string strLocation)
        {
            List<Cus_CV_Det_Model> listCV = new Cus_CV_Det().GetModelList("log_location = '" + strLocation + "' and log_has_jobid = 'N' ");
            cvGrid.DataSource = listCV;
            cvGrid.DataKeyNames = new string[] { "log_guid", "log_path" };
            cvGrid.DataBind();
        }

        protected void cvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AttachAddr = cvGrid.DataKeys[e.Row.RowIndex]["log_path"].ToString().Trim().ToUpper() == "WTSZ" ? System.Configuration.ConfigurationManager.AppSettings["WTSZ-DispAttach"].ToString().Trim() : System.Configuration.ConfigurationManager.AppSettings["WWTS-DispAttach"].ToString().Trim();
                e.Row.Cells[1].Text = "<a  target='_self' href='" + AttachAddr + cvGrid.DataKeys[e.Row.RowIndex]["log_path"].ToString().Trim() + "'>" + e.Row.Cells[1].Text + "</a>";
            }
        }

        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            binDropDept(dropCompany.SelectedItem.Text);
        }

        protected void dropDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindJobs(dropCompany.SelectedItem.Text.Trim(), strUser,dropDept.SelectedItem.Text);
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
                dropCompany.Text = strLocation.Trim();
          
        }
        private void binDropDept(string Location)
        {

            dropDept.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + Location + "'");
            dropDept.DataTextField = "user_dept";
            dropDept.DataValueField = "user_dept";
            dropDept.DataBind();
        }
    }
}