using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Workflow.Model;

namespace Workflow.Common
{
    [Serializable]
    public class UserInfo
    {
        public const string CurrentUserCode = "OA-UserInfo";
        private string userLoginName;
        private string userLang;
        private string userEmail;
        private string userDepartment;
        private string userLocation;
        public string UserLoginName
        {
            get { return userLoginName; }
        }

        public string UserLang
        {
            get { return userLang; }
        }

        public string UserEmail
        {
            get { return userEmail; }
        }

        public string UserDepartment
        {
            get { return userDepartment; }
        }
        public string UserLocation
        {
            get { return userLocation; }
        }

        public static UserInfo CurrentUser
        {
            get
            {

                string guestID = "Guest";
                return (UserInfo)WebCaching.CurrentUser == null ? new UserInfo(guestID) : (UserInfo)WebCaching.CurrentUser;
            }
            set
            {
                WebCaching.CurrentSession[CurrentUserCode] = value;
                WebCaching.CurrentUser = value;
            }
        }

        public static void ClearUser()
        {
            WebCaching.CurrentSession[CurrentUserCode] = null;
        }


        public void InitialUserInfo(Sys_User_Info_Model sysUsersEntity)
        {
            userLoginName = sysUsersEntity.user_name;
            userLang = sysUsersEntity.user_lang;
            userEmail = sysUsersEntity.user_mail;
            userDepartment = sysUsersEntity.user_dept;
            userLocation = sysUsersEntity.user_location;
            WebCaching.CurrentUser = this;
        }

        #region Method
        public UserInfo(string userID)
        {
            userLoginName = userID;

        }
        #endregion
    }
}
