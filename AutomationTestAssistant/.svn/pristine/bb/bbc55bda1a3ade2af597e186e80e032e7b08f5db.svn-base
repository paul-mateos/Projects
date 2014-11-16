using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutomationTestAssistantCore;
using System.IO;
using System.Xml;
using ATADataModel;

namespace TestApiConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string executionResultRunId = ATACore.TestExecution.TestListParser.GetExecutionResultRunFromResultFile(@"D:\results\06-02-2013-02-48-54.trx", 13);
            ATACore.TestExecution.TestListParser.GetResultRunsFromResultFile(@"D:\results\06-02-2013-02-48-54.trx", executionResultRunId);
            Console.WriteLine(executionResultRunId);
        }
    }  
}

