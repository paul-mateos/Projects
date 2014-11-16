using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsMsTest : BaseMessageArgs
    {
        public string TestListContent { get; set; }

        public string ResultsFilePath { get; set; }

        public string TestListPath { get; set; }

        public string ListName { get; set; }

        public MessageArgsMsTest(Command command, string projectPath, IpAddressSettings ipAddressSettings, string workingDir, string testListContent, string testListName, string resultsFilePath)
            : base(command, projectPath, ipAddressSettings, workingDir)
        {
            this.TestListContent = testListContent;
            this.ResultsFilePath = resultsFilePath;
            this.ListName = testListName;
        }

        public MessageArgsMsTest()
        {
        }

        public string CreateTestList()
        {
            TestListPath = String.Empty;
            if (!String.IsNullOrEmpty(TestListContent))
            {
                TestListPath = Path.GetTempFileName();
                StreamWriter sw = new StreamWriter(TestListPath, false, Encoding.UTF8);
                TestListContent = TestListContent.TrimStart('?');
                sw.WriteLine(TestListContent);                
                sw.Close();
                sw = new StreamWriter(@"E:\AutomationTestAssistant\ServerAgent\bin\Release\testList.xml", false, Encoding.UTF8);
                sw.WriteLine(TestListContent);
                sw.Close();
            }
            return TestListPath;
        }
    }
}
