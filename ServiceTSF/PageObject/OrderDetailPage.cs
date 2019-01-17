using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ServiceTSF.WrapperFactory;
using SeleniumExtras.PageObjects;

namespace ServiceTSF.PageObject
{
    class OrderDetailPage
    {
        [FindsBy(How = How.CssSelector, Using = "#content > div.bg-light.index-1.intro-full-next.pt-6 > div > h2")]
        private IWebElement PageTitle;

        public void WaitForCancelSignal()
        {
            WebDriverWait wait = new WebDriverWait(BrowserFactory.Driver, TimeSpan.FromSeconds(100000));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-4 > div.card.card-info > div.card-body.overflow-hidden > address > p:nth-child(4) > i")));
        }

        public String getTextOfPageTitle()
        {
            return PageTitle.Text;
        }

        [FindsBy(How = How.CssSelector, Using = "#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-8 > div:nth-child(1) > div.card-body > table > tbody > tr:nth-child(1) > td")]
        private IWebElement OrderNumber;

        public String GetOrderNumber()
        {
            return OrderNumber.Text;
        }

        [FindsBy(How = How.CssSelector, Using = "#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-8 > div:nth-child(1) > div.card-body > div.text-right.mt-4 > small > a")]
        private IWebElement Cancel;

        [FindsBy(How = How.CssSelector, Using = "#confirm > div > div > div.modal-footer > button.btn.btn-raised.btn-primary.btn-ok")]
        private IWebElement YESOnCancelConfirm;

        public void CancelOrder()
        {
            Cancel.Click();
            YESOnCancelConfirm.Click();
            BrowserFactory.wait_page_load();
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='content']/div[1]/div/div/div[2]/div[1]/div[2]/address/p[4]")]
        private IWebElement OrderCancelled;

        [FindsBy(How = How.CssSelector, Using = "#content > div.bg-light.index-1.intro-full-next.pt-6 > div > div > div.col-md-4 > div.card.card-info > div.card-body.overflow-hidden > address > p:nth-child(4) > i")]
        private IWebElement SignalOfCancel;

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
