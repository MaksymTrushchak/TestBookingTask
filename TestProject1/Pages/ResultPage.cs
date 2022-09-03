using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TestProject1.Tools;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace TestProject1.Pages
{
    internal class ResultPage : TestRunner
    {




        protected override string BookingURL { get => driver.Url; }

        public IWebElement SearchBar
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id=\"ss\"]"));
            }
        }

        public IWebElement SeeAvailability
        {
            get
            {
                return driver.FindElement(By.ClassName("a68bfa09c2"));

            }
        }

        public IWebElement PriceCheckbox
        {
            get
            {
                return driver.FindElement(By.XPath("//div[7]/label/span[2]"));

            }
        }



        public IWebElement HotelPrice
        {
            get
            {
                return driver.FindElement(By.CssSelector("span[class=\"fcab3ed991 bd73d13072\"]"));

            }
        }



        public IList<IWebElement> ListOfHotels
        {

            get
            {
                return driver.FindElements(By.CssSelector("[data-testid=\"property-card\"]"));
            }
        }






        public ResultPage(WebDriver driver)
        {
            this.driver = driver;
        }


        public IList<IWebElement> GetListOfHotels()
        {

            IList<IWebElement> listOfHotels = ListOfHotels;


            return listOfHotels;

        }


        public string GetCityName(IWebElement hotel)
        {

            string cityName = hotel.FindElement(By.CssSelector("[data-testid=\"address\"]")).Text;



            return cityName;
        }

        public string GetHotelLink(IWebElement hotel)
        {

            string hotelLink = hotel.FindElement(By.CssSelector("a[target=\"_blank\"]")).GetAttribute("href");



            return hotelLink;
        }


        public int GetHotelPrice(IWebElement hotel)
        {

            string hotelPriceLine = HotelPrice.Text;


            int hotelPrice = Int32.Parse(Regex.Replace(hotelPriceLine, "[^.0-9]", ""));



            return hotelPrice;

        }




        public void ClickSeeAvailability() => SeeAvailability.Click();


        public void ClickPriceCheckbox() => PriceCheckbox.Click();
    }
}
