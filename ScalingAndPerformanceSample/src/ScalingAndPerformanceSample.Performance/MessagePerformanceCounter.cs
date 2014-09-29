using System.Diagnostics;
using XSockets.Core.Common.Interceptor;
using XSockets.Core.Common.Protocol;
using XSockets.Core.Common.Socket.Event.Interface;

namespace ScalingAndPerformanceSample.Performance
{
    /// <summary>
    /// Remeber to install XSockets.PerformanceCounters from Chocolatey.org
    /// cinst XSockets.PerformanceCounters    
    /// </summary>
    public class MessagePerformanceCounter : IMessageInterceptor
    {
        private static readonly PerformanceCounter InPerSecCounter;
        private static readonly PerformanceCounter OutPerSecCounter;

        static MessagePerformanceCounter()
        {
            InPerSecCounter = new PerformanceCounter("XSockets.NET", "IN/SEC", "XSockets.NET", false);
            OutPerSecCounter = new PerformanceCounter("XSockets.NET", "OUT/SEC", "XSockets.NET", false);
        }
        public void OnIncomingMessage(IXSocketProtocol protocol, IMessage message)
        {
            InPerSecCounter.IncrementBy(1);
        }

        public void OnOutgoingMessage(IXSocketProtocol protocol, IMessage message)
        {
            OutPerSecCounter.IncrementBy(1);
        }
    }
}
