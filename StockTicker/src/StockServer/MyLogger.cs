using Serilog;
using XSockets.Logger;

namespace StockServer
{
    /// <summary>
    /// A custom logger to log verbose... Information is default level
    /// </summary>    
    public class MyLogger : XLogger
    {
        public MyLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.ColoredConsole().MinimumLevel.Verbose()                    
                .CreateLogger();
        }
    }
}