using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomationTestAssistantCore
{
    public class TestLink
    {
        public string TestShortName { get; set; }
        // TestTime.TimeTest.TestEqualsObjectEqualTimes   Namespace.Class.TestMethod
        public string TestFullName { get; set; }
        public string TestId { get; set; }
        public FileInfo TestStorage { get; set; }

        public TestLink(string testShortName, string testFullName, string testId, FileInfo testStorage)
        {
            TestShortName = testShortName;
            TestStorage = testStorage;
            TestFullName = testFullName;
            TestId = testId;
        }      
    }
}
