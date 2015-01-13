using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.BLL;
using Workflow.Model;

namespace Workflow.Systems
{
    public partial class UserGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindDropDownList();
            }
        }

        private void BindData(string strComCode)
        {
            this.userTree.Nodes.Clear();
            List<Sys_User_Dept_Model> scopeTree = new Sys_User_Info().GetDeptModelList(" user_location = '"+strComCode+"'");
            foreach (Sys_User_Dept_Model userdept in scopeTree)
            {
                TreeNode node = new TreeNode(userdept.user_dept.Trim());
                this.userTree.Nodes.Add(node);
                AddTreeNode(node, userdept,strComCode);
            }
        }

        private void AddTreeNode(TreeNode parentNode, Sys_User_Dept_Model nodeInfo,string strComCode)
        {
            TreeNode treeNode = null;
            List<Sys_User_Info_Model> childTree = new Sys_User_Info().GetModelList("user_dept = '" + parentNode.Text + "' and user_location = '" + strComCode + "'");
            foreach (Sys_User_Info_Model childInfo in childTree)
            {
                treeNode = new TreeNode(childInfo.user_name.Trim());
                parentNode.ChildNodes.Add(treeNode);
            }
        }
        private void bindDropDownList()
        {
            List<Sys_Code_Mstr_Model> code_mstr_list = new Sys_Code_Mstr().GetModelList("code_cmmt='LDAP' order by code_fldname");
            dropComCode.DataSource = code_mstr_list;
            dropComCode.DataTextField = "code_desc";
            dropComCode.DataValueField = "code_value";
            dropComCode.DataBind();
            BindData(dropComCode.SelectedItem.Text.Trim());

        }

        protected void dropComCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindData(dropComCode.SelectedItem.Text.Trim());
        }
    }
}