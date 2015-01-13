using System;
namespace Workflow.Model
{
    /// <summary>
    /// Sys_Appr_Mstr:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_Appr_Mstr
    {
        public Sys_Appr_Mstr()
        { }
        #region Model
        private string _appr_nbr;
        private string _appr_location;
        private string _appr_type;
        private int? _appr_seq;
        private int? _appr_level;
        private string _appr_parallel;
        private string _appr_user;
        private string _appr_dept;
        private DateTime? _appr_date_in;
        private string _appr_group;
        private string _appr_appr;
        private string _appr_now;
        /// <summary>
        /// 
        /// </summary>
        public string appr_nbr
        {
            set { _appr_nbr = value; }
            get { return _appr_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_location
        {
            set { _appr_location = value; }
            get { return _appr_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_type
        {
            set { _appr_type = value; }
            get { return _appr_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appr_seq
        {
            set { _appr_seq = value; }
            get { return _appr_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? appr_level
        {
            set { _appr_level = value; }
            get { return _appr_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_parallel
        {
            set { _appr_parallel = value; }
            get { return _appr_parallel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_user
        {
            set { _appr_user = value; }
            get { return _appr_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_dept
        {
            set { _appr_dept = value; }
            get { return _appr_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? appr_date_in
        {
            set { _appr_date_in = value; }
            get { return _appr_date_in; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_group
        {
            set { _appr_group = value; }
            get { return _appr_group; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_appr
        {
            set { _appr_appr = value; }
            get { return _appr_appr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appr_now
        {
            set { _appr_now = value; }
            get { return _appr_now; }
        }
        #endregion Model

    }
}

