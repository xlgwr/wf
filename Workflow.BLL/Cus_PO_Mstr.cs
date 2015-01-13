using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Common;
using Workflow.Model;
namespace Workflow.BLL
{
    /// <summary>
    /// Cus_PO_Mstr_Model
    /// </summary>
    public partial class Cus_PO_Mstr
    {
        private readonly Workflow.DAL.Cus_PO_MstrDAL dal = new Workflow.DAL.Cus_PO_MstrDAL();
        public Cus_PO_Mstr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string po_guid)
        {
            return dal.Exists(po_guid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_PO_Mstr_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_PO_Mstr_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string po_guid)
        {

            return dal.Delete(po_guid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string po_guidlist)
        {
            return dal.DeleteList(po_guidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_PO_Mstr_Model GetModel(string po_guid)
        {

            return dal.GetModel(po_guid);
        }
        public Workflow.Model.Cus_PO_Mstr_Model GetModel(string po_loc,string po_nbr)
        {

            return dal.GetModel(po_loc,po_nbr);
        }
        public Workflow.Model.Cus_PO_Mstr_Model GetGuidModel(string po_guid)
        {

            return dal.GetGuidModel( po_guid);
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
        public List<Workflow.Model.Cus_PO_Mstr_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_PO_Mstr_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_PO_Mstr_Model> modelList = new List<Workflow.Model.Cus_PO_Mstr_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_PO_Mstr_Model model;
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
        public string ExecTerminatePOProc(string strGuid,string strUser)
        {
            string strIret = dal.ExecTerminatePOProc(strGuid, strUser);
            return strIret;
        }
        #endregion  ExtensionMethod
    }
}

