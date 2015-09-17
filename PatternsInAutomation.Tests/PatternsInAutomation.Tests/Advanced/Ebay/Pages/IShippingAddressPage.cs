using PatternsInAutomation.Tests.Advanced.Ebay.Data;

namespace PatternsInAutomation.Tests.Conference
{
    public interface IShippingAddressPage
    {
        void FillShippingInfo(ClientInfo clientInfo);

        void ClickContinueButton();
    }
}