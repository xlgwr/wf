using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
using Workflow.DAL;
namespace Workflow.BLL
{
    public partial class Cus_UserPP_Right
    {
        private readonly Workflow.DAL.Cus_UserPP_RightDAL dal = new Workflow.DAL.Cus_UserPP_RightDAL();
        public Cus_UserPP_Right()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string user_group, string user_site, string user_part_Fr, string user_part_to, string user_id, string user_name, string user_location, string user_mail, string user_act_name)
        {
            return dal.Exists(user_group, user_site, user_part_Fr, user_part_to, user_id, user_name, user_location, user_mail, user_act_name);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_UserPP_Right_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_UserPP_Right_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string user_group, string user_site, string user_part_Fr, string user_part_to, string user_id, string user_name, string user_location, string user_mail, string user_act_name)
        {

            return dal.Delete(user_group, user_site, user_part_Fr, user_part_to, user_id, user_name, user_location, user_mail, user_act_name);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_UserPP_Right_Model GetModel(string user_group, string user_site, string user_part_Fr, string user_part_to, string user_id, string user_name, string user_location, string user_mail, string user_act_name)
        {

            return dal.GetModel(user_group, user_site, user_part_Fr, user_part_to, user_id, user_name, user_location, user_mail, user_act_name);
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
        public List<Workflow.Model.Cus_UserPP_Right_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_UserPP_Right_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_UserPP_Right_Model> modelList = new List<Workflow.Model.Cus_UserPP_Right_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_UserPP_Right_Model model;
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
        public bool ExistsPP(string user_name)
        {
            return dal.ExistsPP(user_name);
        }
        #endregion  ExtensionMethod
    }
}

