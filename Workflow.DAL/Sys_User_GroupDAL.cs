using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_User_Group_Model
    /// </summary>
    public partial class Sys_User_GroupDAL
    {
        public Sys_User_GroupDAL()
        { }
        #region  BasicMethod


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Workflow.Model.Sys_User_Group_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_User_Group(");
            strSql.Append("user_name,user_location,user_group,user_custom,user_readonly)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@user_location,@user_group,@user_custom,@user_readonly)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,50),
					new SqlParameter("@user_custom", SqlDbType.Char,1),
					new SqlParameter("@user_readonly", SqlDbType.Char,1)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_location;
            parameters[2].Value = model.user_group;
            parameters[3].Value = model.user_custom;
            parameters[4].Value = model.user_readonly;

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
        public bool Update(Workflow.Model.Sys_User_Group_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_User_Group set ");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_location=@user_location,");
            strSql.Append("user_group=@user_group,");
            strSql.Append("user_custom=@user_custom,");
            strSql.Append("user_readonly=@user_readonly");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,50),
					new SqlParameter("@user_custom", SqlDbType.Char,1),
					new SqlParameter("@user_readonly", SqlDbType.Char,1),
					new SqlParameter("@user_id", SqlDbType.Int,4)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_location;
            parameters[2].Value = model.user_group;
            parameters[3].Value = model.user_custom;
            parameters[4].Value = model.user_readonly;
            parameters[5].Value = model.user_id;

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
        public bool Delete(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_User_Group ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

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
        public bool DeleteList(string user_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_User_Group ");
            strSql.Append(" where user_id in (" + user_idlist + ")  ");
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
        public Workflow.Model.Sys_User_Group_Model GetModel(int user_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_id,user_name,user_location,user_group,user_custom,user_readonly from Sys_User_Group ");
            strSql.Append(" where user_id=@user_id");
            SqlParameter[] parameters = {
					new SqlParameter("@user_id", SqlDbType.Int,4)
			};
            parameters[0].Value = user_id;

            Workflow.Model.Sys_User_Group_Model model = new Workflow.Model.Sys_User_Group_Model();
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
        public Workflow.Model.Sys_User_Group_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_User_Group_Model model = new Workflow.Model.Sys_User_Group_Model();
            if (row != null)
            {
                if (row["user_id"] != null && row["user_id"].ToString() != "")
                {
                    model.user_id = int.Parse(row["user_id"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["user_location"] != null)
                {
                    model.user_location = row["user_location"].ToString();
                }
                if (row["user_group"] != null)
                {
                    model.user_group = row["user_group"].ToString();
                }
                if (row["user_custom"] != null)
                {
                    model.user_custom = row["user_custom"].ToString();
                }
                if (row["user_readonly"] != null)
                {
                    model.user_readonly = row["user_readonly"].ToString();
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
            strSql.Append("select user_id,user_name,user_location,user_group,user_custom,user_readonly ");
            strSql.Append(" FROM Sys_User_Group ");
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
            strSql.Append(" user_id,user_name,user_location,user_group,user_custom,user_readonly ");
            strSql.Append(" FROM Sys_User_Group ");
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
            strSql.Append("select count(1) FROM Sys_User_Group ");
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
                strSql.Append("order by T.user_id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_User_Group T ");
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
            parameters[0].Value = "Sys_User_Group";
            parameters[1].Value = "user_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool ExistsUserGroup(string user_name, string user_group)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_User_Group");
            strSql.Append(" where user_name=@user_name and user_group=@user_group ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_group", SqlDbType.VarChar,20)
		};
            parameters[0].Value = user_name;
            parameters[1].Value = user_group;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsUserGroupLocation(string user_name, string user_group,string user_location)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_User_Group");
            strSql.Append(" where user_name=@user_name and user_group=@user_group and user_location = @user_location ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_group", SqlDbType.VarChar,20),
                    new SqlParameter("@user_location", SqlDbType.VarChar,20)
		};
            parameters[0].Value = user_name;
            parameters[1].Value = user_group;
            parameters[2].Value = user_location;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

