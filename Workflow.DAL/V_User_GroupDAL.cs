using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:V_User_Group_Model
    /// </summary>
    public partial class V_User_GroupDAL
    {
        public V_User_GroupDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string user_name, string user_dept, string flow_location, string flow_type, string user_group, string user_custom, string flow_group, int flow_seq, int flow_level, string flow_parallel_flag)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from V_User_Group");
            strSql.Append(" where user_name=@user_name and user_dept=@user_dept and flow_location=@flow_location and flow_type=@flow_type and user_group=@user_group and user_custom=@user_custom and flow_group=@flow_group and flow_seq=@flow_seq and flow_level=@flow_level and flow_parallel_flag=@flow_parallel_flag ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_dept", SqlDbType.NVarChar,50),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,20),
					new SqlParameter("@user_custom", SqlDbType.VarChar,1),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int,4),
					new SqlParameter("@flow_level", SqlDbType.Int,4),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1)			};
            parameters[0].Value = user_name;
            parameters[1].Value = user_dept;
            parameters[2].Value = flow_location;
            parameters[3].Value = flow_type;
            parameters[4].Value = user_group;
            parameters[5].Value = user_custom;
            parameters[6].Value = flow_group;
            parameters[7].Value = flow_seq;
            parameters[8].Value = flow_level;
            parameters[9].Value = flow_parallel_flag;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool ExistsUserGroup(string user_name ,string user_group)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from V_User_Group");
            strSql.Append(" where user_name=@user_name and user_group=@user_group ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_group", SqlDbType.VarChar,20)
		};
            parameters[0].Value = user_name;
            parameters[1].Value = user_group;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.V_User_Group_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into V_User_Group(");
            strSql.Append("user_name,user_dept,flow_location,flow_type,user_group,user_custom,flow_group,flow_seq,flow_level,flow_parallel_flag)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@user_dept,@flow_location,@flow_type,@user_group,@user_custom,@flow_group,@flow_seq,@flow_level,@flow_parallel_flag)");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_dept", SqlDbType.NVarChar,50),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,20),
					new SqlParameter("@user_custom", SqlDbType.VarChar,1),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int,4),
					new SqlParameter("@flow_level", SqlDbType.Int,4),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_dept;
            parameters[2].Value = model.flow_location;
            parameters[3].Value = model.flow_type;
            parameters[4].Value = model.user_group;
            parameters[5].Value = model.user_custom;
            parameters[6].Value = model.flow_group;
            parameters[7].Value = model.flow_seq;
            parameters[8].Value = model.flow_level;
            parameters[9].Value = model.flow_parallel_flag;

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
        public bool Update(Workflow.Model.V_User_Group_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update V_User_Group set ");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_dept=@user_dept,");
            strSql.Append("flow_location=@flow_location,");
            strSql.Append("flow_type=@flow_type,");
            strSql.Append("user_group=@user_group,");
            strSql.Append("user_custom=@user_custom,");
            strSql.Append("flow_group=@flow_group,");
            strSql.Append("flow_seq=@flow_seq,");
            strSql.Append("flow_level=@flow_level,");
            strSql.Append("flow_parallel_flag=@flow_parallel_flag");
            strSql.Append(" where user_name=@user_name and user_dept=@user_dept and flow_location=@flow_location and flow_type=@flow_type and user_group=@user_group and user_custom=@user_custom and flow_group=@flow_group and flow_seq=@flow_seq and flow_level=@flow_level and flow_parallel_flag=@flow_parallel_flag ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_dept", SqlDbType.NVarChar,50),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,20),
					new SqlParameter("@user_custom", SqlDbType.VarChar,1),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int,4),
					new SqlParameter("@flow_level", SqlDbType.Int,4),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_dept;
            parameters[2].Value = model.flow_location;
            parameters[3].Value = model.flow_type;
            parameters[4].Value = model.user_group;
            parameters[5].Value = model.user_custom;
            parameters[6].Value = model.flow_group;
            parameters[7].Value = model.flow_seq;
            parameters[8].Value = model.flow_level;
            parameters[9].Value = model.flow_parallel_flag;

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
        public bool Delete(string user_name, string user_dept, string flow_location, string flow_type, string user_group, string user_custom, string flow_group, int flow_seq, int flow_level, string flow_parallel_flag)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from V_User_Group ");
            strSql.Append(" where user_name=@user_name and user_dept=@user_dept and flow_location=@flow_location and flow_type=@flow_type and user_group=@user_group and user_custom=@user_custom and flow_group=@flow_group and flow_seq=@flow_seq and flow_level=@flow_level and flow_parallel_flag=@flow_parallel_flag ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_dept", SqlDbType.NVarChar,50),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,20),
					new SqlParameter("@user_custom", SqlDbType.VarChar,1),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int,4),
					new SqlParameter("@flow_level", SqlDbType.Int,4),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1)			};
            parameters[0].Value = user_name;
            parameters[1].Value = user_dept;
            parameters[2].Value = flow_location;
            parameters[3].Value = flow_type;
            parameters[4].Value = user_group;
            parameters[5].Value = user_custom;
            parameters[6].Value = flow_group;
            parameters[7].Value = flow_seq;
            parameters[8].Value = flow_level;
            parameters[9].Value = flow_parallel_flag;

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
        public Workflow.Model.V_User_Group_Model GetModel(string user_name, string user_dept, string flow_location, string flow_type, string user_group, string user_custom, string flow_group, int flow_seq, int flow_level, string flow_parallel_flag)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_name,user_dept,flow_location,flow_type,user_group,user_custom,flow_group,flow_seq,flow_level,flow_parallel_flag from V_User_Group ");
            strSql.Append(" where user_name=@user_name and user_dept=@user_dept and flow_location=@flow_location and flow_type=@flow_type and user_group=@user_group and user_custom=@user_custom and flow_group=@flow_group and flow_seq=@flow_seq and flow_level=@flow_level and flow_parallel_flag=@flow_parallel_flag ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_dept", SqlDbType.NVarChar,50),
					new SqlParameter("@flow_location", SqlDbType.VarChar,20),
					new SqlParameter("@flow_type", SqlDbType.VarChar,20),
					new SqlParameter("@user_group", SqlDbType.VarChar,20),
					new SqlParameter("@user_custom", SqlDbType.VarChar,1),
					new SqlParameter("@flow_group", SqlDbType.VarChar,20),
					new SqlParameter("@flow_seq", SqlDbType.Int,4),
					new SqlParameter("@flow_level", SqlDbType.Int,4),
					new SqlParameter("@flow_parallel_flag", SqlDbType.Char,1)			};
            parameters[0].Value = user_name;
            parameters[1].Value = user_dept;
            parameters[2].Value = flow_location;
            parameters[3].Value = flow_type;
            parameters[4].Value = user_group;
            parameters[5].Value = user_custom;
            parameters[6].Value = flow_group;
            parameters[7].Value = flow_seq;
            parameters[8].Value = flow_level;
            parameters[9].Value = flow_parallel_flag;

            Workflow.Model.V_User_Group_Model model = new Workflow.Model.V_User_Group_Model();
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
        public Workflow.Model.V_User_Group_Model GetModel(string user_name, string user_dept)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_name,user_dept,flow_location,flow_type,user_group,user_custom,flow_group,flow_seq,flow_level,flow_parallel_flag from V_User_Group ");
            strSql.Append(" where user_name=@user_name and user_dept=@user_dept");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_dept", SqlDbType.NVarChar,50)
						};
            parameters[0].Value = user_name;
            parameters[1].Value = user_dept;
          

            Workflow.Model.V_User_Group_Model model = new Workflow.Model.V_User_Group_Model();
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
        public Workflow.Model.V_User_Group_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.V_User_Group_Model model = new Workflow.Model.V_User_Group_Model();
            if (row != null)
            {
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["user_dept"] != null)
                {
                    model.user_dept = row["user_dept"].ToString();
                }
                if (row["flow_location"] != null)
                {
                    model.flow_location = row["flow_location"].ToString();
                }
                if (row["flow_type"] != null)
                {
                    model.flow_type = row["flow_type"].ToString();
                }
                if (row["user_group"] != null)
                {
                    model.user_group = row["user_group"].ToString();
                }
                if (row["user_custom"] != null)
                {
                    model.user_custom = row["user_custom"].ToString();
                }
                if (row["flow_group"] != null)
                {
                    model.flow_group = row["flow_group"].ToString();
                }
                if (row["flow_seq"] != null && row["flow_seq"].ToString() != "")
                {
                    model.flow_seq = int.Parse(row["flow_seq"].ToString());
                }
                if (row["flow_level"] != null && row["flow_level"].ToString() != "")
                {
                    model.flow_level = int.Parse(row["flow_level"].ToString());
                }
                if (row["flow_parallel_flag"] != null)
                {
                    model.flow_parallel_flag = row["flow_parallel_flag"].ToString();
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
            strSql.Append("select user_name,user_dept,flow_location,flow_type,user_group,user_custom,flow_group,flow_seq,flow_level,flow_parallel_flag ");
            strSql.Append(" FROM V_User_Group ");
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
            strSql.Append(" user_name,user_dept,flow_location,flow_type,user_group,user_custom,flow_group,flow_seq,flow_level,flow_parallel_flag ");
            strSql.Append(" FROM V_User_Group ");
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
            strSql.Append("select count(1) FROM V_User_Group ");
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
                strSql.Append("order by T.flow_parallel_flag desc");
            }
            strSql.Append(")AS Row, T.*  from V_User_Group T ");
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
            parameters[0].Value = "V_User_Group";
            parameters[1].Value = "flow_parallel_flag";
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

