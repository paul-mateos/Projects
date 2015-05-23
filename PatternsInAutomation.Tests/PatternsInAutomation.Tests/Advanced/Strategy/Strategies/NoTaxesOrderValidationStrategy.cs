using PatternsInAutomation.Tests.Advanced.Strategy.Base;
using PatternsInAutomation.Tests.Advanced.Strategy.Data;
using PatternsInAutomation.Tests.Advanced.Strategy.Pages.PlaceOrderPage;

namespace PatternsInAutomation.Tests.Advanced.Strategy.Strategies
{
    class NoTaxesOrderValidationStrategy : IOrderValidationStrategy
    {
        public void ValidateOrderSummary(string itemsPrice, ClientPurchaseInfo clientPurchaseInfo)
        {
            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice("0.00");
        }
    }
}
