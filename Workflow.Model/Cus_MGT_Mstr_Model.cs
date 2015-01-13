using System;
namespace Workflow.Model
{
    /// <summary>
    /// Cus_MGT_Mstr_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cus_MGT_Mstr_Model
    {
        public Cus_MGT_Mstr_Model()
        { }
        #region Model
        private int _manage_id;
        private string _manage_location;
        private string _manage_dept;
        private string _manage_name;
        private string _manage_title;
        private int _manage_level = 0;
        private string _manage_cre_by;
        private DateTime _manage_cre_date;
        private string _manage_lastmodify_by;
        private DateTime _manage_lastmodify_date;
        private string _manage_status;
        /// <summary>
        /// 
        /// </summary>
        public int manage_id
        {
            set { _manage_id = value; }
            get { return _manage_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_location
        {
            set { _manage_location = value; }
            get { return _manage_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_dept
        {
            set { _manage_dept = value; }
            get { return _manage_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_name
        {
            set { _manage_name = value; }
            get { return _manage_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_title
        {
            set { _manage_title = value; }
            get { return _manage_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int manage_level
        {
            set { _manage_level = value; }
            get { return _manage_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_cre_by
        {
            set { _manage_cre_by = value; }
            get { return _manage_cre_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime manage_cre_date
        {
            set { _manage_cre_date = value; }
            get { return _manage_cre_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_lastmodify_by
        {
            set { _manage_lastmodify_by = value; }
            get { return _manage_lastmodify_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime manage_lastmodify_date
        {
            set { _manage_lastmodify_date = value; }
            get { return _manage_lastmodify_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manage_status
        {
            set { _manage_status = value; }
            get { return _manage_status; }
        }
        #endregion Model

    }
}

