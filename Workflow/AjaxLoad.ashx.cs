using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workflow.Common;
using Workflow.Model;
using Workflow.BLL;
using System.Data;

namespace Workflow
{
    /// <summary>
    /// Summary description for AjaxLoad1
    /// </summary>
    public class AjaxLoad1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string AjaxType = context.Request.Params["AjaxType"].Trim().ToUpper();
            context.Response.ContentType = "text/plain";
            string response;
            switch (AjaxType)
            { 
                case "EXECFLOWAPPROVE":
                    string nbr=context.Request.Params["ReqNbr"].Trim();
                    string location=context.Request.Params["ReqLoc"].Trim();
                    string type=context.Request.Params["ReqType"].Trim();
                    string action=context.Request.Params["ReqAction"].Trim();
                    string user=context.Request.Params["ReqUser"].Trim();
                    string remark=context.Request.Params["ReqRemark"].Trim();
                    string lang = context.Request.Params["ReqLang"].Trim();
                     response= EXECFLOWAPPROVE(nbr, location, type, action, user, remark, lang);
                    context.Response.Write(response);
                    break;
                case "CVALLOCATION":
                   response = CVALLOCATION();
                    context.Response.Write(response);
                    break;
                default:
                    context.Response.Write("Ajax Type Error");
                    break;
            }
            context.Response.Flush();
        }
        private string CVALLOCATION()
        {
            DataSet ds = new Cus_Job_Det().GetList("");

            return Common.ConvertToJson.DataSetToJson(ds);
        }
        private string EXECFLOWAPPROVE(string nbr, string location, string type, string action, string user, string remark,string lang)
        {
            string strIret = new Sys_System().ExecApproveProc(nbr, location, type, action, user, remark).Trim();
            switch (strIret)//todo
            {
                case "0":
                    return Response("Submit Successfully", "提交成功", lang);
                case "1":
                    return Response("Form flow not exists", "申请流程不存在", lang);
                case "2":
                    return Response("User not exists", "用户不存在", lang);
                case "3":
                    return Response("Have no approve right", "没有审批权限", lang);
                case "78":
                    return Response("Next step approver lost", "下一步骤审批人丢失", lang);
                case "77":
                    return Response("Applicant not exists", "申请人不存在", lang);
                case "99":
                    return Response("Document flow approve error", "文档流程审批出错", lang);
                default:
                    return "Other error";
            }
        }

        private string Response(string en,string cn,string lang)
        {
            if (lang.Trim().ToUpper() == "CN")
            {
                return cn;
            }
            else
            {
                return en;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}