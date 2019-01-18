using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace ServiceTSF.Util
{
    class Data
    {
        private static String url;

        public static void ReadDataFromConfig()
        {
            Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly()
              .GetName().CodeBase));
            string appPath = UriAssemblyFolder.LocalPath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(appPath + @"\" + "ServiceTSF.dll");

            var settings = config.AppSettings.Settings;
            url = settings["Url"].Value;
        }

        public static String Url
        {
            get
            {
                return url;
            }
        }
    }
}
