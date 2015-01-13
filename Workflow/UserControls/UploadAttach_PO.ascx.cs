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
using System.Web.Services;


namespace Workflow.UserControls
{
    public partial class UploadAttach_PO : System.Web.UI.UserControl
    {
        private Sys_Attach_Mstr_Model _attachModel;

        public Sys_Attach_Mstr_Model AttachModel
        {
            get { return _attachModel; }
            set { _attachModel = value; }
        }
        public string strUser = "";
        public string strLocation = "";
        public string strLang = "";
        public string AttachAddr = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo userInfo = (UserInfo)Session["OA-UserInfo"];
            string ReqNbr = AttachModel.attach_nbr;
            string ReqLoc = AttachModel.attach_location;
            strUser = userInfo != null ? userInfo.UserLoginName.Trim() : "";
            strLocation = userInfo != null ? userInfo.UserLocation.Trim() : "";
            strLang = userInfo != null ? userInfo.UserLang.Trim().ToUpper() : "";
            if (userInfo != null)
            {
                strLang = userInfo.UserLang.Trim().ToUpper();
                if (!IsPostBack)
                {
                    changToolTip(strLang);
                    bindAttachGrid(this.AttachModel.attach_nbr);
                    V_Appr_Flow apprMstr = new V_Appr_Flow();
                    
                    if (!apprMstr.ExistsApproveRight(ReqNbr, ReqLoc, strUser))
                    {
                        btnAddAttach.Enabled = false;
                    }
                }
            }
        }
        private void changToolTip(string Lang)
        {

            //btnAddAttach.Text = Lang == "CN" ? btnAddAttach.ToolTip : btnAddAttach.Text;
            if (Lang == "CN")
            {
                for (int i = 0; i < attachGrid.Columns.Count; i++)
                {
                    attachGrid.Columns[i].HeaderText = attachGrid.Columns[i].FooterText;
                }
            }
        }



