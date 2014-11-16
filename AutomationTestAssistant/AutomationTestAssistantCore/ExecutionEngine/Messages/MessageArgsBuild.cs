using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsBuild : BaseMessageArgs
    {
        public MessageArgsBuild(string localPath, string name, IpAddressSettings ipAddressSettings)
        {
            ProjectPath = GetCurrentProjectFullPath(localPath, name);
            Command = Command.BUILD;
            IpAddressSettings = ipAddressSettings;
        }

        public MessageArgsBuild()
        {
        }

        public string GetCurrentProjectFullPath(string localPath, string name)
        {
            string currentProjectFullPath = String.Concat(Path.Combine(localPath, name), ".csproj");
            return currentProjectFullPath;
        }
    }
}
