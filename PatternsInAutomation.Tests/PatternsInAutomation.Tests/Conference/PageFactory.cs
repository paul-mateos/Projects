using System;
using OpenQA.Selenium;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.CheckoutPage;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.ItemPage;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.ShippingAddressPage;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.SignInPage;

namespace PatternsInAutomation.Tests.Conference
{
    public class PurchaseFacadeFactory : IFactory<ShoppingCart>
    {
        private readonly IWebDriver driver;

        public PurchaseFacadeFactory(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ShoppingCart Create()
        {
            var itemPage = new ItemPage(this.driver);
            var signInPage = new SignInPage(this.driver);
            var checkoutPage = new CheckoutPage(this.driver);
            var shippingAddressPage = new ShippingAddressPage(this.driver);
            var purchaseFacade = new ShoppingCart(itemPage, signInPage, checkoutPage, shippingAddressPage);
            return purchaseFacade;
        }
    }    
}