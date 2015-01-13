using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.DBUtility;
using System.Data;
namespace Workflow.DAL
{
    public class Sys_Task_ListDAL
    {
        public DataSet GetList(string strWhere,string strLang)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLang == "CN")
            {
                strSql.Append("select distinct appr_nbr,appr_seq,appr_type,config_title,config_title_cn,max(appr_date_in) as appr_date_in ,datediff(hour,max(appr_date_in),getdate()) as appr_pending,flow_page  ,form_applicant,form_dept,form_location,form_guid,form_seq,flow_status_cn as flow_status,m_svr_subject");
                strSql.Append(" from V_Appr_Mstr,Sys_Flow_Config,Sys_Flow_Mstr,Sys_Form_Mstr,Cus_MIS_Service ");
                strSql.Append(" where appr_type = config_type and appr_nbr = form_nbr and appr_appr='N' and flow_seq = appr_seq and flow_type = config_type and appr_now='Y' and appr_nbr = m_svr_nbr ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" group by appr_nbr,appr_seq,appr_type,config_title,config_title_cn,flow_page,form_applicant,form_dept,form_location,form_guid,form_seq,flow_status_cn,m_svr_subject order by appr_type ,appr_nbr ");
                
            }
            else
            {
                strSql.Append("select distinct appr_nbr,appr_seq,appr_type,config_title,config_title_cn,max(appr_date_in) as appr_date_in ,datediff(hour,max(appr_date_in),getdate()) as appr_pending,flow_page  ,form_applicant,form_dept,form_location,form_guid,form_seq,flow_status_en as flow_status,m_svr_subject");
                strSql.Append(" from V_Appr_Mstr,Sys_Flow_Config,Sys_Flow_Mstr,Sys_Form_Mstr,Cus_MIS_Service ");
                strSql.Append(" where appr_type = config_type and appr_nbr = form_nbr and appr_appr='N' and flow_seq = appr_seq and flow_type = config_type and appr_now='Y' and appr_nbr = m_svr_nbr ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" group by appr_nbr,appr_seq,appr_type,config_title,config_title_cn,flow_page,form_applicant,form_dept,form_location,form_guid,form_seq,flow_status_en,m_svr_subject order by appr_type ,appr_nbr ");
            }
            
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList_RECRUIT(string strWhere, string strLang,string strWhere1)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLang == "CN")
            {
                strSql.Append("select distinct job_nbr,job_guid,job_applicant,job_date,job_title,job_location,job_dept,flow_type,'Waiting your approve' as status");
                strSql.Append(" from V_Appr_Mstr,Sys_Flow_Config,Sys_Flow_Mstr,Sys_Form_Mstr,Cus_Job_Det,Cus_Job_Mstr ");
                strSql.Append(" where appr_nbr = cv_nbr and appr_nbr = form_nbr and appr_appr='N' and flow_seq = appr_seq and flow_type = config_type and appr_now='Y' and appr_type = config_type  and cv_job_guid = job_guid and form_seq > 10 ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" union select distinct job_nbr,job_guid,job_applicant,job_date,job_title,job_location,job_dept,flow_type,flow_status_en as status");
                strSql.Append(" from V_Appr_Mstr,Sys_Flow_Config,Sys_Flow_Mstr,Sys_Form_Mstr,Cus_Job_Mstr ");
                strSql.Append(" where appr_nbr = job_nbr and appr_nbr = form_nbr and appr_appr='N' and flow_seq = appr_seq and flow_type = config_type and appr_now='Y' and appr_type = config_type  ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere1);
                }
                //strSql.Append("  order by appr_type ,job_nbr ");

            }
            else
            {
                strSql.Append("select distinct job_nbr,job_guid,job_applicant,job_date,job_title,job_location,job_dept,flow_type,'Waiting your approve' as status");
                strSql.Append(" from V_Appr_Mstr,Sys_Flow_Config,Sys_Flow_Mstr,Sys_Form_Mstr,Cus_Job_Det,Cus_Job_Mstr ");
                strSql.Append(" where appr_nbr = cv_nbr and appr_nbr = form_nbr and appr_appr='N' and flow_seq = appr_seq and flow_type = config_type and appr_now='Y' and appr_type = config_type  and cv_job_guid = job_guid and form_seq >10 ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere);
                }
                strSql.Append(" union select distinct job_nbr,job_guid,job_applicant,job_date,job_title,job_location,job_dept,flow_type,flow_status_en as status");
                strSql.Append(" from V_Appr_Mstr,Sys_Flow_Config,Sys_Flow_Mstr,Sys_Form_Mstr,Cus_Job_Mstr ");
                strSql.Append(" where appr_nbr = job_nbr and appr_nbr = form_nbr and appr_appr='N' and flow_seq = appr_seq and flow_type = config_type and appr_now='Y' and appr_type = config_type  ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" and " + strWhere1);
                }
                //strSql.Append("  order by appr_type ,job_nbr ");
            }

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
