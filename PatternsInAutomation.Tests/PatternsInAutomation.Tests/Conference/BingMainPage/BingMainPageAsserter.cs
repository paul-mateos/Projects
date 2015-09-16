using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PatternsInAutomation.Tests.Conference.BingMainPage
{
    public static class BingMainPageAsserter
    {
        public static BingMainPage AssertResultsCountIsAsExpected(this BingMainPage page, string expectedCount)
        {
            Assert.IsTrue(page.Map.ResultsCountDiv.Text.Contains(expectedCount), "The results DIV doesn't contains the specified text.");

            return page;
        }
    }
}