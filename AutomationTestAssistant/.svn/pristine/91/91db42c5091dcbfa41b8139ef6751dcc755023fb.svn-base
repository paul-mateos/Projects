using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace AutomationTestAssistantCore
{
    public class IpAddressSettings
    {
        public string IpString { get; set; }
        public int Port { get; set; }

        public IpAddressSettings(string ipAddress, string port)
        {
            //IPAddress = IPAddress.Parse(ipAddress);
            Port = int.Parse(port);
            IpString = ipAddress;
        }

        public IpAddressSettings()
        {
        }

        public IpAddressSettings(string wholeAddress)
        {
            string[] IpAddressA = wholeAddress.Split(':');
            //IPAddress = IPAddress.Parse(IpAddressA[0]);
            IpString = IpAddressA[0];
            Port = int.Parse(IpAddressA[1]);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", IpString, this.Port);
        }

        public IPAddress GetIPAddress()
        {
            return IPAddress.Parse(IpString);
        }
    }
}
