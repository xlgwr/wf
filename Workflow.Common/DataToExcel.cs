using System;
using System.Diagnostics;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Workflow.Common
{
    /// <summary>
    /// 操作EXCEL导出数据报表的类
    /// Copyright (C) Maticsoft
    /// </summary>
    public class DataToExcel
    {
        public DataToExcel()
        {

        }
        public static void DataTableExcel(System.Data.DataTable pData, string pFileName, string pHeader)
        {
            System.Web.UI.WebControls.DataGrid dgExport = null;
            System.Web.HttpContext curContext = System.Web.HttpContext.Current;
            System.IO.StringWriter strWriter = null;
            System.Web.UI.HtmlTextWriter htmlWriter = null;
            if (pData != null)
            {
                string UserAgent = curContext.Request.ServerVariables["http_user_agent"].ToLower();
                if (UserAgent.IndexOf("firefox") == -1)
                    pFileName = HttpUtility.UrlEncode(pFileName, System.Text.Encoding.UTF8);
                curContext.Response.AddHeader("Content-Disposition", "attachment; filename=" + pFileName + ".xls");
                curContext.Response.ContentType = "application/vnd.ms-excel";
                strWriter = new System.IO.StringWriter();
                htmlWriter = new System.Web.UI.HtmlTextWriter(strWriter);
                dgExport = new System.Web.UI.WebControls.DataGrid();
                dgExport.DataSource = pData.DefaultView;
                dgExport.AllowPaging = false;
                dgExport.ShowHeader = false;
                dgExport.DataBind();
                string[] arrHeader = pHeader.Split('|');
                string strHeader = "<table border=\"1\" style=\"background-color:Gray;font-weight:bold;\"><tr>";
                foreach (string j in arrHeader)
                {
                    strHeader += "<td>" + j.ToString() + "</td>";
                }
                strHeader += "</tr></table>";
                dgExport.RenderControl(htmlWriter);
                string strMeta = "<meta http-equiv=\"content-type\" content=\"application/ms-excel; charset=UTF-8\"/>";
                curContext.Response.Write(strMeta + strHeader + strWriter.ToString());
                curContext.Response.End();
            }
        }
    }
}
