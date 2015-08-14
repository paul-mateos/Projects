namespace PatternsInAutomation.Tests.Advanced.Decorator.Services
{
    public class SalesTaxCalculationService
    {
        public decimal Calculate(decimal price, PatternsInAutomation.Tests.Advanced.Decorator.Enums.States state, string zip)
        {
            decimal taxPrice = default(decimal);
            // Call Real Web Service to determine the Sales Tax.
            switch (state)
            {
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.Arizona:
                    taxPrice = CalculateTaxPriceInternal(price, 7.125, zip);
                    break;
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.Illinois:
                    taxPrice = CalculateTaxPriceInternal(price, 3.75, zip);
                    break;
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.Massachusetts:
                    taxPrice = CalculateTaxPriceInternal(price, 6.25, zip);
                    break;
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.California:
                    taxPrice = CalculateTaxPriceInternal(price, 2.50, zip);
                    break;
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.Washington:
                    taxPrice = CalculateTaxPriceInternal(price, 3.10, zip);
                    break;
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.NewJersey:
                    taxPrice = CalculateTaxPriceInternal(price, 7.00, zip);
                    break;
                case PatternsInAutomation.Tests.Advanced.Decorator.Enums.States.Texas:
                    taxPrice = CalculateTaxPriceInternal(price, 8.15, zip);
                    break;
                default:
                    taxPrice = 0;
                    break;
            }

            return taxPrice;
        }

        private static decimal CalculateTaxPriceInternal(decimal price, double percent, string zip)
        {
            decimal taxPrice = price / (decimal)percent;
            return taxPrice;
        }
    }
}
