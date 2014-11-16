using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class TestResultRunManager
    {
        public void Save(ATAEntities context, TestResultRun testResultRun)
        {
            context.TestResultRuns.Add(testResultRun);
            context.SaveChanges();
        }

        public List<TestResultRun> GetRunsByExecutionResultRun(ATAEntities context, string executionResultRunId)
        {
            List<TestResultRun> testResultRuns = context.TestResultRuns.Where(t => t.ExecutionResultRunId.Equals(executionResultRunId)).ToList();
            return testResultRuns;
        }   
    }
}