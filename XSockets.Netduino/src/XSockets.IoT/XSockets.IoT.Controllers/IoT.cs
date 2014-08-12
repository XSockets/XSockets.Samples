using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace XSockets.IoT.Controllers
{
    /// <summary>
    /// A Simple Xsockets controller
    /// </summary>
    public class IoT : XSocketController
    {
        /// <summary>
        /// Each client has its own state (Netduino or Browser)
        /// </summary>        
        public ClientType ClientType { get; set; }

        /// <summary>
        /// Browser will call this and turn light on/off on the netduino
        /// Information will be sent to Netduinos only
        /// </summary>
        /// <param name="toggle"></param>
        public void Light(Toggle toggle)
        {            
            this.InvokeTo(p => p.ClientType == ClientType.Netduino, toggle,"light");
        }

        /// <summary>
        /// Netduino will call this when the onboard button is hit
        /// Information will be sent to Browsers only
        /// </summary>
        public void ChatMessage(ChatMessage message)
        {
            this.InvokeTo(p => p.ClientType == ClientType.Browser || p.ClientType == ClientType.Native, message, "chatmessage");
        }
    }
}