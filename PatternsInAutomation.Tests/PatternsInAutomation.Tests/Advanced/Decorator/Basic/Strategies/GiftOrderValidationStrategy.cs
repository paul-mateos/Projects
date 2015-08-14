using PatternsInAutomation.Tests.Advanced.Decorator.Basic.Base;
using PatternsInAutomation.Tests.Advanced.Decorator.Data;
using PatternsInAutomation.Tests.Advanced.Decorator.Pages.PlaceOrderPage;
using PatternsInAutomation.Tests.Advanced.Decorator.Services;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Basic.Strategies
{
    public class GiftOrderValidationStrategy : IOrderValidationStrategy
    {
        public GiftOrderValidationStrategy()
        {
            this.GiftWrappingPriceCalculationService = new GiftWrappingPriceCalculationService();
        }

        public GiftWrappingPriceCalculationService GiftWrappingPriceCalculationService { get; set; }

        public void ValidateOrderSummary(string itemsPrice, ClientPurchaseInfo clientPurchaseInfo)
        {
            decimal giftWrapPrice = this.GiftWrappingPriceCalculationService.Calculate(clientPurchaseInfo.GiftWrapping);

            PlaceOrderPage.Instance.Validate().GiftWrapPrice(giftWrapPrice.ToString());
        }
    }
}
