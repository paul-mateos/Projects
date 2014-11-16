using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsTfsGettingLatest : BaseMessageArgs
    {
        public string PathToGet { get; set; }

        public string UserName { get; set; }

        public MessageArgsTfsGettingLatest(Command command, string projectPath, IpAddressSettings ipAddressSettings, string pathToGet, string userName)
            : base(command, projectPath, ipAddressSettings)
        {
            this.PathToGet = pathToGet;
            this.UserName = userName;
        }

        public MessageArgsTfsGettingLatest()
        {
        }
    }
}
