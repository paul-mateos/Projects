using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public interface IMessageArgs
    {
        Command Command { get; set; }

        string ProjectPath { get; set; }

        IpAddressSettings IpAddressSettings { get; set; }
    }
}
