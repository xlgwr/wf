using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Workflow.Common
{
    public class ConvertToJson
    {
        public static string StringToJson(String s)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s.ToCharArray()[i];

                switch (c)
                {
                    case '\"':
                        sb.Append("\\\""); break;
                    case '\\':
                        sb.Append("\\\\"); break;
                    case '/':
                        sb.Append("\\/"); break;
                    case '\b':
                        sb.Append("\\b"); break;
                    case '\f':
                        sb.Append("\\f"); break;
                    case '\n':
                        sb.Append("\\n"); break;
                    case '\r':
                        sb.Append("\\r"); break;
                    case '\t':
                        sb.Append("\\t"); break;
                    default:
                        sb.Append(c); break;
                }
            }
            string returns = "[{\"msg\":\"" + sb + "\"}]";
            return returns.ToString();
        }
        public static string DataReaderToJson(SqlDataReader dataReader)
        {
            StringBuilder jsonString = new StringBuilder();
            if (dataReader.HasRows == true)
            {
                jsonString.Append("[");
                while (dataReader.Read())
                {
                    jsonString.Append("{");
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Type type = dataReader.GetFieldType(i);
                        string strKey = dataReader.GetName(i);
                        string strValue = dataReader[i].ToString();
                        jsonString.Append("\"" + strKey + "\":");
                        strValue = StringFormat(strValue, type);
                        if (i < dataReader.FieldCount - 1)
                        {
                            jsonString.Append(strValue + ",");
                        }
                        else
                        {
                            jsonString.Append(strValue);
                        }
                    }
                    jsonString.Append("},");
                }
                dataReader.Close();
                jsonString.Remove(jsonString.Length - 1, 1);
                jsonString.Append("]");
            }
            else
            {
                jsonString.Append("[{\"msg\":\"no records\"}]");
            }
            return jsonString.ToString();
        }
        private static string StringFormat(string str, Type type)
        {
            if (type == typeof(string))
            {
                str = StringToJson(str);
                str = "\"" + str + "\"";
            }
            else if (type == typeof(DateTime))
            {
                str = "\"" + Convert.ToDateTime(str).ToShortDateString() + "\"";
            }
            else if (type == typeof(bool))
            {
                str = str.ToLower();
            }

            if (str.Length == 0)
                str = "\"\"";

            return str;
        }
        public static string DataSetToJson(DataSet ds)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder("");
            for (int o = 0; o < ds.Tables.Count; o++)
            {
             
                str.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    str.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        str.Append(string.Format("\"{0}\":\"{1}\",", ds.Tables[0].Columns[j].ColumnName, ds.Tables[0].Rows[i][j].ToString()));
                    } 
                    str.Remove(str.Length - 1, 1);
                    str.Append("},");
                }
                str.Remove(str.Length - 1, 1); 
            }
            str.Append("]");
            return str.ToString().Replace('\n',' ');
        }
    }
}
