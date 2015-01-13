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
    public partial class Recruitment_Approve_Dialog : PageBase
    {
        public string AttachAddr = "";
        public const string FLOWTYPE = "CV";
        public string ReqGuid;
        public string ReqJobGuid;
        public string ReqLoc;
        public string ReqNbr;
        public string ReqType;
        public string ReqSeq;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public int job_lines;
        public const string CV_TYPE = "CV";
        public string job_nbr;
        protected void Page_Load(object sender, EventArgs e)
        {
            ReqGuid = Request["ReqGuid"] == null ? "" : Request["ReqGuid"].ToString().Trim();
            ReqJobGuid = Request["ReqJobGuid"] == null ? "" : Request["ReqJobGuid"].ToString().Trim();
            Cus_Job_Mstr_Model jobModel = new Cus_Job_Mstr().GetModel(ReqJobGuid);
            Cus_Job_Det_Model jobDetModel = new Cus_Job_Det().GetModel(ReqGuid);
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
                ReqSeq = "";
                ReqLoc = "";
            }
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (jobModel != null)
            {
                Sys_Flow_Mstr flowMstr = new Sys_Flow_Mstr();
                Sys_Flow_Mstr_Model flowMstrModel = flowMstr.GetModel(ReqLoc, int.Parse(ReqSeq), ReqType);
                txtCVNbr.Text = jobDetModel.cv_nbr.Trim();
                txtReqLoc.Text = jobModel.job_location.Trim();
                txtDesc1.Text = jobModel.job_desc.Trim();
                txtDept1.Text = jobModel.job_dept.Trim();
                txtTitle.Text = jobModel.job_title.Trim();
                job_nbr = jobModel.job_nbr;
                Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr().GetModelByNbr(txtCVNbr.Text.Trim());
                Cus_Job_Det_Model cvModel = new Cus_Job_Det().GetModel(ReqGuid);
                txtConfirmDate.Text = cvModel.cv_confirm_date.ToString("MM/dd/yyyy") == "01/01/0001" ? "" : cvModel.cv_confirm_date.ToString("MM/dd/yyyy");
                if (flowMstrModel != null)
                {
                    lblTaskStatus.Text = ReqSeq + " : " + (strLang == "CN" ? flowMstrModel.flow_status_cn.Trim() : flowMstrModel.flow_status_en.Trim());
                }
                if (attachModel != null)
                {
                    AttachAddr = (strLocation == "WTSZ") ? System.Configuration.ConfigurationManager.AppSettings["WTSZ-DispAttach"].ToString().Trim() : System.Configuration.ConfigurationManager.AppSettings["WWTS-DispAttach"].ToString().Trim();
                    lblCV.Text = "<a  target='_blank' href='" + AttachAddr + attachModel.attach_path + "'>" + attachModel.attach_title.Trim() + "</a>";
                }
            }
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);

                bindRejectReason(strLocation);
                bindHistoryGrid(ReqGuid);
                bindInterview(ReqGuid);
                if (ReqSeq == "200")
                {
                    Panel3.Visible = true;
                }
                if (ReqSeq == "210")
                {
                    Panel1.Visible = true;
                    //checkApprove.Checked = true;

                }
                if (ReqSeq == "200")
                {
                    btnReject.Visible = false;

                }
                if (ReqSeq == "230")
                {
                    Panel2.Visible = true;
                }
                if (ReqSeq == "240")
                {
                    Panel4.Visible = true;
                }
                txtCandidate.Text = jobDetModel.cv_candidate.Trim();
                txtPhone.Text = jobDetModel.cv_candidate_phone.Trim();
            }
            Sys_Attach_Mstr_Model AddattachModel = new Sys_Attach_Mstr_Model();
            AddattachModel.attach_nbr = txtCVNbr.Text.Trim();
            AddattachModel.attach_user = strUser;
            AddattachModel.attach_time = DateTime.Now;
            AddattachModel.attach_type = "RECRUIT-REF";
            AddattachModel.attach_location = strLocation;
            UploadAttach1.AttachModel = AddattachModel;
        }
        private bool extend()
        {
            Cus_Job_Det_Model cvModel = new Cus_Job_Det_Model();
            Cus_Job_Det cv = new Cus_Job_Det();
            Sys_Appr_Mstr apprMstr = new Sys_Appr_Mstr();
            Sys_User_Info userInfo = new Sys_User_Info();
            cvModel.cv_nbr = txtCVNbr.Text.Trim();
            if (checkApprove.Checked == true)
            {
                cvModel.cv_relative = "Y";

                if (txtRelative.Text == "")
                {
                    Show(Page, "Please select relative approver", "请选择相关审批人", strLang);
                    return false;
                }
                if (cv.UpdateRelative(cvModel) == true)
                {
                    string[] approver = txtRelative.Text.Split(';');

                    apprMstr.Delete(txtCVNbr.Text, 220, "N", "N");
                    for (int i = 0; i < approver.Length; i++)
                    {
                        Sys_User_Info_Model userModel = userInfo.GetModel(approver[i]);
                        if (userModel == null)
                        {
                            Show(Page, "Approver" + approver[i] + " not exists", "审批人" + approver[i] + "不存在", strLang);
                            return false;
                        }
                        else
                        {
                            Sys_Appr_Mstr_Model apprModel = new Sys_Appr_Mstr_Model();
                            apprModel.appr_nbr = txtCVNbr.Text.Trim();
                            apprModel.appr_type = "CV";
                            apprModel.appr_user = approver[i];
                            apprModel.appr_seq = 220;
                            apprModel.appr_parallel = "Y";
                            apprModel.appr_now = "N";
                            apprModel.appr_group = "Assign";
                            apprModel.appr_date_in = DateTime.Now;
                            apprModel.appr_level = 1;
                            apprModel.appr_dept = userModel.user_dept;
                            apprModel.appr_location = ReqLoc;
                            apprModel.appr_appr = "N";
                            apprMstr.Add(apprModel);
                        }
                    }
                    return true;
                }
            }
            return true;
        }
        protected void btnApprve_Click(object sender, EventArgs e)
        {
            extend();
            string cv_nbr = txtCVNbr.Text.Trim();
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = cv_nbr;
            approveModel.Type = CV_TYPE;
            approveModel.User = strUser;
            approveModel.Location = txtReqLoc.Text.Trim();
            approveModel.Action = "PASS";
            approveModel.Remark = ReqSeq == "200" ? rdoSuggestion.SelectedItem.Text + " : " + txtRemark.Text.Trim() : txtRemark.Text.Trim();
            if (ReqSeq == "200")
            {
                if (rdoSuggestion.SelectedIndex < 0)
                {
                    Show(Page, "Please select suggestion", "请选择建议", strLang);
                    return;
                }
            }
            if (ReqSeq == "230")
            {
                if (interviewGrid.Rows.Count == 0)
                {
                    Show(Page, "Please enter interview info", "请输入面试信息", strLang);
                    return;
                }
                if (Request.Form["txtConfirmDate"] == "")
                {
                    Show(Page, "Please enter confirm date", "请输入确认日期", strLang);
                    return;
                }
                Cus_Job_Det_Model cvModel = new Cus_Job_Det_Model();
                cvModel.cv_confirm_date = DateTime.Parse(Request.Form["txtConfirmDate"]);
                cvModel.cv_nbr = cv_nbr;
                updateConfirmDay(cvModel);
            }
            string strIret = new Sys_System().ExecApproveProcCV(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndClose(Page, cv_nbr + " Approve Successfully", cv_nbr + " 提交成功", strLang);
                    Sys_Form_Mstr_Model formModel = new Sys_Form_Mstr().GetGuidModel(ReqGuid);
                    if (formModel != null)
                    {
                        ReqSeq = formModel.form_seq.ToString();
                        if (ReqSeq == "-1")
                        {
                            Sys_Flow_Approve_Model jobapproveModel = new Sys_Flow_Approve_Model();
                            jobapproveModel.Nbr = job_nbr;
                            jobapproveModel.Type = "JOB";
                            jobapproveModel.User = strUser;
                            jobapproveModel.Location = txtReqLoc.Text.Trim();
                            jobapproveModel.Action = "PASS";
                            jobapproveModel.Remark = "";
                            string strIretJob = new Sys_System().ExecApproveProc(jobapproveModel).Trim();
                            switch (strIretJob)//todo
                            {
                                case "0":
                                    ShowAndRedirect(Page, job_nbr + " Approve Successfully", job_nbr + " 提交成功", "../Sys_Tasklist_001.aspx", strLang);
                                    //todo
                                    new Sys_Appr_Mstr().UpdateApprNowTOU(job_nbr);
                                    break;
                                case "1":
                                    Show(Page, job_nbr + " Form flow not exists", job_nbr + " 申请流程不存在", strLang);
                                    break;
                                case "2":
                                    Show(Page, job_nbr + " User not exists", job_nbr + " 用户不存在", strLang);
                                    break;
                                case "3":
                                    Show(Page, job_nbr + " Have no approve right", job_nbr + " 没有审批权限", strLang);
                                    break;
                                case "78":
                                    Show(Page, job_nbr + " Next step approver lost", job_nbr + " 下一步骤审批人丢失", strLang);
                                    break;
                                case "77":
                                    Show(Page, job_nbr + " Applicant not exists", job_nbr + " 申请人不存在", strLang);
                                    break;
                                case "99":
                                    Show(Page, job_nbr + " Document flow approve error", job_nbr + " 文档流程审批出错", strLang);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    break;
                case "1":
                    Show(Page, cv_nbr + " Form flow not exists", cv_nbr + " 申请流程不存在", strLang);
                    break;
                case "2":
                    Show(Page, cv_nbr + " User not exists", cv_nbr + " 用户不存在", strLang);
                    break;
                case "3":
                    Show(Page, cv_nbr + " Have no approve right", cv_nbr + " 没有审批权限", strLang);
                    break;
                case "78":
                    Show(Page, cv_nbr + " Next step approver lost", cv_nbr + " 下一步骤审批人丢失", strLang);
                    break;
                case "77":
                    Show(Page, cv_nbr + " Applicant not exists", cv_nbr + " 申请人不存在", strLang);
                    break;
                case "99":
                    Show(Page, cv_nbr + " Document flow approve error", cv_nbr + " 文档流程审批出错", strLang);
                    break;
                default:
                    break;
            }
        }
        private void bindRejectReason(string strLocation)
        {
            Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
            List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'RECRUIT-REJECT' and code_desc = '" + strLocation.Trim() + "' order by code_user1");
            foreach (Sys_Code_Mstr_Model code in codeModel)
            {
                ListItem item = new ListItem(code.code_fldname, code.code_value);
                dropReason.Items.Add(item);
            }
            dropReason.Items.Insert(0, strLang == "CN" ? "" : "");
        }
        protected void btnReject_Click(object sender, EventArgs e)
        {
            string reason = "";
            if (dropReason.SelectedIndex == 0)
            {
                Show(Page, "Please select reject reason", "请选择反对原因", strLang);
                return;
            }
            reason = dropReason.SelectedItem.Text.Trim();
            if (dropReason.SelectedItem.Text.Trim().ToUpper() == "OTHERS")
            {
                if (txtOther.Text == "")
                {
                    Show(Page, "Please enter other reason", "请输入其他的原因", strLang);
                    return;
                }
                else
                {
                    reason = "Other:" + txtOther.Text;
                }
            }
            string cv_nbr = txtCVNbr.Text.Trim();
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = ReqNbr;
            approveModel.Type = CV_TYPE;
            approveModel.User = strUser;
            approveModel.Location = ReqLoc;
            approveModel.Action = "REJECT";
            approveModel.Remark = reason + "\n" + txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProcCV(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndClose(Page, cv_nbr + " Reject Successfully", cv_nbr + " 提交成功", strLang);
                    break;
                case "1":
                    Show(Page, cv_nbr + " Form flow not exists", cv_nbr + "申请流程不存在", strLang);
                    break;
                case "2":
                    Show(Page, cv_nbr + " User not exists", cv_nbr + "用户不存在", strLang);
                    break;
                case "3":
                    Show(Page, cv_nbr + " Have no approve right", cv_nbr + "没有审批权限", strLang);
                    break;
                case "78":
                    Show(Page, cv_nbr + " Next step approver lost", cv_nbr + "下一步骤审批人丢失", strLang);
                    break;
                case "77":
                    Show(Page, cv_nbr + " Applicant not exists", cv_nbr + "申请人不存在", strLang);
                    break;
                case "99":
                    Show(Page, "Document flow approve error", "文档流程审批出错", strLang);
                    break;
                default:
                    break;
            }
        }
        private void bindHistoryGrid(string strGuid)
        {
            List<Sys_Appd_Mstr_Model> listAppd = new Sys_Appd_Mstr().GetModelList("appd_guid ='" + strGuid + "' order by appd_date");
            historyGrid.DataSource = listAppd;
            historyGrid.DataBind();
        }

        protected void rdoReason_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void checkApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (checkApprove.Checked == true)
            {

                panelRelate.Visible = true;
            }
            else
            {

                panelRelate.Visible = false;
            }
        }

        protected void dropReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropReason.SelectedItem.Text.Trim().ToUpper() == "OTHERS")
            {
                txtOther.Visible = true;
            }
            else
            {
                txtOther.Visible = false;
            }
        }

        protected void interviewGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void interviewGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int keys = int.Parse(e.Keys["interview_id"].ToString());
            new Cus_Job_Interview().Delete(keys);
            bindInterview(ReqGuid);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string Interviewer = Request.Form["txtInterviewer"];
            string candidate = txtCandidate.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string gender = dropGender.SelectedItem.Value.Trim();
            if (candidate == ""|| phone == "")
            {
                Show(Page, "please input candidate name and phone", "请输入候选者姓名和号码", strLang);
                return;
            }
            if (PageValidate.IsPhone(phone) == false)
            {
                Show(Page, "please input right phone format", "请输入电话号码的正确格式", strLang);
                return;
            }
            Cus_Job_Det jobDet = new Cus_Job_Det();
            Cus_Job_Det_Model jobDetModel = new Cus_Job_Det_Model();
            jobDet.UpdateCandidate(ReqGuid, candidate, phone, gender);
            if (Interviewer == "")
            {
                return;
            }
            if (txtDate.Text == "")
            {
                return;
            }
            
            Cus_Job_Interview jobInterview = new Cus_Job_Interview();
            Cus_Job_Interview_Model interviewModel = new Cus_Job_Interview_Model();
            //todo check round is exists?
            bool existsRound = new Cus_Job_Interview().ExistsRound(int.Parse(dropRound.SelectedItem.Text), ReqGuid);
            if (existsRound == true)
            {
                Show(Page, "please choose right round", "请选择正确的次数", strLang);
                return;
            }
            interviewModel.interview_by = Interviewer;
            interviewModel.interview_cre_by = strUser;
            interviewModel.interview_cv_guid = ReqGuid;
            interviewModel.interview_date = DateTime.Parse(txtDate.Text.Trim());
            interviewModel.interview_cre_date = System.DateTime.Now;
            interviewModel.interview_round = int.Parse(dropRound.SelectedItem.Text);
            interviewModel.interview_type = dropInterviewType.SelectedItem.Text.Trim();
            jobInterview.Add(interviewModel);
            bindInterview(ReqGuid);
        }

        private void bindInterview(string cv_guid)
        {
            List<Cus_Job_Interview_Model> listInterview = new Cus_Job_Interview().GetModelList("interview_cv_guid = '" + cv_guid + "' order by interview_round");
            interviewGrid.DataSource = listInterview;
            interviewGrid.DataKeyNames = new string[] { "interview_id" };
            interviewGrid.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtConfirmDate.Text == "")
            {
                return;
            }
            if (interviewGrid.Rows.Count == 0)
            {
                Show(Page, "please enter interview info", "请输入面试信息", strLang);
                return;
            }

        }
        private void updateConfirmDay(Cus_Job_Det_Model cvModel)
        {
            Cus_Job_Det cv = new Cus_Job_Det();
            cv.UpdateConfirmDate(cvModel);
        }
    }
}