﻿using System;

namespace XSockets.WebRTC.Models
{
    public class PeerConnection : IPeerConnection
    {
        public Guid Context { get; set; }
        public Guid PeerId { get; set; }
    }
}