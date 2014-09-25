using System.Collections.Generic;
using System.Linq;
using StockServer.Sample.Model;
using XSockets.Core.Common.Socket.Event.Arguments;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;
using XSockets.Plugin.Framework.Attributes;

namespace StockServer.Sample.Controllers
{
    [XSocketMetadata(PluginAlias="stock")]
    public class StockController : XSocketController
    {
        //We have state :) Each user can listen to stocks of choice
        public List<string> MyStocks { get; set; }

        public StockController()
        {
            //By default, listen to all stocks
            MyStocks = Model.StockTicker.Stocks.Values.Select(p => p.Symbol).ToList();

            this.OnOpen += StockController_OnOpen;
        }

        public override void OnMessage(IMessage message)
        {
            this.InvokeToAll(message);
        }

        void StockController_OnOpen(object sender, OnClientConnectArgs e)
        {
            //Send to available stocks to the client when he/she´s connected. No need to ask for them.
            this.Invoke(Model.StockTicker.Stocks.Values, "allStocks");
        }

        /// <summary>
        /// Do a conditional send to only clients listening for the actual stock
        /// </summary>
        /// <param name="stock"></param>
        public void Tick(Stock stock)
        {
            //Send only to client having this stock in their list
            this.InvokeTo<StockController>(p => p.MyStocks.Contains(stock.Symbol), stock, "tick");
        }

        /// <summary>
        /// Not in the SignalR example, but we think it is a good use-case
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="price"></param>
        public void AddOrUpdateStock(string symbol, decimal price)
        {
            //Format the symbol
            symbol = symbol.Trim().ToUpper();
            //If true it was a new stock and we tell every client.
            if (Model.StockTicker.AddOrUpdateStock(new Stock { Symbol = symbol, Price = price }))
            {
                //Add to everyones stockmodel
                foreach (var client in this.Find<StockController>(p => !p.MyStocks.Contains(symbol)))
                {
                    client.MyStocks.Add(symbol);
                }
                //Send the new stock to all clients
                this.InvokeToAll(Model.StockTicker.Stocks[symbol], "stock");
            }
            //The stock exists, just tell about the change...
            else
            {
                this.InvokeTo<StockController>(p => p.MyStocks.Contains(symbol), Model.StockTicker.Stocks[symbol], "tick");
            }
        }
    }
}
