using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
namespace Workflow.BLL
{
    /// <summary>
    /// Cus_PO_Mstr_Hist_Model
    /// </summary>
    public partial class Cus_PO_Mstr_Hist
    {
        private readonly Workflow.DAL.Cus_PO_Mstr_HistDAL dal = new Workflow.DAL.Cus_PO_Mstr_HistDAL();
        public Cus_PO_Mstr_Hist()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string hist_po_guid)
        {
            return dal.Exists(hist_po_guid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_PO_Mstr_Hist_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_PO_Mstr_Hist_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string hist_po_guid)
        {

            return dal.Delete(hist_po_guid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string hist_po_guidlist)
        {
            return dal.DeleteList(hist_po_guidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_PO_Mstr_Hist_Model GetModel(string hist_po_guid)
        {

            return dal.GetModel(hist_po_guid);
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
        public DataSet GetSpecialList(string strWhere)
        {
            return dal.GetSpecialList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_PO_Mstr_Hist_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_PO_Mstr_Hist_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_PO_Mstr_Hist_Model> modelList = new List<Workflow.Model.Cus_PO_Mstr_Hist_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_PO_Mstr_Hist_Model model;
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

        #endregion  ExtensionMethod
    }
}

