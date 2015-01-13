using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;

namespace Workflow.DAL
{
    public class Sys_SystemDAL
    {
        #region  ExtensionMethod
        public string ExecApproveProc(Workflow.Model.Sys_Flow_Approve_Model model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,10),
                    new SqlParameter("@nbr", SqlDbType.Char, 20),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 20),
                    new SqlParameter("@action", SqlDbType.VarChar,10),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@remark", SqlDbType.VarChar,1000),
                    };
            parameters[1].Value = model.Nbr;
            parameters[2].Value = model.Location;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Action;
            parameters[5].Value = model.User;
            parameters[6].Value = model.Remark;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_flow_approve]", parameters);
            return parameters[0].Value.ToString();
        }
        public string ExecApproveProcCV(Workflow.Model.Sys_Flow_Approve_Model model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,10),
                    new SqlParameter("@nbr", SqlDbType.Char, 20),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 20),
                    new SqlParameter("@action", SqlDbType.VarChar,10),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@remark", SqlDbType.VarChar,1000),
                    };
            parameters[1].Value = model.Nbr;
            parameters[2].Value = model.Location;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Action;
            parameters[5].Value = model.User;
            parameters[6].Value = model.Remark;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_flow_approve_cv]", parameters);
            return parameters[0].Value.ToString();
        }
        public string ExecApproveProc(string nbr,string location,string type,string action,string user,string remark)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,10),
                    new SqlParameter("@nbr", SqlDbType.Char, 20),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 20),
                    new SqlParameter("@action", SqlDbType.VarChar,10),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@remark", SqlDbType.VarChar,1000),
                    };
            parameters[1].Value = nbr;
            parameters[2].Value = location;
            parameters[3].Value = type;
            parameters[4].Value = action;
            parameters[5].Value = user;
            parameters[6].Value = remark;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_flow_approve]", parameters);
            return parameters[0].Value.ToString();
        }
        public string ExecApprovePOProc(Workflow.Model.Sys_Flow_Approve_Model model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,10),
                    new SqlParameter("@nbr", SqlDbType.Char, 20),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 20),
                    new SqlParameter("@action", SqlDbType.VarChar,10),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@remark", SqlDbType.VarChar,1000),
                    };
            parameters[1].Value = model.Nbr;
            parameters[2].Value = model.Location;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Action;
            parameters[5].Value = model.User;
            parameters[6].Value = model.Remark;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_flow_approve_po]", parameters);
            return parameters[0].Value.ToString();
        }
        public void ExecSendMailProc(string mailto, string mailcc, string mailsubject, string mailbody)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@mailto", SqlDbType.VarChar,4000),
                    new SqlParameter("@mailcc", SqlDbType.VarChar, 4000),
                    new SqlParameter("@mailsubject", SqlDbType.VarChar, 4000),
                    new SqlParameter("@mailbody", SqlDbType.VarChar, 4000)
                    };
            parameters[0].Value = mailto;
            parameters[1].Value = mailcc;
            parameters[2].Value = mailsubject;
            parameters[3].Value = mailbody;
            DbHelperSQL.RunProcedure("[sp_send_mail_custom]", parameters);
        }
        #endregion  ExtensionMethod
    }
}
