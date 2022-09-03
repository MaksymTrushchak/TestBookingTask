using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TestProject1.Tools;
using System.Linq;
using System.Collections.ObjectModel;

namespace TestProject1.Pages
{
    internal class HotelPage : TestRunner
    {

        protected override string BookingURL { get => driver.Url; }



        public IWebElement CheckInDate
        {
            get
            {

                return driver.FindElement(By.CssSelector("[data-placeholder=\"Check-in\"]"));
            }
        }
        public IWebElement CheckOutDate
        {
            get
            {

                return driver.FindElement(By.CssSelector("[data-placeholder=\"Check-out\"]"));
            }
        }




        public HotelPage(WebDriver driver)
        {
            this.driver = driver;
        }



        public string GetCheckInCheckOutDates()
        {


            string dates = CheckInDate.Text + " " + CheckOutDate.Text;

            return dates;
        }




    }
}
