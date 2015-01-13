using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Form_Mstr_Model
    {
        public Sys_Form_Mstr_Model()
        { }
        #region Model
        private string _form_guid;
        private string _form_nbr;
        private string _form_location;
        private string _form_type;
        private string _form_dept;
        private string _form_applicant;
        private int _form_seq;
        private DateTime _form_date;
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string form_guid
        {
            set { _form_guid = value; }
            get { return _form_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// 
        public string form_nbr
        {
            set { _form_nbr = value; }
            get { return _form_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string form_location
        {
            set { _form_location = value; }
            get { return _form_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string form_type
        {
            set { _form_type = value; }
            get { return _form_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string form_dept
        {
            set { _form_dept = value; }
            get { return _form_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string form_applicant
        {
            set { _form_applicant = value; }
            get { return _form_applicant; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int form_seq
        {
            set { _form_seq = value; }
            get { return _form_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime form_date
        {
            set { _form_date = value; }
            get { return _form_date; }
        }
        #endregion Model

    }
}

