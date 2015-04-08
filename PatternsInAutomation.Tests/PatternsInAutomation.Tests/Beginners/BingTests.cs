using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PatternsInAutomation.Tests.Beginners.Selenium.Bing.Pages;
using POP = PatternsInAutomation.Tests.Beginners.Pages.BingMainPage;

namespace PatternsInAutomation.Tests.Beginners
{
    [TestClass]
    public class BingTests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new FirefoxDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void SearchTextInBing_First()
        {
            BingMainPage bingMainPage = new BingMainPage(this.Driver);
            bingMainPage.Navigate();
            bingMainPage.Search("Automate The Planet");
            bingMainPage.ValidateResultsCount("264,000 RESULTS");
        }

        [TestMethod]
        public void SearchTextInBing_Second()
        {
            POP.BingMainPage bingMainPage = new POP.BingMainPage(this.Driver);
            bingMainPage.Navigate();
            bingMainPage.Search("Automate The Planet");
            bingMainPage.Validate().ResultsCount("264,000 RESULTS");
        }
    }
}