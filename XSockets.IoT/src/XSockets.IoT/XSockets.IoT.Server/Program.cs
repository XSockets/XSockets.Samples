using System;
using Serilog;
using XSockets.Core.Common.Socket;
using XSockets.Logger;

namespace XSockets.IoT.Server
{
    public class MyLogger : XLogger
    {
        public MyLogger()
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose().WriteTo.ColoredConsole().CreateLogger();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var container = Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            {
                container.Start();
                Console.ReadLine();
            }
        }
    }
}
