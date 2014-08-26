using System;
using Microsoft.Owin.Hosting;

namespace XSockets.IoT.Owin
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:12345";
            WebApp.Start<Startup>(url);
            Console.WriteLine("Open up: {0}/Web/{1}",url,"index.html");

            Console.ReadLine();
        }
    }
}
