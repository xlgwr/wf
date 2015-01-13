using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;//Please add references
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_Job_Interview_Model
    /// </summary>
    public partial class Cus_Job_InterviewDAL
    {
        public Cus_Job_InterviewDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int interview_id, int interview_round, string interview_cv_guid, string interview_by, DateTime interview_date, DateTime interview_cre_date, string interview_cre_by)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_Job_Interview");
            strSql.Append(" where interview_id=@interview_id");
            SqlParameter[] parameters = {
					new SqlParameter("@interview_id", SqlDbType.Int,4)
			};
            parameters[0].Value = interview_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Workflow.Model.Cus_Job_Interview_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_Job_Interview(");
            strSql.Append("interview_round,interview_cv_guid,interview_by,interview_date,interview_cre_date,interview_cre_by,interview_type)");
            strSql.Append(" values (");
            strSql.Append("@interview_round,@interview_cv_guid,@interview_by,@interview_date,@interview_cre_date,@interview_cre_by,@interview_type)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@interview_round", SqlDbType.Int,4),
					new SqlParameter("@interview_cv_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@interview_by", SqlDbType.NVarChar,50),
					new SqlParameter("@interview_date", SqlDbType.DateTime),
					new SqlParameter("@interview_cre_date", SqlDbType.DateTime),
					new SqlParameter("@interview_cre_by", SqlDbType.NVarChar,50),
                                        new SqlParameter("@interview_type", SqlDbType.NVarChar,50)};

            parameters[0].Value = model.interview_round;
            parameters[1].Value = model.interview_cv_guid;
            parameters[2].Value = model.interview_by;
            parameters[3].Value = model.interview_date;
            parameters[4].Value = model.interview_cre_date;
            parameters[5].Value = model.interview_cre_by;
            parameters[6].Value = model.interview_type;

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
        public bool Update(Workflow.Model.Cus_Job_Interview_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Interview set ");
            strSql.Append("interview_round=@interview_round,");
            strSql.Append("interview_cv_guid=@interview_cv_guid,");
            strSql.Append("interview_by=@interview_by,");
            strSql.Append("interview_date=@interview_date,");
            strSql.Append("interview_cre_date=@interview_cre_date,");
            strSql.Append("interview_cre_by=@interview_cre_by");
            strSql.Append(" where interview_id=@interview_id");
            SqlParameter[] parameters = {
					new SqlParameter("@interview_round", SqlDbType.Int,4),
					new SqlParameter("@interview_cv_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@interview_by", SqlDbType.NVarChar,50),
					new SqlParameter("@interview_date", SqlDbType.DateTime),
					new SqlParameter("@interview_cre_date", SqlDbType.DateTime),
					new SqlParameter("@interview_cre_by", SqlDbType.NVarChar,50),
					new SqlParameter("@interview_id", SqlDbType.Int,4)};
            parameters[0].Value = model.interview_round;
            parameters[1].Value = model.interview_cv_guid;
            parameters[2].Value = model.interview_by;
            parameters[3].Value = model.interview_date;
            parameters[4].Value = model.interview_cre_date;
            parameters[5].Value = model.interview_cre_by;
            parameters[6].Value = model.interview_id;

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
        public bool Delete(int interview_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_Job_Interview ");
            strSql.Append(" where interview_id=@interview_id");
            SqlParameter[] parameters = {
					new SqlParameter("@interview_id", SqlDbType.Int,4)
			};
            parameters[0].Value = interview_id;

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
        public bool DeleteList(string interview_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_Job_Interview ");
            strSql.Append(" where interview_id in (" + interview_idlist + ")  ");
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
        public Workflow.Model.Cus_Job_Interview_Model GetModel(int interview_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 interview_id,interview_round,interview_cv_guid,interview_by,interview_date,interview_cre_date,interview_cre_by from Cus_Job_Interview ");
            strSql.Append(" where interview_id=@interview_id");
            SqlParameter[] parameters = {
					new SqlParameter("@interview_id", SqlDbType.Int,4)
			};
            parameters[0].Value = interview_id;

            Workflow.Model.Cus_Job_Interview_Model model = new Workflow.Model.Cus_Job_Interview_Model();
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
        public Workflow.Model.Cus_Job_Interview_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_Job_Interview_Model model = new Workflow.Model.Cus_Job_Interview_Model();
            if (row != null)
            {
                if (row["interview_id"] != null && row["interview_id"].ToString() != "")
                {
                    model.interview_id = int.Parse(row["interview_id"].ToString());
                }
                if (row["interview_round"] != null && row["interview_round"].ToString() != "")
                {
                    model.interview_round = int.Parse(row["interview_round"].ToString());
                }
                if (row["interview_cv_guid"] != null)
                {
                    model.interview_cv_guid = row["interview_cv_guid"].ToString();
                }
                if (row["interview_by"] != null)
                {
                    model.interview_by = row["interview_by"].ToString();
                }
                if (row["interview_date"] != null && row["interview_date"].ToString() != "")
                {
                    model.interview_date = DateTime.Parse(row["interview_date"].ToString());
                }
                if (row["interview_cre_date"] != null && row["interview_cre_date"].ToString() != "")
                {
                    model.interview_cre_date = DateTime.Parse(row["interview_cre_date"].ToString());
                }
                if (row["interview_cre_by"] != null)
                {
                    model.interview_cre_by = row["interview_cre_by"].ToString();
                }
                if (row["interview_type"] != null)
                {
                    model.interview_type = row["interview_type"].ToString();
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
            strSql.Append("select interview_id,interview_round,interview_cv_guid,interview_by,interview_date,interview_cre_date,interview_cre_by,interview_type");
            strSql.Append(" FROM Cus_Job_Interview ");
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
            strSql.Append(" interview_id,interview_round,interview_cv_guid,interview_by,interview_date,interview_cre_date,interview_cre_by ");
            strSql.Append(" FROM Cus_Job_Interview ");
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
            strSql.Append("select count(1) FROM Cus_Job_Interview ");
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
                strSql.Append("order by T.interview_id desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_Job_Interview T ");
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
            parameters[0].Value = "Cus_Job_Interview";
            parameters[1].Value = "interview_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool ExistsRound(int interview_round, string interview_cv_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_Job_Interview");
            strSql.Append(" where interview_cv_guid=@interview_cv_guid");
            strSql.Append("  and interview_round = @interview_round");
            SqlParameter[] parameters = {
					new SqlParameter("@interview_cv_guid", SqlDbType.NVarChar,50),
                    new SqlParameter("@interview_round", SqlDbType.Int,4)
			};
            parameters[0].Value = interview_cv_guid;
            parameters[1].Value = interview_round;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

