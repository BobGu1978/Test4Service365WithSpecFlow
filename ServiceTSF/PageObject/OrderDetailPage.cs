using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ServiceTSF.WrapperFactory;

namespace ServiceTSF.PageObject
{
    class OrderDetailPage
    {
        private IWebElement PageTitle
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#content > div.bg-light.index-1.intro-full-next.pt-6 > div > h2")); }
        }

        public void WaitForCancelSignal()
        {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(100000));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-4 > div.card.card-info > div.card-body.overflow-hidden > address > p:nth-child(4) > i")));
        }

        public String getTextOfPageTitle()
        {
            return PageTitle.Text;
        }

        private IWebElement OrderNumber
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-8 > div:nth-child(1) > div.card-body > table > tbody > tr:nth-child(1) > td")); }
        }

        public String GetOrderNumber()
        {
            return OrderNumber.Text;
        }

        private IWebElement Cancel
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-8 > div:nth-child(1) > div.card-body > div.text-right.mt-4 > small > a")); }
        }

        private IWebElement YESOnCancelConfirm
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#confirm > div > div > div.modal-footer > button.btn.btn-raised.btn-primary.btn-ok")); }
        }

        public void CancelOrder()
        {
            Cancel.Click();
            YESOnCancelConfirm.Click();
            BrowserFactory.wait_page_load();
        }

        private IWebElement OrderCancelled
        {
            get { return BrowserFactory.Driver.FindElement(By.XPath("//*[@id='content']/div[1]/div/div/div[2]/div[1]/div[2]/address/p[4]")); }
        }

        private IWebElement SignalOfCancel
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-4 > div.card.card-info > div.card-body.overflow-hidden > address > p:nth-child(4) > i")); }
        }

        public Boolean IsOrderCancelledStatusShow()
        {
            if (!SignalOfCancel.GetAttribute("class").Equals("color-danger zmdi zmdi-close-circle mr-1"))
            {
                return false;
            }
            String str = OrderCancelled.Text.Trim();
            return str.Equals("Order cancelled");
        }
    }
}
