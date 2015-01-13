using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_User_Info_Model
    {
        public Sys_User_Info_Model()
        { }
        #region Model
        private int _user_id;
        private string _user_name;
        private string _user_location;
        private string _user_dept;
        private string _user_title;
        private string _user_mail;
        private string _user_password;
        private string _user_phase;
        private string _user_status;
        private string _user_lang;
        private string _user_above_section;
        private string _user_no_domain;
        private string _user_contact;
        private string _user_no_password;
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
        public string user_dept
        {
            set { _user_dept = value; }
            get { return _user_dept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_title
        {
            set { _user_title = value; }
            get { return _user_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_mail
        {
            set { _user_mail = value; }
            get { return _user_mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_password
        {
            set { _user_password = value; }
            get { return _user_password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_phase
        {
            set { _user_phase = value; }
            get { return _user_phase; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_status
        {
            set { _user_status = value; }
            get { return _user_status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_lang
        {
            set { _user_lang = value; }
            get { return _user_lang; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_above_section
        {
            set { _user_above_section = value; }
            get { return _user_above_section; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_no_domain
        {
            set { _user_no_domain = value; }
            get { return _user_no_domain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_contact
        {
            set { _user_contact = value; }
            get { return _user_contact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_no_password
        {
            set { _user_no_password = value; }
            get { return _user_no_password; }
        }
        #endregion Model

    }
}
