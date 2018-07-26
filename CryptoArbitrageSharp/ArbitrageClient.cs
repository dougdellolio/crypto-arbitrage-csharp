using System.Threading.Tasks;
using CryptoArbitrageSharp.Calculator;
using CryptoArbitrageSharp.Exchanges;
using CryptoArbitrageSharp.Exchanges.Binance;
using CryptoArbitrageSharp.Exchanges.Bitfinex;
using CryptoArbitrageSharp.Exchanges.Bitstamp;
using CryptoArbitrageSharp.Exchanges.Bittrex;
using CryptoArbitrageSharp.Exchanges.CoinExchange;
using CryptoArbitrageSharp.Exchanges.GDAX;
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
            var bittrexResult = await bittrexExchange.Get(currencyPair);

            var gdaxExchange = new GdaxExchange(httpClient, httpRequestMessageService, currencyPairService);
            var gdaxResult = await gdaxExchange.Get(currencyPair);

            var coinExchangeExchange = new CoinExchangeExchange(httpClient, httpRequestMessageService, currencyPairService);
            var coinExchangeExchangeResult = await coinExchangeExchange.Get(currencyPair);

            var krakenExchange = new CoinExchangeExchange(httpClient, httpRequestMessageService, currencyPairService);
            var krakenExchangeResult = await krakenExchange.Get(currencyPair);

            var poloniexExchange = new PoloniexExchange(httpClient, httpRequestMessageService, currencyPairService);
            var poloniexExchangeResult = await poloniexExchange.Get(currencyPair);

            var binanceExchange = new BinanceExchange(httpClient, httpRequestMessageService, currencyPairService);
            var binanceExchangeResult = await binanceExchange.Get(currencyPair);

            var bitfinexExchange= new BitfinexExchange(httpClient, httpRequestMessageService, currencyPairService);
            var bitfinexExchangeResult = await bitfinexExchange.Get(currencyPair);

            var bitstampExchange = new BitstampExchange(httpClient, httpRequestMessageService, currencyPairService);
            var bitstampExchangeResult = await bitstampExchange.Get(currencyPair);

            var result = arbitrageCalculator.Calculate(
                bittrexResult, 
                gdaxResult, 
                coinExchangeExchangeResult, 
                krakenExchangeResult,
                poloniexExchangeResult,
                binanceExchangeResult,
                bitfinexExchangeResult,
                bitstampExchangeResult);

            return result;
        }
    }
}
