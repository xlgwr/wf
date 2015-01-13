using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;

namespace Workflow.Systems
{
    public partial class Sys_WorkEntrust : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName : "";
            strLocation = userInfo != null ? userInfo.UserLocation : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (chkAllType.Checked == true)
            {
                drpFlowList.Enabled = false;
            }
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                bindDropList();
                bindData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string entrust_type = "";
            string entrust_to = "";
            entrust_to = Request.Form["txtMan"].ToString().Trim();
            if (strUser.Trim().ToUpper().Equals(entrust_to.Trim().ToUpper()))
            {
                Show(Page, "You can't select yourself", "你不能选择你自己", strLang);
                return;
            }
            if (entrust_to == "")
            {
                Show(Page, "please choose user", "请选择被委托人", strLang);
                return;
            }
            if ((txtBeginDate.Text == "" || txtEndDate.Text == "") || (DateTime.Parse(txtBeginDate.Text) > DateTime.Parse(txtEndDate.Text)))
            {
                Show(Page, "Please fill right Date", "请填写正确的日期", strLang);
                return;
            }
            if (DateTime.Parse(txtBeginDate.Text + " 23:59:59") < DateTime.Now || DateTime.Parse(txtEndDate.Text + " 23:59:59") < DateTime.Now)
            {
                Show(Page, "Date must more than today", "日期必须大于等于今天", strLang);
                return;
            }
            DateTime en_begin = DateTime.Now;
            DateTime en_end = DateTime.Now;
            if (chkAllType.Checked == true)
            {
                entrust_type = "ALL";
            }
            else
            {
                if (drpFlowList.SelectedIndex > 0)
                {
                    entrust_type = drpFlowList.SelectedItem.Value.Trim();
                }
                else
                {
                    Show(Page, "Please choose delegate type", "请选择代理类别", strLang);
                    return;
                }
            }
            en_begin = DateTime.Parse(txtBeginDate.Text.Trim());
            en_end = DateTime.Parse(txtEndDate.Text.Trim() +" 23:59:59");
            Sys_Entrust_Mstr_Model entrustModel = new Sys_Entrust_Mstr_Model();
            entrustModel.entrust_type = entrust_type;
            entrustModel.entrust_by = strUser;
            entrustModel.entrust_to = entrust_to;
            entrustModel.entrust_location = strLocation;
            entrustModel.entrust_begin = en_begin;
            entrustModel.entrust_end = en_end;
            entrustModel.Entrust_creater = strUser;
            entrustModel.entrust_date = DateTime.Now;
            entrustModel.entrust_status = "Y";
            new Sys_Entrust_Mstr().Add(entrustModel);
            bindData();
            txtBeginDate.Text = "";
            txtEndDate.Text = "";
            chkAllType.Checked = false;
        }

        private void bindDropList()
        {
            List<Sys_Flow_Config_Model> flow_config_list = new Sys_Flow_Config().GetModelList("");
            drpFlowList.DataSource = flow_config_list;
            drpFlowList.DataTextField = strLang == "CN" ? "config_title_cn" : "config_title";
            drpFlowList.DataValueField = "config_type";
            drpFlowList.DataBind();
            ListItem item = new ListItem(strLang == "CN" ? "请选择代理类别" : "Choose Delegate Type");
            drpFlowList.Items.Insert(0, item);
        }

        private void bindData()
        {
            gridMstr.DataSource = new Sys_Entrust_Mstr().GetList("getdate() between entrust_begin and entrust_end and entrust_status='Y' and entrust_by ='" + strUser + "'");
            gridMstr.DataKeyNames = new string[] { "entrust_id" };
            gridMstr.DataBind();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMan.Text = "";
        }

        protected void gridMstr_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int keys = int.Parse(e.Keys["entrust_id"].ToString());
            new Sys_Entrust_Mstr().Delete(keys, strUser);
            bindData();
        }
    }
}