using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
namespace Workflow.BLL
{
    public partial class V_Appr_Flow
    {
        private readonly Workflow.DAL.V_Appr_FlowDAL dal = new Workflow.DAL.V_Appr_FlowDAL();
        public V_Appr_Flow()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string appr_nbr, string appr_location, string appr_type, int appr_seq, int appr_level, string appr_parallel, string approver, string appr_dept, DateTime appr_date_in, string appr_group, string appr_appr, string appr_now, string mandatory)
        {
            return dal.Exists(appr_nbr, appr_location, appr_type, appr_seq, appr_level, appr_parallel, approver, appr_dept, appr_date_in, appr_group, appr_appr, appr_now, mandatory);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.V_Appr_Flow_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.V_Appr_Flow_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string appr_nbr, string appr_location, string appr_type, int appr_seq, int appr_level, string appr_parallel, string approver, string appr_dept, DateTime appr_date_in, string appr_group, string appr_appr, string appr_now, string mandatory)
        {

            return dal.Delete(appr_nbr, appr_location, appr_type, appr_seq, appr_level, appr_parallel, approver, appr_dept, appr_date_in, appr_group, appr_appr, appr_now, mandatory);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.V_Appr_Flow_Model GetModel(string appr_nbr, string appr_location, string appr_type, int appr_seq, int appr_level, string appr_parallel, string approver, string appr_dept, DateTime appr_date_in, string appr_group, string appr_appr, string appr_now, string mandatory)
        {

            return dal.GetModel(appr_nbr, appr_location, appr_type, appr_seq, appr_level, appr_parallel, approver, appr_dept, appr_date_in, appr_group, appr_appr, appr_now, mandatory);
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
        public List<Workflow.Model.V_Appr_Flow_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.V_Appr_Flow_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.V_Appr_Flow_Model> modelList = new List<Workflow.Model.V_Appr_Flow_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.V_Appr_Flow_Model model;
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
        public bool ExistsApproveRight(string appr_nbr, string appr_location ,string approver)
        {
            return dal.ExistsApproveRight(appr_nbr, appr_location, approver);
        }
        #endregion  ExtensionMethod
    }
}

