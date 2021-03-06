﻿using PatternsInAutomation.Tests.Advanced.Core;

namespace PatternsInAutomation.Tests.Advanced.Decorator.Pages.ShippingPaymentPage
{
    public class ShippingPaymentPage : BasePageSingleton<ShippingPaymentPage, ShippingPaymentPageMap>
    {
        public void ClickBottomContinueButton()
        {
            this.Map.BottomContinueButton.Click();
        }

        public void ClickTopContinueButton()
        {
            this.Map.TopContinueButton.Click();
        }
    }
}
