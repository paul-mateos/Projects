using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class TestResultRunViewModel
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
        public string TestName { get; set; }
        public string ExecutionStatus { get; set; }

        public TestResultRunViewModel(TestResultRun testResultRun)
        {
            string dateTimeFormat = "hh\\:mm\\:ss\\.ffff";
            StartTime = testResultRun.StartTime.ToString(dateTimeFormat);
            EndTime = testResultRun.EndTime.ToString(dateTimeFormat);
            Duration = testResultRun.Duration.ToString(dateTimeFormat);
            Test currentTest = ATACore.Managers.TestManager.GetTestByTestId(ATACore.Managers.ContextManager.Context, testResultRun.TestId);
            ATACore.Managers.ContextManager.Dispose();
            TestName = currentTest.Name;
            ExecutionStatus = testResultRun.ExecutionStatuses.ToString();
        }
    }
}
