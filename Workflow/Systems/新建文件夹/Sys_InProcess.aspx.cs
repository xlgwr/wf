using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;
using System.Data;
using System.Drawing;
using Workflow.Model;
namespace Workflow.Systems
{
    public partial class Alltask : PageBase
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
                bindData(strUser, strLocation);
            }
        }

        private void bindData(string strUser, string strLocation)
        {
            gridData.DataSource = new Sys_Form_Mstr().GetModelList("form_seq > 10 and form_type <>'CV' and form_applicant = '" + strUser + "' ");//and form_location = '"+strLocation+"'
            gridData.DataKeyNames = new string[] { "form_guid","form_type","form_nbr" };
            gridData.DataBind();
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string ReqGuid = gridData.DataKeys[e.Row.RowIndex]["form_guid"].ToString();
                string type = gridData.DataKeys[e.Row.RowIndex]["form_type"].ToString();
                string ReqNbr = gridData.DataKeys[e.Row.RowIndex]["form_nbr"].ToString();
                LinkButton linknum = (LinkButton)e.Row.Cells[1].FindControl("linkNum");
                linknum.Text = ReqNbr;
                linknum.ToolTip = ReqNbr;
                if (type.Trim().ToUpper() =="JOB")
                {
                    e.Row.Cells[1].Text = "<a target='_self' href='Sys_InProcess_Sub.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>Details</a>";
                }
                else
                {
                    e.Row.Cells[0].Text = "<a target='_self' href='Sys_FlowDisplay.aspx?ReqGuid=" + ReqGuid + "&ReqNbr=" + ReqNbr + "'>" + e.Row.Cells[0].Text + "</a>";
                }
            }
           
        }

        private void bindFlowChart(string strGuid)
        {
            string strType, strLocation, strNbr, strSeq;
            Sys_Form_Mstr_Model formModel = new Sys_Form_Mstr().GetGuidModel(strGuid);
            if (formModel != null)
            {
                strType = formModel.form_type;
                strLocation = formModel.form_location;
                strSeq = formModel.form_seq.ToString();
                strNbr = formModel.form_nbr;
            }
            else
            {
                strType = "";
                strLocation = "";
                strSeq = "";
                strNbr = "";
            }
            DataTable dtFlowStepInfo = null;
            if (strType != "")
            {
                DataSet dsFlowStepInfo = new Sys_Flow_Mstr().GetFlowStepInfo(" flow_type='" + strType + "' and flow_location = '" + strLocation + "' and flow_seq > 0", strLang);
                dtFlowStepInfo = dsFlowStepInfo != null ? dsFlowStepInfo.Tables[0] : null;
                if (dtFlowStepInfo != null && dtFlowStepInfo.Rows.Count > 0)
                {
                    Table table = new Table();
                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    table.Width = Unit.Percentage(100);//Unit.Pixel(300);
                    table.HorizontalAlign = HorizontalAlign.Center;

                    AddRowPoint(table, strLang == "CN" ? new Sys_Flow_Config().GetModel(strType).config_title_cn : new Sys_Flow_Config().GetModel(strType).config_title, Color.FromArgb(250, 250, 250));
                    foreach (DataRow dr in dtFlowStepInfo.Rows)
                    {
                        if (AddStep(table, dr, strLang, strSeq, strNbr) == false)
                        {
                            continue;
                        }
                    }
                    if (strSeq.Trim() == "-1")
                    {
                        AddRowPoint(table, "<span lang='EN-US' style='font-size: 10.5pt; font-family: Wingdings;color:green'>ò</span>", Color.FromArgb(250, 250, 250));
                        AddRowPoint(table, strLang == "CN" ? "<a>结束</a>" : "<a>Closed</a>", Color.FromName("#81B470"));
                    }
                    else
                    {
                        AddRowPoint(table, "<span lang='EN-US' style='font-size: 10.5pt; font-family: Wingdings;color:green'>ò</span>", Color.FromArgb(250, 250, 250));
                        AddRowPoint(table, strLang == "CN" ? "<a>结束</a>" : "<a>Closed</a>", Color.FromArgb(250, 250, 250));
                    }
                    lblPlace.Controls.Add(table);
                }
            }
        }
        private bool AddStep(Table table, DataRow dr, string strLang, string strSeq_Curr, string strNbr)
        {
            string strSeq = dr["flow_seq"] != null ? dr["flow_seq"].ToString() : "";
            string strBackSeq = dr["flow_back_seq"] != null ? dr["flow_back_seq"].ToString() : "";
            string strStatus = dr["status"] != null ? dr["status"].ToString() : "";
            string strCondition = dr["flow_condition_flag"] != null ? dr["flow_condition_flag"].ToString() : "";
            string strConditionDisplay = dr["condition_display"] != null ? dr["condition_display"].ToString() : "";
            string strConditionContent = dr["flow_condition_content"] != null ? dr["flow_condition_content"].ToString() : "";
            Sys_Flow_Mstr flowMstr = new Sys_Flow_Mstr();
            Table t = new Table();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            //long top = 300 + 500 * Step;
            t.HorizontalAlign = HorizontalAlign.Center;
            t.Style.Add("left", "100px");
            //tt.Style.Add("top", top.ToString() + "px");
            t.Style.Add("BORDER-COLLAPSE", "collapse");
            t.Style.Add("width", "300px");
            //t.Style.Add("font-size", "10pt");
            t.BorderColor = Color.FromName("#83B3D8");
            t.BorderWidth = 1;
            Color backColor = Color.White;
            if (strCondition.Trim().ToUpper() == "Y")
            {
                backColor = Color.FromName("#EBF09B");
            }
            else
            {
                backColor = Color.FromName("#BDDEFF");
            }
            if (strSeq.Trim().Equals(strSeq_Curr.Trim()))
            {
                backColor = Color.FromName("#81B470");
            }
            if (strCondition.Trim().ToUpper() == "Y" && strConditionContent != "")
            {
                if (flowMstr.ExistsCondition(strConditionContent, strNbr) == true)
                {
                    AddRowPoint(table, "<span lang='EN-US' style='font-size: 10.5pt; font-family: Wingdings;color:green'>ò</span>", Color.FromArgb(250, 250, 250));
                    AddRowPoint(table, "<span lang='EN-US' style='ont-size: 10.5pt;font-family: Wingdings;color:green'>&eth;</span>" + strConditionDisplay, Color.FromArgb(250, 250, 250));
                    if (strLang == "CN")
                    {
                        AddCaptionRow(t, "第" + strSeq + "步", dr["status"].ToString(), backColor);
                        //AddRow(t, "退回到", strBackSeq + "步");
                    }
                    else
                    {
                        AddCaptionRow(t, "Step " + strSeq, dr["status"].ToString(), backColor);
                        // AddRow(t, "Back To", strBackSeq + "Step");
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                AddRowPoint(table, "<span lang='EN-US' style='font-size: 10.5pt; font-family: Wingdings;color:green'>ò</span>", Color.FromArgb(250, 250, 250));
                if (strLang == "CN")
                {
                    AddCaptionRow(t, "第" + strSeq + "步", dr["status"].ToString(), backColor);
                    //AddRow(t, "退回到", strBackSeq + "步");
                }
                else
                {
                    AddCaptionRow(t, "Step " + strSeq, dr["status"].ToString(), backColor);
                    // AddRow(t, "Back To", strBackSeq + "Step");
                }
            }
            if (strSeq.Trim().Equals(strSeq_Curr.Trim()))
            {
                //AddRowPoint(t, strLang == "CN" ? "当前所在步骤" : "Current Step", Color.Green);
                //t.ForeColor = Color.Red;
                //t.Font.Bold = true;
                List<V_Appr_Flow_Model> apprModel = new V_Appr_Flow().GetModelList(" appr_nbr = '" + strNbr + "' and appr_seq = '" + strSeq_Curr + "' and appr_now = 'Y'");
                if (apprModel != null && apprModel.Count > 0)
                {
                    if (strLang == "CN")
                    {
                        AddApprover(t, "部门", "审批人", "代理人", Color.FromName("#83B3D8"));
                    }
                    else
                    {
                        AddApprover(t, "Dept", "Approver", "Delegate To", Color.FromName("#83B3D8"));
                    }

                    foreach (V_Appr_Flow_Model model in apprModel)
                    {
                        AddApprover(t, model.appr_dept, model.approver, model.mandatory == "" ? "N/A" : model.mandatory, Color.FromName("#D6DBEF"));
                    }
                }
                else
                {
                    AddRowPoint(t, "<a href='#' onclick='history.back();'>" + strLang == "CN" ? "审批人丢失" : "Approver Loss" + "</a>", Color.Red);
                }
            }
            tc.Controls.Add(t);
            tr.Cells.Add(tc);
            table.Rows.Add(tr);
            return true;

        }
        private void AddCaptionRow(Table table, string Label, string Caption, Color BackColor)
        {

            TableRow tr = new TableRow();
            TableCell td1 = new TableCell();
            TableCell td2 = new TableCell();
            td1.Text = Label;
            td1.HorizontalAlign = HorizontalAlign.Right;
            td1.BackColor = BackColor;
            td2.Text = Caption;
            td2.HorizontalAlign = HorizontalAlign.Left;
            td2.BackColor = BackColor;
            tr.Height = Unit.Pixel(30);
            td1.Style.Add("width", "50px");
            td2.Style.Add("width", "250px");
            td2.ColumnSpan = 2;
            tr.Cells.Add(td1);
            tr.Cells.Add(td2);
            table.Rows.Add(tr);
        }
        void AddRow(Table table, string Label, string Caption)
        {
            TableRow tr = new TableRow();
            TableCell td1 = new TableCell();
            TableCell td2 = new TableCell();
            td1.Text = Label;
            td1.HorizontalAlign = HorizontalAlign.Right;
            td1.BackColor = Color.FromArgb(240, 240, 240);
            td1.Style.Add("width", "50px");
            td2.Text = Caption;
            td2.HorizontalAlign = HorizontalAlign.Left;
            td2.Style.Add("width", "250px");
            td2.ColumnSpan = 2;
            tr.Cells.Add(td1);
            tr.Cells.Add(td2);
            table.Rows.Add(tr);
        }
        void AddRowPoint(Table table, string Label, Color BackColor)
        {
            TableRow tr = new TableRow();
            TableCell td1 = new TableCell();
            td1.Text = Label;
            td1.HorizontalAlign = HorizontalAlign.Center;
            td1.BackColor = BackColor;
            //td1.Style.Add("width", "300px");
            td1.ColumnSpan = 3;
            tr.Cells.Add(td1);
            table.Rows.Add(tr);
        }
        private void AddApprover(Table table, string Label, string strUser, string strDept, Color BackColor)
        {

            TableRow tr = new TableRow();
            TableCell td1 = new TableCell();
            TableCell td2 = new TableCell();
            TableCell td3 = new TableCell();
            td1.Text = Label;
            td1.HorizontalAlign = HorizontalAlign.Right;
            td1.BackColor = BackColor;
            td2.Text = strUser;
            td2.HorizontalAlign = HorizontalAlign.Center;
            td3.Text = strDept;
            td3.HorizontalAlign = HorizontalAlign.Center;
            td2.BackColor = BackColor;
            td3.BackColor = BackColor;
            td1.Style.Add("width", "50px");
            td2.Style.Add("width", "100px");
            td2.Style.Add("width", "150px");
            tr.Cells.Add(td1);
            tr.Cells.Add(td2);
            tr.Cells.Add(td3);
            table.Rows.Add(tr);
        }

        protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string cur_guid;
            if (e.CommandName == "LinkNum")
            {
                cur_guid = e.CommandArgument.ToString();
                bindFlowChart(cur_guid);
                bindHistoryGrid(cur_guid);
                ClientScript.RegisterStartupScript(GetType(), "message", "<script language='javascript' defer>showDiv()</script>");
            }
        }
        private void bindHistoryGrid(string strGuid)
        {
            List<Sys_Appd_Mstr_Model> listAppd = new Sys_Appd_Mstr().GetModelList("appd_guid ='" + strGuid + "' order by appd_date");
            historyGrid.DataSource = listAppd;
            historyGrid.DataBind();
        }
    }
}