using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Common;
using Workflow.Model;
namespace Workflow.BLL
{
    /// <summary>
    /// Sys_User_Group_Model
    /// </summary>
    public partial class Sys_User_Group
    {
        private readonly Workflow.DAL.Sys_User_GroupDAL dal = new Workflow.DAL.Sys_User_GroupDAL();
        public Sys_User_Group()
        { }
        #region  BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Workflow.Model.Sys_User_Group_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Sys_User_Group_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int user_id)
        {

            return dal.Delete(user_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string user_idlist)
        {
            return dal.DeleteList(user_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Sys_User_Group_Model GetModel(int user_id)
        {

            return dal.GetModel(user_id);
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
        public List<Workflow.Model.Sys_User_Group_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Sys_User_Group_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Sys_User_Group_Model> modelList = new List<Workflow.Model.Sys_User_Group_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Sys_User_Group_Model model;
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
        public bool ExistsUserGroup(string user_name, string user_group)
        {
            return dal.ExistsUserGroup(user_name, user_group);
        }
        public bool ExistsUserGroupLocation(string user_name, string user_group,string user_location)
        {
            return dal.ExistsUserGroupLocation(user_name, user_group,user_location);
        }
        #endregion  ExtensionMethod
    }
}

