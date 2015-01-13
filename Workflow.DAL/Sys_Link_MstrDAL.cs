using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Link_Mstr_Model
    /// </summary>
    public partial class Sys_Link_MstrDAL
    {
        public Sys_Link_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string link_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Link_Mstr,Sys_Code_Mstr");
            strSql.Append(" where code_cmmt='RESETPWD' and link_guid=@link_guid and link_effected='N' and datediff(mi,link_date,getdate())<=code_value ");
            SqlParameter[] parameters = {
					new SqlParameter("@link_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = link_guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Link_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Link_Mstr(");
            strSql.Append("link_guid,link_type,link_user,link_count,link_date,link_effected)");
            strSql.Append(" values (");
            strSql.Append("@link_guid,@link_type,@link_user,@link_count,@link_date,@link_effected)");
            SqlParameter[] parameters = {
					new SqlParameter("@link_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@link_type", SqlDbType.VarChar,20),
					new SqlParameter("@link_user", SqlDbType.VarChar,50),
					new SqlParameter("@link_count", SqlDbType.Int,4),
					new SqlParameter("@link_date", SqlDbType.DateTime),
					new SqlParameter("@link_effected", SqlDbType.Char,1)};
            parameters[0].Value = model.link_guid;
            parameters[1].Value = model.link_type;
            parameters[2].Value = model.link_user;
            parameters[3].Value = model.link_count;
            parameters[4].Value = model.link_date;
            parameters[5].Value = model.link_effected;

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
        public bool Update(Workflow.Model.Sys_Link_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Link_Mstr set ");
            strSql.Append("link_type=@link_type,");
            strSql.Append("link_user=@link_user,");
            strSql.Append("link_count=@link_count,");
            strSql.Append("link_date=@link_date,");
            strSql.Append("link_effected=@link_effected");
            strSql.Append(" where link_guid=@link_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@link_type", SqlDbType.VarChar,20),
					new SqlParameter("@link_user", SqlDbType.VarChar,50),
					new SqlParameter("@link_count", SqlDbType.Int,4),
					new SqlParameter("@link_date", SqlDbType.DateTime),
					new SqlParameter("@link_effected", SqlDbType.Char,1),
					new SqlParameter("@link_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.link_type;
            parameters[1].Value = model.link_user;
            parameters[2].Value = model.link_count;
            parameters[3].Value = model.link_date;
            parameters[4].Value = model.link_effected;
            parameters[5].Value = model.link_guid;

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
        public bool Delete(string link_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Link_Mstr ");
            strSql.Append(" where link_guid=@link_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@link_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = link_guid;

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
        public bool DeleteList(string link_guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Link_Mstr ");
            strSql.Append(" where link_guid in (" + link_guidlist + ")  ");
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
        public Workflow.Model.Sys_Link_Mstr_Model GetModel(string link_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 link_guid,link_type,link_user,link_count,link_date,link_effected from Sys_Link_Mstr ");
            strSql.Append(" where link_guid=@link_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@link_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = link_guid;

            Workflow.Model.Sys_Link_Mstr_Model model = new Workflow.Model.Sys_Link_Mstr_Model();
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
        public Workflow.Model.Sys_Link_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Link_Mstr_Model model = new Workflow.Model.Sys_Link_Mstr_Model();
            if (row != null)
            {
                if (row["link_guid"] != null)
                {
                    model.link_guid = row["link_guid"].ToString();
                }
                if (row["link_type"] != null)
                {
                    model.link_type = row["link_type"].ToString();
                }
                if (row["link_user"] != null)
                {
                    model.link_user = row["link_user"].ToString();
                }
                if (row["link_count"] != null && row["link_count"].ToString() != "")
                {
                    model.link_count = int.Parse(row["link_count"].ToString());
                }
                if (row["link_date"] != null && row["link_date"].ToString() != "")
                {
                    model.link_date = DateTime.Parse(row["link_date"].ToString());
                }
                if (row["link_effected"] != null)
                {
                    model.link_effected = row["link_effected"].ToString();
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
            strSql.Append("select link_guid,link_type,link_user,link_count,link_date,link_effected ");
            strSql.Append(" FROM Sys_Link_Mstr ");
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
            strSql.Append(" link_guid,link_type,link_user,link_count,link_date,link_effected ");
            strSql.Append(" FROM Sys_Link_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Link_Mstr ");
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
                strSql.Append("order by T.link_guid desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Link_Mstr T ");
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
            parameters[0].Value = "Sys_Link_Mstr";
            parameters[1].Value = "link_guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string ExecResetPwdProc(string strID, string strUser, string strLocation, string strType, string strIP, string strPassword)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Int),
                    new SqlParameter("@guid", SqlDbType.NVarChar, 50),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 20),
                    new SqlParameter("@ip", SqlDbType.VarChar,20),
                    new SqlParameter("@password", SqlDbType.VarChar,50)
                    };
            parameters[1].Value = strID;
            parameters[2].Value = strUser;
            parameters[3].Value = strLocation;
            parameters[4].Value = strType;
            parameters[5].Value = strIP;
            parameters[6].Value = strPassword;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_reset_passphrase]", parameters);
            return parameters[0].Value.ToString();
        }
        public string ExecResetPwdApplyProc(string strID, string strUser, string strLocation, string strType, string strIP)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Int),
                    new SqlParameter("@guid", SqlDbType.NVarChar, 50),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@location", SqlDbType.VarChar, 20),
                    new SqlParameter("@type", SqlDbType.VarChar, 20),
                    new SqlParameter("@ip", SqlDbType.VarChar,20)
                    };
            parameters[1].Value = strID;
            parameters[2].Value = strUser;
            parameters[3].Value = strLocation;
            parameters[4].Value = strType;
            parameters[5].Value = strIP;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_reset_passphrase_apply]", parameters);
            return parameters[0].Value.ToString();
        }
        #endregion  ExtensionMethod
    }
}

