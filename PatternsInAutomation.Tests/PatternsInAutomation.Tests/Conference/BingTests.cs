using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Conference.Pages.BingMain;

namespace PatternsInAutomation.Tests.Conference
{
    [TestClass]
    public class BingTests 
    {
        private IFactory<ShoppingCart> shoppingCartFactory;
        private ShoppingCart shoppingCart;
        private IBingMainPage bingMainPage;
        private IWebDriver driver;

        [TestInitialize]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            shoppingCartFactory = new PurchaseFacadeFactory(driver);
            bingMainPage = new BingMainPage(driver);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            driver.Quit();
        }

        [TestMethod]
        public void SearchTextInBing_First_Conference()
        {
            // the facade design pattern no facade in the name because you don't want to know that this class is hiding the complexity
            // You can use the page objects directly. Because the page objects can be used easily in tests.
            /*
             *  hard instanciation to facade
             *  no need to factory to the pages, 
             *  you can change it.
             *  pages are created easily
             */
            shoppingCart = shoppingCartFactory.Create();
            shoppingCart.PurchaseItem("", "", null);
        }

        [TestMethod]
        public void BingMainPageTest()
        {
            this.bingMainPage.Open();
            this.bingMainPage.Search("Automate The Planet");
            this.bingMainPage.AssertResultsCountIsAsExpected(264);
        }
    }
}