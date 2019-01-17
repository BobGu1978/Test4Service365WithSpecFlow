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
    class LoginPage
    {
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement UserName;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement Pwd;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[2]/form[1]/fieldset/div[3]/div[1]/button")]
        private IWebElement Login;

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
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[1]/div[1]/h2")]
        private IWebElement PageTitle;

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
