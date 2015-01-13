using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
namespace Workflow.BLL
{
    public partial class Cus_MIS_Type
    {
        private readonly Workflow.DAL.Cus_MIS_TypeDAL dal = new Workflow.DAL.Cus_MIS_TypeDAL();
        public Cus_MIS_Type()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string mis_type_code)
        {
            return dal.Exists(mis_type_code);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_MIS_Type_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_MIS_Type_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string mis_type_code)
        {

            return dal.Delete(mis_type_code);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string mis_type_codelist)
        {
            return dal.DeleteList(mis_type_codelist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_MIS_Type_Model GetModel(string mis_type_code)
        {

            return dal.GetModel(mis_type_code);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_MIS_Type_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_MIS_Type_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_MIS_Type_Model> modelList = new List<Workflow.Model.Cus_MIS_Type_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_MIS_Type_Model model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod
        public string GetTypeFullName(string strCode,string strLang)
        {
            int len = strCode.Length;
            if (len == 3)
            {
                return strLang=="CN"?dal.GetModel(strCode).mis_type_value_cn.Trim():dal.GetModel(strCode).mis_type_value.Trim();
             }
            else if (len == 6)
            {
                string parentCode = strCode.Substring(0, 3);
                string childCode = strCode;
                return strLang == "CN" ? dal.GetModel(parentCode).mis_type_value_cn.Trim() + " : " + dal.GetModel(childCode).mis_type_value_cn.Trim() : dal.GetModel(parentCode).mis_type_value.Trim() + " : " + dal.GetModel(childCode).mis_type_value.Trim();
            }
            else
            {
                return "";
            }

        }
        #endregion  ExtensionMethod
    }
}

