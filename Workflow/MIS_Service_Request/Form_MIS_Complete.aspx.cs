﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.BLL;
using Workflow.Common;
using Workflow.Model;

namespace Workflow.MIS_Service_Request
{
    public partial class From_MIS_Complete : PageBase
    {
        public string ReqNbr;
        public string ReqType;
        public string ReqSeq;
        public string ReqLoc;
        public string ReqGuid;
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        string AttachAddr = System.Configuration.ConfigurationManager.AppSettings["DispAttach"];
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
                ReqSeq = "";
                ReqLoc = "";
            }
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                if (ReqType != "" && ReqNbr != "" && ReqSeq != "")
                {
                    Sys_Flow_Mstr flowMstr = new Sys_Flow_Mstr();
                    Sys_Flow_Mstr_Model flowMstrModel = flowMstr.GetModel(ReqLoc, int.Parse(ReqSeq),ReqType);
                    if (flowMstrModel != null)
                    {
                        lblTaskStatus.Text = strLang == "CN" ? flowMstrModel.flow_status_cn.Trim() : flowMstrModel.flow_status_en.Trim();
                    }
                    Cus_MIS_Service_Model mis_service = new Cus_MIS_Service().GetModel(ReqNbr);
                    txtNbr.Text = mis_service.m_svr_nbr;
                    txtLocation.Text = mis_service.m_svr_location;
                    txtApplicant.Text = mis_service.m_svr_user;
                    txtDept.Text = mis_service.m_svr_dept;
                    txtRequestDate.Text = mis_service.m_svr_exp_date == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_exp_date.ToString("MM/dd/yyyy");
                    chkUrgent.Checked = mis_service.m_svr_urgent == "Y" ? true : false;
                    txtType.Text = new Cus_MIS_Type().GetTypeFullName(mis_service.m_svr_type, strLang);
                    txtSubject.Text = mis_service.m_svr_subject;
                    txtDesc.Text = mis_service.m_svr_desc;
                    txtPlanBegin.Text = mis_service.m_svr_plan_from == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_plan_from.ToString("MM/dd/yyyy");
                    txtPlanEnd.Text = mis_service.m_svr_plan_end == DateTime.Parse("01/01/0001 0:00:00") ? "" : mis_service.m_svr_plan_end.ToString("MM/dd/yyyy");
                    bindHistoryGrid(ReqNbr);
                }
            }
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            attachModel.attach_nbr = ReqNbr;
            attachModel.attach_user = strUser;
            attachModel.attach_time = DateTime.Now;
            attachModel.attach_type = "MIS";
            attachModel.attach_location = strLocation;
            UploadAttach1.AttachModel = attachModel;
        }

        protected void btnApprve_Click(object sender, EventArgs e)
        {
            if (extend() == false)
            {
                return;
            }
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = strUser;
            approveModel.Location = ReqLoc;
            approveModel.Action = "PASS";
            approveModel.Remark = txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_Tasklist_001.aspx",strLang);
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
                default:
                    break;
            }
        }
        private void bindHistoryGrid(string strNbr)
        {
            List<Sys_Appd_Mstr_Model> listAppd = new Sys_Appd_Mstr().GetModelList("appd_nbr ='" + strNbr + "' order by appd_date");
            historyGrid.DataSource = listAppd;
            historyGrid.DataBind();
        }
        private string getMenuName(string code)
        {
            Cus_MIS_Type_Model typeModel = new Cus_MIS_Type().GetModel(code);
            if (typeModel != null)
            {
                return strLang == "CN" ? typeModel.mis_type_value_cn : typeModel.mis_type_value;
            }
            else
            {
                return "";
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            if (txtRemark.Text == "")
            {
                Show(Page, "Enter reject remark", "输入反对备注", strLang);
                return;
            }
            Sys_Flow_Approve_Model approveModel = new Sys_Flow_Approve_Model();
            approveModel.Nbr = txtNbr.Text.Trim();
            approveModel.Type = "MIS";
            approveModel.User = strUser;
            approveModel.Location = ReqLoc;
            approveModel.Action = "REJECT";
            approveModel.Remark = txtRemark.Text;
            string strIret = new Sys_System().ExecApproveProc(approveModel).Trim();
            switch (strIret)//todo
            {
                case "0":
                    ShowAndRedirect(Page, "Submit Successfully", "提交成功", "../Systems/Sys_Tasklist_001.aspx", strLang);
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
                default:
                    break;
            }
        }
        private bool extend()
        {
            Cus_MIS_Service mis = new Cus_MIS_Service();
            Cus_MIS_Service_Model misModel = new Cus_MIS_Service_Model();
            Sys_User_Info userInfo = new Sys_User_Info();
            misModel.m_svr_nbr = txtNbr.Text.Trim();
            if (txtActBegin.Text == "" || txtActEnd.Text == "")
            {
                Show(Page, "Please enter begin date and end date", "请输入开始和结束日期", strLang);
                return false;
            }
            if (DateTime.Parse(txtActBegin.Text.Trim()) > DateTime.Parse(txtActEnd.Text.Trim()))
            {
                Show(Page, "Please enter right begin date and end date", "请输入正确的开始和结束日期", strLang);
                return false;
            }
            misModel.m_svr_act_from = DateTime.Parse(txtActBegin.Text);
            misModel.m_svr_act_end = DateTime.Parse(txtActEnd.Text);

            if (mis.UpdateAct(misModel) == true)
            {

                return true;

            }
            else
            {
                return false; ;
            }


        }
    }
}