using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace AutomationTestAssistantCore
{
    public class TestListGenerator
    {
        /// <summary>
        /// Generates the list of specified tests.
        /// </summary>
        /// <param name="testLinks">The test links.</param>
        /// <returns></returns>
        public string GenerateListOfSpecifiedTests(List<TestLink> testLinks, string listName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            string result = String.Empty;
            using (MemoryStream output = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(output, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("TestLists", "http://microsoft.com/schemas/VisualStudio/TeamTest/2010");

                    writer.WriteStartElement("TestList");
                    writer.WriteAttributeString("name", listName);
                    writer.WriteAttributeString("id", Guid.NewGuid().ToString());
                    writer.WriteAttributeString("parentListId", "8c43106b-9dc1-4907-a29f-aa66a61bf5b6");
                    writer.WriteStartElement("TestLinks");
                    foreach (TestLink currentTestLink in testLinks)
                    {
                        writer.WriteStartElement("TestLink");
                        writer.WriteAttributeString("id", UnitTestIdGenerator.GuidFromString(currentTestLink.TestFullName).ToString());
                        writer.WriteAttributeString("name", currentTestLink.TestShortName);
                        writer.WriteAttributeString("storage", currentTestLink.TestStorage.FullName);
                        writer.WriteAttributeString("type", "Microsoft.VisualStudio.TestTools.TestTypes.Unit.UnitTestElement, Microsoft.VisualStudio.QualityTools.Tips.UnitTest.ObjectModel, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.WriteStartElement("TestList");
                    writer.WriteAttributeString("name", "Lists of Tests");
                    writer.WriteAttributeString("id", "8c43106b-9dc1-4907-a29f-aa66a61bf5b6");

                    writer.WriteStartElement("RunConfiguration");
                    writer.WriteAttributeString("id", "8780a2e3-78a6-4742-922c-4ad691741c2c");
                    writer.WriteAttributeString("name", "Local");
                    writer.WriteAttributeString("storage", "local.testsettings");
                    writer.WriteAttributeString("type", "Microsoft.VisualStudio.TestTools.Common.TestRunConfiguration, Microsoft.VisualStudio.QualityTools.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Flush();
                }
                result = Encoding.UTF8.GetString(output.ToArray());
            }

            return result;
        }

        /// <summary>
        /// Generates the test links.
        /// </summary>
        /// <param name="methodInfos">The method infos.</param>
        /// <param name="assemblyFullPath">The assembly full path.</param>
        /// <returns></returns>
        public List<TestLink> GenerateTestLinks(MethodInfo[] methodInfos, string assemblyFullPath)
        {
            List<TestLink> testLinks = new List<TestLink>();
            foreach (var currentMethodInfo in methodInfos)
            {
                string currentNameSpace = currentMethodInfo.DeclaringType.FullName;
                string currentTestMethodShortName = currentMethodInfo.Name;
                string currentTestMethodFullName = String.Concat(currentNameSpace, ".", currentTestMethodShortName);
                string testId = UnitTestIdGenerator.GuidFromString(currentTestMethodFullName).ToString();
                TestLink testLink = new TestLink(currentMethodInfo.Name, currentTestMethodFullName, testId, new FileInfo(assemblyFullPath));
                testLinks.Add(testLink);
            }

            return testLinks;
        }

        /// <summary>
        /// Gets the project test links multiple assemblies.
        /// </summary>
        /// <param name="assembliesPaths">The assemblies paths.</param>
        /// <returns></returns>
        public List<TestLink> GetProjectTestLinksMultipleAssemblies(List<string> assembliesPaths, List<string> agentAssembliesPaths)
        {
            List<TestLink> testLinks = new List<TestLink>();
            int i = 0;
            foreach (string assemblyFullPath in assembliesPaths)
            {
                MethodInfo[] methods = ATACore.Project.ProjectInfoCollector.GetProjectTestMethods(assemblyFullPath);
                List<TestLink> currentTestLinks = GenerateTestLinks(methods, agentAssembliesPaths[i++]);

                testLinks.AddRange(currentTestLinks);
            }
            return testLinks;
        }

        /// <summary>
        /// Generates the test method id.
        /// </summary>
        /// <param name="methodInfo">The method info.</param>
        /// <param name="assemblyFullPath">The assembly full path.</param>
        /// <returns></returns>
        public string GenerateTestMethodId(MethodInfo methodInfo, string assemblyFullPath)
        {
            string currentNameSpace = methodInfo.DeclaringType.FullName;
            string currentTestMethodShortName = methodInfo.Name;
            string currentTestMethodFullName = String.Concat(currentNameSpace, ".", currentTestMethodShortName);
            string testId = UnitTestIdGenerator.GuidFromString(currentTestMethodFullName).ToString();

            return testId;
        }

        /// <summary>
        /// Removes the test links not specified ids.
        /// </summary>
        /// <param name="testIds">The test ids.</param>
        /// <param name="testLinksToFilter">The test links to filter.</param>
        /// <returns></returns>
        public List<TestLink> RemoveTestLinksNotSpecifiedIds(List<string> testIds, List<TestLink> testLinksToFilter)
        {
            List<TestLink> testLinks = new List<TestLink>();
            foreach (var id in testIds)
            {
                foreach (var currentTestLink in testLinksToFilter)
                {
                    if (currentTestLink.TestId.Equals(id))
                    {
                        testLinks.Add(currentTestLink);
                    }    
                }                        
            }

            return testLinks;
        }

        /// <summary>
        /// Generates the test ids.
        /// </summary>
        /// <param name="methodInfos">The method infos.</param>
        /// <param name="assemblyFullPath">The assembly full path.</param>
        /// <returns></returns>
        public List<string> GenerateTestMethodIds(MethodInfo[] methodInfos, string assemblyFullPath)
        {
            List<string> testIds = new List<string>();
            foreach (var currentMethodInfo in methodInfos)
            {
                string currentTestId = GenerateTestMethodId(currentMethodInfo, assemblyFullPath);
                testIds.Add(currentTestId);
            }

            return testIds;
        }
    }
}
