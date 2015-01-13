using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
namespace Workflow.BLL
{

    public partial class Sys_Form_Mstr
    {
        private readonly Workflow.DAL.Sys_Form_MstrDAL dal = new Workflow.DAL.Sys_Form_MstrDAL();
        public Sys_Form_Mstr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string form_nbr)
        {
            return dal.Exists(form_nbr);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Sys_Form_Mstr_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Sys_Form_Mstr_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string form_nbr)
        {

            return dal.Delete(form_nbr);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string form_nbrlist)
        {
            return dal.DeleteList(form_nbrlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Sys_Form_Mstr_Model GetModel(string form_nbr)
        {

            return dal.GetModel(form_nbr);
        }
        public Workflow.Model.Sys_Form_Mstr_Model GetModel(string form_seq,string form_type,string form_location)
        {

            return dal.GetModel(form_seq,form_type,form_location);
        }
        public Workflow.Model.Sys_Form_Mstr_Model GetGuidModel(string form_guid)
        {

            return dal.GetGuidModel(form_guid);
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
        public List<Workflow.Model.Sys_Form_Mstr_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Sys_Form_Mstr_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Sys_Form_Mstr_Model> modelList = new List<Workflow.Model.Sys_Form_Mstr_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Sys_Form_Mstr_Model model;
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
        public DataSet GetPOList(string strName)
        {
            return dal.GetPOList(strName);
        }
        public DataSet GetStatusList(string strWhere)
        {
            return dal.GetStatusList(strWhere);
        }
        public DataSet GetPOStatusList(string strWhere)
        {
            return dal.GetPOStatusList(strWhere);
        }
        public bool UpdateSeq(Workflow.Model.Sys_Form_Mstr_Model model)
        {
            return dal.UpdateSeq(model);
        }
        #endregion  ExtensionMethod
    }
}

