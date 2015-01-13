using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
    [Serializable]
    public partial class V_PO_Query_Right_Model
    {
        public V_PO_Query_Right_Model()
        { }
        #region Model
        private string _right_user;
        private string _right_nbr;
        private string _right_location;
        private string _right_guid;
        private int _right_seq;
        private string _right_type;
        private string _right_buyer;
        private DateTime _right_date;
        /// <summary>
        /// 
        /// </summary>
        public string right_user
        {
            set { _right_user = value; }
            get { return _right_user; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string right_nbr
        {
            set { _right_nbr = value; }
            get { return _right_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string right_location
        {
            set { _right_location = value; }
            get { return _right_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string right_guid
        {
            set { _right_guid = value; }
            get { return _right_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int right_seq
        {
            set { _right_seq = value; }
            get { return _right_seq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string right_type
        {
            set { _right_type = value; }
            get { return _right_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string right_buyer
        {
            set { _right_buyer = value; }
            get { return _right_buyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime right_date
        {
            set { _right_date = value; }
            get { return _right_date; }
        }
        #endregion Model

    }
}
