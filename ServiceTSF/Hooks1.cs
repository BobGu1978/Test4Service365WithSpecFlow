using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ServiceTSF.WrapperFactory;
using OpenQA.Selenium;

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
            Configuration config = ConfigurationManager.OpenExeConfiguration(appPath + @"\" + "OnlineStore.dll");

            var settings = config.AppSettings.Settings;

            url = settings["Url"].Value;
            */
            BrowserFactory.InitBrowser("Chrome");//here we will use System.Environment() to replace with

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            //            tbDriver = new BrowserFactory(ScenarioContext.Current);
            //            ScenarioContext.Current["Driver"] = tbDriver;
            BrowserFactory.LoadApplication("https://uat.service365.co.nz/"); // here we will use value from config file
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            BrowserFactory.CloseAllDrivers();
        }
    }
}
