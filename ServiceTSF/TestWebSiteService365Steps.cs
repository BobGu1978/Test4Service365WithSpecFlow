using System;
using TechTalk.SpecFlow;
using ServiceTSF.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;
using System.Threading;

namespace ServiceTSF
{
    [Binding]
    public class TestWebSiteService365Steps
    {

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
            BasePage.Login.SetUserName("guyu_susa@hotmail.com");
            BasePage.Login.SetPwd("Gy9618002");
            //here we will use data from data file to replace with hardcoding string
        }
        
        [When(@"User press Login")]
        public void WhenUserPressLogin()
        {
            //            ScenarioContext.Current.Pending();
            BasePage.Login.ClickLogin();
        }

        [When(@"User click LOG OFF")]
        public void WhenUserClickLOGOFF()
        {
            //            ScenarioContext.Current.Pending();
            BasePage.Home.LogOut();
        }
        
        [Then(@"User go to Home Page")]
        public void ThenUserGoToHomePage()
        {
            //            ScenarioContext.Current.Pending();
            Assert.IsTrue(BasePage.Home.IsHomePageDisplay());
        }

        [Then(@"User go to unlogon Home Page")]
        public void ThenUserGoToUnlogonHomePage()
        {
//            ScenarioContext.Current.Pending();
            Assert.IsTrue(BasePage.NonLoginHome.IsPageTitleDisplay());
//            Thread.Sleep(2000);
        }
    }
}
