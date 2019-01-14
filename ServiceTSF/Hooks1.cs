using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ServiceTSF.WrapperFactory;
using OpenQA.Selenium;
using System.Configuration;
using System.Reflection;

namespace ServiceTSF
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
//        private static BrowserFactory tbDriver;

        [BeforeTestRun]
        public static void Init()
        {
            /*
            Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly()
              .GetName().CodeBase));
            string appPath = UriAssemblyFolder.LocalPath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(appPath + @"\" + "ServiceTSF.dll");

            var settings = config.AppSettings.Settings;

            url = settings["Url"].Value;
            */
            String BrowserType = System.Environment.GetEnvironmentVariable("Browser");
            if(BrowserType==null)
            {
                BrowserType = "Chrome";//now we use Chrome as default brwoser temporarily.
            }else
            {
                if ((!BrowserType.Equals("Chrome")) && (!BrowserType.Equals("Firefox")) && (!BrowserType.Equals("IE")))
                    throw new ArgumentOutOfRangeException("The browser type must be one of the following values: Chrome, Firefox and IE.");
            }
            BrowserFactory.InitBrowser(BrowserType);//here we will use System.Environment() to replace with

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                          .GetName().CodeBase));
            string appPath = UriAssemblyFolder.LocalPath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(appPath + @"\" + "ServiceTSF.dll");

            var settings = config.AppSettings.Settings;

            String url = settings["Url"].Value;

//            BrowserFactory.LoadApplication("https://uat.service365.co.nz/"); // here we will use value from config file
            BrowserFactory.LoadApplication(url); // here we will use value from config file
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            BrowserFactory.CloseAllDrivers();
        }
    }
}
