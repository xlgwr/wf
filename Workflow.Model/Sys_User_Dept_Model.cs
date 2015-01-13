using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Workflow.Model
{
     [Serializable]
    public partial class Sys_User_Dept_Model
    {
         public Sys_User_Dept_Model()
        { }
         private string _user_dept;

         /// <summary>
         /// 
         /// </summary>
         public string user_dept
         {
             set { _user_dept = value; }
             get { return _user_dept; }
         }
    }
}
