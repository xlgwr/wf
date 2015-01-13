using System;
namespace Workflow.Model
{
    /// <summary>
    /// Sys_User_Group_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_User_Group_Model
    {
        public Sys_User_Group_Model()
        { }
        #region Model
        private int _user_id;
        private string _user_name;
        private string _user_location;
        private string _user_group;
        private string _user_custom;
        private string _user_readonly = "N";
        /// <summary>
        /// 
        /// </summary>
        public int user_id
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
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
        public string user_location
        {
            set { _user_location = value; }
            get { return _user_location; }
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
        public string user_readonly
        {
            set { _user_readonly = value; }
            get { return _user_readonly; }
        }
        #endregion Model

    }
}

