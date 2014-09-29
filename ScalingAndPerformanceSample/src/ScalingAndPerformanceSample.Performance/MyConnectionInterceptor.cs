using XSockets.Core.Common.Interceptor;
using XSockets.Core.Common.Protocol;
using XSockets.Core.Common.Utility.Logging;
using XSockets.Plugin.Framework;

namespace ScalingAndPerformanceSample.Performance
{
    /// <summary>
    /// A connection interceptor so that we can see that 
    /// clients connect to several servers behind the loadbalancer
    /// </summary>
    public class MyConnectionInterceptor : IConnectionInterceptor
    {

        public void Connected(IXSocketProtocol protocol)
        {
            //Composable.GetExport<IXLogger>().Information("New connection from {c}",protocol.Socket.RemoteIpAddress);
        }

        public void Disconnected(IXSocketProtocol protocol)
        {
            //Composable.GetExport<IXLogger>().Information("Client disconnected");
        }

        public void HandshakeCompleted(IXSocketProtocol protocol)
        {

        }

        public void HandshakeInvalid(string rawHandshake)
        {

        }
    }
}
