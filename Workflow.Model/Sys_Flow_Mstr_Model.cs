using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Flow_Mstr_Model
    {
        public Sys_Flow_Mstr_Model()
        { }
        #region Model
        private int _flow_id;
        private string _flow_type;
        private string _flow_location;
        private string _flow_group;
        private int _flow_seq;
        private int _flow_back_seq;
        private int _flow_level;
        private string _flow_page;
        private string _flow_table;
        private string _flow_condition_flag;
        private string _flow_condition_content;
        private string _flow_status_en;
        private string _flow_status_cn;
        private string _flow_parallel_flag;
        private string _flow_current_status;
        private DateTime? _flow_last_start_date;
        private string _flow_condition_display_en;
        private string _flow_condition_display_cn;
        /// <summary>
        /// 
        /// </summary>
        public int flow_id
        {
            set { _flow_id = value; }
            get { return _flow_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_type
        {
            set { _flow_type = value; }
            get { return _flow_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_location
        {
            set { _flow_location = value; }
            get { return _flow_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_group
        {
            set { _flow_group = value; }
            get { return _flow_group; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int flow_seq
        {
            set { _flow_seq = value; }
            get { return _flow_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int flow_back_seq
        {
            set { _flow_back_seq = value; }
            get { return _flow_back_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int flow_level
        {
            set { _flow_level = value; }
            get { return _flow_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_page
        {
            set { _flow_page = value; }
            get { return _flow_page; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_table
        {
            set { _flow_table = value; }
            get { return _flow_table; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_condition_flag
        {
            set { _flow_condition_flag = value; }
            get { return _flow_condition_flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_condition_content
        {
            set { _flow_condition_content = value; }
            get { return _flow_condition_content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_status_en
        {
            set { _flow_status_en = value; }
            get { return _flow_status_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_status_cn
        {
            set { _flow_status_cn = value; }
            get { return _flow_status_cn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_parallel_flag
        {
            set { _flow_parallel_flag = value; }
            get { return _flow_parallel_flag; }
        }
        /// <summary>
        /// current status
        /// </summary>
        public string flow_current_status
        {
            set { _flow_current_status = value; }
            get { return _flow_current_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? flow_last_start_date
        {
            set { _flow_last_start_date = value; }
            get { return _flow_last_start_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_condition_display_en
        {
            set { _flow_condition_display_en = value; }
            get { return _flow_condition_display_en; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_condition_display_cn
        {
            set { _flow_condition_display_cn = value; }
            get { return _flow_condition_display_cn; }
        }
        #endregion Model

    }
}

