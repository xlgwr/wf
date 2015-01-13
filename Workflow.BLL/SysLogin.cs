using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Net;
using System.Web;
using System.Management;

namespace Workflow.BLL
{
    public class SysLogin
    {
        public string ADValidate(string ADPath, string Uname, string Password)
        {

            DirectoryEntry de = new DirectoryEntry(ADPath, Uname, Password);
            try
            {
                DirectorySearcher search = new DirectorySearcher(de);
                search.Filter = "(sAMAccountName=" + Uname + ")";
                SearchResult result = search.FindOne();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                de.Close();
            }

        }

        public static string GetIP4Address()
        {
            try
            {
                string IP4Address = String.Empty;

                foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP4Address = IPA.ToString();
                        break;
                    }
                }

                if (IP4Address != String.Empty)
                {
                    return IP4Address;
                }

                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
                {
                    if (IPA.AddressFamily.ToString() == "InterNetwork")
                    {
                        IP4Address = IPA.ToString();
                        break;
                    }
                }
                return IP4Address;
            }
            catch
            {
                return "";
            }
        }
        public static string GetMACAddress()
        {
            string mac = ""; ManagementClass mc;
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (mo["IPEnabled"].ToString() == "True")
                    mac = mo["MacAddress"].ToString();
            }
            return mac;
        }

        public static string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        public static string GetBrowserInfo()
        {
            HttpBrowserCapabilities b = HttpContext.Current.Request.Browser;
            return b.Type + "--" + b.Browser + "--" + b.Version;
        }

    }
}
