using PatternsInAutomation.Tests.Advanced.Decorator.Data;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Advanced.Base
{
    public interface IOrderPurchaseStrategy
    {
        void ValidateOrderSummary(string itemPrice, ClientPurchaseInfo clientPurchaseInfo);

        void ValidateClientPurchaseInfo(ClientPurchaseInfo clientPurchaseInfo);
    }
}