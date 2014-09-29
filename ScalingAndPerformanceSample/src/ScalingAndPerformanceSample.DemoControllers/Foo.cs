using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace ScalingAndPerformanceSample.DemoControllers
{
    public class Foo : XSocketController
    {                
        /// <summary>        
        /// Basically broadcast all messages to all clients
        /// Do not do it like this IRL, this is just for demo purpose
        /// 
        /// IRL you should use the InvokeTo extensions and write lambdaexpressions to target clients
        /// </summary>
        /// <param name="message"></param>
        public override void OnMessage(IMessage message)
        {
            this.InvokeToAll(message);
        }
    }
}
