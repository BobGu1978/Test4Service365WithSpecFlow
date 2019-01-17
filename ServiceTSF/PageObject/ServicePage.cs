using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;
using SeleniumExtras.PageObjects;

namespace ServiceTSF.PageObject
{
    class ServicePage
    {
        [FindsBy(How = How.Name, Using = "k")]
        private IWebElement KeyWordField;

        public void InputKeyWord(String str)
        {
            KeyWordField.Clear();
            KeyWordField.SendKeys(str);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='Filters']/button")]
        private IWebElement SearchButton;

        public void ClickSearch()
        {
            SearchButton.Click();
            BrowserFactory.wait_page_load();
        }

        private ReadOnlyCollection<IWebElement> ServiceBlockList
        {
            get { return BrowserFactory.Driver.FindElements(By.ClassName("col-xl-12")); }
        }

        public void OrderServiceByName(String ServiceName)
        {
            String str = String.Format("//a[text()='{0}']", ServiceName);
            foreach(var item in ServiceBlockList)
            {
                if(item.FindElement(By.XPath(str)).Displayed)
                {
                    item.FindElement(By.XPath("//a[contains(@href,'/Order/Place')]")).Click();
                    BrowserFactory.wait_page_load();
                    return;
                }
            }
            throw new ArgumentOutOfRangeException(String.Format("The service {0} is not existed.", ServiceName));
        }

    }
}
