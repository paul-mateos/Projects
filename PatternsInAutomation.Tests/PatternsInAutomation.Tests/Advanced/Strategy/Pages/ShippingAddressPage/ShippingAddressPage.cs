using PatternsInAutomation.Tests.Advanced.Core;
using PatternsInAutomation.Tests.Advanced.Strategy.Data;

namespace PatternsInAutomation.Tests.Advanced.Strategy.Pages.ShippingAddressPage
{
    public class ShippingAddressPage : BasePageSingleton<ShippingAddressPage, ShippingAddressPageMap>
    {
        public void ClickContinueButton()
        {
            this.Map.ContinueButton.Click();
        }

        public void FillShippingInfo(ClientPurchaseInfo clientInfo)
        {
            this.Map.CountryDropDown.SelectByText(clientInfo.Country);
            this.Map.FullNameInput.SendKeys(clientInfo.FullName);
            this.Map.Address1Input.SendKeys(clientInfo.Address1);
            this.Map.CityInput.SendKeys(clientInfo.City);
            this.Map.ZipInput.SendKeys(clientInfo.Zip);
            this.Map.PhoneInput.SendKeys(clientInfo.Phone);
            this.Map.ShipToThisAddress.Click();
        }
    }
}
