using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.DAL;
using System.Data;

namespace Workflow.BLL
{
    public class Sys_Task_List
    {
        public DataTable getList(string strWhere,string strLang)
        {
            return new Sys_Task_ListDAL().GetList(strWhere, strLang).Tables[0];
        }
        public DataTable GetList_RECRUIT(string strWhere, string strLang,string strWhere1)
        {
            return new Sys_Task_ListDAL().GetList_RECRUIT(strWhere, strLang, strWhere1).Tables[0];
        }
    }
}
