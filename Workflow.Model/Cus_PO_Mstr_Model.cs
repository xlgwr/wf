using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Cus_PO_Mstr_Model
    {
        public Cus_PO_Mstr_Model()
        { }
        #region Model
        private string _po_guid;
        private string _po_nbr;
        private string _po_location;
        private string _po_type;
        private string _po_revision;
        private string _po_xml_name;
        private string _po_xml;
        private DateTime _po_date_cre = DateTime.Now;
        private string _po_rmk1;
        private string _po_rmk2;
        private string _po_rmk3;
        /// <summary>
        /// 
        /// </summary>
        public string po_guid
        {
            set { _po_guid = value; }
            get { return _po_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_nbr
        {
            set { _po_nbr = value; }
            get { return _po_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_location
        {
            set { _po_location = value; }
            get { return _po_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_type
        {
            set { _po_type = value; }
            get { return _po_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_revision
        {
            set { _po_revision = value; }
            get { return _po_revision; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_xml_name
        {
            set { _po_xml_name = value; }
            get { return _po_xml_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_xml
        {
            set { _po_xml = value; }
            get { return _po_xml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime po_date_cre
        {
            set { _po_date_cre = value; }
            get { return _po_date_cre; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_rmk1
        {
            set { _po_rmk1 = value; }
            get { return _po_rmk1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_rmk2
        {
            set { _po_rmk2 = value; }
            get { return _po_rmk2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string po_rmk3
        {
            set { _po_rmk3 = value; }
            get { return _po_rmk3; }
        }
        #endregion Model

    }
}

