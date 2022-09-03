using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V102.Storage;
using TestProject1.Pages;
using TestProject1.Tools;




namespace TestProject1.Tests
{
    public class Tests : TestRunner
    {

        protected override string BookingURL { get => "https://www.booking.com"; }

        [SetUp]
        public void Initial()
        {

            HomePage homePage = new HomePage(driver);


            homePage.SeartchBarText("New York");
            homePage.SelectDates();
            homePage.ClickSearchButton();



        }

        [Test]
        public void CheckCityTest()
        {

            ResultPage resultPage = new ResultPage(driver);

            foreach (var hotel in resultPage.GetListOfHotels())
            {
                Assert.That(resultPage.GetCityName(hotel), Does.Contain("New York"));
            }

        }

        [Test]
        public void VerifyDatesTest()
        {

            ResultPage resultPage = new ResultPage(driver);



            string expectedResult = "Thu, Dec 1 Sat, Dec 31";


            foreach (var hotel in resultPage.GetListOfHotels())
            {
                resultPage.ClickSeeAvailability();

                driver.SwitchTo().Window(driver.WindowHandles[1]);
                HotelPage hotelPage = new HotelPage(driver);
                Assert.That(hotelPage.GetCheckInCheckOutDates(), Is.EqualTo(expectedResult));
                driver.Close();
                driver.SwitchTo().Window(driver.WindowHandles[0]);


            }
        }


        [Test]
        public void ChangeCurrencyTest()
        {


            ResultPage resultPage = new ResultPage(driver);

            resultPage.ClickPriceCheckbox();

            foreach (var hotel in resultPage.GetListOfHotels())
            {

                Assert.IsTrue(resultPage.GetHotelPrice(hotel) >= 12000);



            }


        }
    }
}