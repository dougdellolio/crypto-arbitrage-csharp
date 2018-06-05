using System;
using System.Collections.Generic;

namespace CryptoArbitrageSharp.Exchanges.Bitfinex.Models
{
    public class OrderBook
    {
        public IEnumerable<Bid> Bids { get; set; }

        public IEnumerable<Ask> Asks { get; set; }
    }

    public class Bid
    {
        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }

    public class Ask
    {
        public decimal Price { get; set; }

        public decimal Amount { get; set; }
    }
}
