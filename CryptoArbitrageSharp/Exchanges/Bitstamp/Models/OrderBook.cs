using System.Collections.Generic;

namespace CryptoArbitrageSharp.Exchanges.Bitstamp.Models
{
    public class OrderBook
    {
        public IEnumerable<IEnumerable<decimal>> Bids { get; set; }

        public IEnumerable<IEnumerable<decimal>> Asks { get; set; }
    }
}
