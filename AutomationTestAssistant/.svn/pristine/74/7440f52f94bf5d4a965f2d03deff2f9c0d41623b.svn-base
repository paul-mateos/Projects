using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsWorkspaceCreation : BaseMessageArgs
    {
        public string TfsServerUrl { get; set; }

        public string WorkspaceName { get; set; }

        public string TfsPath { get; set; }

        public string LocalPath { get; set; }

        public MessageArgsWorkspaceCreation(Command command, string projectPath, string tfsServerUrl, IpAddressSettings ipAddressSettings, string workspaceName, string tfsPath, string localPath)
            : base(command, projectPath, ipAddressSettings)
        {
            this.WorkspaceName = workspaceName;
            this.TfsPath = tfsPath;
            this.LocalPath = localPath;
            this.TfsServerUrl = tfsServerUrl;
        }

        public MessageArgsWorkspaceCreation()
        {
        }
    }
}
