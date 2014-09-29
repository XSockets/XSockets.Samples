using System;
using System.Threading;
using System.Threading.Tasks;
using XSockets.Client40;

namespace ScalingAndPerformanceSample.Clients
{
    /// <summary>
    /// Messages will be slower to receive here since we have 4000 clients in the same console app.    
    /// </summary>
    class Program
    {
        private static int messagecounter;
        private static string[] servers = new[] {"4503", "4504", "4505","4506"};
        static void Main(string[] args)
        {
            Console.WriteLine("Hit enter to start connecting 4000 clients...");
            Console.ReadLine();
            
            var server = 0;
            for (var i = 0; i < 4000; i++, server++)
            {
                if (server > 3) server = 0;
                
                var c = new XSocketClient("ws://127.0.0.1:"+servers[server],"http://localhost","foo");                
                c.Open();
                c.Controller("foo").On("m", () =>
                {
                    Interlocked.Increment(ref messagecounter);         
                });                
            }

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Console.WriteLine(messagecounter);
                    Thread.Sleep(10000);
                }
            });

            Console.WriteLine("All clients connected. Hit enter to quit...");
            Console.ReadLine();
        }        
    }
}
