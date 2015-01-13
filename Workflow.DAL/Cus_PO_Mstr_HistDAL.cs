using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Workflow.DBUtility;
namespace Workflow.DAL
{
    /// <summary>
    /// 数据访问类:Cus_PO_Mstr_Hist_Model
    /// </summary>
    public partial class Cus_PO_Mstr_HistDAL
    {
        public Cus_PO_Mstr_HistDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string hist_po_guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Cus_PO_Mstr_Hist");
            strSql.Append(" where hist_po_guid=@hist_po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@hist_po_guid", SqlDbType.VarChar,50)			};
            parameters[0].Value = hist_po_guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_PO_Mstr_Hist_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Cus_PO_Mstr_Hist(");
            strSql.Append("hist_po_guid,hist_po_nbr,hist_po_revision,hist_po_location,hist_po_type,hist_po_xml,hist_po_xml_name,hist_po_date_cre,hist_po_rmk1,hist_po_rmk2,hist_po_rmk3)");
            strSql.Append(" values (");
            strSql.Append("@hist_po_guid,@hist_po_nbr,@hist_po_revision,@hist_po_location,@hist_po_type,@hist_po_xml,@hist_po_xml_name,@hist_po_date_cre,@hist_po_rmk1,@hist_po_rmk2,@hist_po_rmk3)");
            SqlParameter[] parameters = {
					new SqlParameter("@hist_po_guid", SqlDbType.VarChar,50),
					new SqlParameter("@hist_po_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@hist_po_revision", SqlDbType.VarChar,20),
					new SqlParameter("@hist_po_location", SqlDbType.VarChar,20),
					new SqlParameter("@hist_po_type", SqlDbType.VarChar,20),
					new SqlParameter("@hist_po_xml", SqlDbType.Xml),
					new SqlParameter("@hist_po_xml_name", SqlDbType.VarChar,50),
					new SqlParameter("@hist_po_date_cre", SqlDbType.DateTime),
					new SqlParameter("@hist_po_rmk1", SqlDbType.NVarChar,50),
					new SqlParameter("@hist_po_rmk2", SqlDbType.NVarChar,50),
					new SqlParameter("@hist_po_rmk3", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.hist_po_guid;
            parameters[1].Value = model.hist_po_nbr;
            parameters[2].Value = model.hist_po_revision;
            parameters[3].Value = model.hist_po_location;
            parameters[4].Value = model.hist_po_type;
            parameters[5].Value = model.hist_po_xml;
            parameters[6].Value = model.hist_po_xml_name;
            parameters[7].Value = model.hist_po_date_cre;
            parameters[8].Value = model.hist_po_rmk1;
            parameters[9].Value = model.hist_po_rmk2;
            parameters[10].Value = model.hist_po_rmk3;

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
        public bool Update(Workflow.Model.Cus_PO_Mstr_Hist_Model model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Cus_PO_Mstr_Hist set ");
            strSql.Append("hist_po_nbr=@hist_po_nbr,");
            strSql.Append("hist_po_revision=@hist_po_revision,");
            strSql.Append("hist_po_location=@hist_po_location,");
            strSql.Append("hist_po_type=@hist_po_type,");
            strSql.Append("hist_po_xml=@hist_po_xml,");
            strSql.Append("hist_po_xml_name=@hist_po_xml_name,");
            strSql.Append("hist_po_date_cre=@hist_po_date_cre,");
            strSql.Append("hist_po_rmk1=@hist_po_rmk1,");
            strSql.Append("hist_po_rmk2=@hist_po_rmk2,");
            strSql.Append("hist_po_rmk3=@hist_po_rmk3");
            strSql.Append(" where hist_po_guid=@hist_po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@hist_po_nbr", SqlDbType.VarChar,50),
					new SqlParameter("@hist_po_revision", SqlDbType.VarChar,20),
					new SqlParameter("@hist_po_location", SqlDbType.VarChar,20),
					new SqlParameter("@hist_po_type", SqlDbType.VarChar,20),
					new SqlParameter("@hist_po_xml", SqlDbType.Xml),
					new SqlParameter("@hist_po_xml_name", SqlDbType.VarChar,50),
					new SqlParameter("@hist_po_date_cre", SqlDbType.DateTime),
					new SqlParameter("@hist_po_rmk1", SqlDbType.NVarChar,50),
					new SqlParameter("@hist_po_rmk2", SqlDbType.NVarChar,50),
					new SqlParameter("@hist_po_rmk3", SqlDbType.NVarChar,50),
					new SqlParameter("@hist_po_guid", SqlDbType.VarChar,50)};
            parameters[0].Value = model.hist_po_nbr;
            parameters[1].Value = model.hist_po_revision;
            parameters[2].Value = model.hist_po_location;
            parameters[3].Value = model.hist_po_type;
            parameters[4].Value = model.hist_po_xml;
            parameters[5].Value = model.hist_po_xml_name;
            parameters[6].Value = model.hist_po_date_cre;
            parameters[7].Value = model.hist_po_rmk1;
            parameters[8].Value = model.hist_po_rmk2;
            parameters[9].Value = model.hist_po_rmk3;
            parameters[10].Value = model.hist_po_guid;

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
        public bool Delete(string hist_po_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_PO_Mstr_Hist ");
            strSql.Append(" where hist_po_guid=@hist_po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@hist_po_guid", SqlDbType.VarChar,50)			};
            parameters[0].Value = hist_po_guid;

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
        public bool DeleteList(string hist_po_guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Cus_PO_Mstr_Hist ");
            strSql.Append(" where hist_po_guid in (" + hist_po_guidlist + ")  ");
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
        public Workflow.Model.Cus_PO_Mstr_Hist_Model GetModel(string hist_po_guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 hist_po_guid,hist_po_nbr,hist_po_revision,hist_po_location,hist_po_type,hist_po_xml,hist_po_xml_name,hist_po_date_cre,hist_po_rmk1,hist_po_rmk2,hist_po_rmk3 from Cus_PO_Mstr_Hist ");
            strSql.Append(" where hist_po_guid=@hist_po_guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@hist_po_guid", SqlDbType.VarChar,50)			};
            parameters[0].Value = hist_po_guid;

            Workflow.Model.Cus_PO_Mstr_Hist_Model model = new Workflow.Model.Cus_PO_Mstr_Hist_Model();
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
        public Workflow.Model.Cus_PO_Mstr_Hist_Model DataRowToModel(DataRow row)
        {
            Workflow.Model.Cus_PO_Mstr_Hist_Model model = new Workflow.Model.Cus_PO_Mstr_Hist_Model();
            if (row != null)
            {
                if (row["hist_po_guid"] != null)
                {
                    model.hist_po_guid = row["hist_po_guid"].ToString();
                }
                if (row["hist_po_nbr"] != null)
                {
                    model.hist_po_nbr = row["hist_po_nbr"].ToString();
                }
                if (row["hist_po_revision"] != null)
                {
                    model.hist_po_revision = row["hist_po_revision"].ToString();
                }
                if (row["hist_po_location"] != null)
                {
                    model.hist_po_location = row["hist_po_location"].ToString();
                }
                if (row["hist_po_type"] != null)
                {
                    model.hist_po_type = row["hist_po_type"].ToString();
                }
                if (row["hist_po_xml"] != null)
                {
                    model.hist_po_xml = row["hist_po_xml"].ToString();
                }
                if (row["hist_po_xml_name"] != null)
                {
                    model.hist_po_xml_name = row["hist_po_xml_name"].ToString();
                }
                if (row["hist_po_date_cre"] != null && row["hist_po_date_cre"].ToString() != "")
                {
                    model.hist_po_date_cre = DateTime.Parse(row["hist_po_date_cre"].ToString());
                }
                if (row["hist_po_rmk1"] != null)
                {
                    model.hist_po_rmk1 = row["hist_po_rmk1"].ToString();
                }
                if (row["hist_po_rmk2"] != null)
                {
                    model.hist_po_rmk2 = row["hist_po_rmk2"].ToString();
                }
                if (row["hist_po_rmk3"] != null)
                {
                    model.hist_po_rmk3 = row["hist_po_rmk3"].ToString();
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
            strSql.Append("select hist_po_guid,hist_po_nbr,hist_po_revision,hist_po_location,hist_po_type,hist_po_xml,hist_po_xml_name,hist_po_date_cre,hist_po_rmk1,hist_po_rmk2,hist_po_rmk3 ");
            strSql.Append(" FROM Cus_PO_Mstr_Hist ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSpecialList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select hist_po_guid,hist_po_nbr,hist_po_revision,hist_po_location,hist_po_type,hist_po_xml_name, ");
            strSql.Append(" rtrim(hist_po_xml.value('(po_appr/po_header/type_po)[1]','nvarchar(20)')) +'-'+ ");
            strSql.Append(" rtrim(hist_po_xml.value('(po_appr/po_header/cac)[1]','nvarchar(50)')) + '-'+ ");
            strSql.Append(" rtrim(hist_po_xml.value('(po_appr/po_header/model_group)[1]','nvarchar(10)'))+'-'+ ");
            strSql.Append(" rtrim(hist_po_xml.value('(po_appr/po_header/po_nbr)[1]','nvarchar(50)')) + '-('+ ");
            strSql.Append(" rtrim(hist_po_xml.value('(po_appr/po_header/po_rev)[1]','nvarchar(50)'))+')'  as POTitle, ");
            strSql.Append(" hist_po_date_cre,hist_po_rmk1,hist_po_rmk2,hist_po_rmk3 ");
            strSql.Append(" FROM Cus_PO_Mstr_Hist ");
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
            strSql.Append(" hist_po_guid,hist_po_nbr,hist_po_revision,hist_po_location,hist_po_type,hist_po_xml,hist_po_xml_name,hist_po_date_cre,hist_po_rmk1,hist_po_rmk2,hist_po_rmk3 ");
            strSql.Append(" FROM Cus_PO_Mstr_Hist ");
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
            strSql.Append("select count(1) FROM Cus_PO_Mstr_Hist ");
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
                strSql.Append("order by T.hist_po_guid desc");
            }
            strSql.Append(")AS Row, T.*  from Cus_PO_Mstr_Hist T ");
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
            parameters[0].Value = "Cus_PO_Mstr_Hist";
            parameters[1].Value = "hist_po_guid";
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

