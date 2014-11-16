using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build.BuildEngine;
using System.Globalization;

namespace AutomationTestAssistantCore
{
    public class ProjectBuilder
    {
        public static bool BuildProject(string projectPath)
        {
            bool success = false;
            CultureInfo ci = CultureInfo.InvariantCulture;
            Engine engine = new Engine();
            engine.BinPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System)
                + @"\..\Microsoft.NET\Framework\v4.0.30319";
            try
            {
                success = engine.BuildProjectFile(projectPath);
            }
            finally
            {
                engine.UnloadAllProjects();
            }

            return success;
        }
    }
}
