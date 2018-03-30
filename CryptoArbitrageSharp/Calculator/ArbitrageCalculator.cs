using System.Linq;

namespace CryptoArbitrageSharp.Calculator
{
    public class ArbitrageCalculator : IArbitrageCalculator
    {
        public (BestExchangeQuote lowestBid, BestExchangeQuote highestAsk) Calculate(params BestExchangeQuote[] bestExchangeQuotes)
        {
            var lowestBid = bestExchangeQuotes.OrderBy(p => p.BestBid).First();
            var highestAsk = bestExchangeQuotes.OrderByDescending(p => p.BestAsk).First();

            return (lowestBid, highestAsk);
        }
    }
}
