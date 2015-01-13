using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;//Please add references
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_MGT_Mstr_Model
    /// </summary>
    public partial class Cus_MGT_MstrDAL
    {
        public Cus_MGT_MstrDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int manage_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_MGT_Mstr");
            strSql.Append(" where manage_id=@manage_id");
            SqlParameter[] parameters = {
					new SqlParameter("@manage_id", SqlDbType.Int,4)
			};
            parameters[0].Value = manage_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Workflow.Model.Cus_MGT_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_MGT_Mstr(");
            strSql.Append("manage_location,manage_dept,manage_name,manage_title,manage_level,manage_cre_by,manage_cre_date,manage_lastmodify_by,manage_lastmodify_date,manage_status)");
            strSql.Append(" values (");
            strSql.Append("@manage_location,@manage_dept,@manage_name,@manage_title,@manage_level,@manage_cre_by,@manage_cre_date,@manage_lastmodify_by,@manage_lastmodify_date,@manage_status)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@manage_location", SqlDbType.VarChar,20),
					new SqlParameter("@manage_dept", SqlDbType.VarChar,50),
					new SqlParameter("@manage_name", SqlDbType.VarChar,50),
					new SqlParameter("@manage_title", SqlDbType.NVarChar,100),
					new SqlParameter("@manage_level", SqlDbType.Int,4),
					new SqlParameter("@manage_cre_by", SqlDbType.VarChar,50),
					new SqlParameter("@manage_cre_date", SqlDbType.DateTime),
					new SqlParameter("@manage_lastmodify_by", SqlDbType.VarChar,50),
					new SqlParameter("@manage_lastmodify_date", SqlDbType.DateTime),
					new SqlParameter("@manage_status", SqlDbType.Char,1)};
            parameters[0].Value = model.manage_location;
            parameters[1].Value = model.manage_dept;
            parameters[2].Value = model.manage_name;
            parameters[3].Value = model.manage_title;
            parameters[4].Value = model.manage_level;
            parameters[5].Value = model.manage_cre_by;
            parameters[6].Value = model.manage_cre_date;
            parameters[7].Value = model.manage_lastmodify_by;
            parameters[8].Value = model.manage_lastmodify_date;
            parameters[9].Value = model.manage_status;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_MGT_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_MGT_Mstr set ");
            strSql.Append("manage_location=@manage_location,");
            strSql.Append("manage_dept=@manage_dept,");
            strSql.Append("manage_name=@manage_name,");
            strSql.Append("manage_title=@manage_title,");
            strSql.Append("manage_level=@manage_level,");
            strSql.Append("manage_cre_by=@manage_cre_by,");
            strSql.Append("manage_cre_date=@manage_cre_date,");
            strSql.Append("manage_lastmodify_by=@manage_lastmodify_by,");
            strSql.Append("manage_lastmodify_date=@manage_lastmodify_date,");
            strSql.Append("manage_status=@manage_status");
            strSql.Append(" where manage_id=@manage_id");
            SqlParameter[] parameters = {
					new SqlParameter("@manage_location", SqlDbType.VarChar,20),
					new SqlParameter("@manage_dept", SqlDbType.VarChar,50),
					new SqlParameter("@manage_name", SqlDbType.VarChar,50),
					new SqlParameter("@manage_title", SqlDbType.NVarChar,100),
					new SqlParameter("@manage_level", SqlDbType.Int,4),
					new SqlParameter("@manage_cre_by", SqlDbType.VarChar,50),
					new SqlParameter("@manage_cre_date", SqlDbType.DateTime),
					new SqlParameter("@manage_lastmodify_by", SqlDbType.VarChar,50),
					new SqlParameter("@manage_lastmodify_date", SqlDbType.DateTime),
					new SqlParameter("@manage_status", SqlDbType.Char,1),
					new SqlParameter("@manage_id", SqlDbType.Int,4)};
            parameters[0].Value = model.manage_location;
            parameters[1].Value = model.manage_dept;
            parameters[2].Value = model.manage_name;
            parameters[3].Value = model.manage_title;
            parameters[4].Value = model.manage_level;
            parameters[5].Value = model.manage_cre_by;
            parameters[6].Value = model.manage_cre_date;
            parameters[7].Value = model.manage_lastmodify_by;
            parameters[8].Value = model.manage_lastmodify_date;
            parameters[9].Value = model.manage_status;
            parameters[10].Value = model.manage_id;

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
        public bool Delete(int manage_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_MGT_Mstr ");
            strSql.Append(" where manage_id=@manage_id");
            SqlParameter[] parameters = {
					new SqlParameter("@manage_id", SqlDbType.Int,4)
			};
            parameters[0].Value = manage_id;

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
        public bool DeleteList(string manage_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_MGT_Mstr ");
            strSql.Append(" where manage_id in (" + manage_idlist + ")  ");
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
        public Workflow.Model.Cus_MGT_Mstr_Model GetModel(int manage_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 manage_id,manage_location,manage_dept,manage_name,manage_title,manage_level,manage_cre_by,manage_cre_date,manage_lastmodify_by,manage_lastmodify_date,manage_status from Cus_MGT_Mstr ");
            strSql.Append(" where manage_id=@manage_id");
            SqlParameter[] parameters = {
					new SqlParameter("@manage_id", SqlDbType.Int,4)
			};
            parameters[0].Value = manage_id;

            Workflow.Model.Cus_MGT_Mstr_Model model = new Workflow.Model.Cus_MGT_Mstr_Model();
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
        public Workflow.Model.Cus_MGT_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_MGT_Mstr_Model model = new Workflow.Model.Cus_MGT_Mstr_Model();
            if (row != null)
            {
                if (row["manage_id"] != null && row["manage_id"].ToString() != "")
                {
                    model.manage_id = int.Parse(row["manage_id"].ToString());
                }
                if (row["manage_location"] != null)
                {
                    model.manage_location = row["manage_location"].ToString();
                }
                if (row["manage_dept"] != null)
                {
                    model.manage_dept = row["manage_dept"].ToString();
                }
                if (row["manage_name"] != null)
                {
                    model.manage_name = row["manage_name"].ToString();
                }
                if (row["manage_title"] != null)
                {
                    model.manage_title = row["manage_title"].ToString();
                }
                if (row["manage_level"] != null && row["manage_level"].ToString() != "")
                {
                    model.manage_level = int.Parse(row["manage_level"].ToString());
                }
                if (row["manage_cre_by"] != null)
                {
                    model.manage_cre_by = row["manage_cre_by"].ToString();
                }
                if (row["manage_cre_date"] != null && row["manage_cre_date"].ToString() != "")
                {
                    model.manage_cre_date = DateTime.Parse(row["manage_cre_date"].ToString());
                }
                if (row["manage_lastmodify_by"] != null)
                {
                    model.manage_lastmodify_by = row["manage_lastmodify_by"].ToString();
                }
                if (row["manage_lastmodify_date"] != null && row["manage_lastmodify_date"].ToString() != "")
                {
                    model.manage_lastmodify_date = DateTime.Parse(row["manage_lastmodify_date"].ToString());
                }
                if (row["manage_status"] != null)
                {
                    model.manage_status = row["manage_status"].ToString();
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
            strSql.Append("select manage_id,manage_location,manage_dept,manage_name,manage_title,manage_level,manage_cre_by,manage_cre_date,manage_lastmodify_by,manage_lastmodify_date,manage_status ");
            strSql.Append(" FROM Cus_MGT_Mstr ");
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
            strSql.Append(" manage_id,manage_location,manage_dept,manage_name,manage_title,manage_level,manage_cre_by,manage_cre_date,manage_lastmodify_by,manage_lastmodify_date,manage_status ");
            strSql.Append(" FROM Cus_MGT_Mstr ");
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
            strSql.Append("select count(1) FROM Cus_MGT_Mstr ");
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
                strSql.Append("order by T.manage_id desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_MGT_Mstr T ");
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
            parameters[0].Value = "Cus_MGT_Mstr";
            parameters[1].Value = "manage_id";
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

