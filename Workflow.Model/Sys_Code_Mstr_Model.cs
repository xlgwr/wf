using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
    [Serializable]
    public partial class Sys_Code_Mstr_Model
    {
        public Sys_Code_Mstr_Model()
        { }
        #region Model
        private string _code_cmmt;
        private string _code_desc;
        private string _code_fldname;
        private string _code_user1;
        private string _code_user2;
        private string _code_value;
        /// <summary>
        /// Comments
        /// </summary>
        public string code_cmmt
        {
            set { _code_cmmt = value; }
            get { return _code_cmmt; }
        }
        /// <summary>
        /// Description
        /// </summary>
        public string code_desc
        {
            set { _code_desc = value; }
            get { return _code_desc; }
        }
        /// <summary>
        /// Field Name
        /// </summary>
        public string code_fldname
        {
            set { _code_fldname = value; }
            get { return _code_fldname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code_user1
        {
            set { _code_user1 = value; }
            get { return _code_user1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code_user2
        {
            set { _code_user2 = value; }
            get { return _code_user2; }
        }
        /// <summary>
        /// Value
        /// </summary>
        public string code_value
        {
            set { _code_value = value; }
            get { return _code_value; }
        }
        #endregion Model

    }
}
