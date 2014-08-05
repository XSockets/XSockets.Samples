## XSockets.Samples - Putty

One of the great features with XSockets is that you can communicate cross-protocol.
This is a simple demo of that feature.

Just add the TextProtocol.cs to your XSockets server and you will then be able to communicate to other clients from Putty

This simple demo protocol is very stupid, it expects you to send data in the form "controller:topic:data"
So sending "chat:message:hello from putty" would target the "Chat" controller, the method "Message" and the data would be "hello from putty"


