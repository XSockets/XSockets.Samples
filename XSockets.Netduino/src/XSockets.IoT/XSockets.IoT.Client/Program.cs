using System;
using XSockets.Client40;

namespace XSockets.IoT.Client
{
    /// <summary>
    /// This is a .NET 4 client that will receive messages from the netduino
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new XSocketClient("ws://localhost:4502","http://localhost","IoT");

            conn.Controller("IoT").OnOpen += (sender, connectArgs) => Console.WriteLine("IoT Controller Connected");
            
            conn.Open();

            //Set client type
            conn.Controller("IoT").SetEnum("ClientType","Native");

            //Listen for messages from the Netduino
            conn.Controller("IoT").On<ChatMessage>("chatmessage", message => Console.WriteLine(message.Text));

            Console.WriteLine("Listening for messages from the Netduino, hit enter to quit");
            Console.ReadLine();
        }
    }

    public class ChatMessage
    {
        public string Text { get; set; }
    }    
}
