using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace AutomationTestAssistantCore
{
    public class TcpListenerWrapper : BaseLogger
    {
        public void CloseTcpMsLogger(TcpListener listener, params TcpClient[] tcpClients)
        {
            Log.Info("Close TCP Listener and it's TcpClients");
            CloseAllTcpClients(tcpClients);        
            listener.Stop();
            GC.Collect();
        }

        private void CloseAllTcpClients(TcpClient[] tcpClients)
        {
            foreach (TcpClient cTcpClient in tcpClients)
            {
                cTcpClient.GetStream().Close();
                cTcpClient.Close();
            }
        } 
    }
}
