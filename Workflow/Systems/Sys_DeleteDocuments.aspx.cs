using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;

namespace Workflow.Systems
{
    public partial class Sys_DeleteDocuments : PageBase
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
                bindData(strUser);
            }
        }

        private void bindData(string strUser)
        {
            Sys_Form_Mstr formMstr = new Sys_Form_Mstr();
            gridData.DataSource = formMstr.GetModelList("form_applicant='" + strUser + "' and form_seq=10 and form_type <>'CV' ");
            gridData.DataKeyNames = new string[] { "form_nbr" };
            gridData.DataBind();
        }

        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strNbr = e.Keys["form_nbr"].ToString().Trim();
            Sys_Form_Mstr formMstr = new Sys_Form_Mstr();
            Sys_Appr_Mstr apprMstr = new Sys_Appr_Mstr();
            formMstr.Delete(strNbr);
            apprMstr.Delete(strNbr);
            bindData(strUser);
        }
    }
}