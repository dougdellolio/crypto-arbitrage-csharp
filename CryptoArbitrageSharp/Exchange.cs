namespace CryptoArbitrageSharp
{
    public class Exchange
    {
        public static readonly Exchange Gdax = new Exchange("GDAX");

        public static readonly Exchange CoinExchange = new Exchange("CoinExchange");

        public static readonly Exchange Bittrex = new Exchange("Bittrex");

        public static readonly Exchange Kraken = new Exchange("Kraken");

        public static readonly Exchange Poloniex = new Exchange("Poloniex");

        public static readonly Exchange Binance = new Exchange("Binance");

        public static readonly Exchange Bitfinex = new Exchange("Bitfinex");

        public static readonly Exchange Bitstamp = new Exchange("Bitstamp");

        public Exchange(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
