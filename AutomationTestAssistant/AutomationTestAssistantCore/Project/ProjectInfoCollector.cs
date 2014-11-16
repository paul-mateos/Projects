using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.IO;

namespace AutomationTestAssistantCore
{
    public class ProjectInfoCollector
    {        
        public MethodInfo[] GetProjectTestMethods(string assemblyFullPath)
        {
            Assembly assembly = Assembly.LoadFile(assemblyFullPath);
            MethodInfo[] methods = assembly.GetTypes().SelectMany(t => t.GetMethods().Where(y => y.GetCustomAttributes(false).ToArray().Last().ToString().Equals(typeof(Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute).ToString()))).ToArray();
     
            return methods;
        }

        public MethodInfo[] GetProjectTestMethodsMultipleAssemblies(List<string> assembliesPaths)
        {
            List<MethodInfo> methodInfos = new List<MethodInfo>();
            foreach (string assemblyFullPath in assembliesPaths)
            {
                MethodInfo[] methods = GetProjectTestMethods(assemblyFullPath);
                methodInfos.AddRange(methods);
            }

            return methodInfos.ToArray();
        }       

        public string GetAssemblyPathByProjectPath(string tbProjectPath, string projectName)
        {
            FileInfo currentProject = new FileInfo(tbProjectPath);
            string currentProjecReleasetDllPath = GetAssemblyReleasePathByProjectPath(projectName, currentProject.DirectoryName);
            string currentProjecDebugDllPath = String.Concat(currentProject.DirectoryName, "\\", projectName, @"\bin\Debug\", projectName, ".dll");
            if (File.Exists(currentProjecReleasetDllPath))
                return currentProjecReleasetDllPath;
            else if (File.Exists(currentProjecDebugDllPath))
                return currentProjecDebugDllPath;
            else
                return String.Empty;
        }

        public string GetAssemblyReleasePathByProjectPath(string projectName, string dirName)
        {
            string currentProjecReleasetDllPath = String.Concat(dirName, "\\", projectName, @"\bin\Release\", projectName, ".dll");
            return currentProjecReleasetDllPath;
        }

        public string GetAssemblyReleasePathByProjectFFullPath(string projectName, string dirName)
        {
            string currentProjecReleasetDllPath = String.Concat(dirName, @"\bin\Release\", projectName, ".dll");
            return currentProjecReleasetDllPath;
        }
        public List<string> GetAssemblyPathsByProjectPaths(List<string> tbProjectPaths)
        {
            List<string> assembliesPaths = new List<string>();
            foreach (var currentProjPath in tbProjectPaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(currentProjPath);
                assembliesPaths.Add(GetAssemblyPathByProjectPath(currentProjPath, fileName));
            }

            return assembliesPaths;
        }

        public List<string> GetRelatedProjects(string projectPath)
        {
            List<string> relatedProjectPaths= new List<string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(projectPath);
            XmlNodeList projectReferences= doc.GetElementsByTagName("ProjectReference");
            foreach (XmlNode currentNode in projectReferences)
            {
                relatedProjectPaths.Add(currentNode.Attributes.Item(0).Value);
            }
            return relatedProjectPaths;
        }

        public List<string> GetTestProjectsPaths(string mainFolder, List<string> testProjectPaths = null)
        {
            if(testProjectPaths == null)
            {
                testProjectPaths = new List<string>();
            }
            DirectoryInfo mainDir = new DirectoryInfo(mainFolder);
            SearchFilesForTestProjects(testProjectPaths, mainDir);
            foreach (DirectoryInfo cr in mainDir.GetDirectories())
            {
                SearchFilesForTestProjects(testProjectPaths, cr);
            }
            return testProjectPaths;
        }

        private void SearchFilesForTestProjects(List<string> testProjectPaths, DirectoryInfo cr)
        {
            foreach (FileInfo cf in cr.GetFiles())
            {
                if (cf.Extension.Equals("csproj") && IsTestProject(cf.FullName))
                {
                    testProjectPaths.Add(cf.FullName);
                }
            }
        }

        public string MapWorkingDirTfsPath(string workingDir, string tfsPath)
        {
            tfsPath = tfsPath.Replace("$/", "").Replace("/", "\\");
            string mapLocalPath = Path.Combine(workingDir, tfsPath);

            return mapLocalPath;
        }

        public string GetMsTestProjectPath(string workingDir)
        {
            string mapLocalPath = Path.Combine(workingDir, "MsTest.proj");

            return mapLocalPath;
        }

        public string GetTfsProjectPath(string workingDir)
        {
            string mapLocalPath = Path.Combine(workingDir, "TfsOperations.proj");

            return mapLocalPath;
        }

        public bool IsTestProject(string cf)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(cf);
            XmlNodeList projectReferences = doc.GetElementsByTagName("ProjectTypeGuids");
            bool result = projectReferences.Item(0).Equals("{{3AC096D0-A1C2-E12C-1390-A8335801FDAB}};{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}");

            return result;
        }
    }
}
