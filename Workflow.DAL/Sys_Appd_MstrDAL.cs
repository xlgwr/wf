using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Appd_Mstr_Model
    /// </summary>
    public partial class Sys_Appd_MstrDAL
    {
        public Sys_Appd_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string appd_nbr, string appd_location, string appd_type, string appd_user, string appd_mandator, string appd_dept, int appd_seq, int appd_level, string appd_action, int appd_line, string appd_remark, DateTime appd_date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Appd_Mstr");
            strSql.Append(" where appd_nbr=@appd_nbr and appd_location=@appd_location and appd_type=@appd_type and appd_user=@appd_user and appd_mandator=@appd_mandator and appd_dept=@appd_dept and appd_seq=@appd_seq and appd_level=@appd_level and appd_action=@appd_action and appd_line=@appd_line and appd_remark=@appd_remark and appd_date=@appd_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@appd_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appd_location", SqlDbType.VarChar,20),
					new SqlParameter("@appd_type", SqlDbType.VarChar,10),
					new SqlParameter("@appd_user", SqlDbType.VarChar,50),
					new SqlParameter("@appd_mandator", SqlDbType.VarChar,50),
					new SqlParameter("@appd_dept", SqlDbType.VarChar,20),
					new SqlParameter("@appd_seq", SqlDbType.Int),
					new SqlParameter("@appd_level", SqlDbType.Int),
					new SqlParameter("@appd_action", SqlDbType.VarChar,20),
					new SqlParameter("@appd_line", SqlDbType.Int),
					new SqlParameter("@appd_remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@appd_date", SqlDbType.DateTime)			};
            parameters[0].Value = appd_nbr;
            parameters[1].Value = appd_location;
            parameters[2].Value = appd_type;
            parameters[3].Value = appd_user;
            parameters[4].Value = appd_mandator;
            parameters[5].Value = appd_dept;
            parameters[6].Value = appd_seq;
            parameters[7].Value = appd_level;
            parameters[8].Value = appd_action;
            parameters[9].Value = appd_line;
            parameters[10].Value = appd_remark;
            parameters[11].Value = appd_date;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Appd_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Appd_Mstr(");
            strSql.Append("appd_nbr,appd_location,appd_type,appd_user,appd_mandator,appd_dept,appd_seq,appd_level,appd_action,appd_line,appd_remark,appd_date,appd_guid,appd_parallel_flag)");
            strSql.Append(" values (");
            strSql.Append("@appd_nbr,@appd_location,@appd_type,@appd_user,@appd_mandator,@appd_dept,@appd_seq,@appd_level,@appd_action,@appd_line,@appd_remark,@appd_date,@appd_guid,@appd_parallel_flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@appd_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appd_location", SqlDbType.VarChar,20),
					new SqlParameter("@appd_type", SqlDbType.VarChar,10),
					new SqlParameter("@appd_user", SqlDbType.VarChar,50),
					new SqlParameter("@appd_mandator", SqlDbType.VarChar,50),
					new SqlParameter("@appd_dept", SqlDbType.VarChar,20),
					new SqlParameter("@appd_seq", SqlDbType.Int),
					new SqlParameter("@appd_level", SqlDbType.Int),
					new SqlParameter("@appd_action", SqlDbType.VarChar,20),
					new SqlParameter("@appd_line", SqlDbType.Int),
					new SqlParameter("@appd_remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@appd_date", SqlDbType.DateTime),
                                        new SqlParameter("@appd_guid", SqlDbType.VarChar,50),
                                        new SqlParameter("@appd_parallel_flag", SqlDbType.VarChar,10)
                                        };
            parameters[0].Value = model.appd_nbr;
            parameters[1].Value = model.appd_location;
            parameters[2].Value = model.appd_type;
            parameters[3].Value = model.appd_user;
            parameters[4].Value = model.appd_mandator;
            parameters[5].Value = model.appd_dept;
            parameters[6].Value = model.appd_seq;
            parameters[7].Value = model.appd_level;
            parameters[8].Value = model.appd_action;
            parameters[9].Value = model.appd_line;
            parameters[10].Value = model.appd_remark;
            parameters[11].Value = model.appd_date;
            parameters[12].Value = model.appd_guid;
            parameters[13].Value = model.appd_parallel_flag;

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
        public bool Update(Workflow.Model.Sys_Appd_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Appd_Mstr set ");
            strSql.Append("appd_nbr=@appd_nbr,");
            strSql.Append("appd_location=@appd_location,");
            strSql.Append("appd_type=@appd_type,");
            strSql.Append("appd_user=@appd_user,");
            strSql.Append("appd_mandator=@appd_mandator,");
            strSql.Append("appd_dept=@appd_dept,");
            strSql.Append("appd_seq=@appd_seq,");
            strSql.Append("appd_level=@appd_level,");
            strSql.Append("appd_action=@appd_action,");
            strSql.Append("appd_line=@appd_line,");
            strSql.Append("appd_remark=@appd_remark,");
            strSql.Append("appd_date=@appd_date");
            strSql.Append(" where appd_nbr=@appd_nbr and appd_location=@appd_location and appd_type=@appd_type and appd_user=@appd_user and appd_mandator=@appd_mandator and appd_dept=@appd_dept and appd_seq=@appd_seq and appd_level=@appd_level and appd_action=@appd_action and appd_line=@appd_line and appd_remark=@appd_remark and appd_date=@appd_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@appd_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appd_location", SqlDbType.VarChar,20),
					new SqlParameter("@appd_type", SqlDbType.VarChar,10),
					new SqlParameter("@appd_user", SqlDbType.VarChar,50),
					new SqlParameter("@appd_mandator", SqlDbType.VarChar,50),
					new SqlParameter("@appd_dept", SqlDbType.VarChar,20),
					new SqlParameter("@appd_seq", SqlDbType.Int),
					new SqlParameter("@appd_level", SqlDbType.Int),
					new SqlParameter("@appd_action", SqlDbType.VarChar,20),
					new SqlParameter("@appd_line", SqlDbType.Int),
					new SqlParameter("@appd_remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@appd_date", SqlDbType.DateTime)};
            parameters[0].Value = model.appd_nbr;
            parameters[1].Value = model.appd_location;
            parameters[2].Value = model.appd_type;
            parameters[3].Value = model.appd_user;
            parameters[4].Value = model.appd_mandator;
            parameters[5].Value = model.appd_dept;
            parameters[6].Value = model.appd_seq;
            parameters[7].Value = model.appd_level;
            parameters[8].Value = model.appd_action;
            parameters[9].Value = model.appd_line;
            parameters[10].Value = model.appd_remark;
            parameters[11].Value = model.appd_date;

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
        public bool Delete(string appd_nbr, string appd_location, string appd_type, string appd_user, string appd_mandator, string appd_dept, int appd_seq, int appd_level, string appd_action, int appd_line, string appd_remark, DateTime appd_date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Appd_Mstr ");
            strSql.Append(" where appd_nbr=@appd_nbr and appd_location=@appd_location and appd_type=@appd_type and appd_user=@appd_user and appd_mandator=@appd_mandator and appd_dept=@appd_dept and appd_seq=@appd_seq and appd_level=@appd_level and appd_action=@appd_action and appd_line=@appd_line and appd_remark=@appd_remark and appd_date=@appd_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@appd_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appd_location", SqlDbType.VarChar,20),
					new SqlParameter("@appd_type", SqlDbType.VarChar,10),
					new SqlParameter("@appd_user", SqlDbType.VarChar,50),
					new SqlParameter("@appd_mandator", SqlDbType.VarChar,50),
					new SqlParameter("@appd_dept", SqlDbType.VarChar,20),
					new SqlParameter("@appd_seq", SqlDbType.Int),
					new SqlParameter("@appd_level", SqlDbType.Int),
					new SqlParameter("@appd_action", SqlDbType.VarChar,20),
					new SqlParameter("@appd_line", SqlDbType.Int),
					new SqlParameter("@appd_remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@appd_date", SqlDbType.DateTime)			};
            parameters[0].Value = appd_nbr;
            parameters[1].Value = appd_location;
            parameters[2].Value = appd_type;
            parameters[3].Value = appd_user;
            parameters[4].Value = appd_mandator;
            parameters[5].Value = appd_dept;
            parameters[6].Value = appd_seq;
            parameters[7].Value = appd_level;
            parameters[8].Value = appd_action;
            parameters[9].Value = appd_line;
            parameters[10].Value = appd_remark;
            parameters[11].Value = appd_date;

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
        public Workflow.Model.Sys_Appd_Mstr_Model GetModel(string appd_nbr, string appd_location, string appd_type, string appd_user, string appd_mandator, string appd_dept, int appd_seq, int appd_level, string appd_action, int appd_line, string appd_remark, DateTime appd_date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 appd_nbr,appd_location,appd_type,appd_user,appd_mandator,appd_dept,appd_seq,appd_level,appd_action,appd_line,appd_remark,appd_date from Sys_Appd_Mstr ");
            strSql.Append(" where appd_nbr=@appd_nbr and appd_location=@appd_location and appd_type=@appd_type and appd_user=@appd_user and appd_mandator=@appd_mandator and appd_dept=@appd_dept and appd_seq=@appd_seq and appd_level=@appd_level and appd_action=@appd_action and appd_line=@appd_line and appd_remark=@appd_remark and appd_date=@appd_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@appd_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@appd_location", SqlDbType.VarChar,20),
					new SqlParameter("@appd_type", SqlDbType.VarChar,10),
					new SqlParameter("@appd_user", SqlDbType.VarChar,50),
					new SqlParameter("@appd_mandator", SqlDbType.VarChar,50),
					new SqlParameter("@appd_dept", SqlDbType.VarChar,20),
					new SqlParameter("@appd_seq", SqlDbType.Int),
					new SqlParameter("@appd_level", SqlDbType.Int),
					new SqlParameter("@appd_action", SqlDbType.VarChar,20),
					new SqlParameter("@appd_line", SqlDbType.Int),
					new SqlParameter("@appd_remark", SqlDbType.NVarChar,1000),
					new SqlParameter("@appd_date", SqlDbType.DateTime)			};
            parameters[0].Value = appd_nbr;
            parameters[1].Value = appd_location;
            parameters[2].Value = appd_type;
            parameters[3].Value = appd_user;
            parameters[4].Value = appd_mandator;
            parameters[5].Value = appd_dept;
            parameters[6].Value = appd_seq;
            parameters[7].Value = appd_level;
            parameters[8].Value = appd_action;
            parameters[9].Value = appd_line;
            parameters[10].Value = appd_remark;
            parameters[11].Value = appd_date;

            Workflow.Model.Sys_Appd_Mstr_Model model = new Workflow.Model.Sys_Appd_Mstr_Model();
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
        public Workflow.Model.Sys_Appd_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Appd_Mstr_Model model = new Workflow.Model.Sys_Appd_Mstr_Model();
            if (row != null)
            {
                if (row["appd_nbr"] != null)
                {
                    model.appd_nbr = row["appd_nbr"].ToString();
                }
                if (row["appd_location"] != null)
                {
                    model.appd_location = row["appd_location"].ToString();
                }
                if (row["appd_type"] != null)
                {
                    model.appd_type = row["appd_type"].ToString();
                }
                if (row["appd_user"] != null)
                {
                    model.appd_user = row["appd_user"].ToString();
                }
                if (row["appd_mandator"] != null)
                {
                    model.appd_mandator = row["appd_mandator"].ToString();
                }
                if (row["appd_dept"] != null)
                {
                    model.appd_dept = row["appd_dept"].ToString();
                }
                if (row["appd_seq"] != null && row["appd_seq"].ToString() != "")
                {
                    model.appd_seq = int.Parse(row["appd_seq"].ToString());
                }
                if (row["appd_level"] != null && row["appd_level"].ToString() != "")
                {
                    model.appd_level = int.Parse(row["appd_level"].ToString());
                }
                if (row["appd_action"] != null)
                {
                    model.appd_action = row["appd_action"].ToString();
                }
                if (row["appd_line"] != null && row["appd_line"].ToString() != "")
                {
                    model.appd_line = int.Parse(row["appd_line"].ToString());
                }
                if (row["appd_remark"] != null)
                {
                    model.appd_remark = row["appd_remark"].ToString();
                }
                if (row["appd_date"] != null && row["appd_date"].ToString() != "")
                {
                    model.appd_date = DateTime.Parse(row["appd_date"].ToString());
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
            strSql.Append("select appd_nbr,appd_location,appd_type,appd_user,appd_mandator,appd_dept,appd_seq,appd_level,appd_action,appd_line,appd_remark,appd_date ");
            strSql.Append(" FROM Sys_Appd_Mstr ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSpecialList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select appd_nbr,appd_location,appd_type,appd_user,appd_mandator,appd_dept,appd_seq,appd_level,appd_action,appd_line,appd_remark,appd_date ");
            strSql.Append(" FROM Sys_Appd_Mstr A,Sys_Form_Mstr B where A.appd_guid = B.form_guid and " );
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            else
            {
                strSql.Append("1=1");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetPORevList(string strNbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select appd_nbr,appd_location,appd_type,appd_user,appd_mandator,appd_dept,appd_seq,appd_level,appd_action,appd_line,appd_remark,appd_date,B.hist_po_revision ");
            strSql.Append(" FROM Sys_Appd_Mstr A,Cus_PO_Mstr_Hist B where A.appd_guid = B.hist_po_guid and A.appd_nbr = B.hist_po_nbr and  A.appd_nbr =@nbr ");
            strSql.Append(" order by B.hist_po_revision,appd_date,appd_seq ");
            SqlParameter[] parameters = {
					new SqlParameter("@nbr", SqlDbType.VarChar,20)
                                         };
            parameters[0].Value = strNbr;
            return DbHelperSQL.Query(strSql.ToString(),parameters);
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
            strSql.Append(" appd_nbr,appd_location,appd_type,appd_user,appd_mandator,appd_dept,appd_seq,appd_level,appd_action,appd_line,appd_remark,appd_date ");
            strSql.Append(" FROM Sys_Appd_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Appd_Mstr ");
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
                strSql.Append("order by T.appd_date desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Appd_Mstr T ");
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
            parameters[0].Value = "Sys_Appd_Mstr";
            parameters[1].Value = "appd_date";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

