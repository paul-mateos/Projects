using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.ItemPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PreviewShoppingCartPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.ShippingAddressPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.ShippingPaymentPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.SignInPage;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base
{
    public class PurchaseContext
    {
        private readonly IOrderPurchaseStrategy[] orderpurchaseStrategies;

        public PurchaseContext(params IOrderPurchaseStrategy[] orderpurchaseStrategies)
        {
            this.orderpurchaseStrategies = orderpurchaseStrategies;
        }

        public void PurchaseItem(string itemUrl, string itemPrice, ClientLoginInfo clientLoginInfo, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            this.ValidateClientPurchaseInfo(clientPurchaseInfo);

            ItemPage.Instance.Navigate(itemUrl);
            ItemPage.Instance.ClickBuyNowButton();
            PreviewShoppingCartPage.Instance.ClickProceedToCheckoutButton();
            SignInPage.Instance.Login(clientLoginInfo.Email, clientLoginInfo.Password);
            ShippingAddressPage.Instance.FillShippingInfo(clientPurchaseInfo);
            ShippingAddressPage.Instance.ClickDifferentBillingCheckBox(clientPurchaseInfo);
            ShippingAddressPage.Instance.ClickContinueButton();
            ShippingPaymentPage.Instance.ClickBottomContinueButton();
            ShippingAddressPage.Instance.FillBillingInfo(clientPurchaseInfo);
            ShippingAddressPage.Instance.ClickContinueButton();
            ShippingPaymentPage.Instance.ClickTopContinueButton();

            this.ValidateOrderSummary(itemPrice, clientPurchaseInfo);
        }

        public void ValidateClientPurchaseInfo(ClientPurchaseInfo clientPurchaseInfo)
        {
            foreach (var currentStrategy in orderpurchaseStrategies)
            {
                currentStrategy.ValidateClientPurchaseInfo(clientPurchaseInfo);
            }
        }

        public void ValidateOrderSummary(string itemPrice, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            foreach (var currentStrategy in orderpurchaseStrategies)
            {
                currentStrategy.ValidateOrderSummary(itemPrice, clientPurchaseInfo);
            }
        }
    }
}
