using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(generateContentForInstructionSimonov.webServer.Startup001))]

namespace generateContentForInstructionSimonov.webServer
{
    public class Startup001
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host.
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);

            //appBuilder.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("<html><body><video width = \"480 \" height = \"320\" controls = \"controls\" autoplay = \"autoplay\" > < source src = \"http://localhost:9000/api/camera/fromvideo/?videoName=Christmas\" type = \"video /mp4\" > </video></body></html> ");
            //    webServer.VideoStream videoStream = new VideoStream(@"D:\repository\New_repo\generateContentForInstructionSimonov\GenerateInstruct\videoFilesFromTests\720.mp4");

            //});
        }
    }
}
