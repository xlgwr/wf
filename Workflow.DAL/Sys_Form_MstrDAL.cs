using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Form_Mstr_Model
    /// </summary>
    public partial class Sys_Form_MstrDAL
    {
        public Sys_Form_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string form_nbr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Form_Mstr");
            strSql.Append(" where form_nbr=@form_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_nbr", SqlDbType.VarChar,20)			};
            parameters[0].Value = form_nbr;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Form_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Form_Mstr(");
            strSql.Append("form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date)");
            strSql.Append(" values (");
            strSql.Append("@form_nbr,@form_location,@form_dept,@form_applicant,@form_seq,@form_date)");
            SqlParameter[] parameters = {
					new SqlParameter("@form_nbr", SqlDbType.VarChar,20),
					new SqlParameter("@form_location", SqlDbType.VarChar,20),
                    new SqlParameter("@form_type", SqlDbType.VarChar,20),
					new SqlParameter("@form_dept", SqlDbType.VarChar,20),
					new SqlParameter("@form_applicant", SqlDbType.VarChar,30),
					new SqlParameter("@form_seq", SqlDbType.Int),
					new SqlParameter("@form_date", SqlDbType.DateTime)};
            parameters[0].Value = model.form_nbr;
            parameters[1].Value = model.form_location;
            parameters[2].Value = model.form_type;
            parameters[3].Value = model.form_dept;
            parameters[4].Value = model.form_applicant;
            parameters[5].Value = model.form_seq;
            parameters[6].Value = model.form_date;

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
        public bool Update(Workflow.Model.Sys_Form_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Form_Mstr set ");
            strSql.Append("form_location=@form_location,");
            strSql.Append("form_tpe=@form_type,");
            strSql.Append("form_dept=@form_dept,");
            strSql.Append("form_applicant=@form_applicant,");
            strSql.Append("form_seq=@form_seq,");
            strSql.Append("form_date=@form_date");
            strSql.Append(" where form_nbr=@form_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_location", SqlDbType.VarChar,20),
					new SqlParameter("@form_dept", SqlDbType.VarChar,20),
                    new SqlParameter("@form_type", SqlDbType.VarChar,20),
					new SqlParameter("@form_applicant", SqlDbType.VarChar,30),
					new SqlParameter("@form_seq", SqlDbType.Int),
					new SqlParameter("@form_date", SqlDbType.DateTime),
					new SqlParameter("@form_nbr", SqlDbType.VarChar,20)};
            parameters[0].Value = model.form_location;
            parameters[1].Value = model.form_dept;
            parameters[2].Value = model.form_type;
            parameters[3].Value = model.form_applicant;
            parameters[4].Value = model.form_seq;
            parameters[5].Value = model.form_date;
            parameters[6].Value = model.form_nbr;

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
        public bool Delete(string form_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Form_Mstr set form_seq=-2 ");
            strSql.Append(" where form_nbr=@form_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_nbr", SqlDbType.VarChar,20)			};
            parameters[0].Value = form_nbr;

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
        public bool DeleteList(string form_nbrlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Form_Mstr ");
            strSql.Append(" where form_nbr in (" + form_nbrlist + ")  ");
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
        public Workflow.Model.Sys_Form_Mstr_Model GetModel(string form_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date from Sys_Form_Mstr ");
            strSql.Append(" where form_nbr=@form_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_nbr", SqlDbType.VarChar,20)			};
            parameters[0].Value = form_nbr;

            Workflow.Model.Sys_Form_Mstr_Model model = new Workflow.Model.Sys_Form_Mstr_Model();
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

        public Workflow.Model.Sys_Form_Mstr_Model GetModel(string form_seq, string form_type, string form_location)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date from Sys_Form_Mstr ");
            strSql.Append(" and form_type=@form_type ");
            strSql.Append(" and form_location=@form_location ");
            strSql.Append(" where form_seq=@form_seq ");
            SqlParameter[] parameters = {
                                            new SqlParameter("@form_location", SqlDbType.VarChar,20)		,
                    new SqlParameter("@form_type", SqlDbType.VarChar,20)	,	
					new SqlParameter("@form_seq", SqlDbType.VarChar,20)			};
            parameters[0].Value = form_location;
            parameters[1].Value = form_type;
            parameters[2].Value = form_seq;

            Workflow.Model.Sys_Form_Mstr_Model model = new Workflow.Model.Sys_Form_Mstr_Model();
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

        public Workflow.Model.Sys_Form_Mstr_Model GetGuidModel(string form_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date from Sys_Form_Mstr ");
            strSql.Append(" where form_guid=@form_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = form_guid;

            Workflow.Model.Sys_Form_Mstr_Model model = new Workflow.Model.Sys_Form_Mstr_Model();
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
        public Workflow.Model.Sys_Form_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Form_Mstr_Model model = new Workflow.Model.Sys_Form_Mstr_Model();
            if (row != null)
            {
                if (row["form_guid"] != null)
                {
                    model.form_guid = row["form_guid"].ToString();
                }
                if (row["form_nbr"] != null)
                {
                    model.form_nbr = row["form_nbr"].ToString();
                }
                if (row["form_location"] != null)
                {
                    model.form_location = row["form_location"].ToString();
                }
                if (row["form_dept"] != null)
                {
                    model.form_dept = row["form_dept"].ToString();
                }
                if (row["form_type"] != null)
                {
                    model.form_type = row["form_type"].ToString();
                }
                if (row["form_applicant"] != null)
                {
                    model.form_applicant = row["form_applicant"].ToString();
                }
                if (row["form_seq"] != null && row["form_seq"].ToString() != "")
                {
                    model.form_seq = int.Parse(row["form_seq"].ToString());
                }
                if (row["form_date"] != null && row["form_date"].ToString() != "")
                {
                    model.form_date = DateTime.Parse(row["form_date"].ToString());
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
            strSql.Append("select form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date ");
            strSql.Append(" FROM Sys_Form_Mstr ");
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
            strSql.Append(" form_guid,form_nbr,form_type,form_location,form_dept,form_applicant,form_seq,form_date ");
            strSql.Append(" FROM Sys_Form_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Form_Mstr ");
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
                strSql.Append("order by T.form_nbr desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Form_Mstr T ");
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
            parameters[0].Value = "Sys_Form_Mstr";
            parameters[1].Value = "form_nbr";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public DataSet GetPOList(string strUser)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date ");
            strSql.Append(" FROM Sys_Form_Mstr A,Cus_PO_Mstr B where A.form_guid = B.po_guid  ");
            strSql.Append(" and form_applicant = '"+strUser+"'");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetStatusList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date,case when form_seq>-1 then 'Running' when form_seq = -1 then 'Closed' when form_seq = -4 then 'Terminated' when form_seq = -3 then 'Rejected' else '' end form_status ");
            strSql.Append(" FROM Sys_Form_Mstr ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetPOStatusList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select form_guid,form_nbr,form_location,form_type,form_dept,form_applicant,form_seq,form_date,case when form_seq>-1 then 'Running' when form_seq = -1 then 'Closed' when form_seq = -4 then 'Terminated' when form_seq = -3 then 'Rejected' else '' end form_status ");
            strSql.Append(" FROM Sys_Form_Mstr A inner join Cus_PO_Mstr B on A.form_guid = B.po_guid  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public bool UpdateSeq(Workflow.Model.Sys_Form_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Form_Mstr set ");
            strSql.Append("form_seq=@form_seq");
            strSql.Append(" where form_guid=@form_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_seq", SqlDbType.Int),
					new SqlParameter("@form_guid", SqlDbType.VarChar,50)};
            parameters[0].Value = model.form_seq;
            parameters[1].Value = model.form_guid;
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
        #endregion  ExtensionMethod
    }
}

