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
    public partial class Recruitment_Maintain : PageBase
    {
        public string ReqGuid;
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
                bindJobInfo(" job_applicant = '"+strUser+"'");
                if(isRecruiterHead(strUser, strLocation) == true)
                {
                    div_report.Visible=true;
                }
            }
        }
        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            binDropDept(dropCompany.SelectedItem.Text);
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
             jobGrid.DataKeyNames = new string[] { "job_guid","form_seq" };
             jobGrid.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            string strWhere = "";
            if (isRecruiterHead(strUser, strLocation) == true)
            {
                strWhere = " 1 = 1 and job_location = '" + strLocation + "' ";
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
        private bool isRecruiterHead(string strUser,string strLocation)
        {
            Sys_User_Group userGroup = new Sys_User_Group();
            return userGroup.ExistsUserGroupLocation(strUser, "RECRUIT-HR-HEAD", strLocation);
        }
        protected void jobGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton btnDeletes = e.Row.FindControl("btnDelete") as LinkButton;
                string url = "Recruitment.aspx";
                string ReqGuid = jobGrid.DataKeys[e.Row.RowIndex]["job_guid"].ToString();


                if ((int)jobGrid.DataKeys[e.Row.RowIndex]["form_seq"] >= -1)
                {

                    btnDeletes.Visible = false;
                    e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
                }
                else
                {
                    btnDeletes.Attributes.Add("onclick", "return confirm('Delete this Recruit info?');");
                    e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
                }

                
            }
        }

        protected void jobGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void linkCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Recruitment.aspx");
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Cus_Job_Det job_det = new Cus_Job_Det();
            DataSet cv_task_list = job_det.GetCVTaskList(" job_recruiter = '"+strUser+"'");
            DataTable dt = cv_task_list.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataToExcel.DataTableExcel(dt,"CV"+DateTime.Now.ToString("yyyyMMddHHmmss"),"Job Nbr|CV Nbr|Job Title|Candidate Name|Phone|Gender");
            }
            else
            {
                Show(Page, "Have no cv task!", "没有简历任务", strLang);
                return;
            }
        }

        protected void btnDownReport_Click(object sender, EventArgs e)
        {
           string dateFrom = txtBeginDate.Text.Trim()==""?"1900-1-1":txtBeginDate.Text.Trim();
            string dateTo = txtBeginDate.Text.Trim()==""?DateTime.Now.ToString("MM/dd/yyyy 23:59:59"):txtBeginDate.Text.Trim() + " 23:59:59";
            DataTable dt = new Cus_Job_Mstr().ExecRecruitReport(dateFrom, dateTo, strLocation);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataToExcel.DataTableExcel(dt, "Hiring report" + DateTime.Now.ToString("yyyyMMddHHmmss"), "Job Nbr|Dept|Job Title|Hiring Person|Last Adv Release Date|Last Adv Release Website|Received CV this week|Cum|Recommend for Interview by Hiring Manager this Week|Cum|1st Interview(by HR) this week|Cum|2nd Interview(By Hiring Dept)|Cum|Remarks|Recuit Application Form Received Date|1st Adv. Release Date|Website|Expected Date of Report Duty|Aging (days)|Addition/ Replacement / Contingency|Confirmed Candidate|Confirmed Date|On Board Date|Company");
            }
            else
            {
                Show(Page, "Have no cv task!", "没有简历任务", strLang);
                return;
            }
        }
    }
}