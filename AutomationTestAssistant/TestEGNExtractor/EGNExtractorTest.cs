using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace TestEGNExtractor
{
    [TestClass]
    public class EGNExtractorTest
    {
        [TestMethod]
        public void TestReadEGNsFromFile()
        {
            string inputFileName = Path.GetTempFileName();
            string textForWrite = "I am bay Ivan and my personal ID number is 4806182906!";
            WriteTextToFile(inputFileName, textForWrite);

            string expectedText = textForWrite;
            string actualText = EGNExtractor_Accessor.ReadEGNsFromFile(inputFileName);

            Assert.AreEqual<string>(expectedText, actualText,
                                    "There is a problem reading the file!");
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestReadEGNsFromFileFileNotFoundException()
        {
            string actualText = EGNExtractor_Accessor.ReadEGNsFromFile("Go6o.txt");
            Assert.Fail("If there is no such file for read" +
                        " method should throw FileNotFoundException!");
        }

        [TestMethod()]    
        public void TestExtractAllEGNsNormalCase()
        {
            string text = "I am bay Ivan and my personal ID number is 4806182906!";
            List<string> expected = new List<string>() { "4806182906" };

            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod()]
        public void TestExtractAllEGNsTooLongEGNsAndDifferentNumbers()
        {
            string text = "I am bay Ivan and my personal ID number is 48061829062" +
                          " and my phone number is 08962962653!";

            List<string> expected = new List<string>() { };
            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod()]
        public void TestExtractAllEGNsTooShortEGNs()
        {
            string text = "I am bay Ivan and my personal ID number is 4806" +
                          " and my phone number is 08962!";

            List<string> expected = new List<string>() { };
            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod()]
        public void TestExtractAllEGNsFor3CorrectEGNs()
        {
            string text = "I am bay Ivan and my personal ID number is 4806484852" +
                          " and my phone number is 0896296265!";

            List<string> expected = new List<string>() { "4806484852", "0896296265" };
            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod()]
        public void TestExtractAllEGNsWithEGNsPartOfSubstring()
        {
            string text = "I am bay Ivan and my personal ID number is 4806" +
                          " and my phone number is0896296263!";

            List<string> expected = new List<string>() { };
            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod]
        public void TestExtractAllEGNsWithEGNsWithSpaces()
        {
            string text = "I am bay Ivan and my personal ID number is 48 0618 2902" +
                          " and my phone number is 089 62626 53!";

            List<string> expected = new List<string>() { };
            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod()]
        public void TestExtractAllEGNsEmptyText()
        {
            string text = String.Empty;
            List<string> expected = new List<string>() { };
            List<string> actual = EGNExtractor_Accessor.ExtractAllEGNs(text);

            CollectionAssert.AreEqual(expected, actual,
                                      "There is a problem in extracting all EGNs from text!");
        }

        [TestMethod()]
        public void TestPrintAllEgnsFromFileNormalCase()
        {
            string inputFileName = @"../../input.txt";
            string text = "I am bay Ivan and my personal ID number is 4806484852" +
                          " and my phone number is 0896296265!";
            WriteTextToFile(inputFileName, text);
            string outputFileName = @"../../output.txt";            
            StreamWriter writer = new StreamWriter(outputFileName);
            using (writer)
            {
                Console.SetOut(writer);
                EGNExtractor.PrintAllEgnsFromFile(inputFileName);
            }

            string expected = "4806484852" + "0896296265";
            string actual = ExtractTextFromFile(outputFileName);
            
            Assert.AreEqual<string>(actual, expected,
                                    "There is a problem in printing to the console.");            
        }

        [TestMethod]
        public void TestPrintAllEgnsFromFileEmptyText()
        {
            string inputFileName = @"../../input.txt";
            string text = String.Empty;
            WriteTextToFile(inputFileName, text);
            string outputFileName = @"../../output.txt";            
            StreamWriter writer = new StreamWriter(outputFileName);
            using (writer)
            {
                Console.SetOut(writer);
                EGNExtractor.PrintAllEgnsFromFile(inputFileName);
            }

            string expected = String.Empty;
            string actual = ExtractTextFromFile(outputFileName);

            Assert.AreEqual<string>(actual, expected,
                                    "There is a problem in printing to the console.");
        }

        private static string ExtractTextFromFile(string fileName)
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

        private void WriteTextToFile(string inputFileName, string textForWrite)
        {
            StreamWriter writer = new StreamWriter(inputFileName);
            using (writer)
            {
                writer.Write(textForWrite);
            }
        }
    }
}

