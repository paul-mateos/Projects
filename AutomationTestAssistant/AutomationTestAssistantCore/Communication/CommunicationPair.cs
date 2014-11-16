using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace AutomationTestAssistantCore
{
    public class CommunicationPair
    {
        public TcpClient TcpClient { get; set; }
        public TcpListener TcpListener { get; set; }

        public CommunicationPair(TcpClient tcpClient, TcpListener tcpListener)
        {
            this.TcpClient = tcpClient;
            this.TcpListener = tcpListener;
        }
    }
}
