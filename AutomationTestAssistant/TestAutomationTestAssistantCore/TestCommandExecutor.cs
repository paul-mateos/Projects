using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using AutomationTestAssistantCore;
using System.IO;

namespace TestAutomationTestAssistantCore
{
    [TestClass]
    public class TestCommandExecutor
    {
        //[TestMethod]
        //public void TestExtractCommandArgsCorrectArgsCount()
        //{
        //    string[] args = ATACore.CommandExecutor.ExtractCommandArgs("first second third");

        //    Assert.AreEqual<int>(3, args.Length);
        //}

        //[TestMethod]
        //public void TestExtractCommandArgsCorrectArgsValues()
        //{
        //    string[] args = ATACore.CommandExecutor.ExtractCommandArgs("first second third");

        //    Assert.AreEqual<string>("first", args[0]);
        //    Assert.AreEqual<string>("second", args[1]);
        //    Assert.AreEqual<string>("third", args[2]);
        //}

        //[TestMethod]
        //public void TestGetAgentCommandFromMessageCorrectValue()
        //{
        //    Command agentCommand = ATACore.CommandExecutor.GetAgentCommandFromMessage("#MST#second#third");

        //    Assert.AreEqual<Command>(Command.MST, agentCommand);
        //}

        //[TestMethod]
        //public void TestGetCommandToBeExecutedFromMessageCorrectValue()
        //{
        //    string agentCommand = ATACore.CommandExecutor.GetCommandToBeExecutedFromMessage("#first#second#third");

        //    Assert.AreEqual<string>("second", agentCommand);
        //}

        //[TestMethod]
        //public void TestGetCommandToBeExecutedArgsFromMessageCorrectValue()
        //{
        //    string agentCommand = ATACore.CommandExecutor.GetCommandToBeExecutedArgsFromMessage("#first#second#third");

        //    Assert.AreEqual<string>("third", agentCommand);
        //}
    }
}
