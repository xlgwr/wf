using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_UserPP_Right_Model
    /// </summary>
    public partial class Cus_UserPP_RightDAL
    {
        public Cus_UserPP_RightDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string user_group, string user_site, string user_part_Fr, string user_part_to, string user_id, string user_name, string user_location, string user_mail, string user_act_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_UserPP_Right");
            strSql.Append(" where user_group=@user_group and user_site=@user_site and user_part_Fr=@user_part_Fr and user_part_to=@user_part_to and user_id=@user_id and user_name=@user_name and user_location=@user_location and user_mail=@user_mail and user_act_name=@user_act_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_group", SqlDbType.Char,10),
					new SqlParameter("@user_site", SqlDbType.Char,10),
					new SqlParameter("@user_part_Fr", SqlDbType.Char,10),
					new SqlParameter("@user_part_to", SqlDbType.Char,10),
					new SqlParameter("@user_id", SqlDbType.Char,10),
					new SqlParameter("@user_name", SqlDbType.Char,20),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_mail", SqlDbType.VarChar,50),
					new SqlParameter("@user_act_name", SqlDbType.Char,20)			};
            parameters[0].Value = user_group;
            parameters[1].Value = user_site;
            parameters[2].Value = user_part_Fr;
            parameters[3].Value = user_part_to;
            parameters[4].Value = user_id;
            parameters[5].Value = user_name;
            parameters[6].Value = user_location;
            parameters[7].Value = user_mail;
            parameters[8].Value = user_act_name;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_UserPP_Right_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_UserPP_Right(");
            strSql.Append("user_group,user_site,user_part_Fr,user_part_to,user_id,user_name,user_location,user_mail,user_act_name)");
            strSql.Append(" values (");
            strSql.Append("@user_group,@user_site,@user_part_Fr,@user_part_to,@user_id,@user_name,@user_location,@user_mail,@user_act_name)");
            SqlParameter[] parameters = {
					new SqlParameter("@user_group", SqlDbType.Char,10),
					new SqlParameter("@user_site", SqlDbType.Char,10),
					new SqlParameter("@user_part_Fr", SqlDbType.Char,10),
					new SqlParameter("@user_part_to", SqlDbType.Char,10),
					new SqlParameter("@user_id", SqlDbType.Char,10),
					new SqlParameter("@user_name", SqlDbType.Char,20),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_mail", SqlDbType.VarChar,50),
					new SqlParameter("@user_act_name", SqlDbType.Char,20)};
            parameters[0].Value = model.user_group;
            parameters[1].Value = model.user_site;
            parameters[2].Value = model.user_part_Fr;
            parameters[3].Value = model.user_part_to;
            parameters[4].Value = model.user_id;
            parameters[5].Value = model.user_name;
            parameters[6].Value = model.user_location;
            parameters[7].Value = model.user_mail;
            parameters[8].Value = model.user_act_name;

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
        public bool Update(Workflow.Model.Cus_UserPP_Right_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_UserPP_Right set ");
            strSql.Append("user_group=@user_group,");
            strSql.Append("user_site=@user_site,");
            strSql.Append("user_part_Fr=@user_part_Fr,");
            strSql.Append("user_part_to=@user_part_to,");
            strSql.Append("user_id=@user_id,");
            strSql.Append("user_name=@user_name,");
            strSql.Append("user_location=@user_location,");
            strSql.Append("user_mail=@user_mail,");
            strSql.Append("user_act_name=@user_act_name");
            strSql.Append(" where user_group=@user_group and user_site=@user_site and user_part_Fr=@user_part_Fr and user_part_to=@user_part_to and user_id=@user_id and user_name=@user_name and user_location=@user_location and user_mail=@user_mail and user_act_name=@user_act_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_group", SqlDbType.Char,10),
					new SqlParameter("@user_site", SqlDbType.Char,10),
					new SqlParameter("@user_part_Fr", SqlDbType.Char,10),
					new SqlParameter("@user_part_to", SqlDbType.Char,10),
					new SqlParameter("@user_id", SqlDbType.Char,10),
					new SqlParameter("@user_name", SqlDbType.Char,20),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_mail", SqlDbType.VarChar,50),
					new SqlParameter("@user_act_name", SqlDbType.Char,20)};
            parameters[0].Value = model.user_group;
            parameters[1].Value = model.user_site;
            parameters[2].Value = model.user_part_Fr;
            parameters[3].Value = model.user_part_to;
            parameters[4].Value = model.user_id;
            parameters[5].Value = model.user_name;
            parameters[6].Value = model.user_location;
            parameters[7].Value = model.user_mail;
            parameters[8].Value = model.user_act_name;

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
        public bool Delete(string user_group, string user_site, string user_part_Fr, string user_part_to, string user_id, string user_name, string user_location, string user_mail, string user_act_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_UserPP_Right ");
            strSql.Append(" where user_group=@user_group and user_site=@user_site and user_part_Fr=@user_part_Fr and user_part_to=@user_part_to and user_id=@user_id and user_name=@user_name and user_location=@user_location and user_mail=@user_mail and user_act_name=@user_act_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_group", SqlDbType.Char,10),
					new SqlParameter("@user_site", SqlDbType.Char,10),
					new SqlParameter("@user_part_Fr", SqlDbType.Char,10),
					new SqlParameter("@user_part_to", SqlDbType.Char,10),
					new SqlParameter("@user_id", SqlDbType.Char,10),
					new SqlParameter("@user_name", SqlDbType.Char,20),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_mail", SqlDbType.VarChar,50),
					new SqlParameter("@user_act_name", SqlDbType.Char,20)			};
            parameters[0].Value = user_group;
            parameters[1].Value = user_site;
            parameters[2].Value = user_part_Fr;
            parameters[3].Value = user_part_to;
            parameters[4].Value = user_id;
            parameters[5].Value = user_name;
            parameters[6].Value = user_location;
            parameters[7].Value = user_mail;
            parameters[8].Value = user_act_name;

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
        public Workflow.Model.Cus_UserPP_Right_Model GetModel(string user_group, string user_site, string user_part_Fr, string user_part_to, string user_id, string user_name, string user_location, string user_mail, string user_act_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_group,user_site,user_part_Fr,user_part_to,user_id,user_name,user_location,user_mail,user_act_name from Cus_UserPP_Right ");
            strSql.Append(" where user_group=@user_group and user_site=@user_site and user_part_Fr=@user_part_Fr and user_part_to=@user_part_to and user_id=@user_id and user_name=@user_name and user_location=@user_location and user_mail=@user_mail and user_act_name=@user_act_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_group", SqlDbType.Char,10),
					new SqlParameter("@user_site", SqlDbType.Char,10),
					new SqlParameter("@user_part_Fr", SqlDbType.Char,10),
					new SqlParameter("@user_part_to", SqlDbType.Char,10),
					new SqlParameter("@user_id", SqlDbType.Char,10),
					new SqlParameter("@user_name", SqlDbType.Char,20),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_mail", SqlDbType.VarChar,50),
					new SqlParameter("@user_act_name", SqlDbType.Char,20)			};
            parameters[0].Value = user_group;
            parameters[1].Value = user_site;
            parameters[2].Value = user_part_Fr;
            parameters[3].Value = user_part_to;
            parameters[4].Value = user_id;
            parameters[5].Value = user_name;
            parameters[6].Value = user_location;
            parameters[7].Value = user_mail;
            parameters[8].Value = user_act_name;

            Workflow.Model.Cus_UserPP_Right_Model model = new Workflow.Model.Cus_UserPP_Right_Model();
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
        public Workflow.Model.Cus_UserPP_Right_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_UserPP_Right_Model model = new Workflow.Model.Cus_UserPP_Right_Model();
            if (row != null)
            {
                if (row["user_group"] != null)
                {
                    model.user_group = row["user_group"].ToString();
                }
                if (row["user_site"] != null)
                {
                    model.user_site = row["user_site"].ToString();
                }
                if (row["user_part_Fr"] != null)
                {
                    model.user_part_Fr = row["user_part_Fr"].ToString();
                }
                if (row["user_part_to"] != null)
                {
                    model.user_part_to = row["user_part_to"].ToString();
                }
                if (row["user_id"] != null)
                {
                    model.user_id = row["user_id"].ToString();
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["user_location"] != null)
                {
                    model.user_location = row["user_location"].ToString();
                }
                if (row["user_mail"] != null)
                {
                    model.user_mail = row["user_mail"].ToString();
                }
                if (row["user_act_name"] != null)
                {
                    model.user_act_name = row["user_act_name"].ToString();
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
            strSql.Append("select user_group,user_site,user_part_Fr,user_part_to,user_id,user_name,user_location,user_mail,user_act_name ");
            strSql.Append(" FROM Cus_UserPP_Right ");
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
            strSql.Append(" user_group,user_site,user_part_Fr,user_part_to,user_id,user_name,user_location,user_mail,user_act_name ");
            strSql.Append(" FROM Cus_UserPP_Right ");
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
            strSql.Append("select count(1) FROM Cus_UserPP_Right ");
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
                strSql.Append("order by T.user_act_name desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_UserPP_Right T ");
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
            parameters[0].Value = "Cus_UserPP_Right";
            parameters[1].Value = "user_act_name";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool ExistsPP(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_UserPP_Right");
            strSql.Append(" where user_name = @user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.Char,50)			};
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

