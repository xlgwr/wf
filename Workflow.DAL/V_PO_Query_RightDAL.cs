using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{

    public partial class V_PO_Query_RightDAL
    {
        public V_PO_Query_RightDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string right_user, string right_nbr, string right_location, string right_guid, int right_seq, string right_type, string right_buyer, DateTime right_date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from V_PO_Query_Right");
            strSql.Append(" where right_user=@right_user and right_nbr=@right_nbr and right_location=@right_location and right_guid=@right_guid and right_seq=@right_seq and right_type=@right_type and right_buyer=@right_buyer and right_date=@right_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@right_user", SqlDbType.VarChar,50),
					new SqlParameter("@right_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@right_location", SqlDbType.VarChar,20),
					new SqlParameter("@right_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@right_seq", SqlDbType.Int,4),
					new SqlParameter("@right_type", SqlDbType.VarChar,20),
					new SqlParameter("@right_buyer", SqlDbType.VarChar,30),
					new SqlParameter("@right_date", SqlDbType.DateTime)			};
            parameters[0].Value = right_user;
            parameters[1].Value = right_nbr;
            parameters[2].Value = right_location;
            parameters[3].Value = right_guid;
            parameters[4].Value = right_seq;
            parameters[5].Value = right_type;
            parameters[6].Value = right_buyer;
            parameters[7].Value = right_date;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.V_PO_Query_Right_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into V_PO_Query_Right(");
            strSql.Append("right_user,right_nbr,right_location,right_guid,right_seq,right_type,right_buyer,right_date)");
            strSql.Append(" values (");
            strSql.Append("@right_user,@right_nbr,@right_location,@right_guid,@right_seq,@right_type,@right_buyer,@right_date)");
            SqlParameter[] parameters = {
					new SqlParameter("@right_user", SqlDbType.VarChar,50),
					new SqlParameter("@right_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@right_location", SqlDbType.VarChar,20),
					new SqlParameter("@right_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@right_seq", SqlDbType.Int,4),
					new SqlParameter("@right_type", SqlDbType.VarChar,20),
					new SqlParameter("@right_buyer", SqlDbType.VarChar,30),
					new SqlParameter("@right_date", SqlDbType.DateTime)};
            parameters[0].Value = model.right_user;
            parameters[1].Value = model.right_nbr;
            parameters[2].Value = model.right_location;
            parameters[3].Value = model.right_guid;
            parameters[4].Value = model.right_seq;
            parameters[5].Value = model.right_type;
            parameters[6].Value = model.right_buyer;
            parameters[7].Value = model.right_date;

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
        public bool Update(Workflow.Model.V_PO_Query_Right_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update V_PO_Query_Right set ");
            strSql.Append("right_user=@right_user,");
            strSql.Append("right_nbr=@right_nbr,");
            strSql.Append("right_location=@right_location,");
            strSql.Append("right_guid=@right_guid,");
            strSql.Append("right_seq=@right_seq,");
            strSql.Append("right_type=@right_type,");
            strSql.Append("right_buyer=@right_buyer,");
            strSql.Append("right_date=@right_date");
            strSql.Append(" where right_user=@right_user and right_nbr=@right_nbr and right_location=@right_location and right_guid=@right_guid and right_seq=@right_seq and right_type=@right_type and right_buyer=@right_buyer and right_date=@right_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@right_user", SqlDbType.VarChar,50),
					new SqlParameter("@right_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@right_location", SqlDbType.VarChar,20),
					new SqlParameter("@right_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@right_seq", SqlDbType.Int,4),
					new SqlParameter("@right_type", SqlDbType.VarChar,20),
					new SqlParameter("@right_buyer", SqlDbType.VarChar,30),
					new SqlParameter("@right_date", SqlDbType.DateTime)};
            parameters[0].Value = model.right_user;
            parameters[1].Value = model.right_nbr;
            parameters[2].Value = model.right_location;
            parameters[3].Value = model.right_guid;
            parameters[4].Value = model.right_seq;
            parameters[5].Value = model.right_type;
            parameters[6].Value = model.right_buyer;
            parameters[7].Value = model.right_date;

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
        public bool Delete(string right_user, string right_nbr, string right_location, string right_guid, int right_seq, string right_type, string right_buyer, DateTime right_date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from V_PO_Query_Right ");
            strSql.Append(" where right_user=@right_user and right_nbr=@right_nbr and right_location=@right_location and right_guid=@right_guid and right_seq=@right_seq and right_type=@right_type and right_buyer=@right_buyer and right_date=@right_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@right_user", SqlDbType.VarChar,50),
					new SqlParameter("@right_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@right_location", SqlDbType.VarChar,20),
					new SqlParameter("@right_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@right_seq", SqlDbType.Int,4),
					new SqlParameter("@right_type", SqlDbType.VarChar,20),
					new SqlParameter("@right_buyer", SqlDbType.VarChar,30),
					new SqlParameter("@right_date", SqlDbType.DateTime)			};
            parameters[0].Value = right_user;
            parameters[1].Value = right_nbr;
            parameters[2].Value = right_location;
            parameters[3].Value = right_guid;
            parameters[4].Value = right_seq;
            parameters[5].Value = right_type;
            parameters[6].Value = right_buyer;
            parameters[7].Value = right_date;

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
        public Workflow.Model.V_PO_Query_Right_Model GetModel(string right_user, string right_nbr, string right_location, string right_guid, int right_seq, string right_type, string right_buyer, DateTime right_date)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 right_user,right_nbr,right_location,right_guid,right_seq,right_type,right_buyer,right_date from V_PO_Query_Right ");
            strSql.Append(" where right_user=@right_user and right_nbr=@right_nbr and right_location=@right_location and right_guid=@right_guid and right_seq=@right_seq and right_type=@right_type and right_buyer=@right_buyer and right_date=@right_date ");
            SqlParameter[] parameters = {
					new SqlParameter("@right_user", SqlDbType.VarChar,50),
					new SqlParameter("@right_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@right_location", SqlDbType.VarChar,20),
					new SqlParameter("@right_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@right_seq", SqlDbType.Int,4),
					new SqlParameter("@right_type", SqlDbType.VarChar,20),
					new SqlParameter("@right_buyer", SqlDbType.VarChar,30),
					new SqlParameter("@right_date", SqlDbType.DateTime)			};
            parameters[0].Value = right_user;
            parameters[1].Value = right_nbr;
            parameters[2].Value = right_location;
            parameters[3].Value = right_guid;
            parameters[4].Value = right_seq;
            parameters[5].Value = right_type;
            parameters[6].Value = right_buyer;
            parameters[7].Value = right_date;

            Workflow.Model.V_PO_Query_Right_Model model = new Workflow.Model.V_PO_Query_Right_Model();
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
        public Workflow.Model.V_PO_Query_Right_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.V_PO_Query_Right_Model model = new Workflow.Model.V_PO_Query_Right_Model();
            if (row != null)
            {
                if (row["right_user"] != null)
                {
                    model.right_user = row["right_user"].ToString();
                }
                if (row["right_nbr"] != null)
                {
                    model.right_nbr = row["right_nbr"].ToString();
                }
                if (row["right_location"] != null)
                {
                    model.right_location = row["right_location"].ToString();
                }
                if (row["right_guid"] != null)
                {
                    model.right_guid = row["right_guid"].ToString();
                }
                if (row["right_seq"] != null && row["right_seq"].ToString() != "")
                {
                    model.right_seq = int.Parse(row["right_seq"].ToString());
                }
                if (row["right_type"] != null)
                {
                    model.right_type = row["right_type"].ToString();
                }
                if (row["right_buyer"] != null)
                {
                    model.right_buyer = row["right_buyer"].ToString();
                }
                if (row["right_date"] != null && row["right_date"].ToString() != "")
                {
                    model.right_date = DateTime.Parse(row["right_date"].ToString());
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
            strSql.Append("select right_user,right_nbr,right_location,right_guid,right_seq,right_type,right_buyer,right_date ");
            strSql.Append(" FROM V_PO_Query_Right ");
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
            strSql.Append(" right_user,right_nbr,right_location,right_guid,right_seq,right_type,right_buyer,right_date ");
            strSql.Append(" FROM V_PO_Query_Right ");
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
            strSql.Append("select count(1) FROM V_PO_Query_Right ");
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
                strSql.Append("order by T.right_date desc");
            }
            strSql.Append(")AS Row, T.*  from V_PO_Query_Right T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool Exists(string right_user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from V_PO_Query_Right");
            strSql.Append(" where right_user=@right_user ");
            SqlParameter[] parameters = {
					new SqlParameter("@right_user", SqlDbType.VarChar,50),
						};
            parameters[0].Value = right_user;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        #endregion  ExtensionMethod
    }
}

