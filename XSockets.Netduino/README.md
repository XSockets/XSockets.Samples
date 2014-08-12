## XSockets.Samples.Netduino

A simple project that shows how easy it is to connect 

- Netduino
- Browsers
- Console Application

### Pre Req
Built and tested on windows 8.1 and XSockets.NET 4.0 pre-relase

### Project Info
The project contains 5 projects, when testing you should start them in the order they are listed

#### XSockets.IoT.Server
Simple console application that starts a XSockets server.
Has a ref to the "Controllers" project so that the controller is loaded

#### XSockets.IoT.Owin
Self hosted webapp with Owin that runs on localhost:12345
Testpage is http://localhost:12345/Web/index.html

IMPORTANT: See to it that all files under /Web has the property "Copy Always" set

#### XSockets.IoT.Client
Just a C# .NET 4.0 client that listens for messages from the Netduino

#### XSockets.IoT.Netduino42 (start if you have NETMF 4.2)
The netduino will turn lights on/off when the buttons in the browser.
When you press the button in the Netduino chatmessages will appear in the browser and in the Console client application 

#### XSockets.IoT.Netduino43 (start if you have NETMF 4.3)
The netduino will turn lights on/off when the buttons in the browser.
When you press the button in the Netduino chatmessages will appear in the browser and in the Console client application

#### XSockets.IoT.Controllers (Should not be started)
XSockets Controller and very simple logic