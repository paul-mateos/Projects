using System;
using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Conference;

namespace PatternsInAutomation.Tests.Advanced.Ebay.Pages.CheckoutPage
{
    public class CheckoutPage : BasePage<CheckoutPageMap, CheckoutPageValidator>, ICheckoutPage
    {
        public void AssertSubtotal(string itemPrice)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
