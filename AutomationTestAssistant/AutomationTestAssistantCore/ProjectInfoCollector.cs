using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTestAssistantCore
{
    public class ProjectInfoCollector
    {
        string dllPath = @"D:\PC Important\Anton Lectures\Unit Tests Examples\TestTime\obj\Debug\TestTime.dll";
        public static MethodInfo[] GetProjectTestMethods(string assemblyFullPath)
        {
            Assembly assembly = Assembly.LoadFile(assemblyFullPath);
            MethodInfo[] methods = assembly.GetTypes().SelectMany(t => t.GetMethods().Where(y => y.GetCustomAttributes(false).ToArray().First().ToString().Equals(typeof(Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute).ToString()))).ToArray();
            //.Where(x => x.ToString().Equals(typeof(Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute).ToString()))
            //foreach (MethodInfo item in methods)
            //{ 
            //    if (item.GetCustomAttributes(false).ToArray().First().ToString().Equals(typeof(Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute).ToString()))
            //    {
            //        Console.WriteLine(item.Name);
            //    }
            //}
            return methods;
        }
    }
}
