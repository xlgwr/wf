using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Flow_Config_Model
    {
        public Sys_Flow_Config_Model()
        { }
        #region Model
        private string _config_type;
        private string _config_prefix;
        private int _config_length;
        private int _config_seq;
        private DateTime _config_date = DateTime.Now;
        private string _config_title;
        private string _config_title_cn;
        /// <summary>
        /// 
        /// </summary>
        public string config_type
        {
            set { _config_type = value; }
            get { return _config_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string config_prefix
        {
            set { _config_prefix = value; }
            get { return _config_prefix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int config_length
        {
            set { _config_length = value; }
            get { return _config_length; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int config_seq
        {
            set { _config_seq = value; }
            get { return _config_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime config_date
        {
            set { _config_date = value; }
            get { return _config_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string config_title
        {
            set { _config_title = value; }
            get { return _config_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string config_title_cn
        {
            set { _config_title_cn = value; }
            get { return _config_title_cn; }
        }
        #endregion Model

    }
}

