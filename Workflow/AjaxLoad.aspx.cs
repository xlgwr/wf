using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Workflow
{
    public partial class AjaxLoad : System.Web.UI.Page
    {
        string AjaxType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AjaxType = Request.QueryString["AjaxType"] == null ? "" : Request.QueryString["AjaxType"].ToUpper().Trim();
                loadAjax(AjaxType);
            }
        }

        private void loadAjax(string strType)
        {
            switch (AjaxType)
            { 
                case "GetFileSize":
                default:
                    break;
            }
        }
    }
}