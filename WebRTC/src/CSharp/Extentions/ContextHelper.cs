using System;
using System.Collections.Generic;
using System.Linq;
using XSockets.Core.Common.Socket;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.WebRTC.Constants;
using XSockets.WebRTC.Models;

namespace XSockets.WebRTC.Extentions
{
    /// <summary>
    /// Extension for finding and signaling clients
    /// </summary>
    public static class ContextHelper
    {
        /// <summary>
        /// Send a ContextChanged event to the clients on the context
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        internal static void NotifyContextChange<T>(this T obj, Guid context) where T : class, IBroker, IXSocketController
        {
            obj.NotifyContextChange(context, null);
        }

        /// <summary>
        /// Send a ContextChanged event to the clients on the context and then fires the callback action
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <param name="callback"></param>
        internal static void NotifyContextChange<T>(this T obj, Guid context, Action callback) where T : class, IBroker, IXSocketController
        {
            // Notify a context change                        
            obj.InvokeTo<T>(c => c.Peer.Context == context, obj.Find(q => q.Peer.Context == context).Select(p => p.Peer), Events.Context.Changed);
            if(callback != null)
                callback();
        }

        /// <summary>
        /// Sends a Contect Connect event to all clients connected to this Peer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        internal static void ConnectToContext<T>(this T obj) where T : class,  IBroker, IXSocketController //XSocketController
        {            
            // Pass the client a list of Peers to Connect
            obj.Invoke(obj.Connections(obj.Peer)
                       .Where(q => !q.Connections.Contains(obj.Peer)).
                        Select(p => p.Peer).AsMessage(Events.Context.Connect));
        }

        /// <summary>
        /// Find all clients connected to the context except for the "calling" client
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="peerConnection"></param>
        /// <returns></returns>
        internal static IEnumerable<T> Connections<T>(this T obj, IPeerConnection peerConnection)
            where T : class, IBroker, IXSocketController
        {            
            return obj.Find(f => f.Peer.Context == peerConnection.Context).Select(p => p).Except(new List<T>{obj});
        }
    }
}