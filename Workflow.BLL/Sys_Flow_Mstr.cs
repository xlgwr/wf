using System;
using System.Data;
using System.Collections.Generic;
using Workflow.Model;
using Workflow.DAL;
namespace Workflow.BLL
{
	public partial class Sys_Flow_Mstr
	{
		private readonly Workflow.DAL.Sys_Flow_MstrDAL dal=new Workflow.DAL.Sys_Flow_MstrDAL();
		public Sys_Flow_Mstr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int flow_id)
		{
			return dal.Exists(flow_id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Workflow.Model.Sys_Flow_Mstr_Model model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Workflow.Model.Sys_Flow_Mstr_Model model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int flow_id)
		{
			
			return dal.Delete(flow_id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string flow_idlist )
		{
			return dal.DeleteList(flow_idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Workflow.Model.Sys_Flow_Mstr_Model GetModel(int flow_id)
		{
			
			return dal.GetModel(flow_id);
		}
        public Workflow.Model.Sys_Flow_Mstr_Model GetModel(string flow_location,int flow_seq,string flow_type)
        {

            return dal.GetModel(flow_location, flow_seq, flow_type);
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Workflow.Model.Sys_Flow_Mstr_Model> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Workflow.Model.Sys_Flow_Mstr_Model> DataTableToList(DataTable dt)
		{
			List<Workflow.Model.Sys_Flow_Mstr_Model> modelList = new List<Workflow.Model.Sys_Flow_Mstr_Model>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Workflow.Model.Sys_Flow_Mstr_Model model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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
        public bool ExistsCondition(string strContent, string strNbr)
        {
            return dal.ExistsCondition(strContent, strNbr);
        }
        public DataSet GetFlowStepInfo(string strWhere, string strLang)
        {
            return dal.GetFlowStepInfo(strWhere, strLang);
        }

        public Workflow.Model.Sys_Flow_Mstr_Model GetModel(string flow_type,string flow_location, string flow_seq)
        {

            return dal.GetModel(flow_type,flow_location, flow_seq);
        }
		#endregion  ExtensionMethod
	}
}
