using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Menu_Mstr_Model
    {
        public Sys_Menu_Mstr_Model()
        { }
        #region Model
        private string _menu_id;
        private string _menu_name;
        private string _menu_page;
        private int _menu_level;
        private int _menu_order;
        private string _menu_title;
        private string _menu_title_cn;
        private string _menu_type;
        /// <summary>
        /// 
        /// </summary>
        public string menu_id
        {
            set { _menu_id = value; }
            get { return _menu_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string menu_name
        {
            set { _menu_name = value; }
            get { return _menu_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string menu_page
        {
            set { _menu_page = value; }
            get { return _menu_page; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int menu_level
        {
            set { _menu_level = value; }
            get { return _menu_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int menu_order
        {
            set { _menu_order = value; }
            get { return _menu_order; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string menu_title
        {
            set { _menu_title = value; }
            get { return _menu_title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string menu_title_cn
        {
            set { _menu_title_cn = value; }
            get { return _menu_title_cn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string menu_type
        {
            set { _menu_type = value; }
            get { return _menu_type; }
        }
        #endregion Model

    }
}
