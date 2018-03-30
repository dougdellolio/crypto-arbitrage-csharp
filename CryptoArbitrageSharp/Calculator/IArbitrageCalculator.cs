namespace CryptoArbitrageSharp.Calculator
{
    public interface IArbitrageCalculator
    {
        (BestExchangeQuote lowestBid, BestExchangeQuote highestAsk) Calculate
            (params BestExchangeQuote[] bestExchangeQuotes);
    }
}
