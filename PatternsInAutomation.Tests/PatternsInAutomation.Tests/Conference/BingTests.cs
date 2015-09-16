using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Conference.BingMainPage;
using C = PatternsInAutomation.Tests.Conference.BingMainPage;

namespace PatternsInAutomation.Tests.Conference
{
    [TestClass]
    public class BingTests 
    {
        [TestInitialize]
        public void SetupTest()
        {
            Driver.StartBrowser(BrowserTypes.Firefox);
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Driver.StopBrowser();
        }

        [TestMethod]
        public void SearchTextInBing_First_Conference()
        {
            var bingMainPage = PageFactory<C.BingMainPage>.Create();
            bingMainPage.Navigate();
            bingMainPage.Search("Automate The Planet");
            bingMainPage.AssertResultsCountIsAsExpected("264,000 RESULTS");
        }
    }
}