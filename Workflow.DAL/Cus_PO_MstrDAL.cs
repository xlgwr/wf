using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_PO_Mstr_Model
    /// </summary>
    public partial class Cus_PO_MstrDAL
    {
        public Cus_PO_MstrDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string po_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_PO_Mstr");
            strSql.Append(" where po_guid=@po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@po_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = po_guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_PO_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_PO_Mstr(");
            strSql.Append("po_guid,po_nbr,po_location,po_type,po_revision,po_xml_name,po_xml,po_date_cre,po_rmk1,po_rmk2,po_rmk3)");
            strSql.Append(" values (");
            strSql.Append("@po_guid,@po_nbr,@po_location,@po_type,@po_revision,@po_xml_name,@po_xml,@po_date_cre,@po_rmk1,@po_rmk2,@po_rmk3)");
            SqlParameter[] parameters = {
					new SqlParameter("@po_guid", SqlDbType.NVarChar,50),
					new SqlParameter("@po_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@po_location", SqlDbType.VarChar,20),
					new SqlParameter("@po_type", SqlDbType.VarChar,20),
					new SqlParameter("@po_revision", SqlDbType.VarChar,20),
					new SqlParameter("@po_xml_name", SqlDbType.VarChar,50),
					new SqlParameter("@po_xml", SqlDbType.Xml,-1),
					new SqlParameter("@po_date_cre", SqlDbType.DateTime),
					new SqlParameter("@po_rmk1", SqlDbType.NVarChar,50),
					new SqlParameter("@po_rmk2", SqlDbType.NVarChar,50),
					new SqlParameter("@po_rmk3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.po_guid;
            parameters[1].Value = model.po_nbr;
            parameters[2].Value = model.po_location;
            parameters[3].Value = model.po_type;
            parameters[4].Value = model.po_revision;
            parameters[5].Value = model.po_xml_name;
            parameters[6].Value = model.po_xml;
            parameters[7].Value = model.po_date_cre;
            parameters[8].Value = model.po_rmk1;
            parameters[9].Value = model.po_rmk2;
            parameters[10].Value = model.po_rmk3;

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
        public bool Update(Workflow.Model.Cus_PO_Mstr_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_PO_Mstr set ");
            strSql.Append("po_nbr=@po_nbr,");
            strSql.Append("po_location=@po_location,");
            strSql.Append("po_type=@po_type,");
            strSql.Append("po_revision=@po_revision,");
            strSql.Append("po_xml_name=@po_xml_name,");
            strSql.Append("po_xml=@po_xml,");
            strSql.Append("po_date_cre=@po_date_cre,");
            strSql.Append("po_rmk1=@po_rmk1,");
            strSql.Append("po_rmk2=@po_rmk2,");
            strSql.Append("po_rmk3=@po_rmk3");
            strSql.Append(" where po_guid=@po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@po_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@po_location", SqlDbType.VarChar,20),
					new SqlParameter("@po_type", SqlDbType.VarChar,20),
					new SqlParameter("@po_revision", SqlDbType.VarChar,20),
					new SqlParameter("@po_xml_name", SqlDbType.VarChar,50),
					new SqlParameter("@po_xml", SqlDbType.Xml,-1),
					new SqlParameter("@po_date_cre", SqlDbType.DateTime),
					new SqlParameter("@po_rmk1", SqlDbType.NVarChar,50),
					new SqlParameter("@po_rmk2", SqlDbType.NVarChar,50),
					new SqlParameter("@po_rmk3", SqlDbType.NVarChar,50),
					new SqlParameter("@po_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.po_nbr;
            parameters[1].Value = model.po_location;
            parameters[2].Value = model.po_type;
            parameters[3].Value = model.po_revision;
            parameters[4].Value = model.po_xml_name;
            parameters[5].Value = model.po_xml;
            parameters[6].Value = model.po_date_cre;
            parameters[7].Value = model.po_rmk1;
            parameters[8].Value = model.po_rmk2;
            parameters[9].Value = model.po_rmk3;
            parameters[10].Value = model.po_guid;

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
        public bool Delete(string po_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_PO_Mstr ");
            strSql.Append(" where po_guid=@po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@po_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = po_guid;

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
        public bool DeleteList(string po_guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_PO_Mstr ");
            strSql.Append(" where po_guid in (" + po_guidlist + ")  ");
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
        public Workflow.Model.Cus_PO_Mstr_Model GetModel(string po_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 po_guid,po_nbr,po_location,po_type,po_revision,po_xml_name,po_xml,po_date_cre,po_rmk1,po_rmk2,po_rmk3 from Cus_PO_Mstr ");
            strSql.Append(" where po_guid=@po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@po_guid", SqlDbType.NVarChar,50)			};
            parameters[0].Value = po_guid;

            Workflow.Model.Cus_PO_Mstr_Model model = new Workflow.Model.Cus_PO_Mstr_Model();
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
        public Workflow.Model.Cus_PO_Mstr_Model GetModel(string po_loc,string po_nbr)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 po_guid,po_nbr,po_location,po_type,po_revision,po_xml_name,po_xml,po_date_cre,po_rmk1,po_rmk2,po_rmk3 from Cus_PO_Mstr ");
            strSql.Append(" where po_location=@po_loc ");
            strSql.Append(" and po_nbr=@po_nbr ");
            SqlParameter[] parameters = {
					new SqlParameter("@po_loc", SqlDbType.VarChar,20),
                    new SqlParameter("@po_nbr", SqlDbType.VarChar,20)};
            parameters[0].Value = po_loc;
            parameters[1].Value = po_nbr;
            Workflow.Model.Cus_PO_Mstr_Model model = new Workflow.Model.Cus_PO_Mstr_Model();
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
        public Workflow.Model.Cus_PO_Mstr_Model GetGuidModel(string po_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 po_guid,po_nbr,po_location,po_type,po_revision,po_xml_name,po_xml,po_date_cre,po_rmk1,po_rmk2,po_rmk3 from Cus_PO_Mstr ");
            strSql.Append(" where po_guid=@po_guid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@po_guid", SqlDbType.NVarChar,50)};
            parameters[0].Value = po_guid;
            Workflow.Model.Cus_PO_Mstr_Model model = new Workflow.Model.Cus_PO_Mstr_Model();
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
        public Workflow.Model.Cus_PO_Mstr_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_PO_Mstr_Model model = new Workflow.Model.Cus_PO_Mstr_Model();
            if (row != null)
            {
                if (row["po_guid"] != null)
                {
                    model.po_guid = row["po_guid"].ToString();
                }
                if (row["po_nbr"] != null)
                {
                    model.po_nbr = row["po_nbr"].ToString();
                }
                if (row["po_location"] != null)
                {
                    model.po_location = row["po_location"].ToString();
                }
                if (row["po_type"] != null)
                {
                    model.po_type = row["po_type"].ToString();
                }
                if (row["po_revision"] != null)
                {
                    model.po_revision = row["po_revision"].ToString();
                }
                if (row["po_xml_name"] != null)
                {
                    model.po_xml_name = row["po_xml_name"].ToString();
                }
                if (row["po_xml"] != null)
                {
                    model.po_xml = row["po_xml"].ToString();
                }
                if (row["po_date_cre"] != null && row["po_date_cre"].ToString() != "")
                {
                    model.po_date_cre = DateTime.Parse(row["po_date_cre"].ToString());
                }
                if (row["po_rmk1"] != null)
                {
                    model.po_rmk1 = row["po_rmk1"].ToString();
                }
                if (row["po_rmk2"] != null)
                {
                    model.po_rmk2 = row["po_rmk2"].ToString();
                }
                if (row["po_rmk3"] != null)
                {
                    model.po_rmk3 = row["po_rmk3"].ToString();
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
            strSql.Append("select po_nbr as number,upper(po_xml.value('(po_appr/po_header/model_group)[1]','varchar(10)')) as [site], ");
            strSql.Append(" upper(po_xml.value('(po_appr/po_header/t_system)[1]','varchar(20)'))+'-'+upper(po_xml.value('(po_appr/po_header/type_po)[1]','varchar(10)')) ");
            strSql.Append(" as [type], ");
            strSql.Append(" upper(po_xml.value('(po_appr/po_header/buyer_name)[1]','varchar(50)')) as [buyer] ");
            strSql.Append(" FROM Cus_PO_Mstr ");
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
            strSql.Append(" po_guid,po_nbr,po_location,po_type,po_revision,po_xml_name,po_xml,po_date_cre,po_rmk1,po_rmk2,po_rmk3 ");
            strSql.Append(" FROM Cus_PO_Mstr ");
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
            strSql.Append("select count(1) FROM Cus_PO_Mstr ");
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
                strSql.Append("order by T.po_guid desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_PO_Mstr T ");
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
            parameters[0].Value = "Cus_PO_Mstr";
            parameters[1].Value = "po_guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string ExecTerminatePOProc(string strGuid,string strUser)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@iret", SqlDbType.Char,10),
                    new SqlParameter("@guid", SqlDbType.NVarChar, 50),
                    new SqlParameter("@user", SqlDbType.VarChar,50),
                    };
            parameters[1].Value = strGuid;
            parameters[2].Value = strUser;
            parameters[0].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[sp_po_terminate]", parameters);
            return parameters[0].Value.ToString();
        }
        #endregion  ExtensionMethod
    }
}

