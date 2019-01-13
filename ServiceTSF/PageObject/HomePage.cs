using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;

namespace ServiceTSF.PageObject
{
    class HomePage
    {
        private IWebElement LogOff
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.XPath("//*[@id='content']/div/div/div/div[1]/div/div[2]/form/a[4]"));
            }
        }

        public void LogOut()
        {
            LogOff.Click();
            BrowserFactory.wait_page_load();
        }

        private IWebElement NavBar
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.Id("navbar"));
            }
        }

        private IWebElement UserBioContent
        {
            get
            {
                //                return BrowserFactory.Driver.FindElement(By.XPath("//*[@id='content']/div/div/div/div[1]/div/div[1]"));
                return BrowserFactory.Driver.FindElement(By.CssSelector("#content > div > div > div > div.col-lg-4 > div > div.col-lg-12.col-md-8.order-md-1"));
            }
        }

        private IWebElement UserGeneralInforContent
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.CssSelector("#content > div > div > div > div.col-lg-8 > div.card.card-primary"));
            }
        }

        public Boolean IsHomePageDisplay()
        {
            return UserBioContent.Displayed && UserGeneralInforContent.Displayed;
        }

    }
}
