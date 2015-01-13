using System;
namespace Workflow.Model
{
	/// <summary>
	/// Sys_Entrust_Mstr_Model:
	/// </summary>
	[Serializable]
	public partial class Sys_Entrust_Mstr_Model
	{
		public Sys_Entrust_Mstr_Model()
		{}
		#region Model
		private int _entrust_id;
		private string _entrust_type;
		private string _entrust_by;
		private string _entrust_to;
		private string _entrust_location;
		private DateTime _entrust_begin;
		private DateTime _entrust_end;
		private DateTime _entrust_date;
		private string _entrust_status;
        private string _entrust_creater;

       
		/// <summary>
		/// 
		/// </summary>
		public int entrust_id
		{
			set{ _entrust_id=value;}
			get{return _entrust_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entrust_type
		{
			set{ _entrust_type=value;}
			get{return _entrust_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entrust_by
		{
			set{ _entrust_by=value;}
			get{return _entrust_by;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entrust_to
		{
			set{ _entrust_to=value;}
			get{return _entrust_to;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entrust_location
		{
			set{ _entrust_location=value;}
			get{return _entrust_location;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime entrust_begin
		{
			set{ _entrust_begin=value;}
			get{return _entrust_begin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime entrust_end
		{
			set{ _entrust_end=value;}
			get{return _entrust_end;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime entrust_date
		{
			set{ _entrust_date=value;}
			get{return _entrust_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string entrust_status
		{
			set{ _entrust_status=value;}
			get{return _entrust_status;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Entrust_creater
        {
            get { return _entrust_creater; }
            set { _entrust_creater = value; }
        }
		#endregion Model

	}
}

