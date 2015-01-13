using System;
namespace Workflow.Model
{
    /// <summary>
    /// Cus_Job_Interview_Model:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Cus_Job_Interview_Model
    {
        public Cus_Job_Interview_Model()
        { }
        #region Model
        private int _interview_id;
        private int? _interview_round;
        private string _interview_cv_guid;
        private string _interview_by;
        private DateTime? _interview_date;
        private DateTime? _interview_cre_date;
        private string _interview_cre_by;
        private string _interview_type;
        /// <summary>
        /// 
        /// </summary>
        public int interview_id
        {
            set { _interview_id = value; }
            get { return _interview_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? interview_round
        {
            set { _interview_round = value; }
            get { return _interview_round; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string interview_cv_guid
        {
            set { _interview_cv_guid = value; }
            get { return _interview_cv_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string interview_by
        {
            set { _interview_by = value; }
            get { return _interview_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? interview_date
        {
            set { _interview_date = value; }
            get { return _interview_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? interview_cre_date
        {
            set { _interview_cre_date = value; }
            get { return _interview_cre_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string interview_cre_by
        {
            set { _interview_cre_by = value; }
            get { return _interview_cre_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string interview_type
        {
            set { _interview_type = value; }
            get { return _interview_type; }
        }
        #endregion Model

    }
}

