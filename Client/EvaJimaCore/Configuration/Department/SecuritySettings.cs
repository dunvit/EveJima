using System;
using System.Collections;
using System.Configuration;

namespace EveJimaCore.Configuration.Department
{
    public class SecuritySettings 
    {
        public bool IsPrintClipboardDataToLog
        {
            get
            {
                if (((IList)ConfigurationManager.AppSettings.AllKeys).Contains("Security.IsPrintClipboardDataToLog"))
                {
                    return Convert.ToBoolean(ConfigurationManager.AppSettings["Security.IsPrintClipboardDataToLog"]);
                }

                return false;
            }
        }
    }
}
