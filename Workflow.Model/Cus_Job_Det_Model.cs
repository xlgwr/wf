using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Cus_Job_Det_Model
    {
        public Cus_Job_Det_Model()
        { }
        #region Model
        private string _cv_guid;
        private string _cv_job_guid;
        private string _cv_nbr;
        private string _cv_location;
        private string _cv_cre_by;
        private DateTime _cv_cre_date;
        private string _cv_path;
        private string _cv_rmk;
        private string _cv_relative;
        private DateTime _cv_confirm_date;
        private DateTime _cv_onboard_date;
        private string _cv_candidate;
        private string _cv_candidate_phone;
        private DateTime _cv_expect_onboard_date;
        private DateTime _cv_probation_end_date;
        private DateTime _cv_probation_end_extend_date;
        private string _cv_candidate_gender;
        /// <summary>
        /// 
        /// </summary>
        public string cv_guid
        {
            set { _cv_guid = value; }
            get { return _cv_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cv_job_guid
        {
            set { _cv_job_guid = value; }
            get { return _cv_job_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cv_nbr
        {
            set { _cv_nbr = value; }
            get { return _cv_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cv_location
        {
            set { _cv_location = value; }
            get { return _cv_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cv_cre_by
        {
            set { _cv_cre_by = value; }
            get { return _cv_cre_by; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime cv_cre_date
        {
            set { _cv_cre_date = value; }
            get { return _cv_cre_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cv_path
        {
            set { _cv_path = value; }
            get { return _cv_path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cv_rmk
        {
            set { _cv_rmk = value; }
            get { return _cv_rmk; }
        }
        public string cv_relative
        {
            set { _cv_relative = value; }
            get { return _cv_relative; }
        }
        public DateTime cv_confirm_date
        {
            set { _cv_confirm_date = value; }
            get { return _cv_confirm_date; }
        }
        public DateTime cv_onboard_date
        {
            set { _cv_onboard_date = value; }
            get { return _cv_onboard_date; }
        }
        public string cv_candidate
        {
            set { _cv_candidate = value; }
            get { return _cv_candidate; }
        }
        public string cv_candidate_phone
        {
            set { _cv_candidate_phone = value; }
            get { return _cv_candidate_phone; }
        }
        public DateTime cv_expect_onboard_date
        {
            set { _cv_expect_onboard_date = value; }
            get { return _cv_expect_onboard_date;}
        }
        public DateTime cv_probation_end_date
        {
            set { _cv_probation_end_date = value; }
            get { return _cv_probation_end_date; }
        }
        public DateTime cv_probation_end_extend_date
        {
            set { _cv_probation_end_extend_date = value; }
            get { return _cv_probation_end_extend_date; }
        }
        public string cv_candidate_gender
        {
            set { _cv_candidate_gender = value; }
            get { return _cv_candidate_gender; }
        }
        #endregion Model

    }
}

