using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Cus_UserPP_Right_Model
    {
        public Cus_UserPP_Right_Model()
        { }
        #region Model
        private string _user_group;
        private string _user_site;
        private string _user_part_fr;
        private string _user_part_to;
        private string _user_id;
        private string _user_name;
        private string _user_location;
        private string _user_mail;
        private string _user_act_name;
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
        public string user_site
        {
            set { _user_site = value; }
            get { return _user_site; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_part_Fr
        {
            set { _user_part_fr = value; }
            get { return _user_part_fr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_part_to
        {
            set { _user_part_to = value; }
            get { return _user_part_to; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_id
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
        public string user_mail
        {
            set { _user_mail = value; }
            get { return _user_mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string user_act_name
        {
            set { _user_act_name = value; }
            get { return _user_act_name; }
        }
        #endregion Model

    }
}

