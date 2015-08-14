using System;
using PatternsInAutomation.Tests.Advanced.Decorator.Basic.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Enums;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Services;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Basic.Strategies
{
    public class VatTaxOrderValidationStrategy : IOrderValidationStrategy
    {
        public VatTaxOrderValidationStrategy()
        {
            this.VatTaxCalculationService = new VatTaxCalculationService();
        }

        public VatTaxCalculationService VatTaxCalculationService { get; set; }

        public void ValidateOrderSummary(string itemsPrice, ClientPurchaseInfo clientPurchaseInfo)
        {
            Countries currentCountry = (Countries)Enum.Parse(typeof(Countries), clientPurchaseInfo.BillingInfo.Country);
            decimal currentItemPrice = decimal.Parse(itemsPrice);
            decimal vatTax = this.VatTaxCalculationService.Calculate(currentItemPrice, currentCountry);

            PlaceOrderPage.Instance.Validate().EstimatedTaxPrice(vatTax.ToString());
        }
    }
}
