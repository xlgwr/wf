using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_MIS_Type_Model
    /// </summary>
    public partial class Cus_MIS_TypeDAL
    {
        public Cus_MIS_TypeDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string mis_type_code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_MIS_Type");
            strSql.Append(" where mis_type_code=@mis_type_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@mis_type_code", SqlDbType.VarChar,20)			};
            parameters[0].Value = mis_type_code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_MIS_Type_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_MIS_Type(");
            strSql.Append("mis_type_code,mis_type_value,mis_type_value_cn,mis_type_level,mis_type_order)");
            strSql.Append(" values (");
            strSql.Append("@mis_type_code,@mis_type_value,@mis_type_value_cn,@mis_type_level,@mis_type_order)");
            SqlParameter[] parameters = {
					new SqlParameter("@mis_type_code", SqlDbType.VarChar,20),
					new SqlParameter("@mis_type_value", SqlDbType.VarChar,50),
					new SqlParameter("@mis_type_value_cn", SqlDbType.VarChar,50),
					new SqlParameter("@mis_type_level", SqlDbType.Int),
					new SqlParameter("@mis_type_order", SqlDbType.Int)};
            parameters[0].Value = model.mis_type_code;
            parameters[1].Value = model.mis_type_value;
            parameters[2].Value = model.mis_type_value_cn;
            parameters[3].Value = model.mis_type_level;
            parameters[4].Value = model.mis_type_order;

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
        public bool Update(Workflow.Model.Cus_MIS_Type_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_MIS_Type set ");
            strSql.Append("mis_type_value=@mis_type_value,");
            strSql.Append("mis_type_value_cn=@mis_type_value_cn,");
            strSql.Append("mis_type_level=@mis_type_level,");
            strSql.Append("mis_type_order=@mis_type_order");
            strSql.Append(" where mis_type_code=@mis_type_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@mis_type_value", SqlDbType.VarChar,50),
					new SqlParameter("@mis_type_value_cn", SqlDbType.VarChar,50),
					new SqlParameter("@mis_type_level", SqlDbType.Int),
					new SqlParameter("@mis_type_order", SqlDbType.Int),
					new SqlParameter("@mis_type_code", SqlDbType.VarChar,20)};
            parameters[0].Value = model.mis_type_value;
            parameters[1].Value = model.mis_type_value_cn;
            parameters[2].Value = model.mis_type_level;
            parameters[3].Value = model.mis_type_order;
            parameters[4].Value = model.mis_type_code;

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
        public bool Delete(string mis_type_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_MIS_Type ");
            strSql.Append(" where mis_type_code=@mis_type_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@mis_type_code", SqlDbType.VarChar,20)			};
            parameters[0].Value = mis_type_code;

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
        public bool DeleteList(string mis_type_codelist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_MIS_Type ");
            strSql.Append(" where mis_type_code in (" + mis_type_codelist + ")  ");
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
        public Workflow.Model.Cus_MIS_Type_Model GetModel(string mis_type_code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 mis_type_code,mis_type_value,mis_type_value_cn,mis_type_level,mis_type_order from Cus_MIS_Type ");
            strSql.Append(" where mis_type_code=@mis_type_code ");
            SqlParameter[] parameters = {
					new SqlParameter("@mis_type_code", SqlDbType.VarChar,20)			};
            parameters[0].Value = mis_type_code;

            Workflow.Model.Cus_MIS_Type_Model model = new Workflow.Model.Cus_MIS_Type_Model();
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
        public Workflow.Model.Cus_MIS_Type_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_MIS_Type_Model model = new Workflow.Model.Cus_MIS_Type_Model();
            if (row != null)
            {
                if (row["mis_type_code"] != null)
                {
                    model.mis_type_code = row["mis_type_code"].ToString();
                }
                if (row["mis_type_value"] != null)
                {
                    model.mis_type_value = row["mis_type_value"].ToString();
                }
                if (row["mis_type_value_cn"] != null)
                {
                    model.mis_type_value_cn = row["mis_type_value_cn"].ToString();
                }
                if (row["mis_type_level"] != null && row["mis_type_level"].ToString() != "")
                {
                    model.mis_type_level = int.Parse(row["mis_type_level"].ToString());
                }
                if (row["mis_type_order"] != null && row["mis_type_order"].ToString() != "")
                {
                    model.mis_type_order = int.Parse(row["mis_type_order"].ToString());
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
            strSql.Append("select mis_type_code,mis_type_value,mis_type_value_cn,mis_type_level,mis_type_order ");
            strSql.Append(" FROM Cus_MIS_Type ");
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
            strSql.Append(" mis_type_code,mis_type_value,mis_type_value_cn,mis_type_level,mis_type_order ");
            strSql.Append(" FROM Cus_MIS_Type ");
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
            strSql.Append("select count(1) FROM Cus_MIS_Type ");
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
                strSql.Append("order by T.mis_type_code desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_MIS_Type T ");
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
            parameters[0].Value = "Cus_MIS_Type";
            parameters[1].Value = "mis_type_code";
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

