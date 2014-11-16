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
    public class TestProjectBuilder
    {
        [TestMethod]
        public void TestProjectBuildMethod()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string projectFullPath = String.Concat(currentExecutablePath, "\\..\\..\\..\\..\\TestTime\\TestTime.csproj");
            bool isProjectBuild = ATACore.Project.ProjectBuilder.BuildProject(projectFullPath);
            Assert.AreEqual<bool>(true, isProjectBuild);
            string buildDllPath = String.Concat(currentExecutablePath, "\\..\\..\\..\\..\\TestTime\\bin\\Release\\TestTime.dll");
            bool isFileExisting = File.Exists(Path.GetFullPath(buildDllPath));
            Assert.AreEqual<bool>(true, isFileExisting);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
        "Trying to build nonexisting project didn't throw an exception!")]
        public void TestProjectBuildMethodNonExistingProject()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string projectFullPath = String.Concat(currentExecutablePath, "\\..\\..\\..\\..\\TestTime\\TestTime1.csproj");
            bool isProjectBuild = ATACore.Project.ProjectBuilder.BuildProject(projectFullPath);
            Assert.AreEqual<bool>(false, isProjectBuild);        
        }
      
    }
}