        protected void attachGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                AttachAddr = attachGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim().ToUpper() == "WTSZ" ? System.Configuration.ConfigurationManager.AppSettings["WTSZ-DispAttach"].ToString().Trim() : System.Configuration.ConfigurationManager.AppSettings["WWTS-DispAttach"].ToString().Trim();
                e.Row.Cells[1].Text = "<a  target='_self' href='" + AttachAddr + attachGrid.DataKeys[e.Row.RowIndex]["attach_path"].ToString().Trim() + "'>" + e.Row.Cells[1].Text + "</a>";
                if (e.Row.Cells[2].Text.Trim().ToUpper() != AttachModel.attach_user.Trim().ToUpper())
                {
                    e.Row.Cells[0].Enabled = false;
                }
            }
            else
            { 
               
            }
        }

        protected void attachGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Sys_Attach_Mstr attachBLL = new Sys_Attach_Mstr();
            Sys_Code_Mstr codeBLL = new Sys_Code_Mstr();
            Sys_Code_Mstr_Model codeModel = new Sys_Code_Mstr_Model();
            Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
            int keys = int.Parse(e.Keys["attach_id"].ToString());
            attachModel = attachBLL.GetModel(keys);
            string attachDir = attachModel.attach_path.ToString();
            List<Sys_Code_Mstr_Model> codeModelList = new List<Sys_Code_Mstr_Model>();
            codeModelList = codeBLL.GetModelList(" code_cmmt = 'UPLOAD' and code_desc='" + strLocation + "'");
            string ftpAddress = "";
            string ftpUser = "";
            string ftpPwd = "";
            if (codeModelList != null && codeModelList.Count > 0)
            {
                foreach (Sys_Code_Mstr_Model codeChild in codeModelList)
                {
                    ftpAddress = codeChild.code_value.Trim();
                    ftpUser = codeChild.code_user1;
                    ftpPwd = codeChild.code_user2;
                    FTPHelper.fileDelete(ftpAddress, attachDir, ftpUser, ftpPwd);
                }
                attachBLL.Delete(keys);
                bindAttachGrid(AttachModel.attach_nbr);
            }
            else
            {
                return;
            }
        }
        private void bindAttachGrid(string strNhr)
        {
            List<Sys_Attach_Mstr_Model> listAttach = new Sys_Attach_Mstr().GetSpecialModelList(" attach_nbr = '" + AttachModel.attach_nbr + "'");//todo add user upload condition because order to defend others delete on other file upload page. 
            attachGrid.DataSource = listAttach;
            attachGrid.DataKeyNames = new string[] { "attach_id", "attach_path","attach_location" };
            attachGrid.DataBind();
        }

        protected void btnAddAttach_Click(object sender, EventArgs e)
        {
            string strNbr = this.AttachModel.attach_nbr.Trim();
            if (strNbr == "")
            {
                return;
            }
            else
            {
                int maxsize = int.Parse(new Sys_Code_Mstr().GetList("code_cmmt = 'ATTACHSIZE'").Tables[0].Rows[0]["code_value"].ToString());
                if (FileUP.PostedFile != null)
                {
                    if ((FileUP.PostedFile.ContentLength / 1024) > (1024 * maxsize) || FileUP.PostedFile.ContentLength == 0)
                    {
                        PageBase.Show(Page, "the length of file must be less than " + maxsize + "M and more than 0MB", "文件大小要大于0M，小于" + maxsize + "M", strLang);
                        return;
                    }
                }
                else
                {
                    PageBase.Show(Page, "the length of file must be less than " + maxsize + "M and more than 0MB", "文件大小要大于0M，小于" + maxsize + "M", strLang);
                    return;
                }
                string fileFullName = FileUP.PostedFile.FileName;
                string[] arryFile = fileFullName.Split('\\');
                string fileName = arryFile[arryFile.Length - 1].ToString();
                string[] suffix = fileName.Split('.');
                string suffixName = suffix[suffix.Length - 1].ToString();
                if (suffixName.ToUpper() == "EXE")
                {
                    PageBase.Show(Page, "can't upload 'exe' file", "不能上传exe文件", strLang);
                    return;
                }
                int len = System.Text.Encoding.Default.GetByteCount(fileName);
                if (len > 100)
                {
                    PageBase.Show(Page, "File name is too long", "文件名字长度不能超过100位", strLang);
                    return;
                }
                try
                {
                    string temppath = Server.MapPath("~/temp/");

                    Sys_Form_Mstr form = new Sys_Form_Mstr();
                    Sys_Form_Mstr_Model formModel = form.GetModel(strNbr);
                    if (formModel == null)
                    {
                        PageBase.Show(Page, "File number not exists", "单号不存在", strLang);
                        return;
                    }
                    string attach_guid = formModel.form_guid;
                    Sys_Attach_Mstr attachBLL = new Sys_Attach_Mstr();
                    Sys_Code_Mstr codeBLL = new Sys_Code_Mstr();
                    string saveName = strNbr + "-" + attachBLL.getSaveName() + "." + suffixName;
                    string subFolder = DateTime.Now.ToString("yyyyMM");

                    List<Sys_Code_Mstr_Model> codeModel = new List<Sys_Code_Mstr_Model>();
                    codeModel = codeBLL.GetModelList(" code_cmmt = 'UPLOAD' and code_desc='" + strLocation + "'");
                    string ftpAddress = "";
                    string ftpUser = "";
                    string ftpPwd = "";
                    Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                    if (!fso.FolderExists(temppath + "/" + AttachModel.attach_type))
                    {
                        fso.CreateFolder(temppath + "/" + AttachModel.attach_type);
                    }
                    if (!fso.FolderExists(temppath + "/" + AttachModel.attach_type + "/" + subFolder))
                    {
                        fso.CreateFolder(temppath + "/" + AttachModel.attach_type + "/" + subFolder);
                    }
                    string tempTarget = temppath + AttachModel.attach_type + "/" + subFolder + "/" + saveName;
                    fso = null;
                    FileUP.PostedFile.SaveAs(tempTarget);
                    FileInfo file = new FileInfo(tempTarget);
                    if (codeModel != null && codeModel.Count > 0)
                    {
                        foreach (Sys_Code_Mstr_Model codeChild in codeModel)
                        {
                            ftpAddress = codeChild.code_value.Trim();
                            ftpUser = codeChild.code_user1;
                            ftpPwd = codeChild.code_user2;
                            if (FTPHelper.UploadFile(file, saveName, AttachModel.attach_type + "/" + subFolder + "/", ftpAddress, ftpUser, ftpPwd) == false)
                            {
                                return;
                            }
                        }
                        if (FileSystem.Dir(tempTarget) != "")
                        {
                            FileSystem.Kill(tempTarget);
                        }
                    }
                    else
                    {
                        return;
                    }
                    Sys_Attach_Mstr_Model attachModel = new Sys_Attach_Mstr_Model();
                    attachModel.attach_nbr = strNbr;
                    attachModel.attach_guid = attach_guid;
                    attachModel.attach_path = AttachModel.attach_type + "/" + subFolder + "/" + saveName;
                    attachModel.attach_user = AttachModel.attach_user;
                    attachModel.attach_time = DateTime.Now;
                    attachModel.attach_title = fileName;
                    attachModel.attach_type = AttachModel.attach_type;
                    attachModel.attach_location = AttachModel.attach_location;
                    attachBLL.Add(attachModel);
                    bindAttachGrid(strNbr);
                }
                catch (Exception ex)
                {
                    PageBase.Show(Page, ex.ToString(), ex.ToString(), strLang);
                }
            }
        } 
    }
}