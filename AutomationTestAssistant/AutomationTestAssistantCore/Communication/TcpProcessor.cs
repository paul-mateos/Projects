using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore
{
    public class TcpWrapperProcessor
    {
        public TcpMsBuildLoggerProcessor TcpMsBuildLoggerProcessor
        {
            get
            {
                return new TcpMsBuildLoggerProcessor();
            }
        }

        public TcpClientWrapper TcpClientWrapper
        {
            get
            {
                return new TcpClientWrapper();
            }
        }

        public TcpListenerWrapper TcpListenerWrapper
        {
            get
            {
                return new TcpListenerWrapper();
            }
        }
    }
}
