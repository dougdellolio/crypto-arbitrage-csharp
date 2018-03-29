using System.Collections.Generic;

namespace Crypto.Arbitrage.CSharp.Exchanges.CoinExchange.Models
{
    public class SellOrder
    {
        public string Type { get; set; }

        public decimal Price { get; set; }

        public string OrderTime { get; set; }

        public decimal Quantity { get; set; }
    }

    public class BuyOrder
    {
        public string Type { get; set; }

        public decimal Price { get; set; }

        public string OrderTime { get; set; }

        public decimal Quantity { get; set; }
    }

    public class Result
    {
        public List<SellOrder> SellOrders { get; set; }

        public List<BuyOrder> BuyOrders { get; set; }
    }

    public class OrderBook
    {
        public string Success { get; set; }

        public string Request { get; set; }

        public string Message { get; set; }

        public Result Result { get; set; }
    }
}
