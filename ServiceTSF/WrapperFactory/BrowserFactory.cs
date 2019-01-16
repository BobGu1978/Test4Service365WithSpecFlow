using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace ServiceTSF.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public  static IWebDriver Driver
        {
            get
            {
                /*
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                */
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        private static String BrowserType;

        public static void SetBrowserType(String bt)
        {
            BrowserType = bt;
        }

        public static void InitBrowser()
        {
            //here we will need lots of options of webdriver to setup
            switch (BrowserType)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver(@"C:\PathTo\IEDriverServer");
                        Drivers.Add("IE", Driver);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        driver = new ChromeDriver(@"C:\chromedriver");//here we will load the driver's folder from config file
                        Drivers.Add("Chrome", Driver);
                    }
                    break;
            }
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(500);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
        }

        public static void LoadApplication(string url)
        {
            driver.Url = url;
            wait_page_load();
        }

        public static void wait_page_load()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            int timeoutSec = 120;
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
            wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
            Thread.Sleep(1000);
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
//                Drivers[key].Quit();
            }
        }

        public static void QuitAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Quit();
            }

        }

        public static void MoveAndClick(IWebElement ele)
        {
            Actions act = new Actions(Driver);
            act.MoveToElement(ele).Perform();
            act.Click().Perform();
            Thread.Sleep(1000);
        }

        public static void specialClick(IWebElement ele)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", ele);
            Thread.Sleep(1000);
        }
    }
}
