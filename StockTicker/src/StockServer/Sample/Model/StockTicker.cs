using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace StockServer.Sample.Model
{
    /// <summary>
    /// Pumping fake stocks...
    /// Pushed data onto the OnTick event
    /// </summary>
    public class StockTicker
    {
        private readonly object _updateStockPricesLock = new object();
        public static readonly ConcurrentDictionary<string, Stock> Stocks = new ConcurrentDictionary<string, Stock>();

        private readonly int _updateInterval;
        private readonly Timer _stockTtimer;

        public Action<Stock> OnTick;

        public StockTicker(Action<Stock> onTick, int updateInterval = 250)
        {
            this.OnTick = onTick;

            //Setup Stocks...
            LoadDefaultStocks();

            _updateInterval = updateInterval;

            //Initialize ticker...
            _stockTtimer = new Timer(_updateInterval);
            _stockTtimer.Elapsed += _stockTimer_Elapsed;
            _stockTtimer.Start();
        }

        void _stockTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (_updateStockPricesLock)
            {
                foreach (var stock in Stocks.Values.Where(Stock.TryUpdateStockPrice))
                {
                    OnTick.Invoke(stock);
                }
            }
        }

        private static void LoadDefaultStocks()
        {
            Stocks.Clear();

            var stocks = new List<Stock>
                {
                    new Stock { Symbol = "MSFT", Price = 30.31m },
                    new Stock { Symbol = "APPL", Price = 578.18m },
                    new Stock { Symbol = "GOOG", Price = 570.30m },
                    new Stock { Symbol = "XNET", Price = 803.26m }
                };

            stocks.ForEach(stock => Stocks.TryAdd(stock.Symbol, stock));
        }

        public static bool AddOrUpdateStock(Stock stock)
        {
            stock.Symbol = stock.Symbol.Trim().ToUpper();
            if (Stocks.ContainsKey(stock.Symbol))
            {
                Stocks[stock.Symbol].Price = stock.Price;
                return false;
            }
            Stocks.TryAdd(stock.Symbol, stock);
            return true;
        }
    }
}