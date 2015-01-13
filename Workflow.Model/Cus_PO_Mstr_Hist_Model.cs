using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Cus_PO_Mstr_Hist_Model
    {
        public Cus_PO_Mstr_Hist_Model()
        { }
        #region Model
        private string _hist_po_guid;
        private string _hist_po_nbr;
        private string _hist_po_revision;
        private string _hist_po_location;
        private string _hist_po_type;
        private string _hist_po_xml;
        private string _hist_po_xml_name;
        private DateTime? _hist_po_date_cre;
        private string _hist_po_rmk1;
        private string _hist_po_rmk2;
        private string _hist_po_rmk3;
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_guid
        {
            set { _hist_po_guid = value; }
            get { return _hist_po_guid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_nbr
        {
            set { _hist_po_nbr = value; }
            get { return _hist_po_nbr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_revision
        {
            set { _hist_po_revision = value; }
            get { return _hist_po_revision; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_location
        {
            set { _hist_po_location = value; }
            get { return _hist_po_location; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_type
        {
            set { _hist_po_type = value; }
            get { return _hist_po_type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_xml
        {
            set { _hist_po_xml = value; }
            get { return _hist_po_xml; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_xml_name
        {
            set { _hist_po_xml_name = value; }
            get { return _hist_po_xml_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? hist_po_date_cre
        {
            set { _hist_po_date_cre = value; }
            get { return _hist_po_date_cre; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_rmk1
        {
            set { _hist_po_rmk1 = value; }
            get { return _hist_po_rmk1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_rmk2
        {
            set { _hist_po_rmk2 = value; }
            get { return _hist_po_rmk2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hist_po_rmk3
        {
            set { _hist_po_rmk3 = value; }
            get { return _hist_po_rmk3; }
        }
        #endregion Model

    }
}

