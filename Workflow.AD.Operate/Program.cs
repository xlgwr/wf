using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using Workflow.BLL;
using Workflow.Model;
using System.Data.SqlClient;
namespace Workflow.AD.Operate
{
    class Program
    {
        static void Main()
        {
             int count = 0;
                string sLocation = "";
            try
            {
                DataTable dt = null;
                Sys_Code_Mstr code_mstr = new Sys_Code_Mstr();
                Sys_OU_Mstr ou_mstr = new Sys_OU_Mstr();
                Sys_User_Info user_info = new Sys_User_Info();
                List<Sys_Code_Mstr_Model> code_mstr_list = code_mstr.GetModelList("code_cmmt='LDAP' order by code_fldname");
                user_info.ExecResetUser();
               
                foreach (Sys_Code_Mstr_Model code_mstr_model in code_mstr_list)
                {
                    count++;
                    sLocation = code_mstr_model.code_desc;
                    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString());
                    List<Sys_OU_Mstr_Model> ou_mstr_list = ou_mstr.GetModelList("ou_location='" + code_mstr_model.code_desc + "'");
                    SqlCommand cmdUser = new SqlCommand();
                    cmdUser.Connection = conn;
                    conn.Open();
                    cmdUser.CommandType = CommandType.StoredProcedure;
                    cmdUser.CommandText = "sp_add_user";
                    cmdUser.Parameters.Add(new SqlParameter("@user", SqlDbType.Char, 50));
                    cmdUser.Parameters.Add(new SqlParameter("@location", SqlDbType.Char, 20));
                    cmdUser.Parameters.Add(new SqlParameter("@dept", SqlDbType.VarChar, 20));
                    cmdUser.Parameters.Add(new SqlParameter("@title", SqlDbType.VarChar, 50));
                    cmdUser.Parameters.Add(new SqlParameter("@mail", SqlDbType.VarChar, 200));
                    foreach (Sys_OU_Mstr_Model ou_mstr_model in ou_mstr_list)
                    {
                        Console.WriteLine(ou_mstr_model.ou_ou);
                        dt = GetADUsers(code_mstr_model.code_value, code_mstr_model.code_user1, code_mstr_model.code_user2, ou_mstr_model.ou_ou);
                        if (dt == null)
                        {
                            Console.WriteLine("OU exception");
                            Console.WriteLine(ou_mstr_model.ou_ou);
                            continue;
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Sys_User_Info_Model user_info_model = new Sys_User_Info_Model();
                            cmdUser.Parameters["@user"].Value = dt.Rows[i]["sAMAccountName"].ToString();
                            cmdUser.Parameters["@location"].Value = code_mstr_model.code_desc;
                            //user_info_model.user_lang = "en";
                            //user_info_model.user_password = "";//123456
                            //user_info_model.user_phase = "";
                            //user_info_model.user_status = "";
                            cmdUser.Parameters["@mail"].Value = dt.Rows[i]["mail"].ToString();
                            cmdUser.Parameters["@title"].Value = dt.Rows[i]["title"].ToString();
                            cmdUser.Parameters["@dept"].Value = dt.Rows[i]["department"].ToString(); //dt.Rows[i]["department"].ToString();
                            cmdUser.ExecuteNonQuery();
                        }
                    }
                    conn.Close();

                }
                //user_info.ExecDelUser();
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.Write(count);
                Console.Write(sLocation);
                Console.Write(ex.ToString());
                Console.ReadLine();
            }
        }
        private static DataTable GetADUsers(string ldapPath, string adAdmin, string password, string ouName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sAMAccountName");//帐号
            dt.Columns.Add("Name");//姓名
            dt.Columns.Add("mail"); //邮箱地址
            dt.Columns.Add("OU");  //用户组织
            dt.Columns.Add("department");  //用户部门
            dt.Columns.Add("title");  //用户部门

            DirectoryEntry adRoot = new DirectoryEntry(ldapPath, adAdmin, password, AuthenticationTypes.Secure);
            DirectoryEntry ou = adRoot.Children.Find("OU=" + ouName);

            DirectorySearcher mySearcher = new DirectorySearcher(ou);
            mySearcher.Filter = ("(objectClass=user)"); //user表示用户，group表示组

            foreach (System.DirectoryServices.SearchResult resEnt in mySearcher.FindAll())
            {
                DataRow dr = dt.NewRow();
                dr["sAMAccountName"] = string.Empty;
                dr["Name"] = string.Empty;
                dr["mail"] = string.Empty;
                dr["OU"] = string.Empty;
                dr["department"] = string.Empty;
                dr["title"] = string.Empty;

                DirectoryEntry user = resEnt.GetDirectoryEntry();
                if (user.Properties.Contains("sAMAccountName"))
                {
                    dr["sAMAccountName"] = user.Properties["sAMAccountName"][0].ToString();
                }
                if (user.Properties.Contains("Name"))
                {
                    dr["Name"] = user.Properties["Name"][0].ToString();
                }
                if (user.Properties.Contains("mail"))
                {
                    dr["mail"] = user.Properties["mail"][0].ToString();
                }
                if (user.Properties.Contains("department"))
                {
                    dr["department"] = user.Properties["department"][0].ToString();
                }
                if (user.Parent.Name != string.Empty && user.Parent.Name.IndexOf('=') > -1)
                {
                    //获取用户所在的组织单位
                    dr["OU"] = user.Parent.Name.Split('=')[1];
                }
                if (user.Properties.Contains("title"))
                {
                    dr["title"] = user.Properties["title"][0].ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
