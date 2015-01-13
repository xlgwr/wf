using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Cus_Job_Mstr_Model
    {
        public Cus_Job_Mstr_Model()
        { }
        #region Model
        private string _job_guid;
        private string _job_nbr;
        private string _job_applicant;
        private string _job_location;
        private string _job_applicant_dept;
        private string _job_dept;
        private int _job_seq;
        private DateTime _job_date;
        private string _job_title;
        private string _job_desc;
        private string _job_rmk;
        private int _job_lines;
        private string _job_key;
        private string _job_approver;
        private string _job_recruiter;
        private string _job_adviser;
        /// <summary>
        /// 
        /// </summary>
        public string job_guid
        {
            set { _job_guid = value; }
            get { return _job_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_nbr
        {
            set { _job_nbr = value; }
            get { return _job_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_applicant
        {
            set { _job_applicant = value; }
            get { return _job_applicant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_location
        {
            set { _job_location = value; }
            get { return _job_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_applicant_dept
        {
            set { _job_applicant_dept = value; }
            get { return _job_applicant_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_dept
        {
            set { _job_dept = value; }
            get { return _job_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int job_seq
        {
            set { _job_seq = value; }
            get { return _job_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime job_date
        {
            set { _job_date = value; }
            get { return _job_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_title
        {
            set { _job_title = value; }
            get { return _job_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_desc
        {
            set { _job_desc = value; }
            get { return _job_desc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string job_rmk
        {
            set { _job_rmk = value; }
            get { return _job_rmk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int job_lines
        {
            set { _job_lines = value; }
            get { return _job_lines; }
        }
        public string job_key
        {
            set { _job_key = value; }
            get { return _job_key; }
        }
        public string job_approver
        {
            set { _job_approver = value; }
            get { return _job_approver; }
        }
        public string job_recruiter
        {
            set { _job_recruiter = value; }
            get { return _job_recruiter; }
        }
        public string job_adviser
        {
            set { _job_adviser = value; }
            get { return _job_adviser; }
        }
        #endregion Model

    }
}

