using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;//Please add references
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_CV_Det_Model
    /// </summary>
    public partial class Cus_CV_DetDAL
    {
        public Cus_CV_DetDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string log_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_CV_Det");
            strSql.Append(" where log_guid=@log_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = log_guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_CV_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_CV_Det(");
            strSql.Append("log_guid,log_nbr,log_location,log_send_user,log_domain,log_subject,log_path,log_cre_date,log_cre_by,log_modify_by,log_modify_date,log_has_jobid,log_flag)");
            strSql.Append(" values (");
            strSql.Append("@log_guid,@log_nbr,@log_location,@log_send_user,@log_domain,@log_subject,@log_path,@log_cre_date,@log_cre_by,@log_modify_by,@log_modify_date,@log_has_jobid,@log_flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@log_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@log_nbr", SqlDbType.NVarChar,50),
					new SqlParameter("@log_location", SqlDbType.NVarChar,20),
					new SqlParameter("@log_send_user", SqlDbType.NVarChar,50),
					new SqlParameter("@log_domain", SqlDbType.NVarChar,50),
					new SqlParameter("@log_subject", SqlDbType.NVarChar,500),
					new SqlParameter("@log_path", SqlDbType.NVarChar,100),
					new SqlParameter("@log_cre_date", SqlDbType.DateTime),
					new SqlParameter("@log_cre_by", SqlDbType.NVarChar,50),
					new SqlParameter("@log_modify_by", SqlDbType.NVarChar,50),
					new SqlParameter("@log_modify_date", SqlDbType.DateTime),
					new SqlParameter("@log_has_jobid", SqlDbType.Char,1),
					new SqlParameter("@log_flag", SqlDbType.Char,1)};
            parameters[0].Value = model.log_guid;
            parameters[1].Value = model.log_nbr;
            parameters[2].Value = model.log_location;
            parameters[3].Value = model.log_send_user;
            parameters[4].Value = model.log_domain;
            parameters[5].Value = model.log_subject;
            parameters[6].Value = model.log_path;
            parameters[7].Value = model.log_cre_date;
            parameters[8].Value = model.log_cre_by;
            parameters[9].Value = model.log_modify_by;
            parameters[10].Value = model.log_modify_date;
            parameters[11].Value = model.log_has_jobid;
            parameters[12].Value = model.log_flag;

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
        public bool Update(Workflow.Model.Cus_CV_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_CV_Det set ");
            strSql.Append("log_nbr=@log_nbr,");
            strSql.Append("log_location=@log_location,");
            strSql.Append("log_send_user=@log_send_user,");
            strSql.Append("log_domain=@log_domain,");
            strSql.Append("log_subject=@log_subject,");
            strSql.Append("log_path=@log_path,");
            strSql.Append("log_cre_date=@log_cre_date,");
            strSql.Append("log_cre_by=@log_cre_by,");
            strSql.Append("log_modify_by=@log_modify_by,");
            strSql.Append("log_modify_date=@log_modify_date,");
            strSql.Append("log_has_jobid=@log_has_jobid,");
            strSql.Append("log_flag=@log_flag");
            strSql.Append(" where log_guid=@log_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_nbr", SqlDbType.NVarChar,50),
					new SqlParameter("@log_location", SqlDbType.NVarChar,20),
					new SqlParameter("@log_send_user", SqlDbType.NVarChar,50),
					new SqlParameter("@log_domain", SqlDbType.NVarChar,50),
					new SqlParameter("@log_subject", SqlDbType.NVarChar,500),
					new SqlParameter("@log_path", SqlDbType.NVarChar,100),
					new SqlParameter("@log_cre_date", SqlDbType.DateTime),
					new SqlParameter("@log_cre_by", SqlDbType.NVarChar,50),
					new SqlParameter("@log_modify_by", SqlDbType.NVarChar,50),
					new SqlParameter("@log_modify_date", SqlDbType.DateTime),
					new SqlParameter("@log_has_jobid", SqlDbType.Char,1),
					new SqlParameter("@log_flag", SqlDbType.Char,1),
					new SqlParameter("@log_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.log_nbr;
            parameters[1].Value = model.log_location;
            parameters[2].Value = model.log_send_user;
            parameters[3].Value = model.log_domain;
            parameters[4].Value = model.log_subject;
            parameters[5].Value = model.log_path;
            parameters[6].Value = model.log_cre_date;
            parameters[7].Value = model.log_cre_by;
            parameters[8].Value = model.log_modify_by;
            parameters[9].Value = model.log_modify_date;
            parameters[10].Value = model.log_has_jobid;
            parameters[11].Value = model.log_flag;
            parameters[12].Value = model.log_guid;

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
        public bool Delete(string log_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_CV_Det ");
            strSql.Append(" where log_guid=@log_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = log_guid;

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
        public bool DeleteList(string log_guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_CV_Det ");
            strSql.Append(" where log_guid in (" + log_guidlist + ")  ");
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
        public Workflow.Model.Cus_CV_Det_Model GetModel(string log_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 log_guid,log_nbr,log_location,log_send_user,log_domain,log_subject,log_path,log_cre_date,log_cre_by,log_modify_by,log_modify_date,log_has_jobid,log_flag from Cus_CV_Det ");
            strSql.Append(" where log_guid=@log_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@log_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = log_guid;

            Workflow.Model.Cus_CV_Det_Model model = new Workflow.Model.Cus_CV_Det_Model();
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
        public Workflow.Model.Cus_CV_Det_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_CV_Det_Model model = new Workflow.Model.Cus_CV_Det_Model();
            if (row != null)
            {
                if (row["log_guid"] != null)
                {
                    model.log_guid = row["log_guid"].ToString();
                }
                if (row["log_nbr"] != null)
                {
                    model.log_nbr = row["log_nbr"].ToString();
                }
                if (row["log_location"] != null)
                {
                    model.log_location = row["log_location"].ToString();
                }
                if (row["log_send_user"] != null)
                {
                    model.log_send_user = row["log_send_user"].ToString();
                }
                if (row["log_domain"] != null)
                {
                    model.log_domain = row["log_domain"].ToString();
                }
                if (row["log_subject"] != null)
                {
                    model.log_subject = row["log_subject"].ToString();
                }
                if (row["log_path"] != null)
                {
                    model.log_path = row["log_path"].ToString();
                }
                if (row["log_cre_date"] != null && row["log_cre_date"].ToString() != "")
                {
                    model.log_cre_date = DateTime.Parse(row["log_cre_date"].ToString());
                }
                if (row["log_cre_by"] != null)
                {
                    model.log_cre_by = row["log_cre_by"].ToString();
                }
                if (row["log_modify_by"] != null)
                {
                    model.log_modify_by = row["log_modify_by"].ToString();
                }
                if (row["log_modify_date"] != null && row["log_modify_date"].ToString() != "")
                {
                    model.log_modify_date = DateTime.Parse(row["log_modify_date"].ToString());
                }
                if (row["log_has_jobid"] != null)
                {
                    model.log_has_jobid = row["log_has_jobid"].ToString();
                }
                if (row["log_flag"] != null)
                {
                    model.log_flag = row["log_flag"].ToString();
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
            strSql.Append("select log_guid,log_nbr,log_location,log_send_user,log_domain,log_subject,log_path,log_cre_date,log_cre_by,log_modify_by,log_modify_date,log_has_jobid,log_flag ");
            strSql.Append(" FROM Cus_CV_Det ");
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
            strSql.Append(" log_guid,log_nbr,log_location,log_send_user,log_domain,log_subject,log_path,log_cre_date,log_cre_by,log_modify_by,log_modify_date,log_has_jobid,log_flag ");
            strSql.Append(" FROM Cus_CV_Det ");
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
            strSql.Append("select count(1) FROM Cus_CV_Det ");
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
                strSql.Append("order by T.log_guid desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_CV_Det T ");
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
            parameters[0].Value = "Cus_CV_Det";
            parameters[1].Value = "log_guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string ExecCVAllocate(string job_nbr,string user,string log_guid)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,10),
                    new SqlParameter("@job_nbr", SqlDbType.Char, 20),
                    new SqlParameter("@user", SqlDbType.VarChar, 50),
                    new SqlParameter("@log_guid", SqlDbType.VarChar, 50),
                    };
            parameters[1].Value = job_nbr;
            parameters[2].Value = user;
            parameters[3].Value = log_guid;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_recruitment_cv_allocate]", parameters);
            return parameters[0].Value.ToString();
        }
        #endregion  ExtensionMethod
    }
}

