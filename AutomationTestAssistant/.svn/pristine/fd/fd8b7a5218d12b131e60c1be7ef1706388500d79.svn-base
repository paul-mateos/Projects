using System.Collections.Generic;
using System.IO;
using System.Xml;
using AutomationTestAssistantCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace TestAutomationTestAssistantCore
{
    [TestClass]
    public class TestTestListGenerator
    {
        [TestMethod]
        public void TestTestListGeneratorTestListsNodeOnlyOneNodeGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode= doc.GetElementsByTagName("TestLists").Item(0);
            Assert.AreEqual<int>(1, doc.GetElementsByTagName("TestLists").Count);
        }

        [TestMethod]
        public void TestTestListGeneratorTestListsNodeAttributesCount()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestLists").Item(0);
            Assert.AreEqual<int>(1, testListNode.Attributes.Count);
        }

        [TestMethod]
        public void TestTestListGeneratorTestListsNodeCorrectNamespaceGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestLists").Item(0);
            Assert.AreEqual<string>("http://microsoft.com/schemas/VisualStudio/TeamTest/2010", testListNode.NamespaceURI);
        }

        [TestMethod]
        public void TestTestListGeneratorTestListNodeTwoNodesGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(0);
            Assert.AreEqual<int>(2, doc.GetElementsByTagName("TestList").Count);
        }

        [TestMethod]
        public void TestTestListGeneratorFirstTestListNodeAttributesCount()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(0);
            Assert.AreEqual<int>(3, testListNode.Attributes.Count);
        }

        [TestMethod]
        public void TestTestListGeneratorFirstTestListNodeAttributesCorrectNames()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(0);
            Assert.AreEqual<string>("name", testListNode.Attributes.Item(0).Name.ToString());
            Assert.AreEqual<string>("id", testListNode.Attributes.Item(1).Name.ToString());
            Assert.AreEqual<string>("parentListId", testListNode.Attributes.Item(2).Name.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorSecondTestListNodeAttributesCount()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(1);
            Assert.AreEqual<int>(2, testListNode.Attributes.Count);
        }

        [TestMethod]
        public void TestTestListGeneratorSecondTestListNodeAttributesCorrectNames()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(1);
            Assert.AreEqual<string>("name", testListNode.Attributes.Item(0).Name.ToString());
            Assert.AreEqual<string>("id", testListNode.Attributes.Item(1).Name.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorFirstTestListNodeAttributesCorrectValues()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(0);
            Assert.AreEqual<string>("TestListTemplate", testListNode.Attributes.Item(0).Value.ToString());
            Guid newGuid = new Guid();
            Assert.AreEqual<bool>(true, Guid.TryParse(testListNode.Attributes.Item(1).Value.ToString(), out newGuid));
            Assert.AreEqual<string>("8c43106b-9dc1-4907-a29f-aa66a61bf5b6", testListNode.Attributes.Item(2).Value.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorSecondTestListNodeAttributesCorrectValues()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestList").Item(1);
            Assert.AreEqual<string>("Lists of Tests", testListNode.Attributes.Item(0).Value.ToString());
            Assert.AreEqual<string>("8c43106b-9dc1-4907-a29f-aa66a61bf5b6", testListNode.Attributes.Item(1).Value.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinksNodeAttributesCount()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestLinks").Item(0);
            Assert.AreEqual<int>(0, testListNode.Attributes.Count);
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinksNodeOnlyOneNodeGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestLinks").Item(0);
            Assert.AreEqual<int>(1, doc.GetElementsByTagName("TestLinks").Count);
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinksNodeTwoNodesGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestLink").Item(0);
            Assert.AreEqual<int>(2, doc.GetElementsByTagName("TestLink").Count);
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinkNodeAttributesCount()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("TestLink").Item(0);
            Assert.AreEqual<int>(4, testListNode.Attributes.Count);
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinkNodeAttributesCorrectNames()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            var testListNodes = doc.GetElementsByTagName("TestLink");
            foreach (XmlNode item in testListNodes)
            {
                Assert.AreEqual<string>("id", item.Attributes.Item(0).Name.ToString());
                Assert.AreEqual<string>("name", item.Attributes.Item(1).Name.ToString());
                Assert.AreEqual<string>("storage", item.Attributes.Item(2).Name.ToString());
                Assert.AreEqual<string>("type", item.Attributes.Item(3).Name.ToString());
            }        
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinkNodeAttributesCorrectTestNamesAssociated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            var testListNodes = doc.GetElementsByTagName("TestLink");
            Assert.AreEqual<string>("TestPrintAllEgnsFromFileNormalCase", testListNodes.Item(0).Attributes.Item(1).Value.ToString());
            Assert.AreEqual<string>("TestPriceIncreasedEventArgsnewValueWhenPriceDecrease", testListNodes.Item(1).Attributes.Item(1).Value.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinkNodeAttributesCorrectTestIdsGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            var testListNodes = doc.GetElementsByTagName("TestLink");
            Assert.AreEqual<string>("b32db64b-b03d-108a-4b9c-2659a76a2f30", testListNodes.Item(0).Attributes.Item(0).Value.ToString());
            Assert.AreEqual<string>("61d07261-50c7-d2f2-273b-d1f4e562dd46", testListNodes.Item(1).Attributes.Item(0).Value.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinkNodeAttributesCorrectTestStorageAssociated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            var testListNodes = doc.GetElementsByTagName("TestLink");
            Assert.AreEqual<string>(@"D:\AutomationTestHelper\testegnextractor\bin\release\testegnextractor.dll", testListNodes.Item(0).Attributes.Item(2).Value.ToString());
            Assert.AreEqual<string>(@"D:\AutomationTestHelper\testproductsandprices\bin\release\testproductsandprices.dll", testListNodes.Item(1).Attributes.Item(2).Value.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorTestLinkNodeAttributesCorrectTypesAssociated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            var testListNodes = doc.GetElementsByTagName("TestLink");
            Assert.AreEqual<string>("Microsoft.VisualStudio.TestTools.TestTypes.Unit.UnitTestElement, Microsoft.VisualStudio.QualityTools.Tips.UnitTest.ObjectModel, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", testListNodes.Item(0).Attributes.Item(3).Value.ToString());
            Assert.AreEqual<string>("Microsoft.VisualStudio.TestTools.TestTypes.Unit.UnitTestElement, Microsoft.VisualStudio.QualityTools.Tips.UnitTest.ObjectModel, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", testListNodes.Item(1).Attributes.Item(3).Value.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorRunConfigurationOnlyOneNodeGenerated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("RunConfiguration").Item(0);
            Assert.AreEqual<int>(1, doc.GetElementsByTagName("RunConfiguration").Count);
        }

        [TestMethod]
        public void TestTestListGeneratorRunConfigurationAttributesCount()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("RunConfiguration").Item(0);
            Assert.AreEqual<int>(4, testListNode.Attributes.Count);
        }

        [TestMethod]
        public void TestTestListGeneratorRunConfigurationAttributesCorrectNames()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            XmlNode testListNode = doc.GetElementsByTagName("RunConfiguration").Item(0);
            Assert.AreEqual<string>("id", testListNode.Attributes.Item(0).Name.ToString());
            Assert.AreEqual<string>("name", testListNode.Attributes.Item(1).Name.ToString());
            Assert.AreEqual<string>("storage", testListNode.Attributes.Item(2).Name.ToString());
            Assert.AreEqual<string>("type", testListNode.Attributes.Item(3).Name.ToString());
        }

        [TestMethod]
        public void TestTestListGeneratorRunConfigurationAttributesCorrectTestValuesAssociated()
        {
            System.Xml.XmlDocument doc = GenerateTestListXmlDocument();
            var testListNodes = doc.GetElementsByTagName("RunConfiguration");
            Assert.AreEqual<string>("8780a2e3-78a6-4742-922c-4ad691741c2c", testListNodes.Item(0).Attributes.Item(0).Value.ToString());
            Assert.AreEqual<string>("Local", testListNodes.Item(0).Attributes.Item(1).Value.ToString());
            Assert.AreEqual<string>("local.testsettings", testListNodes.Item(0).Attributes.Item(2).Value.ToString());
            Assert.AreEqual<string>("Microsoft.VisualStudio.TestTools.Common.TestRunConfiguration, Microsoft.VisualStudio.QualityTools.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", testListNodes.Item(0).Attributes.Item(3).Value.ToString());
        }

        [TestMethod]
        public void TestGenerateTestLinksCorrectCount()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string asseblyFullPath = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(Path.GetFullPath(asseblyFullPath));
            List<TestLink> realTestLinks = ATACore.TestExecution.TestListGenerator.GenerateTestLinks(currentDllMethods, asseblyFullPath);

            int expectedLinksCount = currentDllMethods.Length;
            Assert.AreEqual<int>(expectedLinksCount, realTestLinks.Count);
        }

        [TestMethod]
        public void TestGenerateTestLinksCorrectValues()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string asseblyFullPath = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(Path.GetFullPath(asseblyFullPath));
            List<TestLink> realTestLinks = ATACore.TestExecution.TestListGenerator.GenerateTestLinks(currentDllMethods, asseblyFullPath);

            Assert.AreEqual<string>("TestProductsAndPrices.ProductTest.TestPriceChange", realTestLinks[0].TestFullName);
            Assert.AreEqual<string>("9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5", realTestLinks[0].TestId);
            Assert.AreEqual<string>("TestPriceChange", realTestLinks[0].TestShortName);
            Assert.AreEqual<string>("TestProductsAndPrices.dll", realTestLinks[0].TestStorage.Name);
        }

        [TestMethod]
        public void TestGenerateTestLinksMultipleAssembliesCorrectCount()
        {
            //string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            //string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            //string asseblyFullPath1 = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            //string asseblyFullPath2 = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices1.dll");
            //List<string> asseblyList = new List<string>()
            //{
            //    Path.GetFullPath(asseblyFullPath1),
            //    Path.GetFullPath(asseblyFullPath2)
            //};
            //List<TestLink> realTestLinks = ATACore.TestExecution.TestListGenerator.GetProjectTestLinksMultipleAssemblies(asseblyList);

            //int expectedLinksCouny = 14;
            //Assert.AreEqual<int>(expectedLinksCouny, realTestLinks.Count);
        }

        [TestMethod]
        public void TestGenerateTestLinksMultipleAssembliesCorrectValues()
        {
            //string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            //string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            //string asseblyFullPath1 = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            //string asseblyFullPath2 = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices1.dll");
            //List<string> asseblyList = new List<string>()
            //{
            //    Path.GetFullPath(asseblyFullPath1),
            //    Path.GetFullPath(asseblyFullPath2)
            //};
            //List<TestLink> realTestLinks = ATACore.TestExecution.TestListGenerator.GetProjectTestLinksMultipleAssemblies(asseblyList);

            //Assert.AreEqual<string>("TestProductsAndPrices.ProductTest.TestPriceChange", realTestLinks[0].TestFullName);
            //Assert.AreEqual<string>("9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5", realTestLinks[0].TestId);
            //Assert.AreEqual<string>("TestPriceChange", realTestLinks[0].TestShortName);
            //Assert.AreEqual<string>("TestProductsAndPrices.dll", realTestLinks[0].TestStorage.Name);
            //Assert.AreEqual<string>("TestProductsAndPrices.ProductTest.TestPriceChange", realTestLinks[7].TestFullName);
            //Assert.AreEqual<string>("9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5", realTestLinks[7].TestId);
            //Assert.AreEqual<string>("TestPriceChange", realTestLinks[7].TestShortName);
            //Assert.AreEqual<string>("TestProductsAndPrices1.dll", realTestLinks[7].TestStorage.Name);
        }

        [TestMethod]
        public void TestGenerateTestMethodId()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string asseblyFullPath = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(Path.GetFullPath(asseblyFullPath));

            string realTestID = ATACore.TestExecution.TestListGenerator.GenerateTestMethodId(currentDllMethods[0], asseblyFullPath);

            Assert.AreEqual<string>("9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5", realTestID);          
        }

        [TestMethod]
        public void TestGenerateTestMethodIds()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string asseblyFullPath = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(Path.GetFullPath(asseblyFullPath));

            List<string> realTestIDs = ATACore.TestExecution.TestListGenerator.GenerateTestMethodIds(currentDllMethods, asseblyFullPath);

            Assert.AreEqual<string>("9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5", realTestIDs[0]);
            Assert.AreEqual<string>("61d07261-50c7-d2f2-273b-d1f4e562dd46", realTestIDs[6]);
        }

        [TestMethod]
        public void TestRemoveTestLinksNotSpecifiedIdsCorrectCount()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string asseblyFullPath = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(Path.GetFullPath(asseblyFullPath));
            List<TestLink> realTestLinks = ATACore.TestExecution.TestListGenerator.GenerateTestLinks(currentDllMethods, asseblyFullPath);

            List<string> testIdsToBeRemoved = new List<string>()
            {
                "9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5",
                "61d07261-50c7-d2f2-273b-d1f4e562dd46"
            };

            List<TestLink> filteredList = ATACore.TestExecution.TestListGenerator.RemoveTestLinksNotSpecifiedIds(testIdsToBeRemoved, realTestLinks);
            Assert.AreEqual<int>(2, filteredList.Count);
        }

        [TestMethod]
        public void TestRemoveTestLinksNotSpecifiedIdsCorrectValues()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string asseblyFullPath = String.Concat(mainFolderPath, "AutomationTestAssistant\\TestAutomationTestAssistantCore\\TestProductsAndPrices.dll");
            MethodInfo[] currentDllMethods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(Path.GetFullPath(asseblyFullPath));
            List<TestLink> realTestLinks = ATACore.TestExecution.TestListGenerator.GenerateTestLinks(currentDllMethods, asseblyFullPath);

            List<string> testIdsToBeRemoved = new List<string>()
            {
                "9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5",
                "61d07261-50c7-d2f2-273b-d1f4e562dd46"
            };

            List<TestLink> filteredList = ATACore.TestExecution.TestListGenerator.RemoveTestLinksNotSpecifiedIds(testIdsToBeRemoved, realTestLinks);
            Assert.AreEqual<string>("9e1d2257-dd53-c44e-9a50-8fba4d2d2ea5", filteredList[0].TestId);
            Assert.AreEqual<string>("61d07261-50c7-d2f2-273b-d1f4e562dd46", filteredList[1].TestId);
        }

        private static System.Xml.XmlDocument GenerateTestListXmlDocument()
        {
            List<TestLink> testLinks = new List<TestLink>()
            {
                new TestLink("TestPrintAllEgnsFromFileNormalCase", "TestEGNExtractor.EGNExtractorTest.TestPrintAllEgnsFromFileNormalCase", UnitTestIdGenerator.GuidFromString("TestEGNExtractor.EGNExtractorTest.TestPrintAllEgnsFromFileNormalCase").ToString(),new FileInfo(@"D:\AutomationTestHelper\testegnextractor\bin\release\testegnextractor.dll")),
                new TestLink("TestPriceIncreasedEventArgsnewValueWhenPriceDecrease", "TestProductsAndPrices.PriceIncreasedEventArgsTest.TestPriceIncreasedEventArgsnewValueWhenPriceDecrease", UnitTestIdGenerator.GuidFromString("TestProductsAndPrices.PriceIncreasedEventArgsTest.TestPriceIncreasedEventArgsnewValueWhenPriceDecrease").ToString(), new FileInfo(@"D:\AutomationTestHelper\testproductsandprices\bin\release\testproductsandprices.dll"))
            };
            string testListPath = ATACore.TestExecution.TestListGenerator.GenerateListOfSpecifiedTests(testLinks, "TestListTemplate");
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(testListPath);
            return doc;
        }      
    }
}
