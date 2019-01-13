using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;

namespace ServiceTSF.PageObject
{
    class LoginPage
    {
        private IWebElement UserName
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.Id("UserName"));
            }
        }

        private IWebElement Pwd
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.Id("Password"));
            }
        }

        private IWebElement Login
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[2]/form[1]/fieldset/div[3]/div[1]/button"));
            }

        }

        public void SetUserName(String username)
        {
            UserName.Clear();
            UserName.SendKeys(username);
        }

        public void SetPwd(String password)
        {
            Pwd.Clear();
            Pwd.SendKeys(password);
        }

        public void ClickLogin()
        {
            Login.Click();
            BrowserFactory.wait_page_load();
        }
/*
        public void MyLogin(String username, String pwd)
        {
            UserName.SendKeys(username);
            Pwd.SendKeys(pwd);
            Login.Click();
        }
*/
        private IWebElement PageTitle
        {
            get
            {
                return BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[1]/div/div[1]/div[1]/h2"));
            }
        }

        public Boolean IsLoginPageDisplay()
        {
            if(! PageTitle.Displayed)
            {
                return false;
            }
            if(!PageTitle.Text.Equals("Log in to Service365"))
            {
                return false;
            }
            return UserName.Displayed && Pwd.Displayed && Login.Displayed;
        }
    }
}
