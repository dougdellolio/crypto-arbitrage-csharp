using System.Threading.Tasks;
using CryptoArbitrageSharp.Calculator;
using CryptoArbitrageSharp.Exchanges;
using CryptoArbitrageSharp.Exchanges.Binance;
using CryptoArbitrageSharp.Exchanges.Bitfinex;
using CryptoArbitrageSharp.Exchanges.Bitstamp;
using CryptoArbitrageSharp.Exchanges.Bittrex;
using CryptoArbitrageSharp.Exchanges.CoinbasePro;
using CryptoArbitrageSharp.Exchanges.CoinExchange;
using CryptoArbitrageSharp.Exchanges.Kraken;
using CryptoArbitrageSharp.Exchanges.Poloniex;

namespace CryptoArbitrageSharp
{
    public class ArbitrageClient
    {
        private readonly IArbitrageCalculator arbitrageCalculator;

        public ArbitrageClient(IArbitrageCalculator arbitrageCalculator)
        {
            this.arbitrageCalculator = arbitrageCalculator;
        }

        public async Task<(BestExchangeQuote bestBid, BestExchangeQuote bestAsk)> Get(CurrencyPair currencyPair)
        {
            var httpClient = new HttpClient();
            var httpRequestMessageService = new HttpRequestMessageService();
            var currencyPairService = new CurrencyPairService();

            var bittrexExchange = new BittrexExchange(httpClient, httpRequestMessageService, currencyPairService);
            var coinbaseProExchange = new CoinbaseProExchange(httpClient, httpRequestMessageService, currencyPairService);
            var krakenExchange = new KrakenExchange(httpClient, httpRequestMessageService, currencyPairService);
            var poloniexExchange = new PoloniexExchange(httpClient, httpRequestMessageService, currencyPairService);
            var binanceExchange = new BinanceExchange(httpClient, httpRequestMessageService, currencyPairService);
            var bitfinexExchange= new BitfinexExchange(httpClient, httpRequestMessageService, currencyPairService);
            var bitstampExchange = new BitstampExchange(httpClient, httpRequestMessageService, currencyPairService);

            var exchangeResults = await Task.WhenAll(
                bittrexExchange.Get(currencyPair),
                coinbaseProExchange.Get(currencyPair),
                krakenExchange.Get(currencyPair),
                poloniexExchange.Get(currencyPair),
                binanceExchange.Get(currencyPair),
                bitfinexExchange.Get(currencyPair),
                bitstampExchange.Get(currencyPair));

            var result = arbitrageCalculator.Calculate(
                exchangeResults[0],
                exchangeResults[1],
                exchangeResults[2],
                exchangeResults[3],
                exchangeResults[4],
                exchangeResults[5],
                exchangeResults[6]);

            return result;
        }
    }
}
