using PatternsInAutomation.Tests.Advanced.Decorator.Basic.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Basic.Strategies
{
    class NoTaxesOrderValidationStrategy : IOrderValidationStrategy
    {
        public void ValidateOrderSummary(string itemsPrice, ClientPurchaseInfo clientPurchaseInfo)
        {
            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice("0.00");
        }
    }
}