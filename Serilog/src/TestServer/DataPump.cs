using System;
using System.Timers;
using XSockets.Core.Common.Utility.Logging;
using XSockets.Core.XSocket;
using XSockets.Plugin.Framework;
using XSockets.Plugin.Framework.Attributes;
using LogEventLevel = Serilog.Events.LogEventLevel;

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
            switch (level)
            {
                    case LogEventLevel.Verbose:
                        Composable.GetExport<IXLogger>().Verbose("This is a Serilog.Sinks.XSockets test with level {0}", level);
                        break;
                    case LogEventLevel.Debug:
                        Composable.GetExport<IXLogger>().Debug("This is a Serilog.Sinks.XSockets test with level {0}", level);
                    break;
                    case LogEventLevel.Information:
                        Composable.GetExport<IXLogger>().Information("This is a Serilog.Sinks.XSockets test with level {0}", level);
                    break;
                    case LogEventLevel.Warning:
                        Composable.GetExport<IXLogger>().Warning("This is a Serilog.Sinks.XSockets test with level {0}", level);
                    break;
                    case LogEventLevel.Error:
                        Composable.GetExport<IXLogger>().Error("This is a Serilog.Sinks.XSockets test with level {0}", level);
                    break;
                    case LogEventLevel.Fatal:
                        Composable.GetExport<IXLogger>().Fatal("This is a Serilog.Sinks.XSockets test with level {0}", level);
                    break;
            }
            
        }
    }
}
