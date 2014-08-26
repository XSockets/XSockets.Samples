using Serilog;
using Serilog.Sinks.XSockets;
using XSockets.Logger;

namespace TestServer
{
    /// <summary>
    /// Write to XSockets and the Console
    /// </summary>
    public class MyLogger : XLogger
    {
        public MyLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole()
                .WriteTo.XSockets().MinimumLevel.Verbose().CreateLogger();
        }
    }
}
