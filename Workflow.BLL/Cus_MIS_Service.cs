using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
using Workflow.DAL;
namespace Workflow.BLL
{
    public partial class Cus_MIS_Service
    {
        private readonly Workflow.DAL.Cus_MIS_ServiceDAL dal = new Workflow.DAL.Cus_MIS_ServiceDAL();
        public Cus_MIS_Service()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string m_svr_nbr)
        {
            return dal.Exists(m_svr_nbr);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_MIS_Service_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_MIS_Service_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string m_svr_nbr)
        {

            return dal.Delete(m_svr_nbr);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string m_svr_nbrlist)
        {
            return dal.DeleteList(m_svr_nbrlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_MIS_Service_Model GetModel(string m_svr_nbr)
        {

            return dal.GetModel(m_svr_nbr);
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
        public List<Workflow.Model.Cus_MIS_Service_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_MIS_Service_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_MIS_Service_Model> modelList = new List<Workflow.Model.Cus_MIS_Service_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_MIS_Service_Model model;
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

        public DataSet DsQuery(string strWhere,string strLang)
        {
            return dal.DsQuery(strWhere,strLang);
        }
        public string SaveMISService(Workflow.Model.Cus_MIS_Service_Model model)
        {
            string strIret = new Cus_MIS_ServiceDAL().SaveMISService(model);
            return strIret;
        }
        public bool UpdateRelative(Workflow.Model.Cus_MIS_Service_Model model)
        {
            return dal.UpdateRelative(model);
        }
        public bool UpdateProcess(Workflow.Model.Cus_MIS_Service_Model model)
        {
            return dal.UpdateProcess(model);
        }
        public bool UpdateAct(Workflow.Model.Cus_MIS_Service_Model model)
        {
            return dal.UpdateAct(model);
        }
        #endregion  ExtensionMethod
    }
}

