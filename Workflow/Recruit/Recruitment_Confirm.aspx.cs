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
    public partial class Recruitment_Confirm : PageBase
    {
        public string AttachAddr = "";
        public const string FLOWTYPE = "CV";
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string strDept = "";
        public int job_lines;
        public const string CV_TYPE = "CV";
        public const string JOB_TYPE = "JOB";
        public string job_cv_guid;
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
                ReqNbr = formModel.form_nbr.Trim();
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
            strDept = userInfo != null ? userInfo.UserDepartment.Trim().ToUpper() : "";
            Sys_Flow_Mstr flowMstr = new Sys_Flow_Mstr();
            Sys_Flow_Mstr_Model flowMstrModel = flowMstr.GetModel(ReqLoc, int.Parse(ReqSeq), ReqType);
            if (!IsPostBack)
            {
                
                changeToolTip(Page, strLang);
                bindropCompany();
                binDropDept(dropCompany.SelectedItem.Text);
                bindPriority(dropCompany.SelectedItem.Text);
                //bindRecruitSite(strLocation);
                bindModel();
                if (isRecruiter(strUser) == true)
                {
                    div_CV.Visible = true;
                    div_ATTACH.Visible = true;
                }
                txtRecruter.Text = strUser;
                if (int.Parse(ReqSeq) > 100)
                {
                    //btnSubmit.Visible = true;
                }
                if (flowMstrModel != null)
                {
                    lblTaskStatus.Text = ReqSeq + " : " + (strLang == "CN" ? flowMstrModel.flow_status_cn.Trim() : flowMstrModel.flow_status_en.Trim());
                }
            } 
            bindCVInfo(txtNbr.Text.Trim());
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            attachModel.attach_nbr = txtNbr.Text;
            attachModel.attach_user = strUser;
            attachModel.attach_time = DateTime.Now;
            attachModel.attach_type = FLOWTYPE;
            attachModel.attach_location = strLocation;
            UploadAttach1.AttachModel = attachModel;
            UploadAttach1.Guid = ReqGuid;
            Sys_Attach_Mstr_Model AddattachModel = new Sys_Attach_Mstr_Model();
            AddattachModel.attach_nbr = txtCVNbr.Text.Trim();
            AddattachModel.attach_user = strUser;
            AddattachModel.attach_time = DateTime.Now;
            AddattachModel.attach_type = "RECRUIT-REF";
            AddattachModel.attach_location = strLocation;
            UploadAttach2.AttachModel = AddattachModel;

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
                txtDeptmanager.Text = jobModel.job_adviser.Trim();
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
            }
        }
        //private void bindRecruitSite(string strLocation)
        //{
        //    Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
        //    List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'RECRUIT-WEBSITE' and code_desc = '" + strLocation.Trim() + "' order by code_fldname");
        //    foreach (Sys_Code_Mstr_Model code in codeModel)
        //    {
        //        ListItem item = new ListItem(code.code_fldname, code.code_value);
        //        dropSites.Items.Add(item);
        //    }
        //    dropSites.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        //}
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
                    ListItem item = new ListItem(code.code_fldname, code.code_value);
                    dropPriority.Items.Add(item);
                }
            }

        }
        //protected void btnAddCV_Click(object sender, EventArgs e)
        //{
        //    if (dropSites.SelectedIndex == 0)
        //    {
        //        PageBase.Show(Page, "Please select CV web site", "请选择CV网站", strLang);
        //        return;
        //    }
        //    string job_nbr = txtNbr.Text.Trim();
        //    string cv_nbr = getCVNbr(job_nbr);
        //    string job_location = dropCompany.SelectedItem.Text.Trim();
        //    string cv_user = strUser;
        //    string cv_path = dropSites.SelectedValue.Trim();
        //    string auto = "N";
        //    int maxsize = int.Parse(new Sys_Code_Mstr().GetList("code_cmmt = 'ATTACHSIZE'").Tables[0].Rows[0]["code_value"].ToString());
        //    if (FileUP.PostedFile != null)
        //    {
        //        if ((FileUP.PostedFile.ContentLength / 1024) > (1024 * maxsize) || FileUP.PostedFile.ContentLength == 0)
        //        {
        //            PageBase.Show(Page, "the length of file must be less than " + maxsize + "M and more than 0MB", "文件大小要大于0M，小于" + maxsize + "M", strLang);
        //            return;
        //        }
        //    }
        //    else
        //    {
        //        PageBase.Show(Page, "the length of file must be less than " + maxsize + "M and more than 0MB", "文件大小要大于0M，小于" + maxsize + "M", strLang);
        //        return;
        //    }
        //    string fileFullName = FileUP.PostedFile.FileName;
        //    string[] arryFile = fileFullName.Split('\\');
        //    string fileName = arryFile[arryFile.Length - 1].ToString();
        //    string[] suffix = fileName.Split('.');
        //    string suffixName = suffix[suffix.Length - 1].ToString();
        //    if (suffixName.ToUpper() == "EXE")
        //    {
        //        PageBase.Show(Page, "can't upload 'exe' file", "不能上传exe文件", strLang);
        //        return;
        //    }
        //    int len = System.Text.Encoding.Default.GetByteCount(fileName);
        //    if (len > 100)
        //    {
        //        PageBase.Show(Page, "File name is too long", "文件名字长度不能超过100位", strLang);
        //        return;
        //    }
        //    try
        //    {
        //        string temppath = Server.MapPath("~/temp/");


        //        Sys_Attach_Mstr attachBLL = new Sys_Attach_Mstr();
        //        Sys_Code_Mstr codeBLL = new Sys_Code_Mstr();
        //        string saveName = cv_nbr + "-" + attachBLL.getSaveName() + "." + suffixName;
        //        string subFolder = DateTime.Now.ToString("yyyyMM");

        //        List<Sys_Code_Mstr_Model> codeModel = new List<Sys_Code_Mstr_Model>();
        //        codeModel = codeBLL.GetModelList(" code_cmmt = 'UPLOAD' and code_desc='" + job_location + "'");
        //        string ftpAddress = "";
        //        string ftpUser = "";
        //        string ftpPwd = "";
        //        Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
        //        if (!fso.FolderExists(temppath + "/" + CV_TYPE))
        //        {
        //            fso.CreateFolder(temppath + "/" + CV_TYPE);
        //        }
        //        if (!fso.FolderExists(temppath + "/" + CV_TYPE + "/" + subFolder))
        //        {
        //            fso.CreateFolder(temppath + "/" + CV_TYPE + "/" + subFolder);
        //        }
        //        string tempTarget = temppath + CV_TYPE + "/" + subFolder + "/" + saveName;
        //        fso = null;
        //        FileUP.PostedFile.SaveAs(tempTarget);
        //        FileInfo file = new FileInfo(tempTarget);
        //        if (codeModel != null && codeModel.Count > 0)
        //        {
        //            foreach (Sys_Code_Mstr_Model codeChild in codeModel)
        //            {
        //                ftpAddress = codeChild.code_value.Trim();
        //                ftpUser = codeChild.code_user1;
        //                ftpPwd = codeChild.code_user2;
        //                if (FTPHelper.UploadFile(file, saveName, CV_TYPE + "/" + subFolder + "/", ftpAddress, ftpUser, ftpPwd) == false)
        //                {
        //                    return;
        //                }
        //            }
        //            if (FileSystem.Dir(tempTarget) != "")
        //            {
        //                FileSystem.Kill(tempTarget);
        //            }
        //        }
        //        else
        //        {
        //            return;
        //        }
        //        string Iret = new Cus_Job_Det().ExecCVProc(job_nbr, cv_nbr, job_lines, job_location, cv_user, CV_TYPE, CV_TYPE + "/" + subFolder + "/" + saveName, "", auto, fileName, cv_path, dropSites.SelectedValue.ToString(), "");
        //        if (Iret == "0")
        //        {
        //            bindCVInfo(job_nbr);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        PageBase.Show(Page, ex.ToString(), ex.ToString(), strLang);
        //    }
        //}

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
            DataTable dtCV = job_det.getList(" job_nbr ='" + job_nbr + "' and form_seq = -1 ", strLang);
            job_cv_guid = dtCV.Rows[0]["cv_guid"].ToString().Trim();
            if (dtCV != null)
            {
                //cvGrid.DataSource = dtCV;
                //cvGrid.DataKeyNames = new string[] { "job_guid", "cv_guid", "attach_path", "form_seq", "attach_id", "attach_title" };
                //cvGrid.DataBind();
                txtCVNbr.Text=dtCV.Rows[0]["cv_nbr"].ToString().Trim();
                if (dtCV.Rows[0]["cv_confirm_date"] == null)
                {
                    txtCondidateDate.Text = "";
                }
                else if (dtCV.Rows[0]["cv_confirm_date"].ToString().Trim() == "")
                {
                    txtCondidateDate.Text = "";
                }
                else
                {
                    txtCondidateDate.Text = DateTime.Parse(dtCV.Rows[0]["cv_confirm_date"].ToString().Trim()).ToString("MM/dd/yyyy");
                }
                if (dtCV.Rows[0]["cv_onboard_date"] == null)
                {
                    txtOnboardDate.Text = "";
                }
                else if (dtCV.Rows[0]["cv_onboard_date"].ToString().Trim() == "")
                {
                    txtOnboardDate.Text = "";
                }
                else
                {
                    txtOnboardDate.Text = DateTime.Parse(dtCV.Rows[0]["cv_onboard_date"].ToString().Trim()).ToString("MM/dd/yyyy");
                }
                txtName.Text = dtCV.Rows[0]["cv_candidate"].ToString().Trim();
                txtPhone.Text = dtCV.Rows[0]["cv_candidate_phone"].ToString().Trim();
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
                //LinkButton btnReject = e.Row.FindControl("btnReject") as LinkButton;
                //btnReject.Attributes.Add("onclick", "return confirm('Reject this JOB and CV info?');");
                string url = "";
                string ReqGuid = cvGrid.DataKeys[e.Row.RowIndex]["cv_guid"].ToString();
                AttachAddr = cvGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim().ToUpper() == "WTSZ" ? System.Configuration.ConfigurationManager.AppSettings["WTSZ-DispAttach"].ToString().Trim() : System.Configuration.ConfigurationManager.AppSettings["WWTS-DispAttach"].ToString().Trim();
                e.Row.Cells[3].Text = "<a  target='_blank' href='" + AttachAddr + cvGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim() + "'>" + cvGrid.DataKeys[e.Row.RowIndex]["attach_title"].ToString() + "</a>";


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
            jobMstr.job_nbr = strNbr;
            jobMstr.job_location = job_location;
            jobMstr.job_dept = job_dept;
            jobMstr.job_title = strTitle;
            jobMstr.job_desc = strDesc;
            jobMstr.job_rmk = "";
            jobMstr.job_applicant = strUser;
            jobMstr.job_key = job_key;
            jobMstr.job_approver = job_approver;
            jobMstr.job_recruiter = job_recruiter;
            jobMstr.job_date = job_applicationdate == "" ? DateTime.Now : DateTime.Parse(job_applicationdate);
            jobMstr.job_adviser = txtDeptmanager.Text.Trim();
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
                        //btnSubmit.Visible = true;
                    }
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
            Cus_Job_Det jobDet = new Cus_Job_Det();
            cv_guid = e.CommandArgument.ToString();
            string onboard = "";
            Cus_Job_Det_Model jobDetModel = jobDet.GetModel(cv_guid);
            if (e.CommandName == "Reject")
            {
                Sys_Flow_Approve_Model jobapproveModel = new Sys_Flow_Approve_Model();
                jobapproveModel.Nbr = ReqNbr;
                jobapproveModel.Type = "JOB";
                jobapproveModel.User = strUser;
                jobapproveModel.Location = ReqLoc;
                jobapproveModel.Action = "REJECT";
                jobapproveModel.Remark = txtRemark.Text.Trim();
                string strIretJob = new Sys_System().ExecApproveProc(jobapproveModel).Trim();
                switch (strIretJob)//todo
                {
                    case "0":
                        ShowAndRedirect(Page, ReqNbr + " Reject Successfully", ReqNbr + " 退回成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
                        //todo
                        if (ReqSeq.Trim() == "300")
                        {
                            new Sys_Appr_Mstr().UpdateApprNowTOY(ReqNbr);
                            Sys_Form_Mstr_Model form = new Sys_Form_Mstr_Model();
                            form.form_guid = cv_guid;
                            form.form_seq = -3;
                            bool isUpdate = new Sys_Form_Mstr().UpdateSeq(form);
                            if (isUpdate == true)
                            {
                                Sys_Appd_Mstr_Model appdModel = new Sys_Appd_Mstr_Model();
                                appdModel.appd_guid = cv_guid;
                                appdModel.appd_nbr = jobDetModel.cv_nbr;
                                appdModel.appd_location = ReqLoc;
                                appdModel.appd_type = "CV";
                                appdModel.appd_user = strUser;
                                appdModel.appd_mandator = "";
                                appdModel.appd_dept = strDept;
                                appdModel.appd_seq = -1;
                                appdModel.appd_level = 1;
                                appdModel.appd_action = "REJECT";
                                appdModel.appd_line = 0;
                                appdModel.appd_remark = txtRemark.Text.Trim();
                                appdModel.appd_parallel_flag = "N";
                                appdModel.appd_date = DateTime.Now;
                                new Sys_Appd_Mstr().Add(appdModel);
                            }
                        }

                        break;
                    case "1":
                        Show(Page, ReqNbr + " Form flow not exists", ReqNbr + " 申请流程不存在", strLang);
                        break;
                    case "2":
                        Show(Page, ReqNbr + " User not exists", ReqNbr + " 用户不存在", strLang);
                        break;
                    case "3":
                        Show(Page, ReqNbr + " Have no approve right", ReqNbr + " 没有审批权限", strLang);
                        break;
                    case "78":
                        Show(Page, ReqNbr + " Next step approver lost", ReqNbr + " 下一步骤审批人丢失", strLang);
                        break;
                    case "77":
                        Show(Page, ReqNbr + " Applicant not exists", ReqNbr + " 申请人不存在", strLang);
                        break;
                    case "99":
                        Show(Page, ReqNbr + " Document flow approve error", ReqNbr + " 文档流程审批出错", strLang);
                        break;
                    default:
                        break;
                }
            }
            if (e.CommandName == "Submit")
            {
                cv_guid = e.CommandArgument.ToString();

                if (jobDetModel != null)
                {
                    onboard = jobDetModel.cv_onboard_date.ToString("MM/dd/yyyy") == "01/01/0001" ? "" : jobDetModel.cv_onboard_date.ToString();
                }
                //cv_nbr = e.CommandArgument.ToString().Trim();
                if (onboard == "")
                {
                    Show(Page, "Please enter on board date", "请输入到班日期", strLang);
                    return;
                }
                Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
                approveModel.Nbr = ReqNbr.Trim();
                approveModel.Type = "JOB";
                approveModel.User = strUser;
                approveModel.Location = dropCompany.SelectedItem.Text.Trim();
                approveModel.Action = "PASS";
                approveModel.Remark = txtRemark.Text.Trim();
                string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
                switch (strIret)//todo
                {
                    case "0":
                        ShowAndRedirect(Page, ReqNbr + " Approve Successfully", ReqNbr + " 提交成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
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



        protected void cvGrid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            cvGrid.EditIndex = e.NewEditIndex;
            bindCVInfo(ReqNbr);
        }

        protected void cvGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string guid = cvGrid.DataKeys[e.RowIndex]["cv_guid"].ToString();
            string boarddate = ((TextBox)cvGrid.Rows[e.RowIndex].FindControl("txtOnBoardDate")).Text;


            if (boarddate == "")
            {
                Show(Page, "Please enter confirm date", "请输入确认日期", strLang);
                return;
            }
            Cus_Job_Det_Model cvModel = new Cus_Job_Det_Model();
            cvModel.cv_onboard_date = DateTime.Parse(boarddate);
            cvModel.cv_guid = guid;
            new Cus_Job_Det().UpdateOnBoardDate(cvModel);
            cvGrid.EditIndex = -1;
            bindCVInfo(ReqNbr);

        }

        protected void cvGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            cvGrid.EditIndex = -1;
            bindCVInfo(ReqNbr);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string cv_guid;
            string onboard = "";
            cv_guid = job_cv_guid;
            Cus_Job_Det jobDet = new Cus_Job_Det();
            Cus_Job_Det_Model jobDetModel = jobDet.GetModel(cv_guid);
            Cus_Job_Det_Model cvModel = new Cus_Job_Det_Model();
            onboard = Request.Form["txtOnboardDate"].Trim();;
            if (onboard == "")
            {
                Show(Page, "Please enter on board date", "请输入到班日期", strLang);
                return;
            }
            cvModel.cv_expect_onboard_date = DateTime.Parse(onboard);
            cvModel.cv_guid = cv_guid;
            new Cus_Job_Det().UpdateExpectOnBoardDate(cvModel);
            if (jobDetModel != null)
            {
                onboard = jobDetModel.cv_expect_onboard_date.ToString("MM/dd/yyyy") == "01/01/0001" ? "" : jobDetModel.cv_expect_onboard_date.ToString();
            }
            //cv_nbr = e.CommandArgument.ToString().Trim();
            
           
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = ReqNbr.Trim();
            approveModel.Type = "JOB";
            approveModel.User = strUser;
            approveModel.Location = dropCompany.SelectedItem.Text.Trim();
            approveModel.Action = "PASS";
            approveModel.Remark = txtRemark.Text.Trim();
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, ReqNbr + " Approve Successfully", ReqNbr + " 提交成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
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

        protected void btnReject_Click(object sender, EventArgs e)
        {

            string cv_guid;
            string onboard = "";
            cv_guid = job_cv_guid;
            Cus_Job_Det jobDet = new Cus_Job_Det();
            Cus_Job_Det_Model jobDetModel = jobDet.GetModel(cv_guid);
            Sys_Flow_Approve_Model jobapproveModel = new Sys_Flow_Approve_Model();
            jobapproveModel.Nbr = ReqNbr;
            jobapproveModel.Type = "JOB";
            jobapproveModel.User = strUser;
            jobapproveModel.Location = ReqLoc;
            jobapproveModel.Action = "REJECT";
            jobapproveModel.Remark = txtRemark.Text.Trim();
            string strIretJob = new Sys_System().ExecApproveProc(jobapproveModel).Trim();
            switch (strIretJob)//todo
            {
                case "0":
                    ShowAndRedirect(Page, ReqNbr + " Reject Successfully", ReqNbr + " 退回成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
                    //todo
                    if (ReqSeq.Trim() == "300")
                    {
                        new Sys_Appr_Mstr().UpdateApprNowTOY(ReqNbr);
                        Sys_Form_Mstr_Model form = new Sys_Form_Mstr_Model();
                        form.form_guid = cv_guid;
                        form.form_seq = -3;
                        bool isUpdate = new Sys_Form_Mstr().UpdateSeq(form);
                        if (isUpdate == true)
                        {
                            Sys_Appd_Mstr_Model appdModel = new Sys_Appd_Mstr_Model();
                            appdModel.appd_guid = cv_guid;
                            appdModel.appd_nbr = jobDetModel.cv_nbr;
                            appdModel.appd_location = ReqLoc;
                            appdModel.appd_type = "CV";
                            appdModel.appd_user = strUser;
                            appdModel.appd_mandator = "";
                            appdModel.appd_dept = strDept;
                            appdModel.appd_seq = -1;
                            appdModel.appd_level = 1;
                            appdModel.appd_action = "REJECT";
                            appdModel.appd_line = 0;
                            appdModel.appd_remark = txtRemark.Text.Trim();
                            appdModel.appd_parallel_flag = "N";
                            appdModel.appd_date = DateTime.Now;
                            new Sys_Appd_Mstr().Add(appdModel);
                        }
                    }

                    break;
                case "1":
                    Show(Page, ReqNbr + " Form flow not exists", ReqNbr + " 申请流程不存在", strLang);
                    break;
                case "2":
                    Show(Page, ReqNbr + " User not exists", ReqNbr + " 用户不存在", strLang);
                    break;
                case "3":
                    Show(Page, ReqNbr + " Have no approve right", ReqNbr + " 没有审批权限", strLang);
                    break;
                case "78":
                    Show(Page, ReqNbr + " Next step approver lost", ReqNbr + " 下一步骤审批人丢失", strLang);
                    break;
                case "77":
                    Show(Page, ReqNbr + " Applicant not exists", ReqNbr + " 申请人不存在", strLang);
                    break;
                case "99":
                    Show(Page, ReqNbr + " Document flow approve error", ReqNbr + " 文档流程审批出错", strLang);
                    break;
                default:
                    break;
            }
        }
    }
}