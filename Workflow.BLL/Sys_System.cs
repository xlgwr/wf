using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Workflow.DAL;
namespace Workflow.BLL
{
    public class Sys_System
    {
        #region  ExtensionMethod
        public string ExecApproveProc(Workflow.Model.Sys_Flow_Approve_Model model)
        {
            string strIret = new Sys_SystemDAL().ExecApproveProc(model);
            return strIret;
        }
        public string ExecApproveProcCV(Workflow.Model.Sys_Flow_Approve_Model model)
        {
            string strIret = new Sys_SystemDAL().ExecApproveProcCV(model);
            return strIret;
        }
        public string ExecApproveProc(string nbr, string location, string type, string action, string user, string remark)
        {
            string strIret = new Sys_SystemDAL().ExecApproveProc(nbr,location,type,action,user,remark);
            return strIret;
        }
        public string ExecApprovePOProc(Workflow.Model.Sys_Flow_Approve_Model model)
        {
            string strIret = new Sys_SystemDAL().ExecApprovePOProc(model);
            return strIret;
        }
        public void ExecSendMailProc(string mailto, string mailcc, string mailsubject, string mailbody)
        {
            new Sys_SystemDAL().ExecSendMailProc(mailto, mailcc, mailsubject, mailbody);
        }
        public bool CheckPageRight(string strUser)
        {
            return true;
        }
       
        #endregion  ExtensionMethod
    }
}
