using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Workflow.Common;
using Workflow.BLL;
using System.Data;
using Workflow.Model;
namespace Workflow
{
    public partial class Index1 : PageBase
    {
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string strDept = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            if (userInfo != null)
            {
                lblUserName.Text = userInfo.UserLoginName;
                lblLocation.Text = userInfo.UserLocation;
                lblDeptName.Text = userInfo.UserDepartment;
                lblUserName.ToolTip = userInfo.UserLoginName;
                lblLocation.ToolTip = userInfo.UserLocation;
                lblDeptName.ToolTip = userInfo.UserDepartment;
                strUser = userInfo.UserLoginName;
                strLocation = userInfo.UserLocation;
                strLang = userInfo.UserLang.Trim().ToUpper();
                strDept = userInfo.UserDepartment;
                changeToolTip(Page, strLang);
                LoadTree(strLang);
            }
            else
            {
                string loginPath = HttpContext.Current.Request.ApplicationPath + "Login.aspx";
                ShowAndRedirectLogin(Page, "Session was expired", loginPath);
            }


        }

        private void LoadTree(string strLang)
        {
            this.rptList.DataSource = new SysMenu().getParentMenu(strUser, strLang);
            this.rptList.DataBind();
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptChild = (Repeater)e.Item.FindControl("rptItem");
                DataRowView row = (DataRowView)e.Item.DataItem;
                DataTable dt = get_ChildMenu(row["menu_id"].ToString().Trim(), strLang);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptChild.DataSource = dt;
                    rptChild.DataBind();
                }
            }
        }

        private DataTable get_ChildMenu(string menu_id, string strLang)
        {
            DataTable dt = new SysMenu().getChildMenu(strUser, strLang, menu_id);
            return dt;
        }

        protected void lblLanguage_Click(object sender, EventArgs e)
        {
            Sys_User_Info_Model userModel = new Sys_User_Info_Model();
            userModel.user_name = strUser;
            userModel.user_lang = strLang == "CN" ? "EN" : "CN";
            userModel.user_location = strLocation;
            userModel.user_dept = strDept;
            new Sys_User_Info().UpdateLanguage(userModel);
            new UserInfo(strUser).InitialUserInfo(userModel);
            //changeToolTip(Page, userModel.user_lang);
            //strLang = userModel.user_lang;
            //LoadTree(userModel.user_lang);
            Response.Redirect("Index1.aspx");
        }

        protected void lnkLogiout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Clear();
            Session["OA-UserInfo"] = null;
            Session.Abandon();
            Response.Write("<script>window.location.href='Login.aspx'</script>");
        }

        protected void imgLoginout_Click(object sender, ImageClickEventArgs e)
        {
            Session.RemoveAll();
            Session.Clear();
            Session["OA-UserInfo"] = null;
            Session.Abandon();
            Response.Write("<script>window.location.href='Login.aspx'</script>");
        }
    }
}