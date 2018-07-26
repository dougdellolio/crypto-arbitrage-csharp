namespace CryptoArbitrageSharp.Exchanges
{
    public interface ICurrencyPairService
    {
        string GetCurrencyPair(Exchange exchange, CurrencyPair currencyPair);
    }
}
