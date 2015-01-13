using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Common;
using Workflow.Model;
namespace Workflow.BLL
{
    /// <summary>
    /// Cus_Job_Interview_Model
    /// </summary>
    public partial class Cus_Job_Interview
    {
        private readonly Workflow.DAL.Cus_Job_InterviewDAL dal = new Workflow.DAL.Cus_Job_InterviewDAL();
        public Cus_Job_Interview()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int interview_id, int interview_round, string interview_cv_guid, string interview_by, DateTime interview_date, DateTime interview_cre_date, string interview_cre_by)
        {
            return dal.Exists(interview_id, interview_round, interview_cv_guid, interview_by, interview_date, interview_cre_date, interview_cre_by);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Workflow.Model.Cus_Job_Interview_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_Job_Interview_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int interview_id)
        {

            return dal.Delete(interview_id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string interview_idlist)
        {
            return dal.DeleteList(interview_idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_Job_Interview_Model GetModel(int interview_id)
        {

            return dal.GetModel(interview_id);
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
        public List<Workflow.Model.Cus_Job_Interview_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_Job_Interview_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_Job_Interview_Model> modelList = new List<Workflow.Model.Cus_Job_Interview_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_Job_Interview_Model model;
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
        public bool ExistsRound(int interview_round, string interview_cv_guid)
        {
            return dal.ExistsRound(interview_round, interview_cv_guid);
        }
        #endregion  ExtensionMethod
    }
}

