using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Flow_Config_Model
    /// </summary>
    public partial class Sys_Flow_ConfigDAL
    {
        public Sys_Flow_ConfigDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string config_type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Flow_Config");
            strSql.Append(" where config_type=@config_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@config_type", SqlDbType.VarChar,20)			};
            parameters[0].Value = config_type;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Flow_Config_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Flow_Config(");
            strSql.Append("config_type,config_prefix,config_length,config_seq,config_date,config_title,config_title_cn)");
            strSql.Append(" values (");
            strSql.Append("@config_type,@config_prefix,@config_length,@config_seq,@config_date,@config_title,@config_title_cn)");
            SqlParameter[] parameters = {
					new SqlParameter("@config_type", SqlDbType.VarChar,20),
					new SqlParameter("@config_prefix", SqlDbType.VarChar,20),
					new SqlParameter("@config_length", SqlDbType.Int),
					new SqlParameter("@config_seq", SqlDbType.Int),
					new SqlParameter("@config_date", SqlDbType.DateTime),
					new SqlParameter("@config_title", SqlDbType.VarChar,100),
					new SqlParameter("@config_title_cn", SqlDbType.VarChar,100)};
            parameters[0].Value = model.config_type;
            parameters[1].Value = model.config_prefix;
            parameters[2].Value = model.config_length;
            parameters[3].Value = model.config_seq;
            parameters[4].Value = model.config_date;
            parameters[5].Value = model.config_title;
            parameters[6].Value = model.config_title_cn;

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
        public bool Update(Workflow.Model.Sys_Flow_Config_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Flow_Config set ");
            strSql.Append("config_prefix=@config_prefix,");
            strSql.Append("config_length=@config_length,");
            strSql.Append("config_seq=@config_seq,");
            strSql.Append("config_date=@config_date,");
            strSql.Append("config_title=@config_title,");
            strSql.Append("config_title_cn=@config_title_cn");
            strSql.Append(" where config_type=@config_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@config_prefix", SqlDbType.VarChar,20),
					new SqlParameter("@config_length", SqlDbType.Int),
					new SqlParameter("@config_seq", SqlDbType.Int),
					new SqlParameter("@config_date", SqlDbType.DateTime),
					new SqlParameter("@config_title", SqlDbType.VarChar,100),
					new SqlParameter("@config_title_cn", SqlDbType.VarChar,100),
					new SqlParameter("@config_type", SqlDbType.VarChar,20)};
            parameters[0].Value = model.config_prefix;
            parameters[1].Value = model.config_length;
            parameters[2].Value = model.config_seq;
            parameters[3].Value = model.config_date;
            parameters[4].Value = model.config_title;
            parameters[5].Value = model.config_title_cn;
            parameters[6].Value = model.config_type;

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
        public bool Delete(string config_type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Flow_Config ");
            strSql.Append(" where config_type=@config_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@config_type", SqlDbType.VarChar,20)			};
            parameters[0].Value = config_type;

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
        public bool DeleteList(string config_typelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Flow_Config ");
            strSql.Append(" where config_type in (" + config_typelist + ")  ");
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
        public Workflow.Model.Sys_Flow_Config_Model GetModel(string config_type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 config_type,config_prefix,config_length,config_seq,config_date,config_title,config_title_cn from Sys_Flow_Config ");
            strSql.Append(" where config_type=@config_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@config_type", SqlDbType.VarChar,20)			};
            parameters[0].Value = config_type;

            Workflow.Model.Sys_Flow_Config_Model model = new Workflow.Model.Sys_Flow_Config_Model();
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
        public Workflow.Model.Sys_Flow_Config_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Flow_Config_Model model = new Workflow.Model.Sys_Flow_Config_Model();
            if (row != null)
            {
                if (row["config_type"] != null)
                {
                    model.config_type = row["config_type"].ToString();
                }
                if (row["config_prefix"] != null)
                {
                    model.config_prefix = row["config_prefix"].ToString();
                }
                if (row["config_length"] != null && row["config_length"].ToString() != "")
                {
                    model.config_length = int.Parse(row["config_length"].ToString());
                }
                if (row["config_seq"] != null && row["config_seq"].ToString() != "")
                {
                    model.config_seq = int.Parse(row["config_seq"].ToString());
                }
                if (row["config_date"] != null && row["config_date"].ToString() != "")
                {
                    model.config_date = DateTime.Parse(row["config_date"].ToString());
                }
                if (row["config_title"] != null)
                {
                    model.config_title = row["config_title"].ToString();
                }
                if (row["config_title_cn"] != null)
                {
                    model.config_title_cn = row["config_title_cn"].ToString();
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
            strSql.Append("select distinct config_type,config_prefix,config_length,config_seq,config_date,config_title,config_title_cn ");
            strSql.Append(" FROM Sys_Flow_Config ");
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
            strSql.Append(" config_type,config_prefix,config_length,config_seq,config_date,config_title,config_title_cn ");
            strSql.Append(" FROM Sys_Flow_Config ");
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
            strSql.Append("select count(1) FROM Sys_Flow_Config ");
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
                strSql.Append("order by T.config_type desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Flow_Config T ");
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
            parameters[0].Value = "Sys_Flow_Config";
            parameters[1].Value = "config_type";
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

