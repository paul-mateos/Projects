using PatternsInAutomation.Tests.Advanced.Strategy.Enums;

namespace PatternsInAutomation.Tests.Advanced.Strategy.Data
{
    public class ClientPurchaseInfo
    {
        public string FullName { get; set; }

        public string Country { get; set; }

        public string Address1 { get; set; }

        public string City { get; set; }

        public string Phone { get; set; }

        public string Zip { get; set; }

        public string Email { get; set; }

        public string State { get; set; }

        public string DeliveryType { get; set; }

        public GiftWrappingStyles GiftWrapping { get; set; }
    }
}