using System;
using PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Enums;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Strategies
{
    public class NoTaxesOrderPurchaseStrategy : IOrderPurchaseStrategy
    {
        public NoTaxesOrderPurchaseStrategy(bool shouldExecute)
        {
        }

        public void ValidateOrderSummary(string itemsPrice, ClientPurchaseInfo clientPurchaseInfo)
        {
            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice("0.00");
        }

        public void ValidateClientPurchaseInfo(ClientPurchaseInfo clientPurchaseInfo)
        {
            if (clientPurchaseInfo.ShippingInfo.Country.Equals(Countries.UnitedStates))
            {
                throw new ArgumentException("If the NoTaxesOrderPurchaseStrategy is used, the country cannot be set to United States because a sales tax is going to be applied.");
            }
            // Add another validation for the EU contries because for them a VAT Tax is going to be applied if not VAT ID is set.
        }
    }
}
