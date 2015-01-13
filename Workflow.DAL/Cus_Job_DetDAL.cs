using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;//Please add references
namespace Workflow.DAL
{
    public partial class Cus_Job_DetDAL
    {
        public Cus_Job_DetDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string cv_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_Job_Det");
            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = cv_guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_Job_Det(");
            strSql.Append("cv_guid,cv_job_guid,cv_nbr,cv_location,cv_cre_by,cv_cre_date,cv_path,cv_rmk)");
            strSql.Append(" values (");
            strSql.Append("@cv_guid,@cv_job_guid,@cv_nbr,@cv_location,@cv_cre_by,@cv_cre_date,@cv_path,@cv_rmk)");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_job_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_nbr", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_location", SqlDbType.NVarChar,20),
					new SqlParameter("@cv_cre_by", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_cre_date", SqlDbType.DateTime),
					new SqlParameter("@cv_path", SqlDbType.NVarChar,100),
					new SqlParameter("@cv_rmk", SqlDbType.NVarChar,800)};
            parameters[0].Value = model.cv_guid;
            parameters[1].Value = model.cv_job_guid;
            parameters[2].Value = model.cv_nbr;
            parameters[3].Value = model.cv_location;
            parameters[4].Value = model.cv_cre_by;
            parameters[5].Value = model.cv_cre_date;
            parameters[6].Value = model.cv_path;
            parameters[7].Value = model.cv_rmk;

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
        public bool Update(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_job_guid=@cv_job_guid,");
            strSql.Append("cv_nbr=@cv_nbr,");
            strSql.Append("cv_location=@cv_location,");
            strSql.Append("cv_cre_by=@cv_cre_by,");
            strSql.Append("cv_cre_date=@cv_cre_date,");
            strSql.Append("cv_path=@cv_path,");
            strSql.Append("cv_rmk=@cv_rmk");
            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_job_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_nbr", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_location", SqlDbType.NVarChar,20),
					new SqlParameter("@cv_cre_by", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_cre_date", SqlDbType.DateTime),
					new SqlParameter("@cv_path", SqlDbType.NVarChar,100),
					new SqlParameter("@cv_rmk", SqlDbType.NVarChar,800),
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cv_job_guid;
            parameters[1].Value = model.cv_nbr;
            parameters[2].Value = model.cv_location;
            parameters[3].Value = model.cv_cre_by;
            parameters[4].Value = model.cv_cre_date;
            parameters[5].Value = model.cv_path;
            parameters[6].Value = model.cv_rmk;
            parameters[7].Value = model.cv_guid;

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
        public bool Delete(string cv_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_Job_Det ");
            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = cv_guid;

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
        public bool DeleteList(string cv_guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_Job_Det ");
            strSql.Append(" where cv_guid in (" + cv_guidlist + ")  ");
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
        public Workflow.Model.Cus_Job_Det_Model GetModel(string cv_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 cv_guid,cv_job_guid,cv_nbr,cv_location,cv_cre_by,cv_cre_date,cv_path,cv_rmk,cv_confirm_date,cv_onboard_date,cv_candidate,cv_candidate_phone,cv_expect_onboard_date,cv_candidate_gender from Cus_Job_Det ");
            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = cv_guid;

            Workflow.Model.Cus_Job_Det_Model model = new Workflow.Model.Cus_Job_Det_Model();
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
        public Workflow.Model.Cus_Job_Det_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_Job_Det_Model model = new Workflow.Model.Cus_Job_Det_Model();
            if (row != null)
            {
                if (row["cv_guid"] != null)
                {
                    model.cv_guid = row["cv_guid"].ToString();
                }
                if (row["cv_job_guid"] != null)
                {
                    model.cv_job_guid = row["cv_job_guid"].ToString();
                }
                if (row["cv_nbr"] != null)
                {
                    model.cv_nbr = row["cv_nbr"].ToString();
                }
                if (row["cv_location"] != null)
                {
                    model.cv_location = row["cv_location"].ToString();
                }
                if (row["cv_cre_by"] != null)
                {
                    model.cv_cre_by = row["cv_cre_by"].ToString();
                }
                if (row["cv_cre_date"] != null && row["cv_cre_date"].ToString() != "")
                {
                    model.cv_cre_date = DateTime.Parse(row["cv_cre_date"].ToString());
                }
                if (row["cv_path"] != null)
                {
                    model.cv_path = row["cv_path"].ToString();
                }
                if (row["cv_rmk"] != null)
                {
                    model.cv_rmk = row["cv_rmk"].ToString();
                }
                if (row["cv_confirm_date"] != null && row["cv_confirm_date"].ToString() != "")
                {
                    model.cv_confirm_date = DateTime.Parse(row["cv_confirm_date"].ToString());
                }
                if (row["cv_onboard_date"] != null && row["cv_onboard_date"].ToString() != "")
                {
                    model.cv_onboard_date = DateTime.Parse(row["cv_onboard_date"].ToString());
                }
                if (row["cv_candidate"] != null)
                {
                    model.cv_candidate = row["cv_candidate"].ToString();
                }
                if (row["cv_candidate_phone"] != null)
                {
                    model.cv_candidate_phone = row["cv_candidate_phone"].ToString();
                }
                if (row["cv_expect_onboard_date"] != null && row["cv_expect_onboard_date"].ToString() != "")
                {
                    model.cv_expect_onboard_date = DateTime.Parse(row["cv_expect_onboard_date"].ToString());
                }
                if (row["cv_candidate_gender"] != null)
                {
                    model.cv_candidate_gender = row["cv_candidate_gender"].ToString();
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
            strSql.Append("select cv_guid,cv_job_guid,cv_nbr,cv_location,cv_cre_by,cv_cre_date,cv_path,cv_rmk ");
            strSql.Append(" FROM Cus_Job_Det ");
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
            strSql.Append(" cv_guid,cv_job_guid,cv_nbr,cv_location,cv_cre_by,cv_cre_date,cv_path,cv_rmk ");
            strSql.Append(" FROM Cus_Job_Det ");
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
            strSql.Append("select count(1) FROM Cus_Job_Det ");
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
                strSql.Append("order by T.cv_guid desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_Job_Det T ");
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
            parameters[0].Value = "Cus_Job_Det";
            parameters[1].Value = "cv_guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetList(string strWhere, string strLang)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLang == "CN")
            {
                strSql.Append("select A.job_guid,A.job_nbr,B.cv_guid,B.cv_candidate,B.cv_candidate_phone,B.cv_expect_onboard_date,B.cv_probation_end_date,B.cv_nbr,B.cv_cre_by,B.cv_confirm_date,B.cv_cre_date,B.cv_onboard_date,C.attach_title,C.attach_path,C.attach_id,D.form_seq,E.flow_status_cn as flow_status");


            }
            else
            {
                strSql.Append("select A.job_guid,A.job_nbr,B.cv_guid,B.cv_candidate,B.cv_candidate_phone,B.cv_expect_onboard_date,B.cv_probation_end_date,B.cv_nbr,B.cv_cre_by,B.cv_confirm_date,B.cv_cre_date,B.cv_onboard_date,C.attach_title,C.attach_path,C.attach_id,D.form_seq,E.flow_status_en as flow_status");

            }
            strSql.Append(" from Cus_Job_Mstr A,Cus_Job_Det B,Sys_Attach_Mstr C,Sys_Form_Mstr D ,Sys_Flow_Mstr E where  ");
            strSql.Append(" A.job_guid = B.cv_job_guid and B.cv_guid = C.attach_guid and B.cv_guid = D.form_guid and D.form_type = E.flow_type and D.form_location = E.flow_location and D.form_seq = E.flow_seq ");
            if (strWhere != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by B.cv_nbr desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet getListByApprover(string strWhere, string strLang)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLang == "CN")
            {
                strSql.Append("select A.job_guid,A.job_nbr,B.cv_guid,B.cv_nbr,B.cv_cre_by,B.cv_cre_date,C.attach_title,C.attach_path,C.attach_id,D.form_seq,E.flow_status_cn as flow_status");


            }
            else
            {
                strSql.Append("select A.job_guid,A.job_nbr,B.cv_guid,B.cv_nbr,B.cv_cre_by,B.cv_cre_date,C.attach_title,C.attach_path,C.attach_id,D.form_seq,E.flow_status_en as flow_status");

            }
            strSql.Append(" from Cus_Job_Mstr A,Cus_Job_Det B,Sys_Attach_Mstr C,Sys_Form_Mstr D ,Sys_Flow_Mstr E,V_Appr_Mstr F where  ");
            strSql.Append(" A.job_guid = B.cv_job_guid and B.cv_guid = C.attach_guid and B.cv_guid = D.form_guid and D.form_type = E.flow_type and D.form_location = E.flow_location and D.form_seq = E.flow_seq and D.form_nbr = F.appr_nbr and D.form_seq > 10 ");
            if (strWhere != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by B.cv_nbr desc ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public string ExecCVProc(string job_nbr, string cv_nbr, int job_lines, string job_location, string cv_user, string cv_type, string attach_path, string cv_rmk, string auto, string filename, string cv_path, string send_user, string send_subject)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Int),
                    new SqlParameter("@job_nbr", SqlDbType.NVarChar, 50),
                    new SqlParameter("@cv_nbr", SqlDbType.NVarChar, 50),
                    new SqlParameter("@job_lines", SqlDbType.Int),
                    new SqlParameter("@job_location", SqlDbType.VarChar,20),
                    new SqlParameter("@cv_user", SqlDbType.NVarChar,50),
                    new SqlParameter("@cv_type", SqlDbType.NVarChar,50),
                    new SqlParameter("@cv_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@attach_path", SqlDbType.NVarChar,100),
                    new SqlParameter("@cv_rmk", SqlDbType.NVarChar,800),
                    new SqlParameter("@auto", SqlDbType.Char,1),
                    new SqlParameter("@attach_title", SqlDbType.NVarChar,100),
                    new SqlParameter("@send_user", SqlDbType.NVarChar,50),
                    new SqlParameter("@send_subject", SqlDbType.NVarChar,500)
                    };
            parameters[1].Value = job_nbr;
            parameters[2].Value = cv_nbr;
            parameters[3].Value = job_lines;
            parameters[4].Value = job_location;
            parameters[5].Value = cv_user;
            parameters[6].Value = cv_type;
            parameters[7].Value = cv_path;
            parameters[8].Value = attach_path;
            parameters[9].Value = cv_rmk;
            parameters[10].Value = auto;
            parameters[11].Value = filename;
            parameters[12].Value = send_user;
            parameters[13].Value = send_subject;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_recruitment_cv_save_manually]", parameters);
            return parameters[0].Value.ToString().Trim();
        }

        public bool UpdateRelative(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_relative=@cv_relative ");
            strSql.Append(" where cv_nbr=@cv_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_relative", SqlDbType.Char,1),

					new SqlParameter("@cv_nbr", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cv_relative;
            parameters[1].Value = model.cv_nbr;


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
        public bool UpdateConfirmDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_confirm_date=@cv_confirm_date");

            strSql.Append(" where cv_nbr=@cv_nbr ");
            SqlParameter[] parameters = {

					new SqlParameter("@cv_confirm_date", SqlDbType.DateTime),
					new SqlParameter("@cv_nbr", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cv_confirm_date;

            parameters[1].Value = model.cv_nbr;

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
        public bool UpdateExtendProbationDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_probation_end_extend_date=@cv_probation_end_extend_date");

            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {

					new SqlParameter("@cv_probation_end_extend_date", SqlDbType.DateTime),
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cv_probation_end_extend_date;

            parameters[1].Value = model.cv_guid;

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
        public bool UpdateOnBoardDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_onboard_date=@cv_onboard_date,");
            strSql.Append("cv_probation_end_date=@cv_probation_end_date");

            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {

					new SqlParameter("@cv_onboard_date", SqlDbType.DateTime),
                    new SqlParameter("@cv_probation_end_date", SqlDbType.DateTime),
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cv_onboard_date;
            parameters[1].Value = model.cv_probation_end_date;

            parameters[2].Value = model.cv_guid;

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
        public bool UpdateExpectOnBoardDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_expect_onboard_date=@cv_expect_onboard_date");

            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {

					new SqlParameter("@cv_expect_onboard_date", SqlDbType.DateTime),
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.cv_expect_onboard_date;

            parameters[1].Value = model.cv_guid;

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

        public bool UpdateCandidate(string cv_guid, string cv_candidate, string cv_candidate_phone, string cv_candidate_gender)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_Job_Det set ");
            strSql.Append("cv_candidate=@cv_candidate,");
            strSql.Append("cv_candidate_phone=@cv_candidate_phone,");
            strSql.Append("cv_candidate_gender=@cv_candidate_gender");
            strSql.Append(" where cv_guid=@cv_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cv_candidate", SqlDbType.NVarChar,50),
					new SqlParameter("@cv_candidate_phone", SqlDbType.NVarChar,50),
                    new SqlParameter("@cv_candidate_gender", SqlDbType.NVarChar,10),
					new SqlParameter("@cv_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = cv_candidate;
            parameters[1].Value = cv_candidate_phone;
            parameters[2].Value = cv_candidate_gender;
            parameters[3].Value = cv_guid;

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
        public DataSet GetCVTaskList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select job_nbr,cv_nbr,job_title,cv_candidate,cv_candidate_phone,cv_candidate_gender from Cus_Job_Mstr,Cus_Job_Det,Sys_Appr_Mstr where job_guid = cv_job_guid and cv_nbr = appr_nbr and appr_seq = 230 and appr_now ='Y' and appr_appr='N'");
            if (strWhere != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by job_nbr,cv_nbr ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}

