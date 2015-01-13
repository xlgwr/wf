using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Workflow.Model;

namespace Workflow.Common
{
    public class WebCaching
    {
        public const string UserSkinCookiesString = "SRM-UserSkin";
        public const string DefaultSkin = "Default";
        public const string UserInfoSessionString = "OA-UserInfo";
        public const string CurrentLanguageString = "OA-LanguageCode";
        public const string DefaultLanguageCode = "2052";
        public const string CurrentCultureString = "OA-Culture";
        public const string DefaultCulture = "CN";

        #region WebContext
        public static HttpContext CurrentContext
        {
            get
            {
                return HttpContext.Current;
            }
        }

        public static HttpSessionState CurrentSession
        {
            get
            {
                return CurrentContext.Session;
            }
        }

        public static HttpCookieCollection CurrentCookie
        {
            get
            {
                return CurrentContext.Request.Cookies;
            }
        }

        public static HttpCookieCollection WriteCookie
        {
            get
            {
                return CurrentContext.Response.Cookies;
            }
        }

        public static System.Web.Caching.Cache CurrentCaching
        {
            get
            {
                return CurrentContext.Cache;
            }
        }
        #endregion

        #region Caching
        public static void AddCache(Object feature, string cacheKey)
        {
            if (CurrentContext != null)
            {
                DateTime expiration = DateTime.Now.AddDays(7);
                CurrentCaching.Add(cacheKey, feature, null, expiration, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Normal, null);
            }
        }

        public static Object GetCache(string cacheKey)
        {
            Object result = null;
            if (CurrentCaching != null)
            {
                result = CurrentCaching[cacheKey];
            }
            return result;
        }

        public static void RemoveCache(string cacheKey)
        {
            if (CurrentCaching != null)
                CurrentCaching.Remove(cacheKey);
        }

        public static void RefreshCache(Object feature, string cacheKey)
        {
            if (CurrentCaching != null)
            {
                RemoveCache(cacheKey);
                AddCache(feature, cacheKey);
            }
        }

        #endregion

        public static string CurrentIP
        {
            get
            {
                return CurrentContext.Request.UserHostAddress;
            }
        }

        public static string CurrentSkin
        {
            get
            {
                if (CurrentCookie[UserSkinCookiesString] == null)
                    return DefaultSkin;
                else
                    return CurrentCookie[UserSkinCookiesString][UserSkinCookiesString];
            }
            set
            {
                if (WriteCookie[UserSkinCookiesString] != null)
                {
                    WriteCookie[UserSkinCookiesString][UserSkinCookiesString] = value;
                    CurrentCookie[UserSkinCookiesString][UserSkinCookiesString] = value;
                    WriteCookie[UserSkinCookiesString].Expires = DateTime.Now.AddMonths(1);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie(UserSkinCookiesString);
                    cookie[UserSkinCookiesString] = value;
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    WriteCookie.Add(cookie);
                    CurrentCookie.Add(cookie);
                }
            }
        }

        public static string CurrentLanguage
        {
            get
            {
                if (CurrentCookie[CurrentLanguageString] == null)
                    return DefaultLanguageCode;
                else
                    return CurrentCookie[CurrentLanguageString][CurrentLanguageString];
            }
            set
            {
                if (WriteCookie[CurrentLanguageString] != null)
                {
                    WriteCookie[CurrentLanguageString][CurrentLanguageString] = value;
                    CurrentCookie[CurrentLanguageString][CurrentLanguageString] = value;
                    WriteCookie[CurrentLanguageString].Expires = DateTime.Now.AddMonths(1);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie(CurrentLanguageString);
                    cookie[CurrentLanguageString] = value;
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    WriteCookie.Add(cookie);
                    CurrentCookie.Add(cookie);
                }
            }
        }

        public static UserInfo CurrentUser
        {
            get
            {
                return (UserInfo)CurrentSession[UserInfoSessionString];
            }
            set
            {
                CurrentSession[UserInfoSessionString] = value;
            }
        }

        public static string CurrentCulture
        {
            get
            {
                if (CurrentCookie[CurrentCultureString] == null)
                    return DefaultCulture;
                else
                    return CurrentCookie[CurrentCultureString][CurrentCultureString];
            }
            set
            {
                if (WriteCookie[CurrentCultureString] != null)
                {
                    WriteCookie[CurrentCultureString][CurrentCultureString] = value;
                    CurrentCookie[CurrentCultureString][CurrentCultureString] = value;
                    WriteCookie[CurrentCultureString].Expires = DateTime.Now.AddMonths(1);
                }
                else
                {
                    HttpCookie cookie = new HttpCookie(CurrentCultureString);
                    cookie[CurrentCultureString] = value;
                    cookie.Expires = DateTime.Now.AddMonths(1);
                    WriteCookie.Add(cookie);
                    CurrentCookie.Add(cookie);
                }
            }
        }
    }
}
