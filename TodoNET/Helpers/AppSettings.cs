using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoNET.Helpers
{
    public class AppSettings
    {
        public static bool IsRelease()
        {
            var s = System.Configuration.ConfigurationManager.AppSettings["Environment"];
            return s != null && s == "Release";
        }
    }
}