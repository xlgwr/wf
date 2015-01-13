using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Workflow.BLL
{
    public partial class Sys_User_Info
    {
        private readonly Workflow.DAL.SysUserManageDAL dal = new Workflow.DAL.SysUserManageDAL();
        public Sys_User_Info()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string user_name,string user_password)
        {
            return dal.Exists(user_name, user_password);
        }

        public bool NodomainExists(string user_name, string user_phase)
        {
            return dal.NodomainExists(user_name, user_phase);
        }

        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_User_Info_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Sys_User_Info_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string user_id)
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
        public Workflow.Model.Sys_User_Info_Model GetModel(string user_id)
        {

            return dal.GetModel(user_id);
        }
        public Workflow.Model.Sys_User_Info_Model GetModel(string user_id, string user_location)
        {
            return dal.GetModel(user_id, user_location);
        }
        public Workflow.Model.Sys_User_Info_Model GetModel(string user_id, string user_password,string location)
        {

            return dal.GetModel(user_id,user_password,location);
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
        public List<Workflow.Model.Sys_User_Info_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Sys_User_Info_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Sys_User_Info_Model> modelList = new List<Workflow.Model.Sys_User_Info_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Sys_User_Info_Model model;
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
        public DataSet GetDeptList(string strWhere)
        {
            return dal.GetDeptList(strWhere);
        }
        public List<Workflow.Model.Sys_User_Dept_Model> GetDeptModelList(string strWhere)
        {
            DataSet ds = dal.GetDeptList(strWhere);
            return DataTableToList_Dept(ds.Tables[0]);
        }

        public List<Workflow.Model.Sys_User_Dept_Model> DataTableToList_Dept(DataTable dt)
        {
            List<Workflow.Model.Sys_User_Dept_Model> modelList = new List<Workflow.Model.Sys_User_Dept_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Sys_User_Dept_Model model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel_Dept(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public bool UpdateLanguage(Workflow.Model.Sys_User_Info_Model model)
        {
            return dal.UpdateLanguage(model);
        }
        public void ExecResetUser()
        {
              dal.ExecResetUser();
        }
        public void ExecAddUser(Workflow.Model.Sys_User_Info_Model model)
        {
            dal.ExecAddUser(model);
        }
        public void ExecDelUser()
        {
            dal.ExecDelUser();
        }
        #endregion  ExtensionMethod
    }
}
