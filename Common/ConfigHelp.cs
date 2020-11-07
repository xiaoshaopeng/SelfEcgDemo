using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SelfEcgDemo.Common
{
    public class ConfigHelp
    {
        public static string imgDirPath = ConfigurationManager.AppSettings["imgDirPath"];
    }
}