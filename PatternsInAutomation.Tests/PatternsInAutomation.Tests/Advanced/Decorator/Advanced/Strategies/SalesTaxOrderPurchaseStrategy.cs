using System;
using PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Strategies
{
    public class SalesTaxOrderPurchaseStrategy : IOrderPurchaseStrategy
    {
        public SalesTaxOrderPurchaseStrategy()
        {
            this.SalesTaxCalculationService = new PatternsInAutomation.Tests.Advanced.Decorator.Services.SalesTaxCalculationService();
        }

        public PatternsInAutomation.Tests.Advanced.Decorator.Services.SalesTaxCalculationService SalesTaxCalculationService { get; set; }

        public void ValidateOrderSummary(string itemsPrice, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            PatternsInAutomation.Tests.Advanced.Decorator.Enums.States currentState = (PatternsInAutomation.Tests.Advanced.Decorator.Enums.States)Enum.Parse(typeof(PatternsInAutomation.Tests.Advanced.Decorator.Enums.States), clientPurchaseInfo.ShippingInfo.State);
            decimal currentItemPrice = decimal.Parse(itemsPrice);
            decimal salesTax = this.SalesTaxCalculationService.Calculate(currentItemPrice, currentState, clientPurchaseInfo.ShippingInfo.Zip);

            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice(salesTax.ToString());
        }

        public void ValidateClientPurchaseInfo(PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            if (!clientPurchaseInfo.ShippingInfo.Country.Equals("United States"))
            {
                throw new ArgumentException("If the NoTaxesOrderPurchaseStrategy is used, the country should be set to United States because otherwise no sales tax is going to be applied.");
            }
        }
    }
}
