using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Attach_MstrDAL
    /// </summary>
    public partial class Sys_Attach_MstrDAL
    {
        public Sys_Attach_MstrDAL()
        { }
        #region  BasicMethod

        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("attach_id", "Sys_Attach_Mstr");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int attach_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Attach_Mstr");
            strSql.Append(" where attach_id=@attach_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int)			};
            parameters[0].Value = attach_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Attach_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Attach_Mstr(");
            strSql.Append("attach_nbr,attach_location,attach_type,attach_title,attach_path,attach_user,attach_time,attach_guid,attach_rmk1,attach_rmk2,attach_rmk3)");
            strSql.Append(" values (");
            strSql.Append("@attach_nbr,@attach_location,@attach_type,@attach_title,@attach_path,@attach_user,@attach_time,@attach_guid,@attach_rmk1,@attach_rmk2,@attach_rmk3)");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@attach_location", SqlDbType.VarChar,20),
					new SqlParameter("@attach_type", SqlDbType.VarChar,50),
					new SqlParameter("@attach_title", SqlDbType.VarChar,100),
					new SqlParameter("@attach_path", SqlDbType.VarChar,100),
                    new SqlParameter("@attach_user", SqlDbType.VarChar,50),
					new SqlParameter("@attach_time", SqlDbType.DateTime),
            new SqlParameter("@attach_guid", SqlDbType.NVarChar,50),
            new SqlParameter("@attach_rmk1", SqlDbType.NVarChar,200),
            new SqlParameter("@attach_rmk2", SqlDbType.NVarChar,200),
            new SqlParameter("@attach_rmk3", SqlDbType.NVarChar,200)
                                        };
            parameters[0].Value = model.attach_nbr;
            parameters[1].Value = model.attach_location;
            parameters[2].Value = model.attach_type;
            parameters[3].Value = model.attach_title;
            parameters[4].Value = model.attach_path;
            parameters[5].Value = model.attach_user;
            parameters[6].Value = model.attach_time;
            parameters[7].Value = model.attach_guid;
            parameters[8].Value = model.attach_rmk1;
            parameters[9].Value = model.attach_rmk2;
            parameters[10].Value = model.attach_rmk3;

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
        public bool Update(Workflow.Model.Sys_Attach_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Attach_Mstr set ");
            strSql.Append("attach_nbr=@attach_nbr,");
            strSql.Append("attach_location=@attach_location,");
            strSql.Append("attach_type=@attach_type,");
            strSql.Append("attach_title=@attach_title,");
            strSql.Append("attach_path=@attach_path,");
            strSql.Append("attach_user=@attach_user,");
            strSql.Append("attach_time=@attach_time");
            strSql.Append("attach_guid=@attach_guid");
            strSql.Append(" where attach_id=@attach_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@attach_location", SqlDbType.VarChar,20),
					new SqlParameter("@attach_type", SqlDbType.VarChar,50),
					new SqlParameter("@attach_title", SqlDbType.VarChar,100),
					new SqlParameter("@attach_path", SqlDbType.VarChar,100),
                    new SqlParameter("@attach_user", SqlDbType.VarChar,50),
					new SqlParameter("@attach_time", SqlDbType.DateTime),
                    new SqlParameter("@attach_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@attach_id", SqlDbType.Int)};
            parameters[0].Value = model.attach_nbr;
            parameters[1].Value = model.attach_location;
            parameters[2].Value = model.attach_type;
            parameters[3].Value = model.attach_title;
            parameters[4].Value = model.attach_path;
            parameters[5].Value = model.attach_user;
            parameters[6].Value = model.attach_time;
            parameters[7].Value = model.attach_guid;
            parameters[8].Value = model.attach_id;

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
        public bool Delete(int attach_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Attach_Mstr ");
            strSql.Append(" where attach_id=@attach_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int)			};
            parameters[0].Value = attach_id;

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
        public bool DeleteList(string attach_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Attach_Mstr ");
            strSql.Append(" where attach_id in (" + attach_idlist + ")  ");
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
        public Workflow.Model.Sys_Attach_Mstr_Model GetModel(int attach_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 attach_guid,attach_id,attach_nbr,attach_location,attach_type,attach_title,attach_path,attach_user,attach_time,attach_rmk1,attach_rmk2,attach_rmk3 from Sys_Attach_Mstr ");
            strSql.Append(" where attach_id=@attach_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_id", SqlDbType.Int)			};
            parameters[0].Value = attach_id;

            Workflow.Model.Sys_Attach_Mstr_Model model = new Workflow.Model.Sys_Attach_Mstr_Model();
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
        public Workflow.Model.Sys_Attach_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Attach_Mstr_Model model = new Workflow.Model.Sys_Attach_Mstr_Model();
            if (row != null)
            {
                if (row["attach_id"] != null && row["attach_id"].ToString() != "")
                {
                    model.attach_id = int.Parse(row["attach_id"].ToString());
                }
                if (row["attach_nbr"] != null)
                {
                    model.attach_nbr = row["attach_nbr"].ToString();
                }
                if (row["attach_location"] != null)
                {
                    model.attach_location = row["attach_location"].ToString();
                }
                if (row["attach_type"] != null)
                {
                    model.attach_type = row["attach_type"].ToString();
                }
                if (row["attach_title"] != null)
                {
                    model.attach_title = row["attach_title"].ToString();
                }
                if (row["attach_path"] != null)
                {
                    model.attach_path = row["attach_path"].ToString();
                }
                if (row["attach_user"] != null)
                {
                    model.attach_user = row["attach_user"].ToString();
                }
                if (row["attach_time"] != null && row["attach_time"].ToString() != "")
                {
                    model.attach_time = DateTime.Parse(row["attach_time"].ToString());
                }
                if (row["attach_guid"] != null && row["attach_guid"].ToString() != "")
                {
                    model.attach_guid = row["attach_guid"].ToString();
                }
                if (row["attach_rmk1"] != null && row["attach_rmk1"].ToString() != "")
                {
                    model.attach_rmk1 = row["attach_rmk1"].ToString();
                }
                if (row["attach_rmk2"] != null && row["attach_rmk2"].ToString() != "")
                {
                    model.attach_rmk2 = row["attach_rmk2"].ToString();
                }
                if (row["attach_rmk3"] != null && row["attach_rmk3"].ToString() != "")
                {
                    model.attach_rmk3 = row["attach_rmk3"].ToString();
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
            strSql.Append("select attach_guid,attach_id,attach_nbr,attach_location,attach_type,attach_title,attach_path,attach_user,attach_time,attach_rmk1,attach_rmk2,attach_rmk3 ");
            strSql.Append(" FROM Sys_Attach_Mstr ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSpecialList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select attach_guid,attach_id,attach_nbr,attach_location,attach_type,attach_title,attach_path,attach_user,attach_time,attach_rmk1,attach_rmk2,attach_rmk3 ");
            strSql.Append(" FROM Sys_Attach_Mstr A,Sys_Form_Mstr B where A.attach_guid = B.form_guid and  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            else
            {
                strSql.Append("1=1");
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
            strSql.Append(" atach_guid,attach_id,attach_nbr,attach_location,attach_type,attach_title,attach_path,attach_user,attach_time,attach_rmk1,attach_rmk2,attach_rmk3 ");
            strSql.Append(" FROM Sys_Attach_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Attach_Mstr ");
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
                strSql.Append("order by T.attach_id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Attach_Mstr T ");
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
                    new SqlParameter("@Name", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Sys_Attach_Mstr";
            parameters[1].Value = "attach_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string OutPut()
        {
            SqlParameter[] parameters = { new SqlParameter("@filename", SqlDbType.VarChar, 50) };
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("sp_getattach", parameters);

            return parameters[0].Value.ToString();
        }

        public Workflow.Model.Sys_Attach_Mstr_Model GetModelByNbr(string attach_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 attach_guid,attach_id,attach_nbr,attach_location,attach_type,attach_title,attach_path,attach_user,attach_time,attach_rmk1,attach_rmk2,attach_rmk3 from Sys_Attach_Mstr ");
            strSql.Append(" where attach_nbr=@attach_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@attach_nbr", SqlDbType.NVarChar,50)			};
            parameters[0].Value = attach_nbr;

            Workflow.Model.Sys_Attach_Mstr_Model model = new Workflow.Model.Sys_Attach_Mstr_Model();
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
