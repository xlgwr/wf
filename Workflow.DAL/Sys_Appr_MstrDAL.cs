﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;

namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Appr_Mstr
    /// </summary>
    public partial class Sys_Appr_MstrDAL
    {
        public Sys_Appr_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string appr_nbr, string appr_location, string appr_type, int appr_seq, int appr_level, string appr_parallel, string appr_user, string appr_dept, DateTime appr_date_in, string appr_group, string appr_appr, string appr_now)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Appr_Mstr");
            strSql.Append(" where appr_nbr=@appr_nbr and appr_location=@appr_location and appr_type=@appr_type and appr_seq=@appr_seq and appr_level=@appr_level and appr_parallel=@appr_parallel and appr_user=@appr_user and appr_dept=@appr_dept and appr_date_in=@appr_date_in and appr_group=@appr_group and appr_appr=@appr_appr and appr_now=@appr_now ");
            SqlParameter[] parameters = {
					new SqlParameter("@appr_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appr_location", SqlDbType.VarChar,20),
					new SqlParameter("@appr_type", SqlDbType.VarChar,20),
					new SqlParameter("@appr_seq", SqlDbType.Int),
					new SqlParameter("@appr_level", SqlDbType.Int),
					new SqlParameter("@appr_parallel", SqlDbType.Char,1),
					new SqlParameter("@appr_user", SqlDbType.VarChar,30),
					new SqlParameter("@appr_dept", SqlDbType.VarChar,30),
					new SqlParameter("@appr_date_in", SqlDbType.DateTime),
					new SqlParameter("@appr_group", SqlDbType.VarChar,20),
					new SqlParameter("@appr_appr", SqlDbType.Char,1),
					new SqlParameter("@appr_now", SqlDbType.Char,1)			};
            parameters[0].Value = appr_nbr;
            parameters[1].Value = appr_location;
            parameters[2].Value = appr_type;
            parameters[3].Value = appr_seq;
            parameters[4].Value = appr_level;
            parameters[5].Value = appr_parallel;
            parameters[6].Value = appr_user;
            parameters[7].Value = appr_dept;
            parameters[8].Value = appr_date_in;
            parameters[9].Value = appr_group;
            parameters[10].Value = appr_appr;
            parameters[11].Value = appr_now;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Appr_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Appr_Mstr(");
            strSql.Append("appr_nbr,appr_location,appr_type,appr_seq,appr_level,appr_parallel,appr_user,appr_dept,appr_date_in,appr_group,appr_appr,appr_now)");
            strSql.Append(" values (");
            strSql.Append("@appr_nbr,@appr_location,@appr_type,@appr_seq,@appr_level,@appr_parallel,@appr_user,@appr_dept,@appr_date_in,@appr_group,@appr_appr,@appr_now)");
            SqlParameter[] parameters = {
					new SqlParameter("@appr_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appr_location", SqlDbType.VarChar,20),
					new SqlParameter("@appr_type", SqlDbType.VarChar,20),
					new SqlParameter("@appr_seq", SqlDbType.Int),
					new SqlParameter("@appr_level", SqlDbType.Int),
					new SqlParameter("@appr_parallel", SqlDbType.Char,1),
					new SqlParameter("@appr_user", SqlDbType.VarChar,30),
					new SqlParameter("@appr_dept", SqlDbType.VarChar,30),
					new SqlParameter("@appr_date_in", SqlDbType.DateTime),
					new SqlParameter("@appr_group", SqlDbType.VarChar,20),
					new SqlParameter("@appr_appr", SqlDbType.Char,1),
					new SqlParameter("@appr_now", SqlDbType.Char,1)};
            parameters[0].Value = model.appr_nbr;
            parameters[1].Value = model.appr_location;
            parameters[2].Value = model.appr_type;
            parameters[3].Value = model.appr_seq;
            parameters[4].Value = model.appr_level;
            parameters[5].Value = model.appr_parallel;
            parameters[6].Value = model.appr_user;
            parameters[7].Value = model.appr_dept;
            parameters[8].Value = model.appr_date_in;
            parameters[9].Value = model.appr_group;
            parameters[10].Value = model.appr_appr;
            parameters[11].Value = model.appr_now;

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
        public bool Update(Workflow.Model.Sys_Appr_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Appr_Mstr set ");
            strSql.Append("appr_nbr=@appr_nbr,");
            strSql.Append("appr_location=@appr_location,");
            strSql.Append("appr_type=@appr_type,");
            strSql.Append("appr_seq=@appr_seq,");
            strSql.Append("appr_level=@appr_level,");
            strSql.Append("appr_parallel=@appr_parallel,");
            strSql.Append("appr_user=@appr_user,");
            strSql.Append("appr_dept=@appr_dept,");
            strSql.Append("appr_date_in=@appr_date_in,");
            strSql.Append("appr_group=@appr_group,");
            strSql.Append("appr_appr=@appr_appr,");
            strSql.Append("appr_now=@appr_now");
            strSql.Append(" where appr_nbr=@appr_nbr and appr_location=@appr_location and appr_type=@appr_type and appr_seq=@appr_seq and appr_level=@appr_level and appr_parallel=@appr_parallel and appr_user=@appr_user and appr_dept=@appr_dept and appr_date_in=@appr_date_in and appr_group=@appr_group and appr_appr=@appr_appr and appr_now=@appr_now ");
            SqlParameter[] parameters = {
					new SqlParameter("@appr_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appr_location", SqlDbType.VarChar,20),
					new SqlParameter("@appr_type", SqlDbType.VarChar,20),
					new SqlParameter("@appr_seq", SqlDbType.Int),
					new SqlParameter("@appr_level", SqlDbType.Int),
					new SqlParameter("@appr_parallel", SqlDbType.Char,1),
					new SqlParameter("@appr_user", SqlDbType.VarChar,30),
					new SqlParameter("@appr_dept", SqlDbType.VarChar,30),
					new SqlParameter("@appr_date_in", SqlDbType.DateTime),
					new SqlParameter("@appr_group", SqlDbType.VarChar,20),
					new SqlParameter("@appr_appr", SqlDbType.Char,1),
					new SqlParameter("@appr_now", SqlDbType.Char,1)};
            parameters[0].Value = model.appr_nbr;
            parameters[1].Value = model.appr_location;
            parameters[2].Value = model.appr_type;
            parameters[3].Value = model.appr_seq;
            parameters[4].Value = model.appr_level;
            parameters[5].Value = model.appr_parallel;
            parameters[6].Value = model.appr_user;
            parameters[7].Value = model.appr_dept;
            parameters[8].Value = model.appr_date_in;
            parameters[9].Value = model.appr_group;
            parameters[10].Value = model.appr_appr;
            parameters[11].Value = model.appr_now;

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
        public bool Delete(string appr_nbr,int appr_seq, string appr_appr, string appr_now)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Appr_Mstr ");
            strSql.Append(" where appr_nbr=@appr_nbr and appr_seq=@appr_seq and appr_appr=@appr_appr and appr_now=@appr_now ");
            SqlParameter[] parameters = {
					new SqlParameter("@appr_nbr", SqlDbType.VarChar,20),
					
					new SqlParameter("@appr_seq", SqlDbType.Int),

					new SqlParameter("@appr_appr", SqlDbType.Char,1),
					new SqlParameter("@appr_now", SqlDbType.Char,1)			};
            parameters[0].Value = appr_nbr;
          
            parameters[1].Value = appr_seq;
           
            parameters[2].Value = appr_appr;
            parameters[3].Value = appr_now;

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

        public bool Delete(string appr_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Appr_Mstr ");
            strSql.Append(" where appr_nbr=@appr_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@appr_nbr", SqlDbType.VarChar,20)	};
            parameters[0].Value = appr_nbr;
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
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Sys_Appr_Mstr_Model GetModel(string appr_nbr, string appr_location, string appr_type, int appr_seq, int appr_level, string appr_parallel, string appr_user, string appr_dept, DateTime appr_date_in, string appr_group, string appr_appr, string appr_now)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 appr_nbr,appr_location,appr_type,appr_seq,appr_level,appr_parallel,appr_user,appr_dept,appr_date_in,appr_group,appr_appr,appr_now from Sys_Appr_Mstr ");
            strSql.Append(" where appr_nbr=@appr_nbr and appr_location=@appr_location and appr_type=@appr_type and appr_seq=@appr_seq and appr_level=@appr_level and appr_parallel=@appr_parallel and appr_user=@appr_user and appr_dept=@appr_dept and appr_date_in=@appr_date_in and appr_group=@appr_group and appr_appr=@appr_appr and appr_now=@appr_now ");
            SqlParameter[] parameters = {
					new SqlParameter("@appr_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appr_location", SqlDbType.VarChar,20),
					new SqlParameter("@appr_type", SqlDbType.VarChar,20),
					new SqlParameter("@appr_seq", SqlDbType.Int),
					new SqlParameter("@appr_level", SqlDbType.Int),
					new SqlParameter("@appr_parallel", SqlDbType.Char,1),
					new SqlParameter("@appr_user", SqlDbType.VarChar,30),
					new SqlParameter("@appr_dept", SqlDbType.VarChar,30),
					new SqlParameter("@appr_date_in", SqlDbType.DateTime),
					new SqlParameter("@appr_group", SqlDbType.VarChar,20),
					new SqlParameter("@appr_appr", SqlDbType.Char,1),
					new SqlParameter("@appr_now", SqlDbType.Char,1)			};
            parameters[0].Value = appr_nbr;
            parameters[1].Value = appr_location;
            parameters[2].Value = appr_type;
            parameters[3].Value = appr_seq;
            parameters[4].Value = appr_level;
            parameters[5].Value = appr_parallel;
            parameters[6].Value = appr_user;
            parameters[7].Value = appr_dept;
            parameters[8].Value = appr_date_in;
            parameters[9].Value = appr_group;
            parameters[10].Value = appr_appr;
            parameters[11].Value = appr_now;

            Workflow.Model.Sys_Appr_Mstr_Model model = new Workflow.Model.Sys_Appr_Mstr_Model();
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
        public Workflow.Model.Sys_Appr_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Appr_Mstr_Model model = new Workflow.Model.Sys_Appr_Mstr_Model();
            if (row != null)
            {
                if (row["appr_nbr"] != null)
                {
                    model.appr_nbr = row["appr_nbr"].ToString();
                }
                if (row["appr_location"] != null)
                {
                    model.appr_location = row["appr_location"].ToString();
                }
                if (row["appr_type"] != null)
                {
                    model.appr_type = row["appr_type"].ToString();
                }
                if (row["appr_seq"] != null && row["appr_seq"].ToString() != "")
                {
                    model.appr_seq = int.Parse(row["appr_seq"].ToString());
                }
                if (row["appr_level"] != null && row["appr_level"].ToString() != "")
                {
                    model.appr_level = int.Parse(row["appr_level"].ToString());
                }
                if (row["appr_parallel"] != null)
                {
                    model.appr_parallel = row["appr_parallel"].ToString();
                }
                if (row["appr_user"] != null)
                {
                    model.appr_user = row["appr_user"].ToString();
                }
                if (row["appr_dept"] != null)
                {
                    model.appr_dept = row["appr_dept"].ToString();
                }
                if (row["appr_date_in"] != null && row["appr_date_in"].ToString() != "")
                {
                    model.appr_date_in = DateTime.Parse(row["appr_date_in"].ToString());
                }
                if (row["appr_group"] != null)
                {
                    model.appr_group = row["appr_group"].ToString();
                }
                if (row["appr_appr"] != null)
                {
                    model.appr_appr = row["appr_appr"].ToString();
                }
                if (row["appr_now"] != null)
                {
                    model.appr_now = row["appr_now"].ToString();
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
            strSql.Append("select appr_nbr,appr_location,appr_type,appr_seq,appr_level,appr_parallel,appr_user,appr_dept,appr_date_in,appr_group,appr_appr,appr_now ");
            strSql.Append(" FROM Sys_Appr_Mstr ");
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
            strSql.Append(" appr_nbr,appr_location,appr_type,appr_seq,appr_level,appr_parallel,appr_user,appr_dept,appr_date_in,appr_group,appr_appr,appr_now ");
            strSql.Append(" FROM Sys_Appr_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Appr_Mstr ");
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
                strSql.Append("order by T.appr_now desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Appr_Mstr T ");
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
            parameters[0].Value = "Sys_Appr_Mstr";
            parameters[1].Value = "appr_now";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool UpdateApprNow_TOU(string appr_nbr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Appr_Mstr set ");
            strSql.Append("appr_now='U'");
            strSql.Append(" where appr_nbr like '"+appr_nbr.Trim()+"-%'");
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
        public bool UpdateApprNow_TOY(string appr_nbr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Appr_Mstr set ");
            strSql.Append("appr_now='Y'");
            strSql.Append(" where appr_nbr like '" + appr_nbr.Trim() + "-%'");
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
        #endregion  ExtensionMethod
    }
}

