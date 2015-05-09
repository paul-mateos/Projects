using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P = PatternsInAutomation.Tests.Advanced.Fluent.BingMainPage;
using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Advanced.Fluent.Enums;

namespace PatternsInAutomation.Tests.Advanced
{
    [TestClass]
    public class FluentBingTests
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
        public void SearchForImageFuent()
        {
            P.BingMainPage.Instance
                                .Navigate()
                                .Search("facebook")
                                .ClickImages()
                                .SetSize(Sizes.Large)
                                .SetColor(Colors.BlackWhite)
                                .SetTypes(Types.Clipart)
                                .SetPeople(People.All)
                                .SetDate(Dates.PastYear)
                                .SetLicense(Licenses.All);
        }
    }
}