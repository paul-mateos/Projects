using System;
using PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Enums;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Services;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Strategies
{
    public class VatTaxOrderPurchaseStrategy : IOrderPurchaseStrategy
    {
        public VatTaxOrderPurchaseStrategy()
        {
            this.VatTaxCalculationService = new VatTaxCalculationService();
        }

        public VatTaxCalculationService VatTaxCalculationService { get; set; }

        public void ValidateOrderSummary(string itemsPrice, PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
            Countries currentCountry = (Countries)Enum.Parse(typeof(Countries), clientPurchaseInfo.BillingInfo.Country);
            decimal currentItemPrice = decimal.Parse(itemsPrice);
            decimal vatTax = this.VatTaxCalculationService.Calculate(currentItemPrice, currentCountry);

            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice(vatTax.ToString());
        }

        public void ValidateClientPurchaseInfo(PatternsInAutomation.Tests.Advanced.Decorator.Data.ClientPurchaseInfo clientPurchaseInfo)
        {
           // Throw a new Argument exection if the country is not part of the EU Union.
        }
    }
}
