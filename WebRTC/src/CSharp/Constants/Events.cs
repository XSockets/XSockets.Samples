﻿namespace XSockets.WebRTC.Constants
{
    /// <summary>
    /// Constants for the events used in communication
    /// </summary>
    public static class Events
    {
        public static class Context
        {
            public const string Created = "ContextCreated";
            public const string Destroyed = "ContextDestroyed";
            public const string Changed = "ContextChanged";
            public const string Signal = "ContextSignal";
            public const string Offer = "ContextOffer";
            public const string Deny = "ContextDeny";
            public const string Connect = "ContextConnect";
        }

        public static class Peer
        {
            public const string Lost = "PeerConnectionLost";
            public const string Disconnect = "PeerConnectionDisconnect";
        }

        public static class Stream
        {
            public const string Add = "StreamAdded";
            public const string Remove = "StreamRemoved";
        }
    }
}