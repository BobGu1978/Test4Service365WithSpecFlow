using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ServiceTSF.WrapperFactory;
using System.Threading;

namespace ServiceTSF.PageObject
{
    class PlaceOrderPage
    {
        private IWebElement CheckBox
        {
            get { return BrowserFactory.Driver.FindElement(By.Id("agreeCheckBox")); }
        }

        public void SelectCheckBox()
        {
            BrowserFactory.specialClick(CheckBox);
        }
        private IWebElement SubmitButton
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#myForm > fieldset > div.form-group.row.justify-content-end > div:nth-child(2) > button")); }
        }

        public Boolean IsSubmitDisplay()
        {
            return SubmitButton.Displayed;
        }

        private IWebElement ErrorOfWrongTime
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#myForm > fieldset > div:nth-child(7) > div > p:nth-child(3) > span")); }
        }

        private IWebElement ErrorOfNoAgreement
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("#errorMessageAgree")); }
        }

        public void SubmitOrder()
        {
            SubmitButton.Click();
            BrowserFactory.wait_page_load();
        }

        private IWebElement DateTimeField
        {
            get { return BrowserFactory.Driver.FindElement(By.Id("ServiceTime")); }
        }

        private IWebElement DateCalendar
        {
            get { return BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[5]/div[3]/table")); }
        }

        private IWebElement CurrentMonthAndYear
        {
            get { return BrowserFactory.Driver.FindElement(By.XPath("/html/body/div[5]/div[3]/table/thead/tr[1]/th[2]")); }
        }

        private IWebElement NextMonth
        {
            get { return BrowserFactory.Driver.FindElement(By.ClassName("next")); }
        }

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

        private IWebElement HourCalendar
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("body > div.datetimepicker.datetimepicker-dropdown-bottom-right.dropdown-menu > div.datetimepicker-hours > table")); }
        }

        private IWebElement MinuteCalendar
        {
            get { return BrowserFactory.Driver.FindElement(By.CssSelector("body > div.datetimepicker.datetimepicker-dropdown-bottom-right.dropdown-menu > div.datetimepicker-minutes > table")); }
        }

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
