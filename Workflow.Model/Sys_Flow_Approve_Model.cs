using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
     [Serializable]
    public class Sys_Flow_Approve_Model
    {
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private string location;

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private string nbr;

        public string Nbr
        {
            get { return nbr; }
            set { nbr = value; }
        }

        private string action;

        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
