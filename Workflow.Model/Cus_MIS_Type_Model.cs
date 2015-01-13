using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Cus_MIS_Type_Model
    {
        public Cus_MIS_Type_Model()
        { }
        #region Model
        private string _mis_type_code;
        private string _mis_type_value;
        private string _mis_type_value_cn;
        private int? _mis_type_level;
        private int? _mis_type_order;
        /// <summary>
        /// 
        /// </summary>
        public string mis_type_code
        {
            set { _mis_type_code = value; }
            get { return _mis_type_code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mis_type_value
        {
            set { _mis_type_value = value; }
            get { return _mis_type_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mis_type_value_cn
        {
            set { _mis_type_value_cn = value; }
            get { return _mis_type_value_cn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mis_type_level
        {
            set { _mis_type_level = value; }
            get { return _mis_type_level; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mis_type_order
        {
            set { _mis_type_order = value; }
            get { return _mis_type_order; }
        }
        #endregion Model

    }
}

