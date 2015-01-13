using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Text;
using Workflow.Model;
using System.IO;
using System.Configuration;
namespace Workflow.Common
{
    /// <summary>
    /// ҳ���(��ʾ��)����,����ҳ��̳и�ҳ��
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        public int PermissionID = -1;//Ĭ��-1Ϊ�����ƣ������ڲ�ͬҳ��̳��������Ʋ�ͬҳ���Ȩ��
        //string virtualPath = Workflow.Common.ConfigHelper.GetConfigString("VirtualPath");

        /// <summary>
        /// ���캯��
        /// </summary>
        public PageBase()
        {
            this.Load += new EventHandler(PageBase_Load);//ί��
        }

        private static string user_Name;

        public static string User_Name
        {
            get { return user_Name; }
            set { user_Name = value; }
        }
        private static string user_Location;
        public static string User_Location
        {
            get { return user_Location; }
            set { user_Location = value; }
        }
        private static string user_Lang;
        public static string User_Lang
        {
            get { return user_Lang; }
            set { user_Lang = value; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string Path = "";
            //if (Session["OA-UserInfo"] == null)
            //{
            //    Path = HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
            //    ShowAndRedirectLogin(Page, "Session was expired", Path);
            //    return;
            //}
            //else
            //{
            //    UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            //    User_Name = userInfo.UserLoginName;
            //    User_Location = userInfo.UserLocation;
            //    User_Lang = userInfo.UserLang.Trim().ToUpper();
            //}
            //Uri uri = Request.UrlReferrer;
            //string reFer = String.Empty;
            //if (!(uri == null)) reFer = uri.AbsoluteUri;
            //if (string.IsNullOrEmpty(reFer))
            //{
            //    Path = HttpContext.Current.Request.ApplicationPath + "/Index.aspx";
            //    ShowAndRedirectLogin(Page, "You can not access with url ", Path);
            //    return;
            //}

            this.Load += new System.EventHandler(PageBase_Load);
            //this.Error += new System.EventHandler(PageBase_Error);
            //writeLog(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString(), "123");
        }
        //������
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            Exception currentError = Server.GetLastError();
            errMsg = "<link rel=\"stylesheet\" href=\"/style.css\">";
            errMsg += "<h1>ϵͳ����</h1><hr/>ϵͳ�������� " +
                "����Ϣ�ѱ�ϵͳ��¼�����Ժ����Ի������Ա��ϵ��<br/>" +
                "�����ַ�� " + Request.Url.ToString() + "<br/>" +
                "������Ϣ�� <font class=\"ErrorMessage\">" + currentError.Message.ToString() + "</font><hr/>" +
                "<b>Stack Trace:</b><br/>" + currentError.ToString();
            Response.Write(errMsg);
            Server.ClearError();

        }
        private void PageBase_Load(object sender, EventArgs e)
        {
            string Path = "";
            
            if (Session["OA-UserInfo"] == null)
            {
                Path = HttpContext.Current.Request.ApplicationPath + "/Login.aspx";
                ShowAndRedirectLogin(Page, "Session was expired", Path);
                return;
            }
            
            //string randID = HttpContext.Current.Request.QueryString["ReqGuid"] == null ? "" : HttpContext.Current.Request.QueryString["ReqGuid"];
            //if (randID != "")
            //{ 
            //   //todo
            //}

            //Ȩ����֤
            //if (Context.User.Identity.IsAuthenticated)
            //{
            //    AccountsPrincipal user = new AccountsPrincipal(Context.User.Identity.Name);
            //    if (Session["UserInfo"] == null)
            //    {
            //        LTP.Accounts.Bus.User currentUser = new LTP.Accounts.Bus.User(user);
            //        Session["UserInfo"] = currentUser;
            //        Session["Style"] = currentUser.Style;
            //        Response.Write("<script defer>location.reload();</script>");
            //    }
            //    if ((PermissionID != -1) && (!user.HasPermissionID(PermissionID)))
            //    {
            //        Response.Clear();
            //        Response.Write("<script defer>window.alert('��û��Ȩ�޽��뱾ҳ��\\n�����µ�¼�������Ա��ϵ');history.back();</script>");
            //        Response.End();
            //    }
            //}
            //else
            //{
            //    FormsAuthentication.SignOut();
            //    Session.Clear();
            //    Session.Abandon();
            //    Response.Clear();
            //    Response.Write("<script defer>window.alert('��û��Ȩ�޽��뱾ҳ��ǰ��¼�û��ѹ��ڣ�\\n�����µ�¼�������Ա��ϵ��');parent.location='" + virtualPath + "/Login.aspx';</script>");
            //    Response.End();
            //}		

        }
        #region Evenroment variables
        //public Sys_User_Info_Model GetUserInfo
        //{
        //    //get
        //    //{
        //    //    Sys_User_Info user = new Sys_User_Info();
        //    //    return user.GetModel("");
        //    //}
        //}

