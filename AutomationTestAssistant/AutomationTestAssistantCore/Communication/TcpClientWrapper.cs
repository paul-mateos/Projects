using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace AutomationTestAssistantCore
{
    public class TcpClientWrapper : BaseLogger
    {
        public  void SendMessageToClient(TcpClient tcpClient, string messageToSend)
        {
            NetworkStream ns = tcpClient.GetStream();
            Byte[] bytesToSend = Encoding.ASCII.GetBytes(messageToSend);
            int totalBytes = bytesToSend.Length;
            int startIndex = 0;
            byte[] intBytes = BitConverter.GetBytes(totalBytes);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;
            ns.Write(result, 0, result.Length);
            do
            {
                int endIndex = (totalBytes - startIndex) > 1000 ? 1000 : totalBytes - startIndex;
                ns.Write(bytesToSend, startIndex, endIndex);
                ns.Flush();
                startIndex += endIndex;
            }
            while (startIndex != totalBytes);
            Log.InfoFormat("Sending >> ", messageToSend);
        }

        public string ReadLargeClientMessage(TcpClient tcpClient)
        {
            string dataFromClient = String.Empty;
            NetworkStream networkStream = tcpClient.GetStream();
            string messageChunk = String.Empty;
            int endIndexOfMsg = -1;
            byte[] bytesTotalBytes = new byte[4];
            networkStream.Read(bytesTotalBytes, 0, bytesTotalBytes.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytesTotalBytes);

            int totalBytes = BitConverter.ToInt32(bytesTotalBytes, 0);
            do
            {
                byte[]  bytesFrom = new byte[1000];
                networkStream.Read(bytesFrom, 0, 1000);
                bytesFrom = NullRemover(bytesFrom, 1000);
                messageChunk = System.Text.Encoding.ASCII.GetString(bytesFrom);
                endIndexOfMsg = messageChunk.IndexOf("$$");
                if (endIndexOfMsg == -1)
                {
                    dataFromClient += messageChunk;
                }
                else
                {
                    string lastPart = messageChunk.Substring(0, endIndexOfMsg);
                    dataFromClient += lastPart;
                }
            }
            while (endIndexOfMsg == -1);

            return dataFromClient;
        }

        public string ReadClientMessage(TcpClient tcpClient)
        {
            string dataFromClient = String.Empty;
            NetworkStream networkStream = tcpClient.GetStream();
            string messageChunk = String.Empty;
            int endIndexOfMsg = -1;
            byte[] bytesTotalBytes = new byte[4];
            networkStream.Read(bytesTotalBytes, 0, bytesTotalBytes.Length);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytesTotalBytes);
            int totalBytes = BitConverter.ToInt32(bytesTotalBytes, 0);
            do
            {
                byte[] bytesFrom = new byte[totalBytes];
                networkStream.Read(bytesFrom, 0, totalBytes);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                int endIndexOf = dataFromClient.IndexOf("$$");
                if (endIndexOf != -1)
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$$"));
                else
                    return null;
            }
            while (endIndexOfMsg != -1);

            return dataFromClient;
        }

        public string ReadSimpleClientMessage(TcpClient tcpClient)
        {
            string dataFromClient = String.Empty;
            NetworkStream networkStream = tcpClient.GetStream();
            string messageChunk = String.Empty;
            int endIndexOfMsg = -1;
            do
            {
                byte[] bytesFrom = new byte[10025];
                networkStream.Read(bytesFrom, 0, tcpClient.ReceiveBufferSize);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                int endIndexOf = dataFromClient.IndexOf("$$");
                if (endIndexOf != -1)
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$$"));
                else
                    return null;
            }
            while (endIndexOfMsg != -1);

            return dataFromClient;
        }

        private byte[] NullRemover(byte[] DataStream, int receiveBufferSize)
        {
            int i;
            byte[] temp = new byte[receiveBufferSize];
            for (i = 0; i < receiveBufferSize; i++)
            {
                if (DataStream[i] == 0x00) break;
                temp[i] = DataStream[i];
            }
            byte[] NullLessDataStream = new byte[i];
            for (i = 0; i < NullLessDataStream.Length; i++)
            {
                NullLessDataStream[i] = temp[i];
            }
            return NullLessDataStream;
        }
    }
}
