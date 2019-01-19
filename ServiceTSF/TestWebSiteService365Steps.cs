using System;
using TechTalk.SpecFlow;
using ServiceTSF.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;
using System.Threading;
using ServiceTSF.Util;

namespace ServiceTSF
{
    [Binding]
    public class TestWebSiteService365Steps : Steps
    {

        [Given(@"User log in as customer")]
        public void GivenUserLoginAsCustomer()
        {
            Given(@"User go to Login Page");
            When(@"User input username and password");
            When(@"User press Login");
        }

        [Given(@"User go to Login Page")]
        public void GivenUserGoToLoginPage()
        {
            BasePage.NonLoginHome.GotoLoginPage();
            Assert.IsTrue(BasePage.Login.IsLoginPageDisplay());
        }
        
        [When(@"User input username and password")]
        public void WhenUserInputUsernameAndPassword()
        {
            //            ScenarioContext.Current.Pending();
            BasePage.Login.SetUserName(CustomerData.UserName);
            BasePage.Login.SetPwd(CustomerData.Pwd);
            //here we will use data from data file to replace with hardcoding string
        }
        
        [When(@"User press Login")]
        public void WhenUserPressLogin()
        {
            BasePage.Login.ClickLogin();
        }

        [When(@"User click LOG OFF")]
        public void WhenUserClickLOGOFF()
        {
            BasePage.Home.LogOut();
        }
        
        [Then(@"User go to Home Page")]
        public void ThenUserGoToHomePage()
        {
            Assert.IsTrue(BasePage.Home.IsHomePageDisplay());
        }

        [Then(@"User go to unlogon Home Page")]
        public void ThenUserGoToUnlogonHomePage()
        {
            Assert.IsTrue(BasePage.NonLoginHome.IsPageTitleDisplay());
//            Thread.Sleep(2000);
        }

        [Given(@"User go to Service Page")]
        public void GivenUserGoToServicePage()
        {
            BasePage.GoToServicePage();
        }

        [When(@"User search for specific service")]
        public void WhenUserSearchForSpecificService()
        {
            BasePage.ServicePage.InputKeyWord(OrderDetail.ServiceName);// now this value is hard-coded.
            BasePage.ServicePage.ClickSearch();
        }

        [When(@"User click Book Now")]
        public void WhenUserClickBookNow()
        {
            BasePage.ServicePage.OrderServiceByName(OrderDetail.ServiceName);//later we will use other method to inject this value.
        }

        [Then(@"User go to place order page")]
        public void ThenUserGoToPlaceOrderPage()
        {
            Assert.IsTrue(BasePage.PlaceOrderPage.IsSubmitDisplay());
        }

        [Given(@"User do some setup")]
        public void GivenUserDoSetup()
        {
            DateTime cdt = DateTime.Now;
            DateTime temp = cdt.AddDays(OrderDetail.DateAdd);
            if (temp.DayOfWeek.Equals("Saturday"))
                temp = cdt.AddDays(OrderDetail.DateAdd+2);
            else
            {
                if (temp.DayOfWeek.Equals("Sunday"))
                    temp = cdt.AddDays(OrderDetail.DateAdd+1);
            }
            BasePage.PlaceOrderPage.ShowCalender();
            BasePage.PlaceOrderPage.SetupDate(temp.Year, temp.Month, temp.Day);
            BasePage.PlaceOrderPage.SetupTime( OrderDetail.Hour, OrderDetail.Minute);//here the time is hard-coded
            BasePage.PlaceOrderPage.SelectCheckBox();
        }

        [Given(@"User click Submit")]
        public void GivenUserClickSubmit()
        {
            BasePage.PlaceOrderPage.SubmitOrder();
        }

        [Then(@"User go to Order detail page")]
        public void ThenUserGoToOrderDetailPage()
        {
            Assert.IsTrue(BasePage.OrderDetailPage.getTextOfPageTitle().Trim().Equals("Order details"));
        }

        [When(@"User Cancel Order")]
        public void WhenUserCancelOrder()
        {
            BasePage.OrderDetailPage.CancelOrder();
            BasePage.OrderDetailPage.WaitForCancelSignal();
            Thread.Sleep(2000);
        }

        [Then(@"on order detail page, the status shows Order Cancelled")]
        public void ThenOnDetailPageStatusShowOrderCancelled()
        {
            Assert.IsTrue(BasePage.OrderDetailPage.IsOrderCancelledStatusShow());
        }

    }
}
