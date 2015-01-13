using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Flow_Mstr_Model
    /// </summary>
    public partial class Sys_Flow_MstrDAL
    {
        public Sys_Flow_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("flow_id", "Sys_Flow_Mstr");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int flow_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Flow_Mstr");
            strSql.Append(" where flow_id=@flow_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@flow_id", SqlDbType.Int)			};
            parameters[0].Value = flow_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Flow_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Flow_Mstr(");
            strSql.Append("flow_id,flow_type,flow_location,flow_group,flow_seq,flow_back_seq,flow_level,flow_page,flow_table,flow_condition_flag,flow_condition_content,flow_status_en,flow_status_cn,flow_parallel_flag,flow_current_status,flow_last_start_date,flow_condition_display_en,flow_condition_display_cn)");
            strSql.Append(" values (");
            strSql.Append("@flow_id,@flow_type,@flow_location,@flow_group,@flow_seq,@flow_back_seq,@flow_level,@flow_page,@flow_table,@flow_condition_flag,@flow_condition_content,@flow_status_en,@flow_status_cn,@flow_parallel_flag,@flow_current_status,@flow_last_start_date,@flow_condition_display_en,@flow_condition_display_cn)");
            SqlParameter[] parameters = {
					new SqlParameter("@flow_id", SqlDbType.Int),
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int),
					new SqlParameter("@flow_back_seq", SqlDbType.Int),
					new SqlParameter("@flow_level", SqlDbType.Int),
					new SqlParameter("@flow_page", SqlDbType.NVarChar,500),
					new SqlParameter("@flow_table", SqlDbType.VarChar,20),
					new SqlParameter("@flow_condition_flag", SqlDbType.Char,1),
					new SqlParameter("@flow_condition_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@flow_status_en", SqlDbType.NVarChar,200),
					new SqlParameter("@flow_status_cn", SqlDbType.NVarChar,200),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1),
					new SqlParameter("@flow_current_status", SqlDbType.Char,1),
					new SqlParameter("@flow_last_start_date", SqlDbType.DateTime),
					new SqlParameter("@flow_condition_display_en", SqlDbType.NVarChar,1000),
					new SqlParameter("@flow_condition_display_cn", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.flow_id;
            parameters[1].Value = model.flow_type;
            parameters[2].Value = model.flow_location;
            parameters[3].Value = model.flow_group;
            parameters[4].Value = model.flow_seq;
            parameters[5].Value = model.flow_back_seq;
            parameters[6].Value = model.flow_level;
            parameters[7].Value = model.flow_page;
            parameters[8].Value = model.flow_table;
            parameters[9].Value = model.flow_condition_flag;
            parameters[10].Value = model.flow_condition_content;
            parameters[11].Value = model.flow_status_en;
            parameters[12].Value = model.flow_status_cn;
            parameters[13].Value = model.flow_parallel_flag;
            parameters[14].Value = model.flow_current_status;
            parameters[15].Value = model.flow_last_start_date;
            parameters[16].Value = model.flow_condition_display_en;
            parameters[17].Value = model.flow_condition_display_cn;

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
        public bool Update(Workflow.Model.Sys_Flow_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Flow_Mstr set ");
            strSql.Append("flow_type=@flow_type,");
            strSql.Append("flow_location=@flow_location,");
            strSql.Append("flow_group=@flow_group,");
            strSql.Append("flow_seq=@flow_seq,");
            strSql.Append("flow_back_seq=@flow_back_seq,");
            strSql.Append("flow_level=@flow_level,");
            strSql.Append("flow_page=@flow_page,");
            strSql.Append("flow_table=@flow_table,");
            strSql.Append("flow_condition_flag=@flow_condition_flag,");
            strSql.Append("flow_condition_content=@flow_condition_content,");
            strSql.Append("flow_status_en=@flow_status_en,");
            strSql.Append("flow_status_cn=@flow_status_cn,");
            strSql.Append("flow_parallel_flag=@flow_parallel_flag,");
            strSql.Append("flow_current_status=@flow_current_status,");
            strSql.Append("flow_last_start_date=@flow_last_start_date,");
            strSql.Append("flow_condition_display_en=@flow_condition_display_en,");
            strSql.Append("flow_condition_display_cn=@flow_condition_display_cn");
            strSql.Append(" where flow_id=@flow_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int),
					new SqlParameter("@flow_back_seq", SqlDbType.Int),
					new SqlParameter("@flow_level", SqlDbType.Int),
					new SqlParameter("@flow_page", SqlDbType.NVarChar,500),
					new SqlParameter("@flow_table", SqlDbType.VarChar,20),
					new SqlParameter("@flow_condition_flag", SqlDbType.Char,1),
					new SqlParameter("@flow_condition_content", SqlDbType.NVarChar,1000),
					new SqlParameter("@flow_status_en", SqlDbType.NVarChar,200),
					new SqlParameter("@flow_status_cn", SqlDbType.NVarChar,200),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1),
					new SqlParameter("@flow_current_status", SqlDbType.Char,1),
					new SqlParameter("@flow_last_start_date", SqlDbType.DateTime),
					new SqlParameter("@flow_condition_display_en", SqlDbType.NVarChar,1000),
					new SqlParameter("@flow_condition_display_cn", SqlDbType.NVarChar,1000),
					new SqlParameter("@flow_id", SqlDbType.Int)};
            parameters[0].Value = model.flow_type;
            parameters[1].Value = model.flow_location;
            parameters[2].Value = model.flow_group;
            parameters[3].Value = model.flow_seq;
            parameters[4].Value = model.flow_back_seq;
            parameters[5].Value = model.flow_level;
            parameters[6].Value = model.flow_page;
            parameters[7].Value = model.flow_table;
            parameters[8].Value = model.flow_condition_flag;
            parameters[9].Value = model.flow_condition_content;
            parameters[10].Value = model.flow_status_en;
            parameters[11].Value = model.flow_status_cn;
            parameters[12].Value = model.flow_parallel_flag;
            parameters[13].Value = model.flow_current_status;
            parameters[14].Value = model.flow_last_start_date;
            parameters[15].Value = model.flow_condition_display_en;
            parameters[16].Value = model.flow_condition_display_cn;
            parameters[17].Value = model.flow_id;

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
        public bool Delete(int flow_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Flow_Mstr ");
            strSql.Append(" where flow_id=@flow_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@flow_id", SqlDbType.Int)			};
            parameters[0].Value = flow_id;

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
        public bool DeleteList(string flow_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Flow_Mstr ");
            strSql.Append(" where flow_id in (" + flow_idlist + ")  ");
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
        public Workflow.Model.Sys_Flow_Mstr_Model GetModel(int flow_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 flow_id,flow_type,flow_location,flow_group,flow_seq,flow_back_seq,flow_level,flow_page,flow_table,flow_condition_flag,flow_condition_content,flow_status_en,flow_status_cn,flow_parallel_flag,flow_current_status,flow_last_start_date,flow_condition_display_en,flow_condition_display_cn from Sys_Flow_Mstr ");
            strSql.Append(" where flow_id=@flow_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@flow_id", SqlDbType.Int)			};
            parameters[0].Value = flow_id;

            Workflow.Model.Sys_Flow_Mstr_Model model = new Workflow.Model.Sys_Flow_Mstr_Model();
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
        public Workflow.Model.Sys_Flow_Mstr_Model GetModel(string flow_location,int flow_seq,string flow_type)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 flow_id,flow_type,flow_location,flow_group,flow_seq,flow_back_seq,flow_level,flow_page,flow_table,flow_condition_flag,flow_condition_content,flow_status_en,flow_status_cn,flow_parallel_flag,flow_current_status,flow_last_start_date,flow_condition_display_en,flow_condition_display_cn from Sys_Flow_Mstr ");
            strSql.Append(" where flow_location=@flow_location ");
            strSql.Append(" and flow_seq=@flow_seq ");
            strSql.Append(" and flow_type=@flow_type ");
            SqlParameter[] parameters = {
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
                    new SqlParameter("@flow_seq", SqlDbType.Int),
            new SqlParameter("@flow_type", SqlDbType.NVarChar,20)};
            parameters[0].Value = flow_location;
            parameters[1].Value = flow_seq;
            parameters[2].Value = flow_type;
            Workflow.Model.Sys_Flow_Mstr_Model model = new Workflow.Model.Sys_Flow_Mstr_Model();
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
        public Workflow.Model.Sys_Flow_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Flow_Mstr_Model model = new Workflow.Model.Sys_Flow_Mstr_Model();
            if (row != null)
            {
                if (row["flow_id"] != null && row["flow_id"].ToString() != "")
                {
                    model.flow_id = int.Parse(row["flow_id"].ToString());
                }
                if (row["flow_type"] != null)
                {
                    model.flow_type = row["flow_type"].ToString();
                }
                if (row["flow_location"] != null)
                {
                    model.flow_location = row["flow_location"].ToString();
                }
                if (row["flow_group"] != null)
                {
                    model.flow_group = row["flow_group"].ToString();
                }
                if (row["flow_seq"] != null && row["flow_seq"].ToString() != "")
                {
                    model.flow_seq = int.Parse(row["flow_seq"].ToString());
                }
                if (row["flow_back_seq"] != null && row["flow_back_seq"].ToString() != "")
                {
                    model.flow_back_seq = int.Parse(row["flow_back_seq"].ToString());
                }
                if (row["flow_level"] != null && row["flow_level"].ToString() != "")
                {
                    model.flow_level = int.Parse(row["flow_level"].ToString());
                }
                if (row["flow_page"] != null)
                {
                    model.flow_page = row["flow_page"].ToString();
                }
                if (row["flow_table"] != null)
                {
                    model.flow_table = row["flow_table"].ToString();
                }
                if (row["flow_condition_flag"] != null)
                {
                    model.flow_condition_flag = row["flow_condition_flag"].ToString();
                }
                if (row["flow_condition_content"] != null)
                {
                    model.flow_condition_content = row["flow_condition_content"].ToString();
                }
                if (row["flow_status_en"] != null)
                {
                    model.flow_status_en = row["flow_status_en"].ToString();
                }
                if (row["flow_status_cn"] != null)
                {
                    model.flow_status_cn = row["flow_status_cn"].ToString();
                }
                if (row["flow_parallel_flag"] != null)
                {
                    model.flow_parallel_flag = row["flow_parallel_flag"].ToString();
                }
                if (row["flow_current_status"] != null)
                {
                    model.flow_current_status = row["flow_current_status"].ToString();
                }
                if (row["flow_last_start_date"] != null && row["flow_last_start_date"].ToString() != "")
                {
                    model.flow_last_start_date = DateTime.Parse(row["flow_last_start_date"].ToString());
                }
                if (row["flow_condition_display_en"] != null)
                {
                    model.flow_condition_display_en = row["flow_condition_display_en"].ToString();
                }
                if (row["flow_condition_display_cn"] != null)
                {
                    model.flow_condition_display_cn = row["flow_condition_display_cn"].ToString();
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
            strSql.Append("select flow_id,flow_type,flow_location,flow_group,flow_seq,flow_back_seq,flow_level,flow_page,flow_table,flow_condition_flag,flow_condition_content,flow_status_en,flow_status_cn,flow_parallel_flag,flow_current_status,flow_last_start_date,flow_condition_display_en,flow_condition_display_cn ");
            strSql.Append(" FROM Sys_Flow_Mstr ");
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
            strSql.Append(" flow_id,flow_type,flow_location,flow_group,flow_seq,flow_back_seq,flow_level,flow_page,flow_table,flow_condition_flag,flow_condition_content,flow_status_en,flow_status_cn,flow_parallel_flag,flow_current_status,flow_last_start_date,flow_condition_display_en,flow_condition_display_cn ");
            strSql.Append(" FROM Sys_Flow_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Flow_Mstr ");
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
                strSql.Append("order by T.flow_id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Flow_Mstr T ");
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
            parameters[0].Value = "Sys_Flow_Mstr";
            parameters[1].Value = "flow_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool ExistsCondition(string strContent,string strNbr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(strContent);
            strSql.Append("=@form_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@form_nbr", SqlDbType.VarChar,20)			};
            parameters[0].Value = strNbr;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public DataSet GetFlowStepInfo(string strWhere,string strLang)
        {
            
            StringBuilder strSql = new StringBuilder();
            if (strLang.Trim().ToUpper()=="CN")
            {
                strSql.Append("select distinct flow_type,flow_location,flow_seq,flow_back_seq,flow_condition_flag,flow_condition_content,flow_status_cn as status,flow_condition_display_cn as condition_display ");
            }
            else
            {
                strSql.Append("select distinct flow_type,flow_location,flow_seq,flow_back_seq,flow_condition_flag,flow_condition_content,flow_status_en as status,flow_condition_display_en as condition_display ");
            }
            
            strSql.Append(" FROM Sys_Flow_Mstr ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ORDER BY flow_seq");
            return DbHelperSQL.Query(strSql.ToString());
        }
        public Workflow.Model.Sys_Flow_Mstr_Model GetModel(string flow_type,string flow_location, string flow_seq)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 flow_id,flow_type,flow_location,flow_group,flow_seq,flow_back_seq,flow_level,flow_page,flow_table,flow_condition_flag,flow_condition_content,flow_status_en,flow_status_cn,flow_parallel_flag,flow_current_status,flow_last_start_date,flow_condition_display_en,flow_condition_display_cn from Sys_Flow_Mstr ");
            strSql.Append(" where flow_type=@flow_type ");
            strSql.Append(" and flow_location=@flow_location ");
            strSql.Append(" and flow_seq=@flow_seq ");
            SqlParameter[] parameters = {
                    new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
                    new SqlParameter("@flow_seq", SqlDbType.VarChar,10)};
            parameters[0].Value = flow_type;
            parameters[1].Value = flow_location;
            parameters[2].Value = flow_seq;
            Workflow.Model.Sys_Flow_Mstr_Model model = new Workflow.Model.Sys_Flow_Mstr_Model();
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
        #endregion  ExtensionMethod
    }
}

