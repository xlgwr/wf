using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Login_Record_Model
    {
        public Sys_Login_Record_Model()
        { }
        #region Model
        private string _login_user;
        private string _login_location;
        private string _login_ip;
        private string _login_hostname;
        private string _login_browser;
        private DateTime? _login_date;
        /// <summary>
        /// 
        /// </summary>
        public string login_user
        {
            set { _login_user = value; }
            get { return _login_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string login_location
        {
            set { _login_location = value; }
            get { return _login_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string login_ip
        {
            set { _login_ip = value; }
            get { return _login_ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string login_hostname
        {
            set { _login_hostname = value; }
            get { return _login_hostname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string login_browser
        {
            set { _login_browser = value; }
            get { return _login_browser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? login_date
        {
            set { _login_date = value; }
            get { return _login_date; }
        }
        #endregion Model

    }
}

