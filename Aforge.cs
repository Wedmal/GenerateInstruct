using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

using System.Web.SessionState;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Moq;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Hosting;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace generateContentForInstructionSimonov
{
    public partial class Aforge : Form
    {
        private VideoCaptureDevice FinalVideo = null;
        private VideoCaptureDeviceForm captureDevice;
        private Bitmap video;
        private DateTime? isdate;



        public class Startup
        {
            // This code configures Web API. The Startup class is specified as a type
            // parameter in the WebApp.Start method.
            public void Configuration(IAppBuilder appBuilder)
            {

                // Configure Web API for self-host.
                HttpConfiguration config = new HttpConfiguration();
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "20017",
                    //routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );

                appBuilder.UseWebApi(config);
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<html><body><video width = \"480 \" height = \"320\" controls = \"controls\" autoplay = \"autoplay\" > <source src = \"http://localhost:9000/20017\" type = \"video/mp4\"> </video></body></html> ");


                });
            }
        }
        public class CameraController : ApiController
        {
            [HttpGet]
            public HttpResponseMessage FromVideo(string videoName)
            {
                var video = new VideoStream(videoName);
                Func<Stream, HttpContent, TransportContext, Task> func = video.WriteToStream;
                var response = Request.CreateResponse();
                response.Content = new PushStreamContent(func, new MediaTypeHeaderValue("video/mp4"));
                return response;
            }
        }
        internal class VideoStream
        {
            private readonly string videoName;

            public VideoStream(string videoName)
            {
                this.videoName = videoName;
            }

            public async Task WriteToStream(Stream outputStream, HttpContent content, TransportContext context)
            {
                string videoFileName = @"D:\repository\New_repo\generateContentForInstructionSimonov\GenerateInstruct\videoFilesFromTests\720.mp4";
                try
                {
                    var buffer = new byte[65536];

                    using (var video = File.Open(videoFileName, FileMode.Open, FileAccess.Read))
                    {
                        var length = (int)video.Length;
                        var bytesRead = 1;

                        while (length > 0 && bytesRead > 0)
                        {
                            bytesRead = video.Read(buffer, 0, Math.Min(length, buffer.Length));
                            
                            await outputStream.WriteAsync(buffer, 0, bytesRead);
                            length -= bytesRead;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return;
                }
                finally
                {
                    outputStream.Close();
                }
            }
        }
        public Aforge()
        {
            InitializeComponent();
            AForge.Video.DirectShow.FilterInfoCollection videoDevices = new AForge.Video.DirectShow.FilterInfoCollection(FilterCategory.VideoInputDevice);



            captureDevice = new VideoCaptureDeviceForm();

            FinalVideo = new VideoCaptureDevice(videoDevices[0].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();


            string baseAddress = "http://localhost:9000/";

            // Start OWIN host
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("Streaming start...");
            Console.ReadLine();




            // Start OWIN host
            // WebApp.Start<owin_Classes.Startup1>(url: baseAddress);
            // WebApp.Start<owin_Classes.Startup1>("http://*:8511");
            //Console.WriteLine("Streaming start...");
            //Console.ReadLine();


            // Start OWIN host
            //WebApp.Start<Startup>(url: baseAddress);
            //Console.WriteLine("Streaming start...");
            //Console.ReadLine();



            //MyUser myUser = new MyUser();
            //myUser.Id = 1;
            //myUser.Name = "AutomatedUITestUser";

            //var fakeHttpSessionState =
            //                     new FakeHttpSessionState(new SessionStateItemCollection());
            //fakeHttpSessionState.Add("__CurrentUser__", myUser);

            //mockControllerContext = Mock.Of<ControllerContext>(ctx =>
            //ctx.HttpContext.User.Identity.Name == myUser.Name &&
            //ctx.HttpContext.User.Identity.IsAuthenticated == true &&
            //ctx.HttpContext.Session == fakeHttpSessionState &&
            //ctx.HttpContext.Request.AcceptTypes ==
            //               new string[] { "MyFormsAuthentication" } &&
            //ctx.HttpContext.Request.IsAuthenticated == true &&
            //ctx.HttpContext.Request.Url == new Uri("http://127.0.0.1") &&
            //ctx.HttpContext.Response.ContentType == "video"
            //);



        }
        //VideoResult videoResult = new VideoResult();
        class MyUser { public int Id { get; set; } public string Name { get; set; } };
        public void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            pictureBox1.Image= (Bitmap)eventArgs.Frame.Clone();
            // videoResult.ExecuteResult(mockControllerContext);
            using (var ms = new MemoryStream())
            {
                //img.Save(ms, ImageFormat.Jpeg);
                //Сохраняем изображение в массив байт, для последующего формирования mjpeg
                _bufImage = ms.ToArray();
            }
        }




        byte[] _bufImage;

        public void ScreenCapture()
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "multipart/x-mixed-replace; boundary=--myboundary";
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);

            var ae = new ASCIIEncoding();
            while (HttpContext.Current.Response.IsClientConnected)
            {
                //byte[] data = getNextFrame(); //Здесь я получаю текущий кадр с рабочего стола
                try
                {
                    //var boundary = ae.GetBytes("\r\n--myboundary\r\nContent-Type: image/jpeg\r\nContent-Length:" + data.Length + "\r\n\r\n");
                    //HttpContext.Current.Response.OutputStream.Write(boundary, 0, boundary.Length);
                    //HttpContext.Current.Response.OutputStream.Write(data, 0, data.Length);
                    //HttpContext.Current.Response.Flush();
                }
                catch (Exception) { }
            }
            HttpContext.Current.Response.End();
        }

    }
}
