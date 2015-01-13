using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;

namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Entrust_Mstr_Model
    /// </summary>
    public partial class Sys_Entrust_MstrDAL
    {
        public Sys_Entrust_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("entrust_id", "Sys_Entrust_Mstr");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int entrust_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Entrust_Mstr");
            strSql.Append(" where entrust_id=@entrust_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@entrust_id", SqlDbType.Int)			};
            parameters[0].Value = entrust_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Entrust_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Entrust_Mstr(");
            strSql.Append("entrust_type,entrust_by,entrust_to,entrust_location,entrust_begin,entrust_end,entrust_date,entrust_status,entrust_creater)");
            strSql.Append(" values (");
            strSql.Append("@entrust_type,@entrust_by,@entrust_to,@entrust_location,@entrust_begin,@entrust_end,@entrust_date,@entrust_status,@entrust_creater)");
            SqlParameter[] parameters = {
					new SqlParameter("@entrust_type", SqlDbType.VarChar,20),
					new SqlParameter("@entrust_by", SqlDbType.VarChar,50),
					new SqlParameter("@entrust_to", SqlDbType.VarChar,50),
					new SqlParameter("@entrust_location", SqlDbType.VarChar,20),
					new SqlParameter("@entrust_begin", SqlDbType.DateTime),
					new SqlParameter("@entrust_end", SqlDbType.DateTime),
					new SqlParameter("@entrust_date", SqlDbType.DateTime),
					new SqlParameter("@entrust_status", SqlDbType.Char,1),
                    new SqlParameter("@entrust_creater", SqlDbType.VarChar,50)                };
            parameters[0].Value = model.entrust_type;
            parameters[1].Value = model.entrust_by;
            parameters[2].Value = model.entrust_to;
            parameters[3].Value = model.entrust_location;
            parameters[4].Value = model.entrust_begin;
            parameters[5].Value = model.entrust_end;
            parameters[6].Value = model.entrust_date;
            parameters[7].Value = model.entrust_status;
            parameters[8].Value = model.Entrust_creater;

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
        public bool Update(Workflow.Model.Sys_Entrust_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Entrust_Mstr set ");
            strSql.Append("entrust_type=@entrust_type,");
            strSql.Append("entrust_by=@entrust_by,");
            strSql.Append("entrust_to=@entrust_to,");
            strSql.Append("entrust_location=@entrust_location,");
            strSql.Append("entrust_begin=@entrust_begin,");
            strSql.Append("entrust_end=@entrust_end,");
            strSql.Append("entrust_date=@entrust_date,");
            strSql.Append("entrust_status=@entrust_status");
            strSql.Append("entrust_creater=@entrust_creater");
            strSql.Append(" where entrust_id=@entrust_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@entrust_type", SqlDbType.VarChar,20),
					new SqlParameter("@entrust_by", SqlDbType.VarChar,50),
					new SqlParameter("@entrust_to", SqlDbType.VarChar,50),
					new SqlParameter("@entrust_location", SqlDbType.VarChar,20),
					new SqlParameter("@entrust_begin", SqlDbType.DateTime),
					new SqlParameter("@entrust_end", SqlDbType.DateTime),
					new SqlParameter("@entrust_date", SqlDbType.DateTime),
					new SqlParameter("@entrust_status", SqlDbType.Char,1),
					new SqlParameter("@entrust_id", SqlDbType.Int),
                    new SqlParameter("@entrust_creater", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = model.entrust_type;
            parameters[1].Value = model.entrust_by;
            parameters[2].Value = model.entrust_to;
            parameters[3].Value = model.entrust_location;
            parameters[4].Value = model.entrust_begin;
            parameters[5].Value = model.entrust_end;
            parameters[6].Value = model.entrust_date;
            parameters[7].Value = model.entrust_status;
            parameters[8].Value = model.entrust_id;
            parameters[9].Value = model.Entrust_creater;

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
        public bool Delete(int entrust_id,string entrust_creater)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Entrust_Mstr set entrust_status='N',entrust_date=getdate(),entrust_creater=@entrust_creater ");
            strSql.Append(" where entrust_id=@entrust_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@entrust_id", SqlDbType.Int),
                    new SqlParameter("@entrust_creater", SqlDbType.VarChar,50)
                                        };
            parameters[0].Value = entrust_id;
            parameters[1].Value = entrust_creater;

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
        public bool DeleteList(string entrust_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Entrust_Mstr ");
            strSql.Append(" where entrust_id in (" + entrust_idlist + ")  ");
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
        public Workflow.Model.Sys_Entrust_Mstr_Model GetModel(int entrust_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 entrust_id,entrust_type,entrust_by,entrust_to,entrust_location,entrust_begin,entrust_end,entrust_date,entrust_status,entrust_creater from Sys_Entrust_Mstr ");
            strSql.Append(" where entrust_id=@entrust_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@entrust_id", SqlDbType.Int)			};
            parameters[0].Value = entrust_id;

            Workflow.Model.Sys_Entrust_Mstr_Model model = new Workflow.Model.Sys_Entrust_Mstr_Model();
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
        public Workflow.Model.Sys_Entrust_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Entrust_Mstr_Model model = new Workflow.Model.Sys_Entrust_Mstr_Model();
            if (row != null)
            {
                if (row["entrust_id"] != null && row["entrust_id"].ToString() != "")
                {
                    model.entrust_id = int.Parse(row["entrust_id"].ToString());
                }
                if (row["entrust_type"] != null)
                {
                    model.entrust_type = row["entrust_type"].ToString();
                }
                if (row["entrust_by"] != null)
                {
                    model.entrust_by = row["entrust_by"].ToString();
                }
                if (row["entrust_to"] != null)
                {
                    model.entrust_to = row["entrust_to"].ToString();
                }
                if (row["entrust_location"] != null)
                {
                    model.entrust_location = row["entrust_location"].ToString();
                }
                if (row["entrust_begin"] != null && row["entrust_begin"].ToString() != "")
                {
                    model.entrust_begin = DateTime.Parse(row["entrust_begin"].ToString());
                }
                if (row["entrust_end"] != null && row["entrust_end"].ToString() != "")
                {
                    model.entrust_end = DateTime.Parse(row["entrust_end"].ToString());
                }
                if (row["entrust_date"] != null && row["entrust_date"].ToString() != "")
                {
                    model.entrust_date = DateTime.Parse(row["entrust_date"].ToString());
                }
                if (row["entrust_status"] != null)
                {
                    model.entrust_status = row["entrust_status"].ToString();
                }
                if (row["entrust_creater"] != null)
                {
                    model.entrust_status = row["entrust_creater"].ToString();
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
            strSql.Append("select entrust_id,entrust_type,entrust_by,entrust_to,entrust_location,entrust_begin,entrust_end,entrust_date,entrust_status,entrust_creater ");
            strSql.Append(" FROM Sys_Entrust_Mstr ");
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
            strSql.Append(" entrust_id,entrust_type,entrust_by,entrust_to,entrust_location,entrust_begin,entrust_end,entrust_date,entrust_status,entrust_creater ");
            strSql.Append(" FROM Sys_Entrust_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Entrust_Mstr ");
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
                strSql.Append("order by T.entrust_id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Entrust_Mstr T ");
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
            parameters[0].Value = "Sys_Entrust_Mstr";
            parameters[1].Value = "entrust_id";
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

