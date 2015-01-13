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
using Microsoft.VisualBasic;

namespace Workflow.Recruit
{
    public partial class Recruitment_Approve : PageBase
    {
        public string AttachAddr = "";
        public const string FLOWTYPE = "CV";
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public int job_lines;
        public const string CV_TYPE = "CV";
        protected void Page_Load(object sender, EventArgs e)
        {
            ReqGuid = Request["ReqGuid"] == null ? "" : Request["ReqGuid"].ToString().Trim();
            Cus_Job_Mstr_Model jobModel = new Cus_Job_Mstr().GetModel(ReqGuid);
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang); 
                if (jobModel != null)
                {
                    txtNbr.Text = jobModel.job_nbr.Trim();
                    ReqGuid = jobModel.job_guid;
                    txtTitle.Text = jobModel.job_title.Trim();
                    txtDesc.Text = jobModel.job_desc.Trim();
                    txtLocation.Text = jobModel.job_location.Trim();
                    txtDept.Text = jobModel.job_dept.Trim();
                }
                
                bindCVInfo(txtNbr.Text.Trim());
                bindAttachGrid(txtNbr.Text.Trim());
            }
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            attachModel.attach_nbr = txtNbr.Text;
            attachModel.attach_user = strUser;
            attachModel.attach_time = DateTime.Now;
            attachModel.attach_type = FLOWTYPE;
            attachModel.attach_location = strLocation;
           
        }
      

        private string getCVNbr(string job_nbr)
        {
            Cus_Job_Mstr jobMstr = new Cus_Job_Mstr();
            Cus_Job_Mstr_Model jobMstrModel = jobMstr.GetModelByNbr(job_nbr);
            string job_location, job_line, job_guid;
            if (jobMstrModel != null)
            {
                job_nbr = jobMstrModel.job_nbr.Trim();
                job_location = jobMstrModel.job_location;
                job_guid = jobMstrModel.job_guid;
                if (jobMstrModel.job_lines.ToString() == "" || jobMstrModel.job_lines.ToString() == null)
                {
                    job_line = "001";
                }
                else
                {
                    //job_lines = (Convert.ToInt32(jobMstrModel.job_lines.ToString()) + 1).ToString().PadLeft(3, '0');
                    job_lines = jobMstrModel.job_lines + 1;
                    job_line = job_lines.ToString().PadLeft(3, '0');
                }
                return job_nbr + "-" + job_line;
            }
            else
            {
                return "";
            }


        }
        private void bindCVInfo(string job_nbr)
        {
            Cus_Job_Det job_det = new Cus_Job_Det();
            DataTable dtCV = job_det.getListByApprover(" job_nbr ='" + job_nbr + "' and approver = '"+strUser+"' ", strLang);
            if (dtCV != null)
            {
                cvGrid.DataSource = dtCV;
                cvGrid.DataKeyNames = new string[] { "job_guid", "cv_guid", "attach_path","form_seq","attach_id" ,"attach_title"};
                cvGrid.DataBind();
            }
            if (dtCV != null && dtCV.Rows.Count == 0)
            {
                ShowAndRedirect(Page, "This recruit info is all approved by you!", "这个招聘信息已经全部被你审批结束", "../Systems/Sys_Tasklist_001.aspx", strLang);
            }
           
        }

        protected void cvGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                LinkButton btnSubmits = e.Row.FindControl("btnSubmit") as LinkButton;
                 LinkButton btnDeletes = e.Row.FindControl("btnDelete") as LinkButton;
                string url = "";
                string ReqGuid = cvGrid.DataKeys[e.Row.RowIndex]["cv_guid"].ToString();
                AttachAddr = cvGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim().ToUpper() == "WTSZ" ? System.Configuration.ConfigurationManager.AppSettings["WTSZ-DispAttach"].ToString().Trim() : System.Configuration.ConfigurationManager.AppSettings["WWTS-DispAttach"].ToString().Trim();
                e.Row.Cells[3].Text = "<a  target='_blank' href='" + AttachAddr + cvGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim() + "'>" + cvGrid.DataKeys[e.Row.RowIndex]["attach_title"].ToString() + "</a>";
                //e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
            }
        }


        protected void cvGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cv_nbr;
            string cv_guid;
            if (e.CommandName == "Toggle")
            {
                cv_guid = e.CommandArgument.ToString();
                Cus_Job_Det jobDet = new Cus_Job_Det();
                Cus_Job_Det_Model jobDetModel = jobDet.GetModel(cv_guid);
                if (jobDetModel != null)
                {
                    cv_nbr = jobDetModel.cv_nbr.Trim();
                    txtReqUser.Text = strUser;
                    txtReqLang.Text = strLang;
                    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>showDialog('" + cv_guid + "','" + ReqGuid + "')</script>");                    
                }
            }
        }

        protected void btnApprve_Click(object sender, EventArgs e)
        {
            //string cv_nbr = txtCVNbr.Text.Trim();
            //Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            //approveModel.Nbr = cv_nbr;
            //approveModel.Type = CV_TYPE;
            //approveModel.User = strUser;
            //approveModel.Location = txtLocation.Text.Trim();
            //approveModel.Action = "PASS";
            //approveModel.Remark = txtRemark.Text;
            //string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            //switch (strIret)//todo
            //{
            //    case "0":
            //        Show(Page, cv_nbr + " Approve Successfully", cv_nbr + " 提交成功", strLang);
            //        bindCVInfo(txtNbr.Text.Trim());
            //        break;
            //    case "1":
            //        Show(Page, cv_nbr + " Form flow not exists", cv_nbr + cv_nbr + " 申请流程不存在", strLang);
            //        break;
            //    case "2":
            //        Show(Page, cv_nbr + " User not exists", cv_nbr + cv_nbr + " 用户不存在", strLang);
            //        break;
            //    case "3":
            //        Show(Page, cv_nbr + " Have no approve right", cv_nbr + " 没有审批权限", strLang);
            //        break;
            //    case "78":
            //        Show(Page, cv_nbr + " Next step approver lost", cv_nbr + " 下一步骤审批人丢失", strLang);
            //        break;
            //    case "77":
            //        Show(Page, cv_nbr + " Applicant not exists", cv_nbr + " 申请人不存在", strLang);
            //        break;
            //    case "99":
            //        Show(Page, cv_nbr + " Document flow approve error", cv_nbr + " 文档流程审批出错", strLang);
            //        break;
            //    default:
            //        break;
            //}
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
          
        }

        protected void attachGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AttachAddr = attachGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim().ToUpper() == "WTSZ" ? System.Configuration.ConfigurationManager.AppSettings["WTSZ-DispAttach"].ToString().Trim() : System.Configuration.ConfigurationManager.AppSettings["WWTS-DispAttach"].ToString().Trim();
                e.Row.Cells[0].Text = "<a  target='_blank' href='" + AttachAddr + attachGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim() + "'>" + e.Row.Cells[0].Text + "</a>";
            }
            else
            {

            }
        }
        private void bindAttachGrid(string strNhr)
        {
            List<Sys_Attach_Mstr_Model> listAttach = new Sys_Attach_Mstr().GetModelList(" attach_nbr = '" + strNhr + "'");//todo add user upload condition because order to defend others delete on other file upload page. 
            attachGrid.DataSource = listAttach;
            attachGrid.DataKeyNames = new string[] { "attach_id", "attach_path", "attach_location" };
            attachGrid.DataBind();
        }
        
    }
}