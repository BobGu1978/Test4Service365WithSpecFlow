using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using ServiceTSF.WrapperFactory;
using OpenQA.Selenium;
using System.Configuration;
using System.Reflection;
using System.IO;
using TechTalk.SpecFlow.Tracing;
using System.Drawing.Imaging;
using ServiceTSF.Util;
using ServiceTSF.PageObject;

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
            Data.ReadDataFromConfig();
            CustomerData.init();
            OrderDetail.init();
            String BrowserType = System.Environment.GetEnvironmentVariable("Browser");
            if(BrowserType==null)
            {
                BrowserType = "Chrome";//now we use Chrome as default brwoser temporarily.
            }else
            {
                if ((!BrowserType.Equals("Chrome")) && (!BrowserType.Equals("Firefox")) && (!BrowserType.Equals("IE")))
                    throw new ArgumentOutOfRangeException("The browser type must be one of the following values: Chrome, Firefox and IE.");
            }
            BrowserFactory.SetBrowserType(BrowserType);
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            /*
            Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                          .GetName().CodeBase));
            string appPath = UriAssemblyFolder.LocalPath;
            Configuration config = ConfigurationManager.OpenExeConfiguration(appPath + @"\" + "ServiceTSF.dll");

            var settings = config.AppSettings.Settings;
            */
            BrowserFactory.InitBrowser();//here we will use System.Environment() to replace with
//            String url = settings["Url"].Value;

            BrowserFactory.LoadApplication(Data.Url); // here we will use value from config file
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            //            BrowserFactory.CloseAllDrivers();
            if (ScenarioContext.Current.TestError != null)
            {
                TakeScreenshot(BrowserFactory.Driver);
            }
            try
            {
                BasePage.GoToHomePage();
                String url ;
                if(BrowserFactory.Driver.Url.EndsWith("/"))
                {
                    url = BrowserFactory.Driver.Url.TrimEnd('/');
                }
                else
                {
                    url = BrowserFactory.Driver.Url;
                }
                if(!url.Equals(Data.Url))
                {
                    BasePage.Home.LogOut();
                }
            }
            catch(OpenQA.Selenium.NoSuchElementException e)
            {
                //do nothing
            }
            finally
            {
                BrowserFactory.CloseAllDrivers();
                BrowserFactory.QuitAllDrivers();
            }
        }
        private static void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(), "testresults");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }
        /*
                [AfterTestRun]
                public static void AfterTestRun()
                {
                    BrowserFactory.QuitAllDrivers();
                }
                */
    }
}
