using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace generateContentForInstructionSimonov.Broadcast
{
    public class UPDProvider001
    {
        /// <summary>
        /// отправить данные
        /// </summary>
        /// <param name="data"></param>
        public static void SendData(byte[] data)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            IPEndPoint iep = new IPEndPoint(IPAddress.Broadcast, 9050);
            sock.SendTo(data, iep);

        }

        public static void GetData() 
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
            sock.Bind(iep);
            EndPoint ep = (EndPoint)iep;
            Console.WriteLine("Ready to receive...");

            byte[] data = new byte[1024];
            int recv = sock.ReceiveFrom(data, ref ep);
            string stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine("received: {0} ", stringData);

            sock.Close();
        }

    }
}
