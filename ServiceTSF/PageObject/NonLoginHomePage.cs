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
    class NonLoginHomePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div/h1")]
        private IWebElement PageTitle;

        public Boolean IsPageTitleDisplay()
        {
            return PageTitle.Displayed;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='home']/div/div/div/div/a[2]")]
        private IWebElement Login;

        public void GotoLoginPage()
        {
            Login.Click();
            BrowserFactory.wait_page_load();
        }

    }
}
