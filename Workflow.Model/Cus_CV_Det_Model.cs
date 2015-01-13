using System;
namespace Workflow.Model
{
    /// <summary>
    /// Cus_CV_Det_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cus_CV_Det_Model
    {
        public Cus_CV_Det_Model()
        { }
        #region Model
        private string _log_guid;
        private string _log_nbr;
        private string _log_location;
        private string _log_send_user;
        private string _log_domain;
        private string _log_subject;
        private string _log_path;
        private DateTime _log_cre_date = DateTime.Now;
        private string _log_cre_by;
        private string _log_modify_by;
        private DateTime _log_modify_date = DateTime.Now;
        private string _log_has_jobid;
        private string _log_flag;
        /// <summary>
        /// 
        /// </summary>
        public string log_guid
        {
            set { _log_guid = value; }
            get { return _log_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_nbr
        {
            set { _log_nbr = value; }
            get { return _log_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_location
        {
            set { _log_location = value; }
            get { return _log_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_send_user
        {
            set { _log_send_user = value; }
            get { return _log_send_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_domain
        {
            set { _log_domain = value; }
            get { return _log_domain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_subject
        {
            set { _log_subject = value; }
            get { return _log_subject; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_path
        {
            set { _log_path = value; }
            get { return _log_path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime log_cre_date
        {
            set { _log_cre_date = value; }
            get { return _log_cre_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_cre_by
        {
            set { _log_cre_by = value; }
            get { return _log_cre_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_modify_by
        {
            set { _log_modify_by = value; }
            get { return _log_modify_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime log_modify_date
        {
            set { _log_modify_date = value; }
            get { return _log_modify_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_has_jobid
        {
            set { _log_has_jobid = value; }
            get { return _log_has_jobid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string log_flag
        {
            set { _log_flag = value; }
            get { return _log_flag; }
        }
        #endregion Model

    }
}

