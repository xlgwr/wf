using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Workflow.DBUtility;

namespace Workflow.DAL
{
   /// <summary>
	/// 数据访问类:Sys_User_Info
	/// </summary>
	public partial class SysUserManageDAL
	{
        public SysUserManageDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string user_name,string user_password)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User_Info");
			strSql.Append(" where user_name=@user_name and user_password = @user_password ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,50)	,
                    new SqlParameter("@user_password", SqlDbType.NVarChar,200)	                   };
			parameters[0].Value = user_name;
            parameters[1].Value = user_password;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public bool NodomainExists(string user_name, string user_phase)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_User_Info");
            strSql.Append(" where user_name=@user_name and user_phase = @user_phase ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,50)	,
                    new SqlParameter("@user_phase", SqlDbType.NVarChar,200)	                   };
			parameters[0].Value = user_name;
            parameters[1].Value = user_phase;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        

        public bool Exists(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_User_Info");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,50)       };
            parameters[0].Value = user_name;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(Workflow.Model.Sys_User_Info_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_User_Info(");
			strSql.Append("user_name,user_location,user_title,user_mail,user_password,user_status,user_lang,user_phase,user_dept)");
			strSql.Append(" values (");
            strSql.Append("@user_name,@user_location,@user_title,@user_mail,@user_password,@user_status,@user_lang,@user_phase,@user_dept)");
			SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.VarChar,50),
					new SqlParameter("@user_location", SqlDbType.VarChar,20),
					new SqlParameter("@user_title", SqlDbType.NVarChar,50),
					new SqlParameter("@user_mail", SqlDbType.NVarChar,200),
					new SqlParameter("@user_password", SqlDbType.NVarChar,200),
					new SqlParameter("@user_status", SqlDbType.NVarChar,2),
					new SqlParameter("@user_lang", SqlDbType.Char,2),
					new SqlParameter("@user_phase", SqlDbType.NVarChar,200),
                    new SqlParameter("@user_dept", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.user_name;
			parameters[1].Value = model.user_location;
			parameters[2].Value = model.user_title;
			parameters[3].Value = model.user_mail;
			parameters[4].Value = model.user_password;
			parameters[5].Value = model.user_status;
			parameters[6].Value = model.user_lang;
			parameters[7].Value = model.user_phase;
            parameters[8].Value = model.user_dept;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Update(Workflow.Model.Sys_User_Info_Model model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_User_Info set ");
            //strSql.Append("user_name=@user_name,");
            //strSql.Append("user_location=@user_location,");
            //strSql.Append("user_title=@user_title,");
            //strSql.Append("user_mail=@user_mail,");
			strSql.Append("user_password=@user_password");
            //strSql.Append("user_status=@user_status,");
            //strSql.Append("user_lang=@user_lang,");
            //strSql.Append("user_phase=@user_phase");
            //strSql.Append("user_dept=@user_dept");
			strSql.Append(" where user_name=@user_name ");
			SqlParameter[] parameters = {
                    //new SqlParameter("@user_name", SqlDbType.VarChar,50),
                    //new SqlParameter("@user_location", SqlDbType.VarChar,20),
                    //new SqlParameter("@user_title", SqlDbType.NVarChar,50),
                    //new SqlParameter("@user_mail", SqlDbType.NVarChar,200),
					new SqlParameter("@user_password", SqlDbType.NVarChar,200),
                    //new SqlParameter("@user_status", SqlDbType.NVarChar,2),
                    //new SqlParameter("@user_lang", SqlDbType.Char,2),
                    //new SqlParameter("@user_phase", SqlDbType.NVarChar,200),
                    //new SqlParameter("@user_dept", SqlDbType.NVarChar,200),
					new SqlParameter("@user_name", SqlDbType.NVarChar,20)};
            //parameters[0].Value = model.user_name;
            //parameters[1].Value = model.user_location;
            //parameters[2].Value = model.user_title;
            //parameters[3].Value = model.user_mail;
			parameters[0].Value = model.user_password;
            //parameters[5].Value = model.user_status;
            //parameters[6].Value = model.user_lang;
            //parameters[7].Value = model.user_phase;
			parameters[1].Value = model.user_name;
            //parameters[9].Value = model.user_dept;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string user_name)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User_Info ");
			strSql.Append(" where user_name=@user_name ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,20)			};
			parameters[0].Value = user_name;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string user_namelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_User_Info ");
			strSql.Append(" where user_name in ("+user_namelist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Workflow.Model.Sys_User_Info_Model GetModel(string user_name)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_name,user_name,user_location,user_title,user_mail,user_password,user_status,user_lang,user_phase,user_dept from Sys_User_Info ");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,20)};
            parameters[0].Value = user_name;
            Workflow.Model.Sys_User_Info_Model model = new Workflow.Model.Sys_User_Info_Model();
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
        public Workflow.Model.Sys_User_Info_Model GetModel(string user_name, string user_location)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 user_name,user_name,user_location,user_title,user_mail,user_password,user_status,user_lang,user_phase,user_dept from Sys_User_Info ");
            strSql.Append(" where user_name=@user_name ");
            strSql.Append(" and user_location=@user_location ");
            SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,20),
                                        new SqlParameter("@user_location", SqlDbType.NVarChar,20)};
            parameters[0].Value = user_name;
            parameters[1].Value = user_location;

            Workflow.Model.Sys_User_Info_Model model = new Workflow.Model.Sys_User_Info_Model();
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
        public Workflow.Model.Sys_User_Info_Model GetModel(string user_name,string user_password,string user_location)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 user_name,user_name,user_location,user_title,user_mail,user_password,user_status,user_lang,user_phase,user_dept from Sys_User_Info ");
			strSql.Append(" where user_name=@user_name ");
            strSql.Append(" and user_password=@user_password ");
            strSql.Append(" and user_location=@user_location ");
			SqlParameter[] parameters = {
					new SqlParameter("@user_name", SqlDbType.NVarChar,20),
                                        new SqlParameter("@user_password", SqlDbType.NVarChar,200),
                                        new SqlParameter("@user_location", SqlDbType.NVarChar,20)};
			parameters[0].Value = user_name;
            parameters[1].Value = user_password;
            parameters[2].Value = user_location;

            Workflow.Model.Sys_User_Info_Model model = new Workflow.Model.Sys_User_Info_Model();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
        public Workflow.Model.Sys_User_Info_Model DataRowToModel(DataRow row)
		{
            Workflow.Model.Sys_User_Info_Model model = new Workflow.Model.Sys_User_Info_Model();
			if (row != null)
			{
				if(row["user_name"]!=null)
				{
					model.user_name=row["user_name"].ToString();
				}
				if(row["user_location"]!=null)
				{
					model.user_location=row["user_location"].ToString();
				}
				if(row["user_title"]!=null)
				{
					model.user_title=row["user_title"].ToString();
				}
				if(row["user_mail"]!=null)
				{
					model.user_mail=row["user_mail"].ToString();
				}
				if(row["user_password"]!=null)
				{
					model.user_password=row["user_password"].ToString();
				}
				if(row["user_status"]!=null)
				{
					model.user_status=row["user_status"].ToString();
				}
				if(row["user_lang"]!=null)
				{
					model.user_lang=row["user_lang"].ToString();
				}
				if(row["user_phase"]!=null)
				{
					model.user_phase=row["user_phase"].ToString();
				}
                if (row["user_dept"] != null)
                {
                    model.user_dept = row["user_dept"].ToString();
                }
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select user_name,user_location,user_title,user_mail,user_password,user_status,user_lang,user_phase,user_dept ");
			strSql.Append(" FROM Sys_User_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" user_name,user_location,user_title,user_mail,user_password,user_status,user_lang,user_phase,user_dept ");
			strSql.Append(" FROM Sys_User_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_User_Info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.user_name desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_User_Info T ");
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
			parameters[0].Value = "Sys_User_Info";
			parameters[1].Value = "user_name";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod
        public DataSet GetDeptList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct user_dept ");
            strSql.Append(" FROM Sys_User_Info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by user_dept");
            return DbHelperSQL.Query(strSql.ToString());
        }

        public Workflow.Model.Sys_User_Dept_Model DataRowToModel_Dept(DataRow row)
        {
            Workflow.Model.Sys_User_Dept_Model model = new Workflow.Model.Sys_User_Dept_Model();
            if (row != null)
            {
                
                if (row["user_dept"] != null)
                {
                    model.user_dept = row["user_dept"].ToString();
                }
            }
            return model;
        }
        public bool UpdateLanguage(Workflow.Model.Sys_User_Info_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_User_Info set ");
            strSql.Append("user_lang=@user_lang");
            strSql.Append(" where user_name=@user_name ");
            SqlParameter[] parameters = {

                    new SqlParameter("@user_lang", SqlDbType.Char,2),
					new SqlParameter("@user_name", SqlDbType.NVarChar,20)};

            parameters[0].Value = model.user_lang;
            parameters[1].Value = model.user_name;
  

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
         public void ExecResetUser()
        {
            DbHelperSQL.ExecuteSql("[sp_reset_user]");
        }
         public void ExecAddUser(Workflow.Model.Sys_User_Info_Model model)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@user", SqlDbType.Char,50),
                    new SqlParameter("@location", SqlDbType.Char, 20),
                    new SqlParameter("@dept", SqlDbType.VarChar, 20),
                    new SqlParameter("@title", SqlDbType.VarChar, 50),
                    new SqlParameter("@mail", SqlDbType.VarChar,200)
                    };
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.user_location;
            parameters[2].Value = model.user_dept;
            parameters[3].Value = model.user_title;
            parameters[4].Value = model.user_mail;
            DbHelperSQL.RunProcedure("[sp_add_user]", parameters);
        }
         public void ExecDelUser()
         {
             DbHelperSQL.ExecuteSql("[sp_del_user]");
         }
        #endregion  ExtensionMethod
	}
}
