using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace TestProductsAndPrices
{
    [TestClass]
    public class PriceIncreasedEventArgsTest
    {
        [TestMethod()]
        public void TestPriceIncreasedEventArgsOldValueWhenPriceIncreases()
        {
            Product beer = new Product("beer", 1.2M);    
            string outputFileName = @"../../beerOldValue.txt";            
            StreamWriter writer = new StreamWriter(outputFileName);
            using (writer)
            {
                Console.SetOut(writer);
                beer.PriceIncreased += new PriceIncreasedEventHandler(
                    Beer_PriceIncreasedPrintOldValue);
                beer.Price = 1.3M;               
            }

            decimal expected = 1.2M;
            string actualStr = ReadTextFromFile(outputFileName);
            decimal actual = decimal.Parse(actualStr);

            Assert.AreEqual<decimal>(actual, expected,
                                     "There is a problem fired event of price increase."); 
        }

        [TestMethod()]
        public void TestPriceIncreasedEventArgsOldValueWhenPriceDecrease()
        {
            Product beer = new Product("beer", 1.2M);
            string outputFileName = @"../../beerOldValue.txt";
            StreamWriter writer = new StreamWriter(outputFileName);
            using (writer)
            {
                Console.SetOut(writer);
                beer.PriceIncreased += new PriceIncreasedEventHandler(
                    Beer_PriceIncreasedPrintOldValue);
                beer.Price = 1.1M;
            }

            string expected = String.Empty;
            string actual = ReadTextFromFile(outputFileName);           

            Assert.AreEqual<string>(actual, expected,
                                    "There is a problem fired event of price increase.");
        }

        static void Beer_PriceIncreasedPrintOldValue(object sender, PriceIncreasedEventArgs e)
        {
            Console.WriteLine(e.OldValue);
        }

        static void Beer_PriceIncreasedPrintNewValue(object sender, PriceIncreasedEventArgs e)
        {
            Console.WriteLine(e.NewValue);
        }

        [TestMethod()]
        public void TestPriceIncreasedEventArgsNewValueWhenPriceIncreases()
        {
            Product beer = new Product("beer", 1.2M);
            string outputFileName = @"../../beerOldValue.txt";
            StreamWriter writer = new StreamWriter(outputFileName);
            using (writer)
            {
                Console.SetOut(writer);
                beer.PriceIncreased += new PriceIncreasedEventHandler(
                    Beer_PriceIncreasedPrintNewValue);
                beer.Price = 1.3M;
            }

            decimal expected = 1.3M;
            string actualStr = ReadTextFromFile(outputFileName);
            decimal actual = decimal.Parse(actualStr);

            Assert.AreEqual<decimal>(actual, expected,
                                     "There is a problem fired event of price increase.");
        }

        [TestMethod()]
        public void TestPriceIncreasedEventArgsnewValueWhenPriceDecrease()
        {
            Product beer = new Product("beer", 1.2M);
            string outputFileName = @"../../beerOldValue.txt";
            StreamWriter writer = new StreamWriter(outputFileName);
            using (writer)
            {
                Console.SetOut(writer);
                beer.PriceIncreased += new PriceIncreasedEventHandler(
                    Beer_PriceIncreasedPrintNewValue);
                beer.Price = 1.1M;
            }

            string expected = String.Empty;
            string actual = ReadTextFromFile(outputFileName);

            Assert.AreEqual<string>(actual, expected,
                                    "There is a problem fired event of price increase.");
        }

        private static string ReadTextFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            StringBuilder sb = new StringBuilder();
            string currentLine = reader.ReadLine();
            while (currentLine != null)
            {
                sb.Append(currentLine);
                currentLine = reader.ReadLine();
            }
            reader.Close();
            string textInFile = sb.ToString();
            return textInFile;
        }
    }
}

