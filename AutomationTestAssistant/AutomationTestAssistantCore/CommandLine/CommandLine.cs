using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore
{
    public class CommandLine
    {
        public CommandLineExecutor CommandLineExecutor
        {
            get
            {
                return new CommandLineExecutor();
            }
        }
    }
}
