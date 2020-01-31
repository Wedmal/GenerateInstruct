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
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = false;

            worker.DoWork += (_s, _e) =>
            {
                start_server_async();
            };

            worker.RunWorkerCompleted += (_s, _e) =>
            {
                //close window
            };

            worker.RunWorkerAsync();


            void start_server_async()
            {
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
                sock.Bind(iep);
                EndPoint ep = (EndPoint)iep;
                Console.WriteLine("Ready to receive...");
                int convertByteToInt(byte[] b)
                {
                    int value = 0;
                    for (int i = 0; i < b.Length; i++)
                        value = (value << 8) | b[i];
                    return value;
                }

                int ArrayLength = 1024;
                while (true)
                {
                    byte[] data = new byte[16880];
                    int recv = sock.ReceiveFrom(data, ref ep);
                    int tmpInt = 0;
                    try { tmpInt = convertByteToInt(new byte[] { data[0], data[1], data[2], data[3] }); } catch (Exception ex) { tmpInt = 1024; }
                    if (tmpInt > 4)
                    {
                        ArrayLength = tmpInt;
                    }
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    NewContentEvent?.Invoke(data, null);
                    if (stringData.Contains("break"))
                    {
                        sock.Close();
                    }
                }
            }

        }

    }
}
