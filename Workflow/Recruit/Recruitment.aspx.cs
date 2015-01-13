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
    public partial class Recruitment : PageBase
    {
        public string AttachAddr = "";
        public const string FLOWTYPE = "CV";
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public int job_lines;
        public const string CV_TYPE = "CV";
        public const string JOB_TYPE = "JOB";
        public string ReqNbr;
        public string ReqType;
        public string ReqSeq;
        public string ReqLoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            ReqGuid = Request["ReqGuid"] == null ? "" : Request["ReqGuid"].ToString().Trim();
            Sys_Form_Mstr_Model formModel = new Sys_Form_Mstr().GetGuidModel(ReqGuid);
            if (formModel != null)
            {
                ReqType = formModel.form_type;
                ReqNbr = formModel.form_nbr;
                ReqSeq = formModel.form_seq.ToString();
                ReqLoc = formModel.form_location;

            }
            else
            {
                ReqType = "";
                ReqNbr = "";
                ReqSeq = "0";
                ReqLoc = "";
            }
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            
            
            if (!IsPostBack)
            {
                bindModel();
                changeToolTip(Page, strLang); 
                bindropCompany();
                binDropDept(dropCompany.SelectedItem.Text);
                bindPriority(dropCompany.SelectedItem.Text);
                bindRecruitSite(strLocation);
                bindCVInfo(txtNbr.Text.Trim());
               
                if (isRecruiter(strUser) == true)
                {
                    div_CV.Visible = true;
                    div_ATTACH.Visible = true;
                    //imgRecruiter.Visible = false;
                }
                else
                {
                    txtRecruter.Text = "";
                }
                txtRecruter.Text = strUser;
            }
            
           
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            attachModel.attach_nbr = txtNbr.Text;
            attachModel.attach_user = strUser;
            attachModel.attach_time = DateTime.Now;
            attachModel.attach_type = FLOWTYPE;
            attachModel.attach_location = strLocation;
            UploadAttach1.AttachModel = attachModel;
            
           
        }
        private bool isRecruiter(string strUser)
        {
            Sys_User_Group userGroup = new Sys_User_Group();
            return userGroup.ExistsUserGroup(strUser, "RECRUIT-HR");
        }
        private void bindModel()
        {
            string strGuid = ReqGuid;
            Cus_Job_Mstr_Model jobModel = new Cus_Job_Mstr().GetModel(strGuid);
            if (jobModel != null)
            {
                txtNbr.Text = jobModel.job_nbr.Trim();
                txtTitle.Text = jobModel.job_title.Trim();
                txtDesc.Text = jobModel.job_desc.Trim();
                dropDept.Text = jobModel.job_dept;
                txtMan.Text = jobModel.job_approver;
                txtApplicationDate.Text = jobModel.job_date.ToString("MM/dd/yyyy");
                txtRecruter.Text = jobModel.job_recruiter;
                txtDeptmanager.Text = jobModel.job_adviser;
                if (strUser.Trim().ToUpper() != jobModel.job_applicant.Trim().ToUpper())
                {
                    txtTitle.Enabled = true;
                    //btnSave.Visible = false;
                }
            }
        }
        private void bindModel(string strNbr)
        {
            Cus_Job_Mstr_Model jobModel = new Cus_Job_Mstr().GetModelByNbr(strNbr);
            if (jobModel != null)
            {
                txtNbr.Text = jobModel.job_nbr.Trim();

                txtTitle.Text = jobModel.job_title.Trim();
                txtDesc.Text = jobModel.job_desc.Trim();
                dropDept.Text = jobModel.job_dept;
                txtMan.Text = jobModel.job_approver;
                txtDeptmanager.Text = jobModel.job_adviser.Trim();
            }
        }
        private void bindRecruitSite(string strLocation)
        {
            Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
            List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'RECRUIT-WEBSITE' and code_desc = '" + strLocation.Trim() + "' order by code_fldname");
            foreach (Sys_Code_Mstr_Model code in codeModel)
            {
                ListItem item = new ListItem(code.code_fldname, code.code_value);
                dropSites.Items.Add(item);
            }
            dropSites.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
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
            if (ReqGuid != "")
            {
                Cus_Job_Mstr_Model jobModel = new Cus_Job_Mstr().GetModel(ReqGuid);
                dropCompany.Text = jobModel.job_location.Trim();
            }
            else
            {
                dropCompany.Text = strLocation.Trim();
            }
        }
        private void bindPriority(string strLocation)
        {
            Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
            List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'RECRUIT-PRIRORITY' and code_desc = '" + strLocation.Trim() + "' order by code_user1 desc");
            if (codeModel != null && codeModel.Count > 0)
            {
                foreach (Sys_Code_Mstr_Model code in codeModel)
                {
                    ListItem item = new ListItem(code.code_fldname,code.code_value);
                    dropPriority.Items.Add(item);
                }
            }
            
        }
        protected void btnAddCV_Click(object sender, EventArgs e)
        {
            if (dropSites.SelectedIndex == 0)
            {
                PageBase.Show(Page, "Please select CV web site", "请选择CV网站", strLang);
                return;
            }
            string job_nbr = txtNbr.Text.Trim();
            string cv_nbr = getCVNbr(job_nbr);
            string job_location = dropCompany.SelectedItem.Text.Trim();
            string cv_user = strUser;
            string cv_path = dropSites.SelectedItem.Text.Trim();
            string auto = "N";
            int maxsize = int.Parse(new Sys_Code_Mstr().GetList("code_cmmt = 'ATTACHSIZE'").Tables[0].Rows[0]["code_value"].ToString());
            if (FileUP.PostedFile != null)
            {
                if ((FileUP.PostedFile.ContentLength / 1024) > (1024 * maxsize) || FileUP.PostedFile.ContentLength == 0)
                {
                    PageBase.Show(Page, "the length of file must be less than " + maxsize + "M and more than 0MB", "文件大小要大于0M，小于" + maxsize + "M", strLang);
                    return;
                }
            }
            else
            {
                PageBase.Show(Page, "the length of file must be less than " + maxsize + "M and more than 0MB", "文件大小要大于0M，小于" + maxsize + "M", strLang);
                return;
            }
            string fileFullName = FileUP.PostedFile.FileName;
            string[] arryFile = fileFullName.Split('\\');
            string fileName = arryFile[arryFile.Length - 1].ToString();
            string[] suffix = fileName.Split('.');
            string suffixName = suffix[suffix.Length - 1].ToString();
            if (suffixName.ToUpper() == "EXE")
            {
                PageBase.Show(Page, "can't upload 'exe' file", "不能上传exe文件", strLang);
                return;
            }
            int len = System.Text.Encoding.Default.GetByteCount(fileName);
            if (len > 100)
            {
                PageBase.Show(Page, "File name is too long", "文件名字长度不能超过100位", strLang);
                return;
            }
            try
            {
                string temppath = Server.MapPath("~/temp/");

                
                Sys_Attach_Mstr attachBLL = new Sys_Attach_Mstr();
                Sys_Code_Mstr codeBLL = new Sys_Code_Mstr();
                string saveName = cv_nbr + "-" + attachBLL.getSaveName() + "." + suffixName;
                string subFolder = DateTime.Now.ToString("yyyyMM");

                List<Sys_Code_Mstr_Model> codeModel = new List<Sys_Code_Mstr_Model>();
                codeModel = codeBLL.GetModelList(" code_cmmt = 'UPLOAD' and code_desc='" + job_location + "'");
                string ftpAddress = "";
                string ftpUser = "";
                string ftpPwd = "";
                Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                if (!fso.FolderExists(temppath + "/" + CV_TYPE))
                {
                    fso.CreateFolder(temppath + "/" + CV_TYPE);
                }
                if (!fso.FolderExists(temppath + "/" + CV_TYPE + "/" + subFolder))
                {
                    fso.CreateFolder(temppath + "/" + CV_TYPE + "/" + subFolder);
                }
                string tempTarget = temppath + CV_TYPE + "/" + subFolder + "/" + saveName;
                fso = null;
                FileUP.PostedFile.SaveAs(tempTarget);
                FileInfo file = new FileInfo(tempTarget);
                if (codeModel != null && codeModel.Count > 0)
                {
                    foreach (Sys_Code_Mstr_Model codeChild in codeModel)
                    {
                        ftpAddress = codeChild.code_value.Trim();
                        ftpUser = codeChild.code_user1;
                        ftpPwd = codeChild.code_user2;
                        if (FTPHelper.UploadFile(file, saveName, CV_TYPE + "/" + subFolder + "/", ftpAddress, ftpUser, ftpPwd) == false)
                        {
                            return;
                        }
                    }
                    if (FileSystem.Dir(tempTarget) != "")
                    {
                        FileSystem.Kill(tempTarget);
                    }
                }
                else
                {
                    return;
                }
                string Iret = new Cus_Job_Det().ExecCVProc(job_nbr, cv_nbr, job_lines, job_location, cv_user, CV_TYPE, CV_TYPE + "/" + subFolder + "/" + saveName, "", auto, fileName, cv_path, dropSites.SelectedValue.ToString(), "");
                if (Iret == "0")
                {
                    bindCVInfo(job_nbr);
                }

            }
            catch (Exception ex)
            {
                PageBase.Show(Page, ex.ToString(), ex.ToString(), strLang);
            }
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
            DataTable dtCV = job_det.getList(" job_nbr ='"+job_nbr+"' ", strLang);
            if (dtCV != null)
            {
                cvGrid.DataSource = dtCV;
                cvGrid.DataKeyNames = new string[] { "job_guid", "cv_guid", "attach_path","form_seq","attach_id","attach_title" };
                cvGrid.DataBind();
            }
            if (dtCV.Rows.Count > 0)
            {
                dropCompany.Enabled = false;
                dropDept.Enabled = false;
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
                if ((int)cvGrid.DataKeys[e.Row.RowIndex]["form_seq"] != 10)
                {

                    btnSubmits.Visible = false;
                    btnDeletes.Visible = false;
                    //btnSave.Visible = false;
                    btnClear.Visible = false;
                    //txtDesc.Enabled = false;
                }
                else
                {
                    btnDeletes.Attributes.Add("onclick", "return confirm('Delete this CV info?');");
                }

                //e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'><font color='blue'>" + e.Row.Cells[0].Text + "</font></a>";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            string strNbr = txtNbr.Text.Trim();
            string strTitle = txtTitle.Text.Trim();
            string strDesc = Server.HtmlDecode(txtDesc.Text.Trim());
            string job_location = dropCompany.SelectedItem.Text.Trim();
            string job_dept = dropDept.SelectedItem.Text.Trim();
            string job_approver = Request.Form["txtMan"].Trim();
            string job_adviser = Request.Form["txtDeptmanager"].Trim();
            string job_key = dropPriority.SelectedValue.ToString();
            string job_recruiter = txtRecruter.Text;
            string job_applicationdate = txtApplicationDate.Text;
            //string strRemark = txtRemark.Text.Trim();
            Cus_Job_Mstr_Model jobMstr = new Cus_Job_Mstr_Model();
            if (strTitle == "")
            {
                Show(Page, "Please enter title", "请输入标题", strLang);
                return;
            }
            if (job_recruiter == "")
            {
                Show(Page, "Please choose recruiter", "请选择招聘人", strLang);
                return;
            }
            if (job_location == "")
            {
                Show(Page, "Please choose company", "请选择公司", strLang);
                return;
            }
            if (job_dept == "")
            {
                Show(Page, "Please choose department", "请选择部门", strLang);
                return;
            }
            if (job_approver == "")
            {
                Show(Page, "Please choose default approver", "请选择默认审批人", strLang);
                return;
            }
            //if (job_applicationdate != "")
            //{
            //    if (DateTime.Parse(job_applicationdate + " 23:59:59") < DateTime.Now)
            //    {
            //        Show(Page, "Application Date can't  less than today", "申请日期不能小于今天", strLang);
            //        return;
            //    }
            //}
            if(isRecruiter(txtRecruter.Text.Trim())==false)
            {
                Show(Page, txtRecruter.Text + " is not recruiter", txtRecruter.Text + " 不是招聘人员", strLang);
                    return;
            }

            jobMstr.job_nbr=strNbr;
            jobMstr.job_location = job_location;
            jobMstr.job_dept=job_dept;
            jobMstr.job_title=strTitle;
            jobMstr.job_desc=strDesc;
            jobMstr.job_rmk="";
            jobMstr.job_applicant = strUser;
            jobMstr.job_key = job_key;
            jobMstr.job_approver = job_approver;
            jobMstr.job_date = job_applicationdate == "" ? DateTime.Now : DateTime.Parse(job_applicationdate);
            jobMstr.job_recruiter = txtRecruter.Text.Trim();
            jobMstr.job_adviser = job_adviser;
            //mis_service.m_svr_remark = strRemark;
            string[] returnArray = new Cus_Job_Mstr().SaveJobMstr(jobMstr).Split('|');
            string strIret = returnArray[0].Trim();
            switch (strIret)//todo
            {
                case "0":
                    Show(Page, "Save Successfully", "保存成功", strLang);
                    txtNbr.Text = returnArray[1];
                    bindModel(txtNbr.Text.Trim());
                    if (isRecruiter(strUser) == false)
                    {
                        btnSubmit.Visible = true;
                    }
                    break;
                case "1":
                    Show(Page, "Job number config error", "单号产生出错!", strLang);
                    
                    break;
                default:
                    break;
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
        }

        protected void cvGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cv_nbr;
            string cv_guid;
            int attach_id;
            if (e.CommandName == "Del")
            {
                attach_id = int.Parse(e.CommandArgument.ToString());
                Sys_Attach_Mstr attachBLL = new Sys_Attach_Mstr();
                Sys_Code_Mstr codeBLL = new Sys_Code_Mstr();
                Sys_Code_Mstr_Model codeModel = new Sys_Code_Mstr_Model();
                Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
                int keys = attach_id;
                attachModel = attachBLL.GetModel(keys);
                if (attachModel != null)
                {
                    cv_guid = attachModel.attach_guid;
                }
                string attachDir = attachModel.attach_path.ToString();
                List<Sys_Code_Mstr_Model> codeModelList = new List<Sys_Code_Mstr_Model>();
                codeModelList = codeBLL.GetModelList(" code_cmmt = 'UPLOAD' and code_desc='" + strLocation + "'");
                string ftpAddress = "";
                string ftpUser = "";
                string ftpPwd = "";
                if (codeModelList != null && codeModelList.Count > 0)
                {
                    foreach (Sys_Code_Mstr_Model codeChild in codeModelList)
                    {
                        ftpAddress = codeChild.code_value.Trim();
                        ftpUser = codeChild.code_user1;
                        ftpPwd = codeChild.code_user2;
                        FTPHelper.fileDelete(ftpAddress, attachDir, ftpUser, ftpPwd);
                    }
                    attachBLL.Delete(keys);
                }
                else
                {
                    return;
                }
                bindCVInfo(txtNbr.Text.Trim());
            }
            if (e.CommandName == "Toggle")
            {
                cv_guid = e.CommandArgument.ToString();
                Cus_Job_Det jobDet = new Cus_Job_Det();
                Cus_Job_Det_Model jobDetModel = jobDet.GetModel(cv_guid);
                //if (jobDetModel != null)
                //{
                //    cv_nbr = jobDetModel.cv_nbr.Trim();
                //    ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>showDialog('" + cv_guid + "','" + ReqGuid + "')</script>");
                //}
                cv_nbr = e.CommandArgument.ToString().Trim();
                Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
                approveModel.Nbr = cv_nbr;
                approveModel.Type = CV_TYPE;
                approveModel.User = strUser;
                approveModel.Location = dropCompany.SelectedItem.Text.Trim();
                approveModel.Action = "PASS";
                approveModel.Remark = "";
                string strIret = new Sys_System().ExecApproveProcCV(approveModel).Trim();
                switch (strIret)
                {
                    case "0":
                        Show(Page, "Submit Successfully", "提交成功", strLang);
                        bindCVInfo(txtNbr.Text.Trim());
                        break;
                    case "1":
                        Show(Page, "Form flow not exists", "申请流程不存在", strLang);
                        break;
                    case "2":
                        Show(Page, "User not exists", "用户不存在", strLang);
                        break;
                    case "3":
                        Show(Page, "Have no approve right", "没有审批权限", strLang);
                        break;
                    case "78":
                        Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                        break;
                    case "77":
                        Show(Page, "Applicant not exists", "申请人不存在", strLang);
                        break;
                    case "99":
                        Show(Page, "Document flow approve error", "文档流程审批出错", strLang);
                        break;
                    case "1001":
                        Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                        break;
                    case "1004":
                        Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                        break;
                    default:
                        break;
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMan.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (int.Parse(ReqSeq) > 100)
            {
                btnSubmit.Attributes.Add("onclick", "return confirm('Are you sure to close this recruit?')");
            }
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text;
            approveModel.Type = JOB_TYPE;
            approveModel.User = strUser;
            approveModel.Location = dropCompany.SelectedItem.Text.Trim();
            approveModel.Action = "PASS";
            approveModel.Remark = "";
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_InProcess.aspx", strLang);
                    bindCVInfo(txtNbr.Text.Trim());
                    break;
                case "1":
                    Show(Page, "Form flow not exists", "申请流程不存在", strLang);
                    break;
                case "2":
                    Show(Page, "User not exists", "用户不存在", strLang);
                    break;
                case "3":
                    Show(Page, "Have no approve right", "没有审批权限", strLang);
                    break;
                case "78":
                    Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                    break;
                case "77":
                    Show(Page, "Applicant not exists", "申请人不存在", strLang);
                    break;
                case "99":
                    Show(Page, "Document flow approve error", "文档流程审批出错", strLang);
                    break;
                case "1001":
                    Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                    break;
                case "1004":
                    Show(Page, "Next step approver lost", "下一步骤审批人丢失", strLang);
                    break;
                default:
                    break;
            }
        }

        protected void cvGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void cvGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            txtDeptmanager.Text = "";
        }        
    }
}