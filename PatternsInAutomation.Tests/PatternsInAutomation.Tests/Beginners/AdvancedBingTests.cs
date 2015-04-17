using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternsInAutomation.Tests.Advanced.BingMainPage;
using PatternsInAutomation.Tests.Advanced.Core;

namespace PatternsInAutomation.Tests.Beginners
{
    [TestClass]
    public class AdvancedBingTests
    {       

        [TestInitialize]
        public void SetupTest()
        {
            Driver.StartBrowser();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Driver.StopBrowser();
        }

        [TestMethod]
        public void SearchTextInBing_Advanced_PageObjectPattern()
        {
            BingMainPage bingMainPage = new BingMainPage();
            bingMainPage.Navigate();
            bingMainPage.Search("Automate The Planet");
            bingMainPage.Validate().ResultsCount(",000 RESULTS");
        }
    }
}