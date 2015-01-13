using System;
namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_OU_Mstr_Model
    {
        public Sys_OU_Mstr_Model()
        { }
        #region Model
        private string _ou_ou;
        private string _ou_location;
        /// <summary>
        /// 
        /// </summary>
        public string ou_ou
        {
            set { _ou_ou = value; }
            get { return _ou_ou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ou_location
        {
            set { _ou_location = value; }
            get { return _ou_location; }
        }
        #endregion Model

    }
}

