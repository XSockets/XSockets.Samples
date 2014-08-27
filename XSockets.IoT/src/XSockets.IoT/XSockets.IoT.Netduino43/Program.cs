using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using XSockets.ClientMF43;
using XSockets.ClientMF43.Event.Arguments.Interfaces;
using XSockets.ClientMF43.Helpers;
using XSockets.ClientMF43.Interfaces;

namespace XSockets.IoT.Netduino43
{
    public class Program
    {
        private static IXSocketClient _conn;
        private static readonly OutputPort LedPort = new OutputPort(Pins.ONBOARD_LED, false);       
        private static readonly InterruptPort Button = new InterruptPort(Pins.ONBOARD_SW1, false, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);

        public static void Main()
        {
            //Change this ip to the IP of your machine (where XSockets is running)
            _conn = new XSocketClient("192.168.1.2", 4502);

            _conn.OnOpen += ConnOnOpen;
            _conn.OnClose += ConnOnClose;
            _conn.OnMessage += ConnOnMessage;

            _conn.Open();

            Thread.Sleep(Timeout.Infinite);
        }

        private static void ConnOnMessage(object sender, IMessage message)
        {
            switch (message.C)
            {
                case "iot":
                    switch (message.T)
                    {
                        case "light":
                            //A lightswitch message was received form IoT controller, convert JSON into the Toggle object
                            var toggle = (Toggle)_conn.Parse(message.D, typeof(Toggle));
                            LedPort.Write(toggle.State);
                            break;
                    }
                    break;
                default:
                    //Unknown controller
                    break;
            }
        }

        /// <summary>
        /// Connection closed, stop listening for button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void ConnOnClose(object sender, EventArgs eventArgs)
        {            
            Button.OnInterrupt -= button_OnInterrupt;
        }

        /// <summary>
        /// Conneciton open, send hardware type and listen for button pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private static void ConnOnOpen(object sender, EventArgs eventArgs)
        {
            //Initialize IoT Controller and set the ClientType
            _conn.SetEnum("ClientType", "Netduino", "IoT");            

            Button.OnInterrupt += button_OnInterrupt;
        }

        /// <summary>
        /// Send a message to XSockets if the button is pressed
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="time"></param>
        static void button_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            _conn.Publish("chatmessage", new ChatMessage { Text = "Hello from Netduino" }, "iot");
        }

    }
}
