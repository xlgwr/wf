using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
namespace Workflow.Common
{
    public class ComLogger
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Info(bool isExConfig,string strMessage)
        {

            if (isExConfig == true)
            {
                log4net.Config.XmlConfigurator.Configure();
            }
            log.Info(strMessage);
        }
    }
}
