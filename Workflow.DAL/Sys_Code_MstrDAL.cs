using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Workflow.DBUtility;

namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Code_MstrDAL
    /// </summary>
    public partial class Sys_Code_MstrDAL
    {
        public Sys_Code_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code_cmmt, string code_desc, string code_fldname, string code_user1, string code_user2, string code_value)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Code_Mstr");
            strSql.Append(" where code_cmmt=@code_cmmt and code_desc=@code_desc and code_fldname=@code_fldname and code_user1=@code_user1 and code_user2=@code_user2 and code_value=@code_value ");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_desc", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user1", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user2", SqlDbType.NVarChar,200),
					new SqlParameter("@code_value", SqlDbType.NVarChar,200)			};
            parameters[0].Value = code_cmmt;
            parameters[1].Value = code_desc;
            parameters[2].Value = code_fldname;
            parameters[3].Value = code_user1;
            parameters[4].Value = code_user2;
            parameters[5].Value = code_value;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string code_cmmt,string code_fldname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Code_Mstr");
            strSql.Append(" where code_cmmt=@code_cmmt and code_fldname=@code_fldname ");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200)		};
            parameters[0].Value = code_cmmt;
            parameters[1].Value = code_fldname;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Code_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Code_Mstr(");
            strSql.Append("code_cmmt,code_desc,code_fldname,code_user1,code_user2,code_value)");
            strSql.Append(" values (");
            strSql.Append("@code_cmmt,@code_desc,@code_fldname,@code_user1,@code_user2,@code_value)");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_desc", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user1", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user2", SqlDbType.NVarChar,200),
					new SqlParameter("@code_value", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.code_cmmt;
            parameters[1].Value = model.code_desc;
            parameters[2].Value = model.code_fldname;
            parameters[3].Value = model.code_user1;
            parameters[4].Value = model.code_user2;
            parameters[5].Value = model.code_value;

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
        public bool Update(Workflow.Model.Sys_Code_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Code_Mstr set ");
            strSql.Append("code_cmmt=@code_cmmt,");
            strSql.Append("code_desc=@code_desc,");
            strSql.Append("code_fldname=@code_fldname,");
            strSql.Append("code_user1=@code_user1,");
            strSql.Append("code_user2=@code_user2,");
            strSql.Append("code_value=@code_value");
            strSql.Append(" where code_cmmt=@code_cmmt and code_desc=@code_desc and code_fldname=@code_fldname and code_user1=@code_user1 and code_user2=@code_user2 and code_value=@code_value ");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_desc", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user1", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user2", SqlDbType.NVarChar,200),
					new SqlParameter("@code_value", SqlDbType.NVarChar,200)};
            parameters[0].Value = model.code_cmmt;
            parameters[1].Value = model.code_desc;
            parameters[2].Value = model.code_fldname;
            parameters[3].Value = model.code_user1;
            parameters[4].Value = model.code_user2;
            parameters[5].Value = model.code_value;

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
        public bool Delete(string code_cmmt, string code_desc, string code_fldname, string code_user1, string code_user2, string code_value)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Code_Mstr ");
            strSql.Append(" where code_cmmt=@code_cmmt and code_desc=@code_desc and code_fldname=@code_fldname and code_user1=@code_user1 and code_user2=@code_user2 and code_value=@code_value ");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_desc", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user1", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user2", SqlDbType.NVarChar,200),
					new SqlParameter("@code_value", SqlDbType.NVarChar,200)			};
            parameters[0].Value = code_cmmt;
            parameters[1].Value = code_desc;
            parameters[2].Value = code_fldname;
            parameters[3].Value = code_user1;
            parameters[4].Value = code_user2;
            parameters[5].Value = code_value;

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
        public Workflow.Model.Sys_Code_Mstr_Model GetModel(string code_cmmt, string code_desc, string code_fldname, string code_user1, string code_user2, string code_value)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 code_cmmt,code_desc,code_fldname,code_user1,code_user2,code_value from Sys_Code_Mstr ");
            strSql.Append(" where code_cmmt=@code_cmmt and code_desc=@code_desc and code_fldname=@code_fldname and code_user1=@code_user1 and code_user2=@code_user2 and code_value=@code_value ");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_desc", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user1", SqlDbType.NVarChar,200),
					new SqlParameter("@code_user2", SqlDbType.NVarChar,200),
					new SqlParameter("@code_value", SqlDbType.NVarChar,200)			};
            parameters[0].Value = code_cmmt;
            parameters[1].Value = code_desc;
            parameters[2].Value = code_fldname;
            parameters[3].Value = code_user1;
            parameters[4].Value = code_user2;
            parameters[5].Value = code_value;

            Workflow.Model.Sys_Code_Mstr_Model model = new Workflow.Model.Sys_Code_Mstr_Model();
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

        public Workflow.Model.Sys_Code_Mstr_Model GetModel(string code_cmmt, string code_fldname)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 code_cmmt,code_desc,code_fldname,code_user1,code_user2,code_value from Sys_Code_Mstr ");
            strSql.Append(" where code_cmmt=@code_cmmt and code_fldname=@code_fldname ");
            SqlParameter[] parameters = {
					new SqlParameter("@code_cmmt", SqlDbType.NVarChar,200),
					new SqlParameter("@code_fldname", SqlDbType.NVarChar,200)		};
            parameters[0].Value = code_cmmt;
            parameters[1].Value = code_fldname;
            Workflow.Model.Sys_Code_Mstr_Model model = new Workflow.Model.Sys_Code_Mstr_Model();
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
        public Workflow.Model.Sys_Code_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Code_Mstr_Model model = new Workflow.Model.Sys_Code_Mstr_Model();
            if (row != null)
            {
                if (row["code_cmmt"] != null)
                {
                    model.code_cmmt = row["code_cmmt"].ToString();
                }
                if (row["code_desc"] != null)
                {
                    model.code_desc = row["code_desc"].ToString();
                }
                if (row["code_fldname"] != null)
                {
                    model.code_fldname = row["code_fldname"].ToString();
                }
                if (row["code_user1"] != null)
                {
                    model.code_user1 = row["code_user1"].ToString();
                }
                if (row["code_user2"] != null)
                {
                    model.code_user2 = row["code_user2"].ToString();
                }
                if (row["code_value"] != null)
                {
                    model.code_value = row["code_value"].ToString();
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
            strSql.Append("select code_cmmt,code_desc,code_fldname,code_user1,code_user2,code_value ");
            strSql.Append(" FROM Sys_Code_Mstr ");
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
            strSql.Append(" code_cmmt,code_desc,code_fldname,code_user1,code_user2,code_value ");
            strSql.Append(" FROM Sys_Code_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Code_Mstr ");
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
                strSql.Append("order by T.code_value desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Code_Mstr T ");
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
                    new SqlParameter("@Name", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Sys_Code_Mstr";
            parameters[1].Value = "code_value";
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
