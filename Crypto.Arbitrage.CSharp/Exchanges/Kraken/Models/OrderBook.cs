using System.Collections.Generic;

namespace Crypto.Arbitrage.CSharp.Exchanges.Kraken.Models
{
    public class Pair
    {
        public List<List<decimal>> Asks { get; set; }

        public List<List<decimal>> Bids { get; set; }
    }

    public class Result
    {
        public Pair Pair { get; set; }
    }

    public class OrderBook
    {
        public List<string> Error { get; set; }

        public Result Result { get; set; }
    }
}
