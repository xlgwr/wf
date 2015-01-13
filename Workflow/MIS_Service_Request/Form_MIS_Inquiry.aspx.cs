using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.BLL;
using Workflow.Common;
using Workflow.Model;
using System.Text;

namespace Workflow.MIS_Service_Request
{
    public partial class Form_MIS_Inquiry : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string strDept = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            strDept = userInfo != null ? userInfo.UserDepartment.Trim() : "";
            if (!IsPostBack)
            {
                changeToolTip(Page, strLang);
                bindDropStatus("MIS", strLocation);
                bindCompany();
                bindDropTypeParent();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string strWhere = "";
            if (txtNbr.Text != "")
            {
                strWhere += " and m_svr_nbr = '" + PageValidate.SqlTextClear(txtNbr.Text.Trim()) + "'";
            }
            if (dropStatus.SelectedIndex > 0)
            {
                strWhere += " and form_seq = '" + dropStatus.SelectedItem.Value.Trim() + "'";
            }
            if (txtBegin.Text != "" && txtEnd.Text != "")
            {
                if (DateTime.Parse(txtBegin.Text) > DateTime.Parse(txtEnd.Text))
                {
                    Show(Page, "End Date must large than begin date", "结束日期必须大于开始日期", strLang);
                    return;
                }
            }
            if (txtBegin.Text != "")
            {
                strWhere += " and m_svr_date >='" + txtBegin.Text + "'";
            }
            if (txtEnd.Text != "")
            {
                strWhere += " and m_svr_date <='" + txtEnd.Text + "'";
            }
            if (dropCompany.SelectedIndex > 0)
            {
                strWhere += " and m_svr_location ='" + dropCompany.SelectedItem.Text.Trim() + "'";
            }
            if (dpdept.SelectedIndex > 0)
            {
                strWhere += " and m_svr_dept ='" + dpdept.SelectedItem.Text.Trim() + "'";
            }
            if (txtApplicant.Text != "")
            {
                strWhere += " and m_svr_user like '%" + PageValidate.SqlTextClear(txtApplicant.Text.Trim()) + "%'";
            }
            if (txtProcess.Text != "")
            {
                strWhere += " and m_svr_process_by like '%" + PageValidate.SqlTextClear(txtProcess.Text.Trim()) + "%'";
            }
            if (dropTypeParent.SelectedIndex > 0&& dropTypeChild.SelectedIndex<=0)
            {
                strWhere += " and m_svr_type like '" + PageValidate.SqlTextClear(dropTypeParent.SelectedItem.Value) + "%'";
            }
            if (dropTypeChild.SelectedIndex > 0)
            {
                strWhere += " and m_svr_type = '" + PageValidate.SqlTextClear(dropTypeChild.SelectedItem.Value) + "'";
            }
            if (txtSubject.Text != "")
            {
                strWhere += " and m_svr_subject like '%" + PageValidate.SqlTextClear(txtSubject.Text.Trim()) + "%'";
            }
            V_User_Group_Model groupModel = new V_User_Group().GetModel(strUser, strDept);
            if (strDept.IndexOf("MIS") > -1)
            {
                strWhere += " and 1 = 1";
            }
            else if(groupModel!=null)
            {
                if (groupModel.flow_group.Trim().ToUpper()== "DEPTMANAGER")
                {
                    strWhere += " and m_svr_dept = '" + strDept + "'";
                }
            }
            else
            {
                strWhere += " and m_svr_user = '" + strUser + "'";
            }
            
            gridData.DataSource = new Cus_MIS_Service().DsQuery(strWhere,strLang);
            gridData.DataKeyNames = new string[] { "form_seq","m_svr_location","form_guid" };
            gridData.DataBind();
        }

