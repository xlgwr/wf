using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
namespace Workflow.BLL
{
    public partial class V_User_Group
    {
        private readonly Workflow.DAL.V_User_GroupDAL dal = new Workflow.DAL.V_User_GroupDAL();
        public V_User_Group()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string user_name, string user_dept, string user_location, string flow_type, string user_group, string user_custom, string flow_group, int flow_seq, int flow_level, string flow_parallel_flag)
        {
            return dal.Exists(user_name, user_dept, user_location, flow_type, user_group, user_custom, flow_group, flow_seq, flow_level, flow_parallel_flag);
        }
        public bool ExistsUserGroup(string user_name, string user_group)
        {
            return dal.ExistsUserGroup(user_name, user_group);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.V_User_Group_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.V_User_Group_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string user_name, string user_dept, string user_location, string flow_type, string user_group, string user_custom, string flow_group, int flow_seq, int flow_level, string flow_parallel_flag)
        {

            return dal.Delete(user_name, user_dept, user_location, flow_type, user_group, user_custom, flow_group, flow_seq, flow_level, flow_parallel_flag);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.V_User_Group_Model GetModel(string user_name, string user_dept, string user_location, string flow_type, string user_group, string user_custom, string flow_group, int flow_seq, int flow_level, string flow_parallel_flag)
        {

            return dal.GetModel(user_name, user_dept, user_location, flow_type, user_group, user_custom, flow_group, flow_seq, flow_level, flow_parallel_flag);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.V_User_Group_Model GetModel(string user_name, string user_dept)
        {

            return dal.GetModel(user_name, user_dept);
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
        public List<Workflow.Model.V_User_Group_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.V_User_Group_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.V_User_Group_Model> modelList = new List<Workflow.Model.V_User_Group_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.V_User_Group_Model model;
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

