using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Strategies;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Tests
{
    [TestClass]
    public class AmazonPurchase_PurchaseStrategy_Tests
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
        public void Purchase_SeleniumTestingToolsCookbook()
        {
            string itemUrl = "/Selenium-Testing-Cookbook-Gundecha-Unmesh/dp/1849515743";
            string itemPrice = "40.49";
            ClientPurchaseInfo clientPurchaseInfo = new ClientPurchaseInfo(
            new ClientAddressInfo()
            {
                FullName = "John Smith",
                Country = "United States",
                Address1 = "950 Avenue of the Americas",
                State = "New York",
                City = "New York City",
                Zip = "10001-2121",
                Phone = "00164644885569"
            })
            {
                GiftWrapping = Enums.GiftWrappingStyles.None
            };
            ClientLoginInfo clientLoginInfo = new ClientLoginInfo()
            {
                Email = "g3984159@trbvm.com",
                Password = "ASDFG_12345"
            };

            new PurchaseContext(new SalesTaxOrderPurchaseStrategy()).PurchaseItem(itemUrl, itemPrice, clientLoginInfo, clientPurchaseInfo);
        }
    }
}