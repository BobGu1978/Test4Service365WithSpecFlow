using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;

namespace ServiceTSF.PageObject
{
    class NonLoginHomePage
    {
        private IWebElement PageTitle
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.XPath("//*[@id='home']/div/div/div/h1"));
            }
        }

        public Boolean IsPageTitleDisplay()
        {
            return PageTitle.Displayed;
        }

        private IWebElement Login
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.XPath("//*[@id='home']/div/div/div/div/a[2]"));
            }
        }

        public void GotoLoginPage()
        {
            Login.Click();
            BrowserFactory.wait_page_load();
        }

    }
}
