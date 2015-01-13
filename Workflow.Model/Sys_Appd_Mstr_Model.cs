using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Appd_Mstr_Model
    {
        public Sys_Appd_Mstr_Model()
        { }
        #region Model
        private string _appd_nbr;
        private string _appd_location;
        private string _appd_type;
        private string _appd_user;
        private string _appd_mandator;
        private string _appd_dept;
        private int? _appd_seq;
        private int? _appd_level;
        private string _appd_action;
        private int? _appd_line;
        private string _appd_remark;
        private DateTime? _appd_date;
        private string _appd_guid;
        private string _appd_parallel_flag;
        /// <summary>
        /// 
        /// </summary>
        public string appd_nbr
        {
            set { _appd_nbr = value; }
            get { return _appd_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_location
        {
            set { _appd_location = value; }
            get { return _appd_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_type
        {
            set { _appd_type = value; }
            get { return _appd_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_user
        {
            set { _appd_user = value; }
            get { return _appd_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_mandator
        {
            set { _appd_mandator = value; }
            get { return _appd_mandator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_dept
        {
            set { _appd_dept = value; }
            get { return _appd_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appd_seq
        {
            set { _appd_seq = value; }
            get { return _appd_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appd_level
        {
            set { _appd_level = value; }
            get { return _appd_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_action
        {
            set { _appd_action = value; }
            get { return _appd_action; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appd_line
        {
            set { _appd_line = value; }
            get { return _appd_line; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appd_remark
        {
            set { _appd_remark = value; }
            get { return _appd_remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? appd_date
        {
            set { _appd_date = value; }
            get { return _appd_date; }
        }
        public string appd_guid
        {
            set { _appd_guid = value; }
            get { return _appd_guid; }
        }
        public string appd_parallel_flag
        {
            set { _appd_parallel_flag = value; }
            get { return _appd_parallel_flag; }
        }
        #endregion Model

    }
}

