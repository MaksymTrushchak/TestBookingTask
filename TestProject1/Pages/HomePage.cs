using System;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject1.Tools;


namespace TestProject1.Pages
{
    public class HomePage : TestRunner
    {

        protected override string BookingURL { get => "https://www.booking.com"; }





        public IWebElement SearchBar
        {
            get
            {
                return driver.FindElement(By.Id("ss"));
            }
        }


        public IWebElement DateField
        {
            get
            {

                return driver.FindElement(By.Id("frm"));
            }
        }

        public IWebElement FirstDate
        {
            get
            {

                return driver.FindElement(By.XPath("//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/table/tbody/tr[1]/td[4]"));
            }
        }

        public IWebElement SecondDate
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id=\"frm\"]/div[1]/div[2]/div[2]/div/div/div[3]/div[2]/table/tbody/tr[5]/td[6]"));
            }
        }

        public IWebElement SearchButton
        {
            get
            {
                return driver.FindElement(By.XPath("//form[@id='frm']/div/div[4]/div[2]/button/span"));
            }
        }

        public IWebElement NextPageCalendar
        {

            get
            {

                return driver.FindElement(By.CssSelector(".bui-calendar__control--next > svg"));
            }
        }

        public IWebElement Calendar
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id=\"frm\"]/div[1]/div[2]"));
            }
        }


        public HomePage(WebDriver driver)
        {

            this.driver = driver;

        }

        public void SeartchBarText(string text)
        {

            SearchBar.SendKeys(text);

        }

        public void ClickSearchButton() => SearchButton.Click();

        public void SelectDates()
        {
            ClickCalendar();
            ClickNextPageCalendar();
            ClickNextPageCalendar();
            FirstDate.Click();
            SecondDate.Click();
        }

        public void ClickCalendar() => Calendar.Click();

        public void ClickNextPageCalendar() => NextPageCalendar.Click();



    }
}
