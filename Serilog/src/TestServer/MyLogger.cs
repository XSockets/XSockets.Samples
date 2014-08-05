using Serilog;
using Serilog.Sinks.XSockets;
using XSockets.Plugin.Framework.Logger;

namespace TestServer
{
    /// <summary>
    /// Write to XSockets and the Console
    /// </summary>
    public class MyLogger : IDefaultLogger
    {
        public ILogger Logger
        {
            get
            {
                return new LoggerConfiguration()
                    .WriteTo.ColoredConsole()
                    .WriteTo.XSockets().MinimumLevel.Verbose().CreateLogger();
            }
        }
    }
}
