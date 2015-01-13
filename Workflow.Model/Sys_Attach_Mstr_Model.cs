using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Attach_Mstr_Model
    {
        public Sys_Attach_Mstr_Model()
        { }
        #region Model
        private int _attach_id;
        private string _attach_nbr;
        private string _attach_location;
        private string _attach_type;
        private string _attach_title;
        private string _attach_path;
        private string _attach_user;
        private string _attach_guid;
        private DateTime _attach_time;
        private string _attach_rmk1;
        private string _attach_rmk2;
        private string _attach_rmk3;
        /// <summary>
        /// 
        /// </summary>
        public int attach_id
        {
            set { _attach_id = value; }
            get { return _attach_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attach_nbr
        {
            set { _attach_nbr = value; }
            get { return _attach_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attach_location
        {
            set { _attach_location = value; }
            get { return _attach_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attach_type
        {
            set { _attach_type = value; }
            get { return _attach_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attach_title
        {
            set { _attach_title = value; }
            get { return _attach_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attach_path
        {
            set { _attach_path = value; }
            get { return _attach_path; }
        }

        public string attach_user
        {
            set { _attach_user = value; }
            get { return _attach_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime attach_time
        {
            set { _attach_time = value; }
            get { return _attach_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attach_guid
        {
            set { _attach_guid = value; }
            get { return _attach_guid; }
        }
        public string attach_rmk1
        {
            set { _attach_rmk1 = value; }
            get { return _attach_rmk1; }
        }
        public string attach_rmk2
        {
            set { _attach_rmk2 = value; }
            get { return _attach_rmk2; }
        }
        public string attach_rmk3
        {
            set { _attach_rmk3 = value; }
            get { return _attach_rmk3; }
        }
        #endregion Model

    }
}
