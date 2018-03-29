using System.Collections.Generic;

namespace Crypto.Arbitrage.CSharp.Exchanges.Bittrex.Models
{
    public class Buy
    {
        public decimal Quantity { get; set; }

        public decimal Rate { get; set; }
    }

    public class Sell
    {
        public decimal Quantity { get; set; }

        public decimal Rate { get; set; }
    }

    public class Result
    {
        public List<Buy> Buy { get; set; }

        public List<Sell> Sell { get; set; }
    }

    public class OrderBook
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public Result Result { get; set; }
    }
}
