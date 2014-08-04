using System;
using System.Collections.Generic;
using XSockets.Client40;

namespace StockClient
{
    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Connect to the XSockets instance hosted in Owin
            var c = new XSocketClient("ws://localhost:12345", "http://localhost", "stock");

            c.OnConnected += (sender, eventArgs) => Console.WriteLine("CONNECTED");

            c.Open();

            //Set the 'mystocks' property on the controller to 'MSFT' and 'XNET'
            c.Controller("stock").SetProperty("MyStocks", new List<string>() { "MSFT", "XNET" });

            //Listen for 'tick', but we use dynamic since we have no reference to the class Stock
            c.Controller("stock").On<Stock>("tick", s =>
            {
                Console.WriteLine("{0}:{1}",s.Symbol, s.Price);
            });
            
            
            
            Console.ReadLine();
        }
    }
}
