using System;
using Microsoft.Owin.Hosting;
using Owin;
using Serilog;
using Serilog.Events;
using XSockets.Owin.Host;
using XSockets.Plugin.Framework.Attributes;
using XSockets.Plugin.Framework.Helpers;
using XSockets.Plugin.Framework.Logger;

namespace StockServer
{
    /// <summary>
    /// A custom logger to log verbose... Information is default level
    /// </summary>
    [Export(typeof(IDefaultLogger))]
    public class MyLogger : IDefaultLogger
    {
        public ILogger Logger
        {
            get
            {
                return new LoggerConfiguration()
                    .WriteTo.ColoredConsole().MinimumLevel.Verbose()                    
                    .CreateLogger();
            }
        }
    }

    /// <summary>
    /// Owin startup, use static files and also XSockets.
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            app.UseStaticFiles("/Sample/Web");
            
            app.UseXSockets(true);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                LogHelper.Log(LogEventLevel.Information, "All files under Sample/Web should have the property 'Copy to output directory' set to 'Copy always'");
                Console.WriteLine("Navigate to: http://localhost:12345/Sample/Web/Stockticker.html");
                Console.ReadLine();
            }
        }
    }
}
