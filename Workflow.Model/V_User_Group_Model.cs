using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class V_User_Group_Model
    {
        public V_User_Group_Model()
        { }
        #region Model
        private string _user_name;
        private string _user_dept;
        private string _flow_location;
        private string _flow_type;
        private string _user_group;
        private string _user_custom;
        private string _flow_group;
        private int _flow_seq;
        private int _flow_level;
        private string _flow_parallel_flag;
        /// <summary>
        /// 
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_dept
        {
            set { _user_dept = value; }
            get { return _user_dept; }
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
        public string flow_type
        {
            set { _flow_type = value; }
            get { return _flow_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_group
        {
            set { _user_group = value; }
            get { return _user_group; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_custom
        {
            set { _user_custom = value; }
            get { return _user_custom; }
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
        public int flow_level
        {
            set { _flow_level = value; }
            get { return _flow_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string flow_parallel_flag
        {
            set { _flow_parallel_flag = value; }
            get { return _flow_parallel_flag; }
        }
        #endregion Model

    }
}

