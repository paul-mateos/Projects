using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

namespace TestEncryption
{
    [TestClass]
    public class EncryptorTest
    {
        [TestMethod]
        public void TestEncryptForBigAmountOfData()
        {
            string textForWrite = "I am Bay Ivan. My Bulgarian personal ID number (EGN) is" +
                                  " 4806182906. My phone number is 0888 / 12-34-56. I have 2 sons." +
                                  " Peter is the oldest. His EGN is: 6203120702. The other is Ivan" +
                                  " and his EGN is 6711287756. My credit card number is 4716315223269910."; 
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();
            WriteTextToFile(inputFileName, textForWrite);
            FileStream outputFile = File.OpenRead(inputFileName);          
            using (outputFile)
            {
                FileStream inputFile = File.OpenWrite(outputFileName);
                using (inputFile)
                {
                    Encryptor.EncryptData(outputFile, inputFile);
                }
            }
            
            string expected = " I amIBay  van.uMy Bilgarean parson l" +
                              " IDenumbGr (EsN) i6 48001829y6. Mn phome nuiber 8s 0818" +
                              " / -2-34I56. e havo 2 sPns.  eterhis tde ol est.EHis sGN" +
                              " i0: 6273120T02. the oiher as Ivdn an  hisiEGN 1s 6771287M56." +
                              " ey crcdit nard rumbe4 is 171632522306991.";
            string actual = ReadTextFromFile(outputFileName);
         
            Assert.AreEqual<string>(actual, expected,
                                    "There is a problem in encrypting the data!");           
        }

        [TestMethod]
        public void TestEncryptEmpty()
        {
            string textForWrite = String.Empty;
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();
            WriteTextToFile(inputFileName, textForWrite);
            FileStream outputFile = File.OpenRead(inputFileName);
            using (outputFile)
            {
                FileStream inputFile = File.OpenWrite(outputFileName);
                using (inputFile)
                {
                    Encryptor.EncryptData(outputFile, inputFile);
                }
            }

            string expected = String.Empty;
            string actual = ReadTextFromFile(outputFileName);

            Assert.AreEqual<string>(actual, expected,
                                    "There was a problem in encrypting the data!");
        }

        [TestMethod]
        public void TestEncryptForSmallAmountOfData()
        {
            string textForWrite = "123";
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();
            WriteTextToFile(inputFileName, textForWrite);
            FileStream outputFile = File.OpenRead(inputFileName);
            using (outputFile)
            {
                FileStream inputFile = File.OpenWrite(outputFileName);
                using (inputFile)
                {
                    Encryptor.EncryptData(outputFile, inputFile);
                }
            }

            string expected = "312";
            string actual = ReadTextFromFile(outputFileName);

            Assert.AreEqual<string>(actual, expected,
                                    "There was a problem in encrypting the data!");
        }

        [TestMethod]
        public void TestDecryptForBigAmountOfData()
        {
            string textForWrite = " I amIBay  van.uMy Bilgarean parson l" +
                                  " IDenumbGr (EsN) i6 48001829y6. Mn phome nuiber 8s 0818" +
                                  " / -2-34I56. e havo 2 sPns.  eterhis tde ol est.EHis sGN" +
                                  " i0: 6273120T02. the oiher as Ivdn an  hisiEGN 1s 6771287M56." +
                                  " ey crcdit nard rumbe4 is 171632522306991.";
          
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();
            WriteTextToFile(inputFileName, textForWrite);
            FileStream outputFile = File.OpenRead(inputFileName);
            using (outputFile)
            {
                FileStream inputFile = File.OpenWrite(outputFileName);
                using (inputFile)
                {
                    Encryptor.DecryptData(outputFile, inputFile);
                }
            }

            string expected = "I am Bay Ivan. My Bulgarian personal ID number (EGN) is" +
                              " 4806182906. My phone number is 0888 / 12-34-56. I have 2 sons." +
                              " Peter is the oldest. His EGN is: 6203120702. The other is Ivan" +
                              " and his EGN is 6711287756. My credit card number is 4716315223269910.";
            string actual = ReadTextFromFile(outputFileName);

            Assert.AreEqual<string>(expected, actual,
                                    "There was a problem in decrypting the data!");
        }

        [TestMethod]
        public void TestDecryptEmpty()
        {
            string textForWrite = String.Empty;
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();
            WriteTextToFile(inputFileName, textForWrite);
            FileStream outputFile = File.OpenRead(inputFileName);
            using (outputFile)
            {
                FileStream inputFile = File.OpenWrite(outputFileName);
                using (inputFile)
                {
                    Encryptor.DecryptData(outputFile, inputFile);
                }
            }

            string expected = String.Empty;
            string actual = ReadTextFromFile(outputFileName);

            Assert.AreEqual<string>(actual, expected,
                                    "There was a problem in decrypting data!");
        }

        [TestMethod]
        public void TestDecryptForSmallAmountOfData()
        {
            string textForWrite = "312";
            string inputFileName = Path.GetTempFileName();
            string outputFileName = Path.GetTempFileName();
            WriteTextToFile(inputFileName, textForWrite);
            FileStream outputFile = File.OpenRead(inputFileName);
            using (outputFile)
            {
                FileStream inputFile = File.OpenWrite(outputFileName);
                using (inputFile)
                {
                    Encryptor.DecryptData(outputFile, inputFile);
                }
            }

            string expected = "123";
            string actual = ReadTextFromFile(outputFileName);

            Assert.AreEqual<string>(actual, expected,
                                    "There was a problem in decrypting the data!");
        }

        [TestMethod]
        public void TestShiftByteArrayRightNormalCase()
        {
            byte[] inputByteArray = { 0, 1, 0, 3 , 4 }; 
            int size = 5; 

            byte[] expected = { 4, 0, 1, 0, 3 }; 
            byte[] actual = Encryptor.ShiftByteArrayRight(inputByteArray, size);

            CollectionAssert.AreEqual(actual, expected,
                                      "There was a problem in shifting bytes right!");
        }

        [TestMethod]
        public void TestShiftByteArrayLeftNormalCase()
        {
            byte[] inputByteArray = { 0, 1, 0, 3, 4 };
            int size = 5;

            byte[] expected = { 1, 0, 3, 4, 0 };
            byte[] actual = Encryptor.ShiftByteArrayLeft(inputByteArray, size);

            CollectionAssert.AreEqual(expected, actual,
                                      "There was a problem in shifting bytes left!");
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