        private void bindCompany()
        {
            dropCompany.DataSource = new Sys_Code_Mstr().GetModelList("code_cmmt = 'Company' order by code_fldname");
            dropCompany.DataTextField = "code_desc";
            dropCompany.DataValueField = "code_fldname";
            dropCompany.DataBind();
            dropCompany.Items.Insert(0, strLang == "CN" ? "--选择--" : "--Choose--");
        }
        private void bindDropStatus(string strType, string strLocation)
        {
            dropStatus.DataSource = new Sys_Flow_Mstr().GetFlowStepInfo("flow_type = '" + strType + "' and flow_location ='" + strLocation + "'", strLang);
            dropStatus.DataTextField = "status";
            dropStatus.DataValueField = "flow_seq";
            dropStatus.DataBind();
            dropStatus.Items.Insert(0, strLang == "CN" ? "--请选择--" : "--Choose--");
        }

        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string url = "../MIS_Service_Request/Form_MIS_Details.aspx";
                //string ReqNbr = e.Row.Cells[0].Text.Trim();
                //string ReqSeq = gridData.DataKeys[e.Row.RowIndex]["form_seq"].ToString().Trim();
                string ReqGuid = gridData.DataKeys[e.Row.RowIndex]["form_guid"].ToString().Trim();
                string ReqLoc = gridData.DataKeys[e.Row.RowIndex]["m_svr_location"].ToString().Trim();
                e.Row.Cells[0].Text = "<a target='_self' href='" + url + "?ReqGuid=" + ReqGuid + "'>" + e.Row.Cells[0].Text + "</a>";
                //string strSubject;
                //if (e.Row.RowType == DataControlRowType.DataRow)
                //{
                //    strSubject = e.Row.Cells[7].Text.Trim();
                //     e.Row.Cells[7].Attributes.Add("")
                //    //display the changed values
                //    e.Row.Cells[0].Text = Intercept(strSubject,3);
                //}

            }
        }

        protected void dropCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDropDept(dropCompany.SelectedItem.Text);
        }
        private void bindDropDept(string strLocation)
        {
            dpdept.DataSource = new Sys_User_Info().GetDeptModelList("user_location = '" + strLocation + "'");
            dpdept.DataTextField = "user_dept";
            dpdept.DataValueField = "user_dept";
            dpdept.DataBind();
            dpdept.Items.Insert(0, strLang == "CN" ? "--选择--" : "-Choose--");
        }

        private void bindDropTypeParent()
        {
            Cus_MIS_Type misType = new Cus_MIS_Type();
            List<Cus_MIS_Type_Model> parentModel = misType.GetModelList(" mis_type_level = 1 order by mis_type_order");
            foreach (Cus_MIS_Type_Model parent in parentModel)
            {
                ListItem item = new ListItem(strLang == "CN" ? parent.mis_type_value_cn : parent.mis_type_value, parent.mis_type_code);
                dropTypeParent.Items.Add(item);
            }
            dropTypeParent.Items.Insert(0, strLang == "CN" ? "---请选择---" : "---Choose---");
        }

        protected void dropTypeParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            dropTypeChild.Items.Clear();
            Cus_MIS_Type misType = new Cus_MIS_Type();
            List<Cus_MIS_Type_Model> childModel = misType.GetModelList(" mis_type_code like '" + dropTypeParent.SelectedItem.Value.Trim() + "%' and mis_type_level>1 order by mis_type_order");
            if (childModel != null && childModel.Count > 0)
            {
               
                dropTypeChild.Visible = true;
                foreach (Cus_MIS_Type_Model child in childModel)
                {
                    ListItem item = new ListItem(strLang == "CN" ? child.mis_type_value_cn : child.mis_type_value, child.mis_type_code);
                    dropTypeChild.Items.Add(item);
                }
                dropTypeChild.Items.Insert(0, strLang == "CN" ? "---请选择---" : "---Choose---");
            }
            else
            {
                if (dropTypeParent.SelectedIndex == 0)
                {
                    dropTypeChild.Visible = false;
                }
                else
                {
                    dropTypeChild.Visible = false;
                }
            }
        }

        protected string Intercept(string strInput,int inLength)
        {
            if (strInput != null && strInput != string.Empty)
            {
                if (strInput.Length > inLength)
                    return strInput = strInput.Substring(0, inLength) + "...";
                else
                    return strInput;
            }
            return "";
        }
    }
}