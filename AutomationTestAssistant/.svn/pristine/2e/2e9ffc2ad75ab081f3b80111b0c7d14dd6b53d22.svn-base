using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsDelete : BaseMessageArgs
    {
        public string LocalPath { get; set; }

        public MessageArgsDelete(string localPath, IpAddressSettings ipAddressSettings)
        {
            Command = Command.DEL;
            IpAddressSettings = ipAddressSettings;
            LocalPath = localPath;
        }

        public MessageArgsDelete()
        {
        }
    }
}
