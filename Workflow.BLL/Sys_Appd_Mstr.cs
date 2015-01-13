using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
namespace Workflow.BLL
{
    public partial class Sys_Appd_Mstr
    {
        private readonly Workflow.DAL.Sys_Appd_MstrDAL dal = new Workflow.DAL.Sys_Appd_MstrDAL();
        public Sys_Appd_Mstr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string appd_nbr, string appd_location, string appd_type, string appd_user, string appd_mandator, string appd_dept, int appd_seq, int appd_level, string appd_action, int appd_line, string appd_remark, DateTime appd_date)
        {
            return dal.Exists(appd_nbr, appd_location, appd_type, appd_user, appd_mandator, appd_dept, appd_seq, appd_level, appd_action, appd_line, appd_remark, appd_date);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Appd_Mstr_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Sys_Appd_Mstr_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string appd_nbr, string appd_location, string appd_type, string appd_user, string appd_mandator, string appd_dept, int appd_seq, int appd_level, string appd_action, int appd_line, string appd_remark, DateTime appd_date)
        {

            return dal.Delete(appd_nbr, appd_location, appd_type, appd_user, appd_mandator, appd_dept, appd_seq, appd_level, appd_action, appd_line, appd_remark, appd_date);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Sys_Appd_Mstr_Model GetModel(string appd_nbr, string appd_location, string appd_type, string appd_user, string appd_mandator, string appd_dept, int appd_seq, int appd_level, string appd_action, int appd_line, string appd_remark, DateTime appd_date)
        {

            return dal.GetModel(appd_nbr, appd_location, appd_type, appd_user, appd_mandator, appd_dept, appd_seq, appd_level, appd_action, appd_line, appd_remark, appd_date);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetSpecialList(string strWhere)
        {
            return dal.GetSpecialList(strWhere);
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
        public List<Workflow.Model.Sys_Appd_Mstr_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        public List<Workflow.Model.Sys_Appd_Mstr_Model> GetSpecialModelList(string strWhere)
        {
            DataSet ds = dal.GetSpecialList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
                public DataSet GetPORevList(string strNbr)
        {
            DataSet ds = dal.GetPORevList(strNbr);
            return ds;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Sys_Appd_Mstr_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Sys_Appd_Mstr_Model> modelList = new List<Workflow.Model.Sys_Appd_Mstr_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Sys_Appd_Mstr_Model model;
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

