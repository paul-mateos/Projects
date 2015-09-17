using System;
using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Conference;

namespace PatternsInAutomation.Tests.Advanced.Ebay.Pages.ItemPage
{
    public class ItemPage : BasePage<ItemPageMap, ItemPageValidator>, IItemPage
    {
        public ItemPage()
            : base("http://www.ebay.com/itm/")
        {
        }

        public void ClickBuyNowButton()
        {
            this.Map.BuyNowButton.Click();
        }

        public override void Navigate(string part)
        {
            //Casio-G-Shock-Standard-GA-100-1A2-Mens-Watch-Brand-New-/161209550414?pt=LH_DefaultDomain_15&hash=item2588d6864e
            base.Navigate(part);
        }
    }
}
