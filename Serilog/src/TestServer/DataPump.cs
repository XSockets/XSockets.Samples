using System;
using System.Timers;
using Serilog.Events;
using XSockets.Core.XSocket;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;
using XSockets.Plugin.Framework.Helpers;

namespace TestServer
{
    /// <summary>
    /// Will pump messages to the log event 5 sec with random levels    
    /// </summary>
    [XSocketMetadata("DataPump", PluginRange.Internal)]
    public class DataPump : XSocketController
    {
        private Timer t;
        public DataPump()
        {
            t = new Timer(3000);
            t.Elapsed += t_Elapsed;
            t.Start();
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            var level = (LogEventLevel)new Random().Next(0, 5); 
            LogHelper.Log(level,"This is a Serilog.Sinks.XSockets test with level {0}",level);
        }
    }
}
