using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceTSF.WrapperFactory;
using OpenQA.Selenium;

namespace ServiceTSF.PageObject
{
    class BasePage
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            return page;
        }

        public static HomePage Home
        {
            get { return GetPage<HomePage>(); }
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static NonLoginHomePage NonLoginHome
        {
            get { return GetPage<NonLoginHomePage>(); }
        }

        public static ServicePage ServicePage
        {
            get { return GetPage<ServicePage>(); }
        }

        public static OrderDetailPage OrderDetailPage
        {
            get { return GetPage<OrderDetailPage>(); }
        }

        public static PlaceOrderPage PlaceOrderPage
        {
            get { return GetPage<PlaceOrderPage>(); }
        }

        private static IWebElement ServiceLink
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.XPath("//*[@id='navbar']/ul/li[2]/a"));
            }
        }

        public static void GoToServicePage()
        {
            ServiceLink.Click();
            BrowserFactory.wait_page_load();
        }

    }
}
