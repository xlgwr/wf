using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Common;
using Workflow.DAL;
using Workflow.Model;
namespace Workflow.BLL
{
    /// <summary>
    /// V_PO_Query_Right_Model
    /// </summary>
    public partial class V_PO_Query_Right
    {
        private readonly Workflow.DAL.V_PO_Query_RightDAL dal = new Workflow.DAL.V_PO_Query_RightDAL();
        public V_PO_Query_Right()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string right_user, string right_nbr, string right_location, string right_guid, int right_seq, string right_type, string right_buyer, DateTime right_date)
        {
            return dal.Exists(right_user, right_nbr, right_location, right_guid, right_seq, right_type, right_buyer, right_date);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.V_PO_Query_Right_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.V_PO_Query_Right_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string right_user, string right_nbr, string right_location, string right_guid, int right_seq, string right_type, string right_buyer, DateTime right_date)
        {

            return dal.Delete(right_user, right_nbr, right_location, right_guid, right_seq, right_type, right_buyer, right_date);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.V_PO_Query_Right_Model GetModel(string right_user, string right_nbr, string right_location, string right_guid, int right_seq, string right_type, string right_buyer, DateTime right_date)
        {

            return dal.GetModel(right_user, right_nbr, right_location, right_guid, right_seq, right_type, right_buyer, right_date);
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
        public List<Workflow.Model.V_PO_Query_Right_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.V_PO_Query_Right_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.V_PO_Query_Right_Model> modelList = new List<Workflow.Model.V_PO_Query_Right_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.V_PO_Query_Right_Model model;
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
        #endregion  BasicMethod
        #region  ExtensionMethod
        public bool Exists(string right_user)
        {
            return dal.Exists(right_user);
        }

        #endregion  ExtensionMethod
    }
}

