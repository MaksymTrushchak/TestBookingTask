using System;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestProject1.Tools
{
    public abstract class TestRunner
    {
        protected WebDriver driver;

        protected abstract string BookingURL { get; }



        [SetUp]
        public void BeforeEachMethod()
        {



            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BookingURL);



        }
        [TearDown]
        public void AfterEachMethod()
        {

            driver.Close();
            driver.Quit();

        }
    }

}
