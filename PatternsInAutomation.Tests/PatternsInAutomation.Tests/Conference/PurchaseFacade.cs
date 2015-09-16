using System;
using System.Linq;
using PatternsInAutomation.Tests.Advanced.Ebay.Data;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.CheckoutPage;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.ItemPage;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.ShippingAddressPage;
using PatternsInAutomation.Tests.Advanced.Ebay.Pages.SignInPage;

namespace PatternsInAutomation.Tests.Conference
{
    public class PurchaseFacade
    {
        public ItemPage ItemPage { get; set; }

        public SignInPage SignInPage { get; set; }

        public CheckoutPage CheckoutPage { get; set; }

        public ShippingAddressPage ShippingAddressPage { get; set; }

        public void PurchaseItem(string item, string itemPrice, ClientInfo clientInfo)
        {
            this.ItemPage.Navigate(item);
            this.ItemPage.Validate().Price(itemPrice);
            this.ItemPage.ClickBuyNowButton();
            this.SignInPage.ClickContinueAsGuestButton();
            this.ShippingAddressPage.FillShippingInfo(clientInfo);
            this.ShippingAddressPage.Validate().Subtotal(itemPrice);
            this.ShippingAddressPage.ClickContinueButton();
            this.CheckoutPage.Validate().Subtotal(itemPrice);
        }
    }
}
