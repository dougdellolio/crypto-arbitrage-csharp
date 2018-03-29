namespace Crypto.Arbitrage.CSharp
{
    public class BestExchangeQuote
    {
        public BestExchangeQuote(
            string exchange,
            decimal bestBid,
            decimal bestAsk)
        {
            Exchange = exchange;
            BestBid = bestBid;
            BestAsk = bestAsk;
        }

        public string Exchange { get; }

        public decimal BestBid { get; }

        public decimal BestAsk { get; }
    }
}
