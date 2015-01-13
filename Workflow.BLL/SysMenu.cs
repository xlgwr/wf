using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Workflow.DAL;

namespace Workflow.BLL
{
    public class SysMenu
    {
        public DataTable getParentMenu(string strUser,string strLang)
        {
            DataSet ds = new Sys_Menu_MstrDAL().GetList_Parent_Right(strUser,strLang);
            return ds.Tables[0];
        }

        public DataTable getChildMenu(string strUser, string strLang, string strMenuID)
        {
            DataSet ds = new Sys_Menu_MstrDAL().GetList_Child_Right(strUser,strLang,strMenuID);
            return ds.Tables[0];
        }
    }
}
