using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class BaseMessageArgs : IMessageArgs
    {
        public Command Command { get; set; }

        public string ProjectPath { get; set; }

        public IpAddressSettings IpAddressSettings { get; set; }

        public string WorkingDir { get; set; }

        public BaseMessageArgs(Command command, string projectPath, IpAddressSettings ipAddressSettings)
        {
            this.Command = command;
            this.ProjectPath = projectPath;
            this.IpAddressSettings = ipAddressSettings;
        }

        public BaseMessageArgs(Command command, string projectPath, IpAddressSettings ipAddressSettings, string workingDir)
            : this(command, projectPath, ipAddressSettings)
        {
            this.WorkingDir = workingDir;
        }

        public BaseMessageArgs()
        {
        }
    }
}
