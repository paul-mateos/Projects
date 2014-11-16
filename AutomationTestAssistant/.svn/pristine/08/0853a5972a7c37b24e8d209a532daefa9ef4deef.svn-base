using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using AutomationTestAssistantCore;

namespace TestAutomationTestAssistantCore
{
    [TestClass]
    public class TestFilesDeleter
    {
        [TestMethod]
        public void TestDeleteAllFilesAndFolders()
        {
            string currentExecutablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            int mainFolderPathStartIndex = currentExecutablePath.IndexOf("AutomationTestAssistant");
            string mainFolderPath = currentExecutablePath.Substring(0, mainFolderPathStartIndex);
            string newDirPath = String.Concat(mainFolderPath, "TestDelete");
            Directory.CreateDirectory(newDirPath);
            string newFilePath = String.Concat(newDirPath, "\\test.txt");
            FileStream newFile =  File.Create(newFilePath);
            newFile.Close();
            Assert.AreEqual<bool>(true, File.Exists(newFilePath));
            ATACore.Utilities.FilesDeleter.DeleteAllFilesAndFolders(newDirPath);
            bool isNewDirExisting = Directory.Exists(newDirPath);
            Assert.AreEqual<bool>(false, isNewDirExisting);
        }
    }
}
