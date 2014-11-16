using System;
using System.Net.Sockets;
using System.Text;
using System.Net;
using AutomationTestAssistantCore;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipServer = IPAddress.Parse("192.168.1.120");
            //IPAddress ipServer = IPAddress.Parse("192.168.56.102");
            TcpListener serverSocket = new TcpListener(ipServer, 8888);
            int requestCount = 0;
            TcpClient clientSocket = default(TcpClient);   
                serverSocket.Start();
                Console.WriteLine(" >> Server Started");
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> Accept connection from client");
                requestCount = 0;

                string message = ATACore.TcpWrapperProcessor.TcpClientWrapper.ReadClientMessage(clientSocket);

                clientSocket.Close();
                serverSocket.Stop();
                Console.WriteLine(" >> exit");
                Console.ReadLine();
            }
        }
    }