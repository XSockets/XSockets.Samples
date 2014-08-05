using Serilog.Events;
using XSockets.Core.XSocket;
using XSockets.Plugin.Framework.Attributes;

namespace Serilog.Sinks.XSockets.Sinks.XSockets
{
    [XSocketMetadata(PluginAlias = "log")]
    public class LogController : XSocketController
    {
        public LogEventLevel LogEventLevel { get; set; }

        public LogController()
        {
            this.LogEventLevel = LogEventLevel.Information;
        }
    }
}