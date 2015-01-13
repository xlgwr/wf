using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Common;
using Workflow.Model;
namespace Workflow.BLL
{
    public partial class Cus_Job_Det
    {
        private readonly Workflow.DAL.Cus_Job_DetDAL dal = new Workflow.DAL.Cus_Job_DetDAL();
        public Cus_Job_Det()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string cv_guid)
        {
            return dal.Exists(cv_guid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Workflow.Model.Cus_Job_Det_Model model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Workflow.Model.Cus_Job_Det_Model model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string cv_guid)
        {

            return dal.Delete(cv_guid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string cv_guidlist)
        {
            return dal.DeleteList(cv_guidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Workflow.Model.Cus_Job_Det_Model GetModel(string cv_guid)
        {

            return dal.GetModel(cv_guid);
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
        public List<Workflow.Model.Cus_Job_Det_Model> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Workflow.Model.Cus_Job_Det_Model> DataTableToList(DataTable dt)
        {
            List<Workflow.Model.Cus_Job_Det_Model> modelList = new List<Workflow.Model.Cus_Job_Det_Model>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Workflow.Model.Cus_Job_Det_Model model;
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
        public DataTable getList(string strWhere, string strLang)
        {
            return dal.GetList(strWhere, strLang).Tables[0];
        }
        public DataTable getListByApprover(string strWhere, string strLang)
        {
            return dal.getListByApprover(strWhere, strLang).Tables[0];
        }
        public string ExecCVProc(string job_nbr, string cv_nbr, int job_lines, string job_location, string cv_user, string cv_type, string attach_path, string cv_rmk, string auto, string filename, string cv_path, string send_user, string send_subject)
        {
            string strIret = dal.ExecCVProc(job_nbr, cv_nbr, job_lines, job_location, cv_user, cv_type, attach_path, cv_rmk, auto, filename, cv_path, send_user, send_subject);
            return strIret;
        }

        public bool UpdateRelative(Cus_Job_Det_Model model)
        {
            return dal.UpdateRelative(model);
        }
        public bool UpdateConfirmDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            return dal.UpdateConfirmDate(model);
        }
        public bool UpdateExtendProbationDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            return dal.UpdateExtendProbationDate(model);
        }
        public bool UpdateOnBoardDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            return dal.UpdateOnBoardDate(model);
        }
        public bool UpdateExpectOnBoardDate(Workflow.Model.Cus_Job_Det_Model model)
        {
            return dal.UpdateExpectOnBoardDate(model);
        }
        public bool UpdateCandidate(string cv_guid, string cv_candidate, string cv_candidate_phone,string cv_candidate_gender)
        {
            return dal.UpdateCandidate(cv_guid, cv_candidate, cv_candidate_phone, cv_candidate_gender);
        }
        public DataSet GetCVTaskList(string strWhere)
        {
            return dal.GetCVTaskList(strWhere);
        }
        #endregion  ExtensionMethod
    }
}

