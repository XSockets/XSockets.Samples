using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serilog.Events;
using Serilog.Sinks.XSockets.Sinks.XSockets.Data;
using XSockets.Client40;
using XSockets.Core.Common.Socket;

namespace TestServer
{
    /// <summary>
    /// When running this you will see that the console logs everything 
    /// but the cilent only receives data when the current loglevel is => the clients level
    /// Notice that all messages with XSockets sink is written in green... So that you can see the difference.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>())
            {
                //Start a server
                container.Start();

                
                Console.WriteLine("Hit enter to start a client that will show Serilog.Sinks.XSockets");
                Console.ReadLine();

                //Start a client and hook up only to the log controller...
                var client = new XSocketClient("ws://localhost:4502","http://localhost","log");

                client.Open();
                
                client.Controller("log").On<LogEventWrapper>("logEvent", logEvent =>
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Message: {0}",logEvent.RenderedMessage);
                    Console.ResetColor();
                });

                //Change the LogEventLevel the client listens to every 8 seconds
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        var newLevel = ((LogEventLevel)new Random().Next(0, 5)).ToString();
                        client.Controller("log").SetEnum("LogEventLevel", newLevel);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("New LogEventLevel set to {0}", newLevel);
                        Console.ResetColor();
                        Thread.Sleep(8000);                        
                    }
                });
                
                Console.WriteLine("Hit enter to quit");
                Console.ReadLine();
            }
        }
    }
}
