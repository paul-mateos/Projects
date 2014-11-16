using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using AutomationTestAssistantCore;

namespace ServerClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("192.168.1.120", 8888);
            ATACore.TcpWrapperProcessor.TcpClientWrapper.SendMessageToClient(tcpClient, "large cool message to send to the agent please test ala bala bnalaldasdasdsadsadas!");
                    
        }
    }
}
