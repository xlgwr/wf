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
        public string strUser = PageBase.User_Name;
        public string strLocation = PageBase.User_Location;
        public string strLang = PageBase.User_Lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropList();
                bindData();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (chkAllTime.Checked == false && (txtBeginDate.Text == "" || txtEndDate.Text == ""))
            {
                Show(Page, "Please fill Date", "请填写日期");
            }
            string en_type = "";
            string en_trust_to = "";
            DateTime en_begin = DateTime.Now;
            DateTime en_end = DateTime.Now;
            if (chkAllType.Checked == true)
            {
                en_type = "ALL";
            }
            else
            {
                en_type = drpFlowList.SelectedItem.Value.Trim();
            }
            if (chkAllTime.Checked == true)
            {
                en_begin = DateTime.Now;
                en_end = DateTime.Parse("9999-12-30");
            }
            else
            {
                en_begin = DateTime.Parse(txtBeginDate.Text.Trim());
                en_end = DateTime.Parse(txtEndDate.Text.Trim());
            }
            Sys_Entrust_Mstr_Model entrustModel = new Sys_Entrust_Mstr_Model();
            entrustModel.entrust_type = en_type;
            entrustModel.entrust_by = strUser;//todo
            entrustModel.entrust_to = en_trust_to;
            entrustModel.entrust_location = strLocation;
            entrustModel.entrust_begin = en_begin;
            entrustModel.entrust_end = en_end;
            entrustModel.entrust_date = DateTime.Now;
            entrustModel.entrust_status = "Y";
            new Sys_Entrust_Mstr().Add(entrustModel);
            bindData();
        }

        private void bindDropList()
        {
            List<Sys_Flow_Config_Model> flow_config_list = new Sys_Flow_Config().GetModelList("");
            drpFlowList.DataSource = flow_config_list;
            drpFlowList.DataTextField =  strLang == "CN" ? "config_title_cn" : "config_title";
            drpFlowList.DataValueField = "config_type";
            drpFlowList.DataBind();
            ListItem item = new ListItem(strLang=="CN"?"请选择委托类别":"Choose Entrust Type");
            drpFlowList.Items.Insert(0, item);
        }

        private void bindData()
        {
            gridMstr.DataSource = new Sys_Entrust_Mstr().GetList("getdate() between entrust_begin and entrust_end and entrust_status='Y'");//todo add user check
            gridMstr.DataBind();

        }
    }
}