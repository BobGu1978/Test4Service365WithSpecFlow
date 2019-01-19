using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace ServiceTSF.PageObject
{
    class PlaceOrderPage
    {
        [FindsBy(How = How.Id, Using = "agreeCheckBox")]
        private IWebElement CheckBox;

        public void SelectCheckBox()
        {
            BrowserFactory.specialClick(CheckBox);
        }

        [FindsBy(How = How.CssSelector, Using = "#myForm > fieldset > div.form-group.row.justify-content-end > div:nth-child(2) > button")]
        private IWebElement SubmitButton;

        public Boolean IsSubmitDisplay()
        {
            return SubmitButton.Displayed;
        }

        [FindsBy(How = How.CssSelector, Using = "#myForm > fieldset > div:nth-child(7) > div > p:nth-child(3) > span")]
        private IWebElement ErrorOfWrongTime;

        [FindsBy(How = How.CssSelector, Using = "#errorMessageAgree")]
        private IWebElement ErrorOfNoAgreement;

        public void SubmitOrder()
        {
            SubmitButton.Click();
            BrowserFactory.wait_page_load();
            Thread.Sleep(5000);
        }

        [FindsBy(How = How.Id, Using = "ServiceTime")]
        private IWebElement DateTimeField;

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[3]/table")]
        private IWebElement DateCalendar;

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div[3]/table/thead/tr[1]/th[2]")]
        private IWebElement CurrentMonthAndYear;

        [FindsBy(How = How.ClassName, Using = "next")]
        private IWebElement NextMonth;

        private String getMonth(int month)
        {
            Dictionary<String, int> myMonth = new Dictionary<string, int>
            {
                {"January",1 },
                { "February",2},
                { "March",3},
                { "April",4 },
                { "May",5 },
                { "June",6 },
                { "July",7 },
                { "August",8},
                { "September",9},
                { "October",10 },
                { "November",11 },
                { "December",12 }
            };
            foreach (String key in myMonth.Keys)
            {
                if (myMonth[key] == month)
                {
                    return key;
                }
            }
            return "";
        }

        public void ShowCalender()
        {
            BrowserFactory.Driver.FindElement(By.CssSelector("#myForm > fieldset > div:nth-child(7) > label")).Click();
            if (!CurrentMonthAndYear.Displayed)
                throw new Exception("the date calender is not pop-up");
        }

        public void SetupDate(int year,int month, int day)
        {
            String strMonth = getMonth(month);
            String str = String.Format("{0} {1}", strMonth, year);
            if(!CurrentMonthAndYear.Text.Trim().Equals(str))
            {
                NextMonth.Click();
                BrowserFactory.wait_page_load();
            }
            String str1 = String.Format("//td[text()='{0}']",day);
            IWebElement date = DateCalendar.FindElement(By.XPath(str1));
            date.Click();
            BrowserFactory.wait_page_load();

        }

        [FindsBy(How = How.CssSelector, Using = "body > div.datetimepicker.datetimepicker-dropdown-bottom-right.dropdown-menu > div.datetimepicker-hours > table")]
        private IWebElement HourCalendar;

        [FindsBy(How = How.CssSelector, Using = "body > div.datetimepicker.datetimepicker-dropdown-bottom-right.dropdown-menu > div.datetimepicker-minutes > table")]
        private IWebElement MinuteCalendar;

        public void SetupTime(int hour, int minute)
        {
            //let's be some kind of lazy that always we'd like to set up AM.
            Thread.Sleep(1000);
            IWebElement tmp = BrowserFactory.Driver.FindElement(By.CssSelector("body > div.datetimepicker.datetimepicker-dropdown-bottom-right.dropdown-menu > div.datetimepicker-hours > table > tbody > tr > td > fieldset:nth-child(1)"));
            String str = String.Format("//span[text()='{0}']",hour.ToString());
            BrowserFactory.MoveAndClick(tmp.FindElement(By.XPath(str)));
            Thread.Sleep(1000);
            String str1 = String.Format("{0}:{1:D2}",hour,minute);
            tmp = BrowserFactory.Driver.FindElement(By.CssSelector("body > div.datetimepicker.datetimepicker-dropdown-bottom-right.dropdown-menu > div.datetimepicker-minutes > table > tbody > tr > td > fieldset"));
            str = String.Format("//span[text()='{0}']",str1);
            BrowserFactory.MoveAndClick(tmp.FindElement(By.XPath(str)));
            BrowserFactory.wait_page_load();
        }
    }
}
