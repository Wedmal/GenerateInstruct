using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Emgu.CV;
namespace generateContentForInstructionSimonov.Broadcast
{
    public class SocketClient
    {

        static Socket sender;
        static bool CloseSocket = false;
        static IPHostEntry ipHost;
        static IPAddress ipAddr;
        static IPEndPoint ipEndPoint;
        public static int port;
        static SocketClient()
        {
            try
            {
                // Соединяемся с удаленным устройством

                // Устанавливаем удаленную точку для сокета
                ipHost = Dns.GetHostEntry("localhost");
                ipAddr = ipHost.AddressList[0];
                ipEndPoint = new IPEndPoint(ipAddr, port);

                sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // Соединяем сокет с удаленной точкой
                sender.Connect(ipEndPoint);




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
        public static void SendMessageFromSocket(int port, byte[] DataFromSend)
        {


            // Буфер для входящих данных
            byte[] bytes = new byte[1024];








            //Console.Write("Введите сообщение: ");
            //string message = Console.ReadLine();

            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            
            //byte[] msg = Encoding.UTF8.GetBytes(DataFromSend);
           // byte[] msg = Kadr;
            // Отправляем данные через сокет
            int bytesSent = sender.Send(DataFromSend);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);

            Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));


            if (CloseSocket) 
            {
                // Освобождаем сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }


        }
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }

    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        // Номер порта для удаленного устройства. 
        private const int port = 11000;

        // ManualResetEvent выполняет завершение сигнала.
        private static ManualResetEvent connectDone =
            new ManualResetEvent(false);
        private static ManualResetEvent sendDone =
            new ManualResetEvent(false);
        private static ManualResetEvent receiveDone =
            new ManualResetEvent(false);

        // Ответ от удаленного устройства.
        private static String response = String.Empty;

        private static void StartClient()
        {
            // Подключение к удаленному устройству.
            try
            {
                // Установить удаленную конечную точку для сокета.
                // Имя
                // удаленное устройство - "host.contoso.com".
                
                IPHostEntry ipHostInfo = Dns.GetHostEntry("host.contoso.com");
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Создать сокет TCP / IP.
                Socket client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Подключаемся к удаленной конечной точке.
                client.BeginConnect(remoteEP,
                    new AsyncCallback(ConnectCallback), client);
                connectDone.WaitOne();


                // Отправляем тестовые данные на удаленное устройство.
                Send(client, "This is a test<EOF>");
                sendDone.WaitOne();

                // Получить ответ от удаленного устройства.
                Receive(client);
                receiveDone.WaitOne();

                // Записать ответ в консоль.
                Console.WriteLine("Response received : {0}", response);

                // Освободить сокет.
                client.Shutdown(SocketShutdown.Both);
                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Получить сокет из объекта состояния.
                Socket client = (Socket)ar.AsyncState;

                // Завершить соединение.
                client.EndConnect(ar);

                Console.WriteLine("Socket connected to {0}",
                    client.RemoteEndPoint.ToString());

                // Сигнал о том, что соединение установлено.
                connectDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Receive(Socket client)
        {
            try
            {
                // Создать объект состояния.
                StateObject state = new StateObject();
                state.workSocket = client;

                // Начало приема данных с удаленного устройства.
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Получаем объект состояния и клиентский сокет
                // из асинхронного объекта состояния.
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;

                // Чтение данных с удаленного устройства.
                int bytesRead = client.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // Может быть больше данных, поэтому сохраните полученные данные.
                    state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
                    // Получить остальные данные.
                    client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(ReceiveCallback), state);
                }
                else
                {
                    // Все данные получены; положить в ответ.
                    if (state.sb.Length > 1)
                    {
                        response = state.sb.ToString();
                    }
                    // Сигнал о том, что все байты были получены.
                    receiveDone.Set();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void Send(Socket client, String data)
        {
            // Преобразование строковых данных в байтовые данные с использованием кодировки ASCII.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Начать отправку данных на удаленное устройство.
            client.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), client);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Получить сокет из объекта состояния.
                Socket client = (Socket)ar.AsyncState;

                // Завершить отправку данных на удаленное устройство.
                int bytesSent = client.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to server.", bytesSent);

                // Сигнал о том, что все байты были отправлены.
                sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }


    }
}