        #endregion

        #region MessageBox
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի���
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void Show(System.Web.UI.Page page, string msgEN, string msgCN, string strLang)
        {
            if (strLang.ToUpper().Trim() == "EN")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgEN.ToString() + "');</script>");
            }
            else if (strLang.ToUpper().Trim() == "CN")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgCN.ToString() + "');</script>");
            }
        }
        public static void ShowAndClose(System.Web.UI.Page page, string msgEN, string msgCN, string strLang)
        {
            if (strLang.ToUpper().Trim() == "EN")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgEN.ToString() + "');window.close();</script>");
            }
            else if (strLang.ToUpper().Trim() == "CN")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgCN.ToString() + "');window.close();</script>");
            }
        }
        /// <summary>
        /// �ؼ���� ��Ϣȷ����ʾ��
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msgEN, string msgCN, string strLang)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            //Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
            if (strLang.ToUpper().Trim() == "EN")
            {
                Control.Attributes.Add("onclick", "return confirm('" + msgEN + "');");
            }
            else if (strLang.ToUpper().Trim() == "CN")
            {
                Control.Attributes.Add("onclick", "return confirm('" + msgCN + "');");
            }

        }

        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msgEN, string msgCN, string url, string strLang)
        {
            if (strLang.ToUpper().Trim() == "EN")
            {

                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgEN + "');window.location=\"" + url + "\"</script>");
            }
            else if (strLang.ToUpper().Trim() == "CN")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgCN + "');window.location=\"" + url + "\"</script>");
            }


        }
        public static void ShowAndRedirectParent(System.Web.UI.Page page, string msgEN, string msgCN, string url, string strLang)
        {
            if (strLang.ToUpper().Trim() == "EN")
            {

                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgEN + "');window.parent.location=\"" + url + "\"</script>");
            }
            else if (strLang.ToUpper().Trim() == "CN")
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgCN + "');window.parent.location=\"" + url + "\"</script>");
            }


        }
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirectLogin(System.Web.UI.Page page, string msgEN, string url)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msgEN + "');window.parent.location.href=\"" + url + "\"</script>");
        }
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="url">��ת��Ŀ��URL</param>
        public static void ShowAndRedirects(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

        }

        /// <summary>
        /// ����Զ���ű���Ϣ
        /// </summary>
        /// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
        /// <param name="script">����ű�</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }
        #endregion

        public static void ChangeCaption(System.Web.UI.Page page, string destLang)
        {
            string strCation = "";
            if (destLang.Trim().ToUpper() == "EN")
            {
                return;
            }
            else if (destLang.Trim().ToUpper() == "CN")
            {
                foreach (Object ctrl in page.Controls)
                {
                    if (ctrl is Label)
                    {

                    }

                }
            }
            else
            {
                return;//todo no language option
            }

        }
        private static void writeLog(string title, string error)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            //try
            //{
            string fileName = HttpContext.Current.Request.ApplicationPath + ConfigurationManager.AppSettings["logInfo"].ToString() + ".txt";
            FileInfo fileInfo = new FileInfo(fileName);
            if (!File.Exists(fileName))
            {
                fs = fileInfo.Create();
                sw = new StreamWriter(fs);
            }
            else
            {
                fs = fileInfo.Open(FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
            }
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "[]" + title + "[]" + error);
            //}
            //finally
            //{
            //    sw.Close();
            //    sw.Dispose();
            //    fs.Close();
            //    fs.Dispose();
            //}
        }
        public static void changeToolTip(System.Web.UI.Page page, string strLang)
        {
            if (strLang.Equals("CN"))
            {
                foreach (Object ob in page.Form.Controls)
                {
                    string strCaption = "";
                    if (ob is Button)
                    {
                        strCaption = ((Button)ob).ToolTip;
                        ((Button)ob).ToolTip = ((Button)ob).Text;
                        ((Button)ob).Text = strCaption;
                    }
                    if (ob is Label)
                    {
                        strCaption = ((Label)ob).ToolTip;
                        ((Label)ob).ToolTip = ((Label)ob).Text;
                        ((Label)ob).Text = strCaption;
                    }
                    if (ob is CheckBox)
                    {
                        strCaption = ((CheckBox)ob).ToolTip;
                        ((CheckBox)ob).ToolTip = ((CheckBox)ob).Text;
                        ((CheckBox)ob).Text = strCaption;
                    }
                    if (ob is LinkButton)
                    {
                        strCaption = ((LinkButton)ob).ToolTip;
                        ((LinkButton)ob).ToolTip = ((LinkButton)ob).Text;
                        ((LinkButton)ob).Text = strCaption;
                    }
                    if (ob is GridView)
                    {
                        GridView gd = (GridView)ob;
                        for (int i = 0; i < gd.Columns.Count; i++)
                        {
                            strCaption = gd.Columns[i].HeaderText;
                            gd.Columns[i].HeaderText = gd.Columns[i].FooterText;
                            gd.Columns[i].FooterText = strCaption;
                        }
                    }
                    if (ob is UserControl)
                    {
                        changeToolTipUC((UserControl)ob, strLang);
                    }
                }
            }
            else
            {
                return;
            }
        }
        public static void changeToolTipUC(System.Web.UI.UserControl page, string strLang)
        {
            if (strLang.Equals("CN"))
            {
                foreach (Object ob in page.Controls)
                {
                    string strCaption = "";
                    if (ob is Button)
                    {
                        strCaption = ((Button)ob).ToolTip;
                        ((Button)ob).ToolTip = ((Button)ob).Text;
                        ((Button)ob).Text = strCaption;
                    }
                    if (ob is Label)
                    {
                        strCaption = ((Label)ob).ToolTip;
                        ((Label)ob).ToolTip = ((Label)ob).Text;
                        ((Label)ob).Text = strCaption;
                    }
                    if (ob is CheckBox)
                    {
                        strCaption = ((CheckBox)ob).ToolTip;
                        ((CheckBox)ob).ToolTip = ((CheckBox)ob).Text;
                        ((CheckBox)ob).Text = strCaption;
                    }
                    if (ob is LinkButton)
                    {
                        strCaption = ((LinkButton)ob).ToolTip;
                        ((LinkButton)ob).ToolTip = ((LinkButton)ob).Text;
                        ((LinkButton)ob).Text = strCaption;
                    }
                    if (ob is GridView)
                    {
                        GridView gd = (GridView)ob;
                        for (int i = 0; i < gd.Columns.Count; i++)
                        {
                            strCaption = gd.Columns[i].HeaderText;
                            gd.Columns[i].HeaderText = gd.Columns[i].FooterText;
                            gd.Columns[i].FooterText = strCaption;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
