using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Login_Record_Model
    /// </summary>
    public partial class Sys_Login_RecordDAL
    {
        public Sys_Login_RecordDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string login_user, string login_location, string login_ip, string login_hostname, string login_browser, DateTime login_date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Login_Record");
            strSql.Append(" where login_user=@login_user and login_location=@login_location and login_ip=@login_ip and login_hostname=@login_hostname and login_browser=@login_browser and login_date=@login_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@login_user", SqlDbType.VarChar,50),
					new SqlParameter("@login_location", SqlDbType.VarChar,20),
					new SqlParameter("@login_ip", SqlDbType.VarChar,20),
					new SqlParameter("@login_hostname", SqlDbType.VarChar,100),
					new SqlParameter("@login_browser", SqlDbType.VarChar,100),
					new SqlParameter("@login_date", SqlDbType.DateTime)			};
            parameters[0].Value = login_user;
            parameters[1].Value = login_location;
            parameters[2].Value = login_ip;
            parameters[3].Value = login_hostname;
            parameters[4].Value = login_browser;
            parameters[5].Value = login_date;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Login_Record_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Login_Record(");
            strSql.Append("login_user,login_location,login_ip,login_hostname,login_browser,login_date)");
            strSql.Append(" values (");
            strSql.Append("@login_user,@login_location,@login_ip,@login_hostname,@login_browser,@login_date)");
            SqlParameter[] parameters = {
					new SqlParameter("@login_user", SqlDbType.VarChar,50),
					new SqlParameter("@login_location", SqlDbType.VarChar,20),
					new SqlParameter("@login_ip", SqlDbType.VarChar,20),
					new SqlParameter("@login_hostname", SqlDbType.VarChar,100),
					new SqlParameter("@login_browser", SqlDbType.VarChar,100),
					new SqlParameter("@login_date", SqlDbType.DateTime)};
            parameters[0].Value = model.login_user;
            parameters[1].Value = model.login_location;
            parameters[2].Value = model.login_ip;
            parameters[3].Value = model.login_hostname;
            parameters[4].Value = model.login_browser;
            parameters[5].Value = model.login_date;

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
        public bool Update(Workflow.Model.Sys_Login_Record_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Login_Record set ");
            strSql.Append("login_user=@login_user,");
            strSql.Append("login_location=@login_location,");
            strSql.Append("login_ip=@login_ip,");
            strSql.Append("login_hostname=@login_hostname,");
            strSql.Append("login_browser=@login_browser,");
            strSql.Append("login_date=@login_date");
            strSql.Append(" where login_user=@login_user and login_location=@login_location and login_ip=@login_ip and login_hostname=@login_hostname and login_browser=@login_browser and login_date=@login_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@login_user", SqlDbType.VarChar,50),
					new SqlParameter("@login_location", SqlDbType.VarChar,20),
					new SqlParameter("@login_ip", SqlDbType.VarChar,20),
					new SqlParameter("@login_hostname", SqlDbType.VarChar,100),
					new SqlParameter("@login_browser", SqlDbType.VarChar,100),
					new SqlParameter("@login_date", SqlDbType.DateTime)};
            parameters[0].Value = model.login_user;
            parameters[1].Value = model.login_location;
            parameters[2].Value = model.login_ip;
            parameters[3].Value = model.login_hostname;
            parameters[4].Value = model.login_browser;
            parameters[5].Value = model.login_date;

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
        public bool Delete(string login_user, string login_location, string login_ip, string login_hostname, string login_browser, DateTime login_date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Login_Record ");
            strSql.Append(" where login_user=@login_user and login_location=@login_location and login_ip=@login_ip and login_hostname=@login_hostname and login_browser=@login_browser and login_date=@login_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@login_user", SqlDbType.VarChar,50),
					new SqlParameter("@login_location", SqlDbType.VarChar,20),
					new SqlParameter("@login_ip", SqlDbType.VarChar,20),
					new SqlParameter("@login_hostname", SqlDbType.VarChar,100),
					new SqlParameter("@login_browser", SqlDbType.VarChar,100),
					new SqlParameter("@login_date", SqlDbType.DateTime)			};
            parameters[0].Value = login_user;
            parameters[1].Value = login_location;
            parameters[2].Value = login_ip;
            parameters[3].Value = login_hostname;
            parameters[4].Value = login_browser;
            parameters[5].Value = login_date;

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
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Sys_Login_Record_Model GetModel(string login_user, string login_location, string login_ip, string login_hostname, string login_browser, DateTime login_date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 login_user,login_location,login_ip,login_hostname,login_browser,login_date from Sys_Login_Record ");
            strSql.Append(" where login_user=@login_user and login_location=@login_location and login_ip=@login_ip and login_hostname=@login_hostname and login_browser=@login_browser and login_date=@login_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@login_user", SqlDbType.VarChar,50),
					new SqlParameter("@login_location", SqlDbType.VarChar,20),
					new SqlParameter("@login_ip", SqlDbType.VarChar,20),
					new SqlParameter("@login_hostname", SqlDbType.VarChar,100),
					new SqlParameter("@login_browser", SqlDbType.VarChar,100),
					new SqlParameter("@login_date", SqlDbType.DateTime)			};
            parameters[0].Value = login_user;
            parameters[1].Value = login_location;
            parameters[2].Value = login_ip;
            parameters[3].Value = login_hostname;
            parameters[4].Value = login_browser;
            parameters[5].Value = login_date;

            Workflow.Model.Sys_Login_Record_Model model = new Workflow.Model.Sys_Login_Record_Model();
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
        public Workflow.Model.Sys_Login_Record_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Login_Record_Model model = new Workflow.Model.Sys_Login_Record_Model();
            if (row != null)
            {
                if (row["login_user"] != null)
                {
                    model.login_user = row["login_user"].ToString();
                }
                if (row["login_location"] != null)
                {
                    model.login_location = row["login_location"].ToString();
                }
                if (row["login_ip"] != null)
                {
                    model.login_ip = row["login_ip"].ToString();
                }
                if (row["login_hostname"] != null)
                {
                    model.login_hostname = row["login_hostname"].ToString();
                }
                if (row["login_browser"] != null)
                {
                    model.login_browser = row["login_browser"].ToString();
                }
                if (row["login_date"] != null && row["login_date"].ToString() != "")
                {
                    model.login_date = DateTime.Parse(row["login_date"].ToString());
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
            strSql.Append("select login_user,login_location,login_ip,login_hostname,login_browser,login_date ");
            strSql.Append(" FROM Sys_Login_Record ");
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
            strSql.Append(" login_user,login_location,login_ip,login_hostname,login_browser,login_date ");
            strSql.Append(" FROM Sys_Login_Record ");
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
            strSql.Append("select count(1) FROM Sys_Login_Record ");
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
                strSql.Append("order by T.login_date desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Login_Record T ");
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
            parameters[0].Value = "Sys_Login_Record";
            parameters[1].Value = "login_date";
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

