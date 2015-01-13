using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_MIS_Service_Model
    /// </summary>
    public partial class Cus_MIS_ServiceDAL
    {
        public Cus_MIS_ServiceDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string m_svr_nbr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_MIS_Service");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)			};
            parameters[0].Value = m_svr_nbr;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_MIS_Service_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_MIS_Service(");
            strSql.Append("m_svr_nbr,m_svr_location,m_svr_dept,m_svr_exp_date,m_svr_subject,m_svr_desc,m_svr_remark,m_svr_user,m_svr_process_by,m_svr_plan_from,m_svr_plan_end,m_svr_act_from,m_svr_act_end,m_svr_type,m_svr_urgent,m_svr_date,m_svr_relate)");
            strSql.Append(" values (");
            strSql.Append("@m_svr_nbr,@m_svr_location,@m_svr_dept,@m_svr_exp_date,@m_svr_subject,@m_svr_desc,@m_svr_remark,@m_svr_user,@m_svr_process_by,@m_svr_plan_from,@m_svr_plan_end,@m_svr_act_from,@m_svr_act_end,@m_svr_type,@m_svr_urgent,@m_svr_date,@m_svr_relate)");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20),
					new SqlParameter("@m_svr_location", SqlDbType.VarChar,20),
					new SqlParameter("@m_svr_dept", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_exp_date", SqlDbType.DateTime),
					new SqlParameter("@m_svr_subject", SqlDbType.VarChar,100),
					new SqlParameter("@m_svr_desc", SqlDbType.VarChar,8000),
					new SqlParameter("@m_svr_remark", SqlDbType.VarChar,8000),
					new SqlParameter("@m_svr_user", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_process_by", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_plan_from", SqlDbType.DateTime),
					new SqlParameter("@m_svr_plan_end", SqlDbType.DateTime),
					new SqlParameter("@m_svr_act_from", SqlDbType.DateTime),
					new SqlParameter("@m_svr_act_end", SqlDbType.DateTime),
					new SqlParameter("@m_svr_type", SqlDbType.VarChar,100),
					new SqlParameter("@m_svr_urgent", SqlDbType.Char,1),
					new SqlParameter("@m_svr_date", SqlDbType.DateTime),
                    new SqlParameter("@m_svr_relate",SqlDbType.Char,1)            
                                        };
            parameters[0].Value = model.m_svr_nbr;
            parameters[1].Value = model.m_svr_location;
            parameters[2].Value = model.m_svr_dept;
            parameters[3].Value = model.m_svr_exp_date;
            parameters[4].Value = model.m_svr_subject;
            parameters[5].Value = model.m_svr_desc;
            parameters[6].Value = model.m_svr_remark;
            parameters[7].Value = model.m_svr_user;
            parameters[8].Value = model.m_svr_process_by;
            parameters[9].Value = model.m_svr_plan_from;
            parameters[10].Value = model.m_svr_plan_end;
            parameters[11].Value = model.m_svr_act_from;
            parameters[12].Value = model.m_svr_act_end;
            parameters[13].Value = model.m_svr_type;
            parameters[14].Value = model.m_svr_urgent;
            parameters[15].Value = model.m_svr_date;
            parameters[16].Value = model.m_svr_relate;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_MIS_Service_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_MIS_Service set ");
            strSql.Append("m_svr_location=@m_svr_location,");
            strSql.Append("m_svr_dept=@m_svr_dept,");
            strSql.Append("m_svr_exp_date=@m_svr_exp_date,");
            strSql.Append("m_svr_subject=@m_svr_subject,");
            strSql.Append("m_svr_desc=@m_svr_desc,");
            strSql.Append("m_svr_remark=@m_svr_remark,");
            strSql.Append("m_svr_user=@m_svr_user,");
            strSql.Append("m_svr_process_by=@m_svr_process_by,");
            strSql.Append("m_svr_plan_from=@m_svr_plan_from,");
            strSql.Append("m_svr_plan_end=@m_svr_plan_end,");
            strSql.Append("m_svr_act_from=@m_svr_act_from,");
            strSql.Append("m_svr_act_end=@m_svr_act_end,");
            strSql.Append("m_svr_status=@m_svr_status,");
            strSql.Append("m_svr_urgent=@m_svr_urgent,");
            strSql.Append("m_svr_date=@m_svr_date");
            strSql.Append("m_svr_relate=@m_svr_relate");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_location", SqlDbType.VarChar,20),
					new SqlParameter("@m_svr_dept", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_exp_date", SqlDbType.DateTime),
					new SqlParameter("@m_svr_subject", SqlDbType.VarChar,100),
					new SqlParameter("@m_svr_desc", SqlDbType.VarChar,8000),
					new SqlParameter("@m_svr_remark", SqlDbType.VarChar,8000),
					new SqlParameter("@m_svr_user", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_process_by", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_plan_from", SqlDbType.DateTime),
					new SqlParameter("@m_svr_plan_end", SqlDbType.DateTime),
					new SqlParameter("@m_svr_act_from", SqlDbType.DateTime),
					new SqlParameter("@m_svr_act_end", SqlDbType.DateTime),
					new SqlParameter("@m_svr_type", SqlDbType.VarChar,100),
					new SqlParameter("@m_svr_urgent", SqlDbType.Char,1),
					new SqlParameter("@m_svr_date", SqlDbType.DateTime),
                    new SqlParameter("@m_svr_relate", SqlDbType.DateTime),
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)};
            parameters[0].Value = model.m_svr_location;
            parameters[1].Value = model.m_svr_dept;
            parameters[2].Value = model.m_svr_exp_date;
            parameters[3].Value = model.m_svr_subject;
            parameters[4].Value = model.m_svr_desc;
            parameters[5].Value = model.m_svr_remark;
            parameters[6].Value = model.m_svr_user;
            parameters[7].Value = model.m_svr_process_by;
            parameters[8].Value = model.m_svr_plan_from;
            parameters[9].Value = model.m_svr_plan_end;
            parameters[10].Value = model.m_svr_act_from;
            parameters[11].Value = model.m_svr_act_end;
            parameters[12].Value = model.m_svr_type;
            parameters[13].Value = model.m_svr_urgent;
            parameters[14].Value = model.m_svr_date;
            parameters[15].Value = model.m_svr_nbr;
            parameters[16].Value = model.m_svr_relate;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string m_svr_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_MIS_Service ");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)			};
            parameters[0].Value = m_svr_nbr;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string m_svr_nbrlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_MIS_Service ");
            strSql.Append(" where m_svr_nbr in (" + m_svr_nbrlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_MIS_Service_Model GetModel(string m_svr_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 m_svr_nbr,m_svr_location,m_svr_dept,m_svr_exp_date,m_svr_subject,m_svr_desc,m_svr_remark,m_svr_user,m_svr_process_by,m_svr_plan_from,m_svr_plan_end,m_svr_act_from,m_svr_act_end,m_svr_type,m_svr_urgent,m_svr_date,m_svr_relate from Cus_MIS_Service ");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)			};
            parameters[0].Value = m_svr_nbr;

            Workflow.Model.Cus_MIS_Service_Model model = new Workflow.Model.Cus_MIS_Service_Model();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_MIS_Service_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_MIS_Service_Model model = new Workflow.Model.Cus_MIS_Service_Model();
            if (row != null)
            {
                if (row["m_svr_nbr"] != null)
                {
                    model.m_svr_nbr = row["m_svr_nbr"].ToString();
                }
                if (row["m_svr_location"] != null)
                {
                    model.m_svr_location = row["m_svr_location"].ToString();
                }
                if (row["m_svr_dept"] != null)
                {
                    model.m_svr_dept = row["m_svr_dept"].ToString();
                }
                if (row["m_svr_exp_date"] != null && row["m_svr_exp_date"].ToString() != "")
                {
                    model.m_svr_exp_date = DateTime.Parse(row["m_svr_exp_date"].ToString());
                }
                if (row["m_svr_subject"] != null)
                {
                    model.m_svr_subject = row["m_svr_subject"].ToString();
                }
                if (row["m_svr_desc"] != null)
                {
                    model.m_svr_desc = row["m_svr_desc"].ToString();
                }
                if (row["m_svr_remark"] != null)
                {
                    model.m_svr_remark = row["m_svr_remark"].ToString();
                }
                if (row["m_svr_user"] != null)
                {
                    model.m_svr_user = row["m_svr_user"].ToString();
                }
                if (row["m_svr_process_by"] != null)
                {
                    model.m_svr_process_by = row["m_svr_process_by"].ToString();
                }
                if (row["m_svr_plan_from"] != null && row["m_svr_plan_from"].ToString() != "")
                {
                    model.m_svr_plan_from = DateTime.Parse(row["m_svr_plan_from"].ToString());
                }
                if (row["m_svr_plan_end"] != null && row["m_svr_plan_end"].ToString() != "")
                {
                    model.m_svr_plan_end = DateTime.Parse(row["m_svr_plan_end"].ToString());
                }
                if (row["m_svr_act_from"] != null && row["m_svr_act_from"].ToString() != "")
                {
                    model.m_svr_act_from = DateTime.Parse(row["m_svr_act_from"].ToString());
                }
                if (row["m_svr_act_end"] != null && row["m_svr_act_end"].ToString() != "")
                {
                    model.m_svr_act_end = DateTime.Parse(row["m_svr_act_end"].ToString());
                }
                if (row["m_svr_type"] != null)
                {
                    model.m_svr_type = row["m_svr_type"].ToString();
                }
                if (row["m_svr_urgent"] != null)
                {
                    model.m_svr_urgent = row["m_svr_urgent"].ToString();
                }
                if (row["m_svr_date"] != null && row["m_svr_date"].ToString() != "")
                {
                    model.m_svr_date = DateTime.Parse(row["m_svr_date"].ToString());
                }
                if (row["m_svr_relate"] != null)
                {
                    model.m_svr_urgent = row["m_svr_relate"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select m_svr_nbr,m_svr_location,m_svr_dept,m_svr_exp_date,m_svr_subject,m_svr_desc,m_svr_remark,m_svr_user,m_svr_process_by,m_svr_plan_from,m_svr_plan_end,m_svr_act_from,m_svr_act_end,m_svr_type,m_svr_urgent,m_svr_date,m_svr_relate ");
            strSql.Append(" FROM Cus_MIS_Service ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" m_svr_nbr,m_svr_location,m_svr_dept,m_svr_exp_date,m_svr_subject,m_svr_desc,m_svr_remark,m_svr_user,m_svr_process_by,m_svr_plan_from,m_svr_plan_end,m_svr_act_from,m_svr_act_end,m_svr_type,m_svr_urgent,m_svr_date,m_svr_relate ");
            strSql.Append(" FROM Cus_MIS_Service ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Cus_MIS_Service ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.m_svr_nbr desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_MIS_Service T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Cus_MIS_Service";
            parameters[1].Value = "m_svr_nbr";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public DataSet DsQuery(string strWhere,string strLang)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLang == "CN")
            {
                strSql.Append("select m_svr_nbr,m_svr_location,m_svr_date,m_svr_dept,m_svr_exp_date,m_svr_subject,m_svr_desc,m_svr_remark,m_svr_user,m_svr_process_by,m_svr_plan_from,m_svr_plan_end,m_svr_act_from,m_svr_act_end,m_svr_type,m_svr_urgent,m_svr_date,m_svr_relate,form_seq,flow_status_cn as mis_status,form_guid,");
                strSql.Append(" case when len(m_svr_type)>3 then (SELECT mis_type_value_cn from cus_mis_type where mis_type_code=substring(m_svr_type,1,3)) + ':' +(SELECT mis_type_value_cn from cus_mis_type where mis_type_code=m_svr_type) ");
                strSql.Append(" else (SELECT mis_type_value from cus_mis_type where mis_type_code=substring(m_svr_type,1,3)) end as 'mis_type' ");
            }
            else
            {
                strSql.Append("select m_svr_nbr,m_svr_location,m_svr_date,m_svr_dept,m_svr_exp_date,m_svr_subject,m_svr_desc,m_svr_remark,m_svr_user,m_svr_process_by,m_svr_plan_from,m_svr_plan_end,m_svr_act_from,m_svr_act_end,m_svr_type,m_svr_urgent,m_svr_date,m_svr_relate,form_seq,flow_status_en as mis_status,form_guid, ");
                strSql.Append(" case when len(m_svr_type)>3 then (SELECT mis_type_value from cus_mis_type where mis_type_code=substring(m_svr_type,1,3)) + ':' +(SELECT mis_type_value from cus_mis_type where mis_type_code=m_svr_type) ");
                strSql.Append(" else (SELECT mis_type_value from cus_mis_type where mis_type_code=substring(m_svr_type,1,3)) end as 'mis_type' ");
            }

            strSql.Append(" FROM Cus_MIS_Service,Sys_Form_Mstr,Sys_Flow_Mstr where m_svr_nbr = form_nbr and form_type = flow_type and form_location = flow_location and  form_seq = flow_seq ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public string SaveMISService(Workflow.Model.Cus_MIS_Service_Model model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,2),
                    new SqlParameter("@nbr", SqlDbType.Char, 20),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 100),
                    new SqlParameter("@exp", SqlDbType.DateTime),
                    new SqlParameter("@subject", SqlDbType.VarChar, 100),
                    new SqlParameter("@desc", SqlDbType.VarChar,1000),
                    new SqlParameter("@remark", SqlDbType.VarChar,1000),
                    new SqlParameter("@urgent", SqlDbType.VarChar,20),
                    new SqlParameter("@user", SqlDbType.VarChar,50)
                    };
            parameters[1].Value = model.m_svr_nbr;
            parameters[2].Value = model.m_svr_location;
            parameters[3].Value = model.m_svr_type;
            parameters[4].Value = model.m_svr_exp_date;
            parameters[5].Value = model.m_svr_subject;
            parameters[6].Value = model.m_svr_desc;
            parameters[7].Value = model.m_svr_remark;
            parameters[8].Value = model.m_svr_urgent;
            parameters[9].Value = model.m_svr_user;
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.InputOutput;
            DbHelperSQL.RunProcedure("sp_MisService_Save", parameters);
            return parameters[0].Value.ToString()+"|"+parameters[1].Value.ToString();
        }
        public bool UpdateRelative(Workflow.Model.Cus_MIS_Service_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_MIS_Service set ");
            strSql.Append("m_svr_relate=@m_svr_relate");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
                    new SqlParameter("@m_svr_relate", SqlDbType.Char,1),
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)};
            parameters[0].Value = model.m_svr_relate;
            parameters[1].Value = model.m_svr_nbr;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateProcess(Workflow.Model.Cus_MIS_Service_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_MIS_Service set ");
            strSql.Append("m_svr_process_by=@m_svr_process_by,");
            strSql.Append("m_svr_plan_from=@m_svr_plan_from,");
            strSql.Append("m_svr_plan_end=@m_svr_plan_end");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_process_by", SqlDbType.VarChar,50),
					new SqlParameter("@m_svr_plan_from", SqlDbType.DateTime),
					new SqlParameter("@m_svr_plan_end", SqlDbType.DateTime),
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)};
            parameters[0].Value = model.m_svr_process_by;
            parameters[1].Value = model.m_svr_plan_from;
            parameters[2].Value = model.m_svr_plan_end;
            parameters[3].Value = model.m_svr_nbr;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateAct(Workflow.Model.Cus_MIS_Service_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_MIS_Service set ");
            strSql.Append("m_svr_act_from=@m_svr_act_from,");
            strSql.Append("m_svr_act_end=@m_svr_act_end");
            strSql.Append(" where m_svr_nbr=@m_svr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@m_svr_act_from", SqlDbType.DateTime),
					new SqlParameter("@m_svr_act_end", SqlDbType.DateTime),
					new SqlParameter("@m_svr_nbr", SqlDbType.Char,20)};
            parameters[0].Value = model.m_svr_act_from;
            parameters[1].Value = model.m_svr_act_end;
            parameters[2].Value = model.m_svr_nbr;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion  ExtensionMethod
    }
}

