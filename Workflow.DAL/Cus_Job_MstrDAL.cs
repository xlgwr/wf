using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;//Please add references
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_Job_Mstr_Model
    /// </summary>
    public partial class Cus_Job_MstrDAL
    {
        public Cus_Job_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string job_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_Job_Mstr");
            strSql.Append(" where job_guid=@job_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@job_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = job_guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_Job_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_Job_Mstr(");
            strSql.Append("job_guid,job_nbr,job_applicant,job_location,job_applicant_dept,job_dept,job_seq,job_date,job_title,job_desc,job_rmk,job_lines,job_key,job_approver)");
            strSql.Append(" values (");
            strSql.Append("@job_guid,@job_nbr,@job_applicant,@job_location,@job_applicant_dept,@job_dept,@job_seq,@job_date,@job_title,@job_desc,@job_rmk,@job_lines,@job_key,@job_approver)");
            SqlParameter[] parameters = {
					new SqlParameter("@job_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@job_nbr", SqlDbType.NVarChar,50),
					new SqlParameter("@job_applicant", SqlDbType.NVarChar,50),
					new SqlParameter("@job_location", SqlDbType.NVarChar,20),
					new SqlParameter("@job_applicant_dept", SqlDbType.NVarChar,20),
					new SqlParameter("@job_dept", SqlDbType.NVarChar,20),
					new SqlParameter("@job_seq", SqlDbType.Int,4),
					new SqlParameter("@job_date", SqlDbType.DateTime),
					new SqlParameter("@job_title", SqlDbType.NVarChar,100),
					new SqlParameter("@job_desc", SqlDbType.NVarChar,4000),
					new SqlParameter("@job_rmk", SqlDbType.NVarChar,4000),
					new SqlParameter("@job_lines", SqlDbType.Int,4),
                                        					new SqlParameter("@job_key", SqlDbType.Char,1),
                                        					new SqlParameter("@job_approver", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.job_guid;
            parameters[1].Value = model.job_nbr;
            parameters[2].Value = model.job_applicant;
            parameters[3].Value = model.job_location;
            parameters[4].Value = model.job_applicant_dept;
            parameters[5].Value = model.job_dept;
            parameters[6].Value = model.job_seq;
            parameters[7].Value = model.job_date;
            parameters[8].Value = model.job_title;
            parameters[9].Value = model.job_desc;
            parameters[10].Value = model.job_rmk;
            parameters[11].Value = model.job_lines;
            parameters[12].Value = model.job_key;
            parameters[13].Value = model.job_approver;

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
        public bool Update(Workflow.Model.Cus_Job_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Mstr set ");
            strSql.Append("job_nbr=@job_nbr,");
            strSql.Append("job_applicant=@job_applicant,");
            strSql.Append("job_location=@job_location,");
            strSql.Append("job_applicant_dept=@job_applicant_dept,");
            strSql.Append("job_dept=@job_dept,");
            strSql.Append("job_seq=@job_seq,");
            strSql.Append("job_date=@job_date,");
            strSql.Append("job_title=@job_title,");
            strSql.Append("job_desc=@job_desc,");
            strSql.Append("job_rmk=@job_rmk,");
            strSql.Append("job_lines=@job_lines");
            strSql.Append("job_key=@job_key,");
            strSql.Append("job_approver=@job_approver");
            strSql.Append(" where job_guid=@job_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@job_nbr", SqlDbType.NVarChar,50),
					new SqlParameter("@job_applicant", SqlDbType.NVarChar,50),
					new SqlParameter("@job_location", SqlDbType.NVarChar,20),
					new SqlParameter("@job_applicant_dept", SqlDbType.NVarChar,20),
					new SqlParameter("@job_dept", SqlDbType.NVarChar,20),
					new SqlParameter("@job_seq", SqlDbType.Int,4),
					new SqlParameter("@job_date", SqlDbType.DateTime),
					new SqlParameter("@job_title", SqlDbType.NVarChar,100),
					new SqlParameter("@job_desc", SqlDbType.NVarChar,4000),
					new SqlParameter("@job_rmk", SqlDbType.NVarChar,4000),
					new SqlParameter("@job_lines", SqlDbType.Int,4),
                    new SqlParameter("@job_key", SqlDbType.Char,1),
                                        					new SqlParameter("@job_approver", SqlDbType.NVarChar,500),
					new SqlParameter("@job_guid", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.job_nbr;
            parameters[1].Value = model.job_applicant;
            parameters[2].Value = model.job_location;
            parameters[3].Value = model.job_applicant_dept;
            parameters[4].Value = model.job_dept;
            parameters[5].Value = model.job_seq;
            parameters[6].Value = model.job_date;
            parameters[7].Value = model.job_title;
            parameters[8].Value = model.job_desc;
            parameters[9].Value = model.job_rmk;
            parameters[10].Value = model.job_lines;
            parameters[12].Value = model.job_key;
            parameters[13].Value = model.job_approver;
            parameters[14].Value = model.job_guid;

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
        public bool Delete(string job_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_Job_Mstr ");
            strSql.Append(" where job_guid=@job_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@job_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = job_guid;

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
        public bool DeleteList(string job_guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_Job_Mstr ");
            strSql.Append(" where job_guid in (" + job_guidlist + ")  ");
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
        public Workflow.Model.Cus_Job_Mstr_Model GetModel(string job_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 job_guid,job_nbr,job_applicant,job_location,job_applicant_dept,job_dept,job_seq,job_date,job_title,job_desc,job_rmk,job_lines,job_key,job_approver,job_recruiter,job_adviser from Cus_Job_Mstr ");
            strSql.Append(" where job_guid=@job_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@job_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = job_guid;

            Workflow.Model.Cus_Job_Mstr_Model model = new Workflow.Model.Cus_Job_Mstr_Model();
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
        public Workflow.Model.Cus_Job_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_Job_Mstr_Model model = new Workflow.Model.Cus_Job_Mstr_Model();
            if (row != null)
            {
                if (row["job_guid"] != null)
                {
                    model.job_guid = row["job_guid"].ToString();
                }
                if (row["job_nbr"] != null)
                {
                    model.job_nbr = row["job_nbr"].ToString();
                }
                if (row["job_applicant"] != null)
                {
                    model.job_applicant = row["job_applicant"].ToString();
                }
                if (row["job_location"] != null)
                {
                    model.job_location = row["job_location"].ToString();
                }
                if (row["job_applicant_dept"] != null)
                {
                    model.job_applicant_dept = row["job_applicant_dept"].ToString();
                }
                if (row["job_dept"] != null)
                {
                    model.job_dept = row["job_dept"].ToString();
                }
                if (row["job_seq"] != null && row["job_seq"].ToString() != "")
                {
                    model.job_seq = int.Parse(row["job_seq"].ToString());
                }
                if (row["job_date"] != null && row["job_date"].ToString() != "")
                {
                    model.job_date = DateTime.Parse(row["job_date"].ToString());
                }
                if (row["job_title"] != null)
                {
                    model.job_title = row["job_title"].ToString();
                }
                if (row["job_desc"] != null)
                {
                    model.job_desc = row["job_desc"].ToString();
                }
                if (row["job_rmk"] != null)
                {
                    model.job_rmk = row["job_rmk"].ToString();
                }
                if (row["job_lines"] != null && row["job_lines"].ToString() != "")
                {
                    model.job_lines = int.Parse(row["job_lines"].ToString());
                }
                if (row["job_key"] != null)
                {
                    model.job_key = row["job_key"].ToString();
                }
                if (row["job_approver"] != null)
                {
                    model.job_approver = row["job_approver"].ToString();
                }
                if (row["job_recruiter"] != null)
                {
                    model.job_recruiter = row["job_recruiter"].ToString();
                }
                if (row["job_adviser"] != null)
                {
                    model.job_adviser = row["job_adviser"].ToString();
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
            strSql.Append("select job_guid,job_nbr,job_applicant,job_location,job_applicant_dept,job_dept,job_seq,job_date,job_title,job_desc,job_rmk,job_lines,job_key,job_approver,job_recruiter,job_adviser ");
            strSql.Append(" FROM Cus_Job_Mstr ");
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
            strSql.Append(" job_guid,job_nbr,job_applicant,job_location,job_applicant_dept,job_dept,job_seq,job_date,job_title,job_desc,job_rmk,job_lines,job_key,job_approver,job_recruiter,job_adviser ");
            strSql.Append(" FROM Cus_Job_Mstr ");
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
            strSql.Append("select count(1) FROM Cus_Job_Mstr ");
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
                strSql.Append("order by T.job_guid desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_Job_Mstr T ");
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
            parameters[0].Value = "Cus_Job_Mstr";
            parameters[1].Value = "job_guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetJobList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select job_guid,job_nbr,job_applicant,job_location,job_applicant_dept,job_dept,job_date,job_title,job_desc,job_rmk,job_lines,job_key,job_approver,form_seq,job_recruiter,flow_status_en ");
            strSql.Append(" FROM Cus_Job_Mstr,Sys_Form_Mstr,Sys_Flow_Mstr where job_guid = form_guid and form_type = flow_type and form_location = flow_location and form_seq = flow_seq");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public Workflow.Model.Cus_Job_Mstr_Model GetModelByNbr(string job_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 job_guid,job_nbr,job_applicant,job_location,job_applicant_dept,job_dept,job_seq,job_date,job_title,job_desc,job_rmk,job_lines,job_key,job_approver,job_recruiter,job_adviser from Cus_Job_Mstr ");
            strSql.Append(" where job_nbr=@job_nbr ");
            SqlParameter[] parameters = {
                                               new SqlParameter("@job_nbr", SqlDbType.NVarChar,50)                          };
            parameters[0].Value = job_nbr;

            Workflow.Model.Cus_Job_Mstr_Model model = new Workflow.Model.Cus_Job_Mstr_Model();
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
        public string SaveJobMstr(Workflow.Model.Cus_Job_Mstr_Model model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,2),
                    new SqlParameter("@nbr", SqlDbType.Char, 20),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@job_dept", SqlDbType.VarChar,50),
                    new SqlParameter("@job_title", SqlDbType.NVarChar, 800),
                    new SqlParameter("@job_desc", SqlDbType.NVarChar,4000),
                    new SqlParameter("@job_rmk", SqlDbType.VarChar,1000),
                    new SqlParameter("@applicant", SqlDbType.VarChar,50),
                    new SqlParameter("@job_key", SqlDbType.VarChar,10),
                    new SqlParameter("@job_approver", SqlDbType.VarChar,500),
                    new SqlParameter("@job_recruiter", SqlDbType.VarChar,50),
                    new SqlParameter("@job_adviser", SqlDbType.VarChar,500),
                    new SqlParameter("@job_date", SqlDbType.DateTime)
                    };
            parameters[1].Value = model.job_nbr;
            parameters[2].Value = model.job_location;
            parameters[3].Value = model.job_dept;
            parameters[4].Value = model.job_title;
            parameters[5].Value = model.job_desc;
            parameters[6].Value = model.job_rmk;
            parameters[7].Value = model.job_applicant;
            parameters[8].Value = model.job_key;
            parameters[9].Value = model.job_approver;
            parameters[10].Value = model.job_recruiter;
            parameters[11].Value = model.job_adviser;
            parameters[12].Value = model.job_date;
            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.InputOutput;
            DbHelperSQL.RunProcedure("sp_recruitment_save", parameters);
            return parameters[0].Value.ToString() + "|" + parameters[1].Value.ToString();
        }
        public DataTable ExecRecruitReport(string dateFrom,string dateTo,string strLocation)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("exec sp_recruitment_wk_rpt '"+dateFrom+"','"+dateTo+"','"+strLocation+"'");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        #endregion  ExtensionMethod
    }
}

