using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
using System.Data;
using Workflow.Model;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Sys_Menu_MstrDAL
    /// </summary>
    public partial class Sys_Menu_MstrDAL
    {
        public Sys_Menu_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string menu_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_Menu_Mstr");
            strSql.Append(" where menu_id=@menu_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.NVarChar,20)			};
            parameters[0].Value = menu_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Menu_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_Menu_Mstr(");
            strSql.Append("menu_id,menu_name,menu_page,menu_level,menu_order,menu_title,menu_title_cn,menu_type)");
            strSql.Append(" values (");
            strSql.Append("@menu_id,@menu_name,@menu_page,@menu_level,@menu_order,@menu_title,@menu_title_cn,@menu_type)");
            SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.NVarChar,20),
					new SqlParameter("@menu_name", SqlDbType.NVarChar,100),
					new SqlParameter("@menu_page", SqlDbType.NVarChar,200),
					new SqlParameter("@menu_level", SqlDbType.Int),
					new SqlParameter("@menu_order", SqlDbType.Int),
					new SqlParameter("@menu_title", SqlDbType.NVarChar,100),
                    new SqlParameter("@menu_title_cn", SqlDbType.NVarChar,1000),
                    new SqlParameter("@menu_type", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.menu_id;
            parameters[1].Value = model.menu_name;
            parameters[2].Value = model.menu_page;
            parameters[3].Value = model.menu_level;
            parameters[4].Value = model.menu_order;
            parameters[5].Value = model.menu_title;
            parameters[6].Value = model.menu_title_cn;
            parameters[7].Value = model.menu_type;

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
        public bool Update(Workflow.Model.Sys_Menu_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Menu_Mstr set ");
            strSql.Append("menu_name=@menu_name,");
            strSql.Append("menu_page=@menu_page,");
            strSql.Append("menu_level=@menu_level,");
            strSql.Append("menu_order=@menu_order,");
            strSql.Append("menu_title=@menu_title");
            strSql.Append("menu_title_cn=@menu_title_cn");
            strSql.Append("menu_type=@menu_type");
            strSql.Append(" where menu_id=@menu_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@menu_name", SqlDbType.NVarChar,100),
					new SqlParameter("@menu_page", SqlDbType.NVarChar,200),
					new SqlParameter("@menu_level", SqlDbType.Int),
					new SqlParameter("@menu_order", SqlDbType.Int),
					new SqlParameter("@menu_title", SqlDbType.NVarChar,100),
                    new SqlParameter("@menu_title_cn", SqlDbType.NVarChar,1000),
					new SqlParameter("@menu_id", SqlDbType.NVarChar,20),
                    new SqlParameter("@menu_type", SqlDbType.NVarChar,20),                    };
            parameters[0].Value = model.menu_name;
            parameters[1].Value = model.menu_page;
            parameters[2].Value = model.menu_level;
            parameters[3].Value = model.menu_order;
            parameters[4].Value = model.menu_title;
            parameters[5].Value = model.menu_title_cn;
            parameters[6].Value = model.menu_id;
            parameters[7].Value = model.menu_type;

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
        public bool Delete(string menu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Menu_Mstr ");
            strSql.Append(" where menu_id=@menu_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.NVarChar,20)			};
            parameters[0].Value = menu_id;

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
        public bool DeleteList(string menu_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_Menu_Mstr ");
            strSql.Append(" where menu_id in (" + menu_idlist + ")  ");
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
        public Workflow.Model.Sys_Menu_Mstr_Model GetModel(string menu_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 menu_id,menu_name,menu_page,menu_level,menu_order,menu_title,menu_title_cn,menu_type from Sys_Menu_Mstr ");
            strSql.Append(" where menu_id=@menu_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@menu_id", SqlDbType.NVarChar,20)			};
            parameters[0].Value = menu_id;

            Workflow.Model.Sys_Menu_Mstr_Model model = new Workflow.Model.Sys_Menu_Mstr_Model();
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
        public Workflow.Model.Sys_Menu_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Sys_Menu_Mstr_Model model = new Workflow.Model.Sys_Menu_Mstr_Model();
            if (row != null)
            {
                if (row["menu_id"] != null)
                {
                    model.menu_id = row["menu_id"].ToString();
                }
                if (row["menu_name"] != null)
                {
                    model.menu_name = row["menu_name"].ToString();
                }
                if (row["menu_page"] != null)
                {
                    model.menu_page = row["menu_page"].ToString();
                }
                if (row["menu_level"] != null && row["menu_level"].ToString() != "")
                {
                    model.menu_level = int.Parse(row["menu_level"].ToString());
                }
                if (row["menu_order"] != null && row["menu_order"].ToString() != "")
                {
                    model.menu_order = int.Parse(row["menu_order"].ToString());
                }
                if (row["menu_title"] != null)
                {
                    model.menu_title = row["menu_title"].ToString();
                }
                if (row["menu_title_cn"] != null)
                {
                    model.menu_title = row["menu_title_cn"].ToString();
                }
                if (row["menu_type"] != null)
                {
                    model.menu_type = row["menu_type"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere,string strLang)
        {
            StringBuilder strSql = new StringBuilder();
            if (strLang == "CN")
            {
                strSql.Append("select menu_id,menu_title_cn as title,menu_page,menu_level,menu_order,menu_title,menu_title_cn,menu_type ");
            }
            else
            {
                strSql.Append("select menu_id,menu_title as title,menu_page,menu_level,menu_order,menu_title,menu_title_cn,menu_type ");
            }
            
            strSql.Append(" FROM Sys_Menu_Mstr ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetList_Parent_Right(string strUser,string strLang)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@lang",SqlDbType.VarChar,2)
                    };
            parameters[0].Value = strUser.Trim();
            parameters[1].Value = strLang.Trim();
            return DbHelperSQL.RunProcedure("[sp_menu_parent_cre]", parameters, "default");
        }
        public DataSet GetList_Child_Right(string strUser, string strLang,string strMenuId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    new SqlParameter("@lang",SqlDbType.VarChar,2),
                    new SqlParameter("@menu_id",SqlDbType.VarChar,50),
                    };
            parameters[0].Value = strUser.Trim();
            parameters[1].Value = strLang.Trim();
            parameters[2].Value = strMenuId.Trim();
            return DbHelperSQL.RunProcedure("[sp_menu_child_cre]", parameters, "default");
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
            strSql.Append(" menu_id,menu_name,menu_page,menu_level,menu_order,menu_title,menu_title_cn,menu_type ");
            strSql.Append(" FROM Sys_Menu_Mstr ");
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
            strSql.Append("select count(1) FROM Sys_Menu_Mstr ");
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
                strSql.Append("order by T.menu_id desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_Menu_Mstr T ");
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
            parameters[0].Value = "Sys_Menu_Mstr";
            parameters[1].Value = "menu_id";
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
