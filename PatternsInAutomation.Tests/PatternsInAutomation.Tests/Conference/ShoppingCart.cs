using PatternsInAutomation.Tests.Advanced.Ebay.Data;

namespace PatternsInAutomation.Tests.Conference
{
    public class ShoppingCart
    {
        private readonly IItemPage itemPage;

        private readonly ISignInPage signInPage;

        private readonly ICheckoutPage checkoutPage;

        private readonly IShippingAddressPage shippingAddressPage;

        public ShoppingCart(IItemPage itemPage, ISignInPage signInPage, ICheckoutPage checkoutPage, IShippingAddressPage shippingAddressPage)
        {
            this.itemPage = itemPage;
            this.signInPage = signInPage;
            this.checkoutPage = checkoutPage;
            this.shippingAddressPage = shippingAddressPage;
        }

        public void PurchaseItem(string item, string itemPrice, ClientInfo clientInfo)
        {
            this.itemPage.Navigate(item);
            ////this.itemPage.AssertPrice(itemPrice);
            this.itemPage.ClickBuyNowButton();
            this.signInPage.ClickContinueAsGuestButton();
            this.shippingAddressPage.FillShippingInfo(clientInfo);
            ////this.shippingAddressPage.AssertSubtotal(itemPrice);
            this.shippingAddressPage.ClickContinueButton();
            this.checkoutPage.AssertSubtotal(itemPrice);
        }
        // interfaces - change pages - different implementation
    }
}
