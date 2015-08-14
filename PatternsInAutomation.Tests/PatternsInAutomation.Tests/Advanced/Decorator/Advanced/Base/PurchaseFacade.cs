using PatternsInAutomation.Tests.Advanced.Decorator.Pages.ItemPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PreviewShoppingCartPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.ShippingAddressPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.ShippingPaymentPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.SignInPage;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base
{
    public class PurchaseFacade
    {
        public void PurchaseItemSalesTax(string itemUrl, string itemPrice, string taxAmount, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientLoginInfo clientLoginInfo, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            PurchaseItemInternal(itemUrl, clientLoginInfo, clientPurchaseInfo);
            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice(taxAmount);
        }

        public void PurchaseItemGiftWrapping(string itemUrl, string itemPrice, string giftWrapTax, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientLoginInfo clientLoginInfo, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            PurchaseItemInternal(itemUrl, clientLoginInfo, clientPurchaseInfo);
            PlaceOrderPage.Instance.Validate().GiftWrapPrice(giftWrapTax);
        }

        public void PurchaseItemShippingTax(string itemUrl, string itemPrice, string shippingTax, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientLoginInfo clientLoginInfo, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            PurchaseItemInternal(itemUrl, clientLoginInfo, clientPurchaseInfo);
            PlaceOrderPage.Instance.Validate().ShippingTaxPrice(shippingTax);
        }

        private void PurchaseItemInternal(string itemUrl, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientLoginInfo clientLoginInfo, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            ItemPage.Instance.Navigate(itemUrl);
            ItemPage.Instance.ClickBuyNowButton();
            PreviewShoppingCartPage.Instance.ClickProceedToCheckoutButton();
            SignInPage.Instance.Login(clientLoginInfo.Email, clientLoginInfo.Password);
            ShippingAddressPage.Instance.FillShippingInfo(clientPurchaseInfo);
            ShippingAddressPage.Instance.ClickContinueButton();
            ShippingPaymentPage.Instance.ClickBottomContinueButton();
            ShippingPaymentPage.Instance.ClickTopContinueButton();
        }
    }
}
