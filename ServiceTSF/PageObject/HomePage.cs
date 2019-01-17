using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;
using SeleniumExtras.PageObjects;

namespace ServiceTSF.PageObject
{
    class HomePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div/div/div/div[1]/div/div[2]/form/a[4]")]
        private IWebElement LogOff;

        public void LogOut()
        {
            LogOff.Click();
            BrowserFactory.wait_page_load();
        }

        [FindsBy(How = How.Id, Using = "navbar")]
        private IWebElement NavBar;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div.col-lg-4 > div > div.col-lg-12.col-md-8.order-md-1")]
        private IWebElement UserBioContent;

        [FindsBy(How = How.CssSelector, Using = "#content > div > div > div > div.col-lg-8 > div.card.card-primary")]
        private IWebElement UserGeneralInforContent;

        public Boolean IsHomePageDisplay()
        {
            return UserBioContent.Displayed && UserGeneralInforContent.Displayed;
        }

    }
}
