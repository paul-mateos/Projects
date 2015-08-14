using PatternsInAutomation.Tests.Advanced.Decorator.Data;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Basic.Base
{
    public interface IOrderValidationStrategy
    {
        void ValidateOrderSummary(string itemPrice, ClientPurchaseInfo clientPurchaseInfo);
    }
}