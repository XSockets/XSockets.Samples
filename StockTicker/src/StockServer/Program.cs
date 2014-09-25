using System;
using Microsoft.Owin.Hosting;
using XSockets.Core.Common.Utility.Logging;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;
using LogEventLevel = Serilog.Events.LogEventLevel;

namespace StockServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:12345"))
            {
                Composable.GetExport<IXLogger>().Information("All files under Sample/Web should have the property 'Copy to output directory' set to 'Copy always'");
                Console.WriteLine("Navigate to: http://localhost:12345/Sample/Web/Stockticker.html");
                Console.ReadLine();
            }
        }
    }
}
