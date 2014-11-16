using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsParseResult : BaseMessageArgs
    {
        public string ResultsFilePath { get; set; }
        public string UserName { get; set; }

        public MessageArgsParseResult(string resultsFilePath, string userName, IpAddressSettings ipAddressSettings)
        {
            Command = Command.PARSE;
            IpAddressSettings = ipAddressSettings;
            ResultsFilePath = resultsFilePath;
            UserName = userName;
        }

        public MessageArgsParseResult()
        {
        }
    }
}