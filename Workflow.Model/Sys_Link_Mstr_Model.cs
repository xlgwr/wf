using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Link_Mstr_Model
    {
        public Sys_Link_Mstr_Model()
        { }
        #region Model
        private string _link_guid;
        private string _link_type;
        private string _link_user;
        private int? _link_count = 0;
        private DateTime _link_date;
        private string _link_effected = "N";
        /// <summary>
        /// 
        /// </summary>
        public string link_guid
        {
            set { _link_guid = value; }
            get { return _link_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string link_type
        {
            set { _link_type = value; }
            get { return _link_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string link_user
        {
            set { _link_user = value; }
            get { return _link_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? link_count
        {
            set { _link_count = value; }
            get { return _link_count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime link_date
        {
            set { _link_date = value; }
            get { return _link_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string link_effected
        {
            set { _link_effected = value; }
            get { return _link_effected; }
        }
        #endregion Model

    }
}

