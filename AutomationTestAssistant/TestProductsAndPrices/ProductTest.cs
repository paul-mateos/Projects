using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProductsAndPrices
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void TestPriceChange()
        {
            string name = "Tee";
            Decimal price = new Decimal(20.3);
            Product product = new Product(name, price);

            decimal expected = 10.3M;
            product.Price = 10.3M;
            decimal actual = product.Price;

            Assert.AreEqual<decimal>(actual, expected,
                "There were a problem in changing the value of the price!");      
        }

        [TestMethod]
        public void TestProductConstructorInitializeWithNormalValues()
        {
            string name = "Tee"; 
            Decimal price = new Decimal(20.3);
            Product product = new Product(name, price);

            bool expected = true;
            bool actual = AreProductsAttributesEqual(
                name, product.Name, price, product.Price);
            Assert.AreEqual<bool>(actual, expected,
                "There were a problem in initializing the product!");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Trying initilize price with negativ value didn't throw an exception!")]
        public void TestProductConstructorNegativPrice()
        {
            string name = "Tee";
            Decimal price = new Decimal(-20.3);
            Product product = new Product(name, price);
        }

        private bool AreProductsAttributesEqual(string firstName, string secondName,
            decimal firstPrice, decimal secondPrice)
        {
            bool areNamesEqual = firstName == secondName;
            bool arePricesEqual = firstPrice == secondPrice;
            bool areProductsEqual = areNamesEqual && arePricesEqual;

            return areProductsEqual;
        }
    }
}


