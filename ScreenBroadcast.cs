using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;



namespace generateContentForInstructionSimonov
{
    public partial class ScreenBroadcast : Form
    {
        private Mat _frame;
        private Mat _grayFrame;

        private VideoCapture _capture;
        
        public ScreenBroadcast()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;

            //Берем кадр
            _capture = new VideoCapture();

            _frame = new Mat();
            _grayFrame = new Mat();


            _capture.ImageGrabbed += ProcessFrame;

            try
            {

            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }


            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = false;

            worker.DoWork += (_s, _e) =>
            {

                send_data();
            };

            worker.RunWorkerCompleted += (_s, _e) =>
            {
                //close window
            };

            worker.RunWorkerAsync();
        }


        private void ProcessFrame(object sender, EventArgs e)
        {

        }
        int i = 10;
        private void send_data()
        {
        
            while (true) 
            {

      
                    try
                    {
                    _capture.Retrieve(_frame, 0);
                    Bitmap tmpBmp= new Bitmap(_frame.ToImage<Bgr, Byte>().Bitmap);
                    this.Invoke(new Action(() =>
                    {
                        //pictureBox1.Image = tmpBmp;
                    }));
        
                        //CvInvoke.CvtColor(_frame, _grayFrame, ColorConversion.Bgr2Gray);
                        //var image = _frame.ToImage<Bgr, Byte>().ToJpegData();
                        //pictureBox1.Image = _frame.ToImage<Bgr, Byte>().Bitmap;
                        
          
                        
                      

                        DataFromSend data = new DataFromSend(id: i, bitmap: tmpBmp);

                        BinaryFormatter binFormat = new BinaryFormatter();
                        var stream = new MemoryStream();
                        binFormat.Serialize(stream, data);
                        byte[] m_Bytes = ReadToEnd(stream);


                        int part = 1;//текущая часть файла
                        int partsize = 1024;//размер части файла в байтах
                        int position = 0;//текущая позиция в разделяемом файле для формирования новой части файла
                        
                       // Broadcast.SocketClient socketClient = new Broadcast.SocketClient(port: 4438);
                    
                    //socketClient.SendMessageFromSocket(port: 4438, new byte[] { 255, 255, 0, 1, 0 });

                    for (int i = 0; i < m_Bytes.Length; i += partsize)
                        {
                            byte[] partbytes = new byte[Math.Min(partsize, m_Bytes.Length - i)];
                            for (int j = 0; j < partbytes.Length; j++)
                            {
                                partbytes[j] = m_Bytes[position++];
                            }

                            //socketClient = new Broadcast.SocketClient(port: 4438);
                            //socketClient.SendMessageFromSocket(port: 4438, DataFromSend: m_Bytes);
                        }


                      
                        //socketClient.SendMessageFromSocket(port: 4438, Kadr: "Вызов номер "+i+ " <EOF>");
                        if (i >= 65535) { i = 0; }
                        i++;
                    }
                    catch (Exception ex)
                    {

                    }

           



            }
        }
        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte)nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }
        [Serializable]
        private class DataFromSend 
        {
            public DataFromSend(int id, Bitmap bitmap)
            {
                Id = id;
                this.bitmap = bitmap;
            }

            public int Id { set; get; }
            public Bitmap bitmap { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {



            _capture.Retrieve(_frame, 0);
            while (true) 
            {
                
            }







            _capture.Retrieve(_frame, 0);
            Bitmap tmpBmp = new Bitmap(_frame.ToImage<Bgr, Byte>().Bitmap);


            DataFromSend data = new DataFromSend(id: i, bitmap: tmpBmp);

            BinaryFormatter binFormat = new BinaryFormatter();
            var stream = new MemoryStream();
            binFormat.Serialize(stream, data);
            byte[] m_Bytes = ReadToEnd(stream);


            int part = 1;//текущая часть файла
            int partsize = 16875;//размер части файла в байтах
            int position = 0;//текущая позиция в разделяемом файле для формирования новой части файла
            //(partbytes, "part" + (part++) + ".part");
            byte idUser = 0;
            byte[] serviceInfo=new byte[] {idUser,0,0 }; //3 сервистных байта. 1й - ид пользователя. 2й и 3й - номер пакета. нумерация с нуля.
            byte[] sendData = null;


            int intValue=m_Bytes.Length;
            byte[] intBytes = BitConverter.GetBytes(intValue);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);
            byte[] result = intBytes;

            int leng = convertByteToInt(result);

            int convertByteToInt(byte[] b)
            {
                int value = 0;
                for (int i = 0; i < b.Length; i++)
                    value = (value << 8) | b[i];
                return value;
            }



            //Broadcast.UPDProvider001.SendData(result);

            //Broadcast.UPDProvider001.SendData(m_Bytes);



            for (int i = 0; i < m_Bytes.Length; i += partsize)
            {
                byte[] partbytes = new byte[Math.Min(partsize, m_Bytes.Length - i)];
                for (int j = 0; j < partbytes.Length; j++)
                {
                    partbytes[j] = m_Bytes[position++];
                }

                if (serviceInfo[2] >= 255) 
                {
                    serviceInfo[1]++;
                    serviceInfo[2] = 0;
                }
                serviceInfo[2]++;

                part++;
                sendData = serviceInfo.Concat(partbytes).ToArray();
                Broadcast.UPDProvider001.SendData(sendData);
            }

           
        }
    }
}
