using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;
using ATADataModel;

namespace AutomationTestAssistantCore
{
    public class TestListParser
    {
        public string GetExecutionResultRunFromResultFile(string resultFilePath, int memberId)
        {
            ExecutionResultRun executionResultRun = new ExecutionResultRun();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(resultFilePath);
            XmlNode timesNode = xmlDoc.GetElementsByTagName("Times")[0];
            executionResultRun.Start = timesNode.Attributes["start"].Value.ToDateTime();
            executionResultRun.Finish = timesNode.Attributes["finish"].Value.ToDateTime();
            XmlNode countersNode = xmlDoc.GetElementsByTagName("Counters")[0];
            executionResultRun.Total = countersNode.Attributes["total"].Value.ToInt();
            executionResultRun.Executed = countersNode.Attributes["executed"].Value.ToInt();
            executionResultRun.Passed = countersNode.Attributes["passed"].Value.ToInt();
            executionResultRun.Failed = countersNode.Attributes["failed"].Value.ToInt();
            executionResultRun.NotExecuted = countersNode.Attributes["notExecuted"].Value.ToInt();
            XmlNode utrNode = xmlDoc.GetElementsByTagName("UnitTestResult")[0];
            executionResultRun.ComputerName = utrNode.Attributes["computerName"].Value;
            executionResultRun.RanBy = memberId;
            executionResultRun.ExecutionResultRunId = Guid.NewGuid().ToString();
            ATACore.Managers.ExecutionResultRunManager.Save(ATACore.Managers.ContextManager.Context, executionResultRun);
            ATACore.Managers.ContextManager.Context.Dispose();

            return executionResultRun.ExecutionResultRunId;
        }

        public List<TestResultRun> GetResultRunsFromResultFile(string resultFilePath, string executionResultRunId)
        {
            List<TestResultRun> testResultRuns = new List<TestResultRun>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(resultFilePath);
            XmlNodeList utrNodeList = xmlDoc.GetElementsByTagName("UnitTestResult");
            foreach (XmlNode currentNode in utrNodeList)
            {
                TestResultRun currentTestResultRun = new TestResultRun();
                string methodId =  currentNode.Attributes["testId"].Value;
                Test currentTest = ATACore.Managers.TestManager.GetTestByMethodId(ATACore.Managers.ContextManager.Context, methodId);
                ATACore.Managers.ContextManager.Context.Dispose();
                currentTestResultRun.Duration = currentNode.Attributes["duration"].Value.ToTimeSpan();
                currentTestResultRun.StartTime = currentNode.Attributes["startTime"].Value.ToDateTime();
                currentTestResultRun.EndTime = currentNode.Attributes["endTime"].Value.ToDateTime();
                string executionStatusStr = currentNode.Attributes["outcome"].Value;
                currentTestResultRun.ExecutionStatuses = (ExecutionStatuses)Enum.Parse(typeof(ExecutionStatuses), executionStatusStr, true);
                currentTestResultRun.ExecutionStatusId = (int)currentTestResultRun.ExecutionStatuses;
                currentTestResultRun.ExecutionResultRunId = executionResultRunId;
                currentTestResultRun.TestId = currentTest.TestId;
                ATACore.Managers.TestResultRunManager.Save(ATACore.Managers.ContextManager.Context, currentTestResultRun);
                ATACore.Managers.ContextManager.Context.Dispose();
            }

            return testResultRuns;
        }
    }
}
