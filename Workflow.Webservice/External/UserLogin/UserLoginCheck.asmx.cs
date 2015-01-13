using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;
using Encryption;

namespace Workflow.Webservice.External.UserLogin
{
    /// <summary>
    /// Summary description for UserLoginCheck
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserLoginCheck : System.Web.Services.WebService
    {

        //[WebMethod]
        /// <summary>
        /// Workflow system login check---second password
        /// </summary>
        /// <param name="strLocation">Company Code</param>
        /// <param name="strUser">User Name</param>
        /// <param name="strPassword">User Second Password(Original Password)</param>
        /// <returns>|"1" -- User first login need initialize second password|"2"--Invalid Password|"3"--User not exists in workflow system|"4"--location or user error|"0"-- Valid Password |</returns>
        [WebMethod]
        public string WFUserSecondPwdChk(string strLocation, string strUser, string strPassword)
        {
            strLocation = PageValidate.SqlTextClear(strLocation);
            strUser = PageValidate.SqlTextClear(strUser);
            strPassword = PageValidate.SqlTextClear(strPassword);

            Sys_User_Info user = new Sys_User_Info();
            if (user.Exists(strUser) == false)
            {
                return "3";
            }
            Sys_User_Info_Model user_model = user.GetModel(strUser, strLocation);
            if (user_model == null)
            {
                return "4";
            }
            String firstLoginPass = user.GetModel(strUser, strLocation).user_password.Trim();
            if (firstLoginPass == "")
            {
                return "1";//User first login need initialize second passwrd
            }
            Sys_User_Info_Model sysUserEntity = user.GetModel(strUser, DESEncrypt.Encode(strPassword), strLocation);
            if (sysUserEntity == null)
            {
                return "2";//Invalid password
            }
            return "0";// valid sencond password
        }
    }
}
