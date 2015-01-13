using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;
using System.IO;
using Microsoft.VisualBasic;

namespace Workflow
{
    public partial class test : System.Web.UI.Page
    {
    
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        string AttachAddr = System.Configuration.ConfigurationManager.AppSettings["DispAttach"];
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = Request.Url.ToString();
            Response.Write(s);
        }
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnApprve_Click(object sender, EventArgs e)
        {
            
        }

      

        protected void attachGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }

        protected void attachGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
        }

        //private void bindTypeMenu()
        //{
        //    Cus_MIS_Type misType = new Cus_MIS_Type();
        //    List<Cus_MIS_Type_Model> parentModel = misType.GetModelList(" mis_type_level = 1 order by mis_type_order");
        //    foreach (Cus_MIS_Type_Model root in parentModel)
        //    {
        //        MenuItem rootitem = new MenuItem();
        //        rootitem.Value = root.mis_type_code;
        //        rootitem.Text = strLang == "CN" ? root.mis_type_value_cn : root.mis_type_value;
        //        TypeMenu.Items.Add(rootitem);
        //        addTypeChildMenu(rootitem);
        //    }
        //}

        private void addTypeChildMenu(MenuItem root)
        {
            Cus_MIS_Type misType = new Cus_MIS_Type();
            string rootvalue = root.Value.Trim();
            List<Cus_MIS_Type_Model> childModel = misType.GetModelList(" mis_type_code like '" + rootvalue + "%' and mis_type_level>1 order by mis_type_order");
            if (childModel != null && childModel.Count > 0)
            {
                foreach (Cus_MIS_Type_Model child in childModel)
                {
                    MenuItem childItem = new MenuItem();
                    childItem.Value = child.mis_type_code;
                    childItem.Text = strLang == "CN" ? child.mis_type_value_cn : child.mis_type_value;
                    root.ChildItems.Add(childItem);
                }
            }
        }

        //protected void TypeMenu_MenuItemClick(object sender, MenuEventArgs e)
        //{

        //    string itemcode = e.Item.Value.Trim();
        //    txtType.Text = getMenuName(itemcode);

        //}

        //private string getMenuName(string code)
        //{
        //    Cus_MIS_Type_Model typeModel = new Cus_MIS_Type().GetModel(code);
        //    lblTypeCode.Text = code;
        //    if (typeModel != null)
        //    {
        //        return strLang == "CN" ? typeModel.mis_type_value_cn : typeModel.mis_type_value;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        //private void bindHistoryGrid(string strNbr)
        //{
        //    List<Sys_Appd_Mstr_Model> listAppd = new Sys_Appd_Mstr().GetModelList("appd_nbr ='" + strNbr + "' order by appd_date");
        //    historyGrid.DataSource = listAppd;
        //    historyGrid.DataBind();
        //}
        //private void bindDropTypeParent()
        //{
        //    Cus_MIS_Type misType = new Cus_MIS_Type();
        //    List<Cus_MIS_Type_Model> parentModel = misType.GetModelList(" mis_type_level = 1 order by mis_type_order");
        //    foreach (Cus_MIS_Type_Model parent in parentModel)
        //    {
        //        ListItem item = new ListItem(strLang == "CN" ? parent.mis_type_value_cn : parent.mis_type_value, parent.mis_type_code);
        //        dropTypeParent.Items.Add(item);
        //    }
        //    dropTypeParent.Items.Insert(0, strLang == "CN" ? "---请选择---" : "---Choose---");
        //}

        //private void bindrdoCompany()
        //{
        //    Sys_Code_Mstr codeMstr = new Sys_Code_Mstr();
        //    List<Sys_Code_Mstr_Model> codeModel = codeMstr.GetModelList("code_cmmt = 'Company' order by code_fldname");
        //    if (codeModel != null && codeModel.Count > 0)
        //    {
        //        foreach (Sys_Code_Mstr_Model code in codeModel)
        //        {
        //            dropCompany.Items.Add(code.code_desc);
        //        }
        //    }
        //    dropCompany.Text = strLocation;
        //}
        //protected void dropTypeParent_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    dropTypeChild.Items.Clear();
        //    Cus_MIS_Type misType = new Cus_MIS_Type();
        //    List<Cus_MIS_Type_Model> childModel = misType.GetModelList(" mis_type_code like '" + dropTypeParent.SelectedItem.Value.Trim() + "%' and mis_type_level>1 order by mis_type_order");
        //    if (childModel != null && childModel.Count > 0)
        //    {
        //        txtType.Text = "";
        //        lblTypeCode.Text = "";
        //        dropTypeChild.Visible = true;
        //        foreach (Cus_MIS_Type_Model child in childModel)
        //        {
        //            ListItem item = new ListItem(strLang == "CN" ? child.mis_type_value_cn : child.mis_type_value, child.mis_type_code);
        //            dropTypeChild.Items.Add(item);
        //        }
        //        dropTypeChild.Items.Insert(0, strLang == "CN" ? "---请选择---" : "---Choose---");
        //    }
        //    else
        //    {
        //        if (dropTypeParent.SelectedIndex == 0)
        //        {
        //            txtType.Text = "";
        //            lblTypeCode.Text = "";
        //            dropTypeChild.Visible = false;
        //        }
        //        else
        //        {
        //            txtType.Text = dropTypeParent.SelectedItem.Text.Trim();
        //            lblTypeCode.Text = dropTypeParent.SelectedItem.Value.Trim();
        //            dropTypeChild.Visible = false;
        //        }
        //    }
        //}

        //protected void dropTypeChild_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dropTypeChild.SelectedIndex == 0)
        //    {
        //        txtType.Text = "";
        //        lblTypeCode.Text = "";
        //    }
        //    else
        //    {
        //        txtType.Text = dropTypeParent.SelectedItem.Text.Trim() + " : " + dropTypeChild.SelectedItem.Text.Trim();
        //        lblTypeCode.Text = dropTypeChild.SelectedItem.Value.Trim();
        //    }
        //}

        protected void rdoCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
    }
}