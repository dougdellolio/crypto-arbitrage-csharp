using System.Collections.Generic;

namespace CryptoArbitrageSharp.Exchanges.Kraken.Models
{
    public class XLTCXXBT
    {
        public List<List<decimal>> Asks { get; set; }

        public List<List<decimal>> Bids { get; set; }
    }

    public class Result
    {
        public XLTCXXBT XLTCXXBT { get; set; } //todo: This needs to be dynamic. Its hard coded to LTCBTC pair
    }

    public class OrderBook
    {
        public List<string> Error { get; set; }

        public Result Result { get; set; }
    }
}
