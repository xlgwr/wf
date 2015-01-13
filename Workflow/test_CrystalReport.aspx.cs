using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using Workflow.Common;

namespace Workflow
{
    public partial class test_CrystalReport : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            setCrReport();
        }
        private void setCrReport()
        {
            ReportDocument poReport = new ReportDocument();

            /*********************************************/
            string sql = "select xml from test4";
            SqlConnection conn = new SqlConnection("server=10.10.11.200;database=WongsOA;uid=qims_user;pwd=information;");
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            string xmlcontent = ds.Tables[0].Rows[0][0].ToString();
            /************************************************/
            PO.templates.po_header DS_PO = new PO.templates.po_header();
            StringReader reader = new StringReader(xmlcontent);
            XmlDocument xmlDoc = new XmlDocument();
            ds.ReadXml(reader,XmlReadMode.InferSchema);
            foreach (DataRow head_row in ds.Tables["po_header"].Rows)
            {
                DS_PO.Tables["po_header"].ImportRow(head_row);
            }
            foreach (DataRow detail_row in ds.Tables["pod_detail_line"].Rows)
            {
                DS_PO.Tables["po_detail"].ImportRow(detail_row);
            }
            foreach (DataRow warning_row in ds.Tables["warninglines"].Rows)
            {
                DS_PO.Tables["po_warning"].ImportRow(warning_row);
            }

            string fileName = Server.MapPath(".") + "/PO_Approval/templates/CRPo.rpt";
            poReport.Load(fileName);
            poReport.SetDataSource(DS_PO);

            cryView.ReportSource = poReport;
        }

        protected void cryView_Init(object sender, EventArgs e)
        {
            setCrReport();
        }
    }
}