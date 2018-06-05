using System.Threading.Tasks;
using CryptoArbitrageSharp.Calculator;
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

        public async Task<(BestExchangeQuote bestBid, BestExchangeQuote bestAsk)> Get()
        {
            var httpClient = new HttpClient();
            var httpRequestMessageService = new HttpRequestMessageService();

            var bittrexExchange = new BittrexExchange(httpClient, httpRequestMessageService);
            var bittrexResult = await bittrexExchange.Get();

            var gdaxExchange = new GdaxExchange(httpClient, httpRequestMessageService);
            var gdaxResult = await gdaxExchange.Get();

            var coinExchangeExchange = new CoinExchangeExchange(httpClient, httpRequestMessageService);
            var coinExchangeExchangeResult = await coinExchangeExchange.Get();

            var krakenExchange = new CoinExchangeExchange(httpClient, httpRequestMessageService);
            var krakenExchangeResult = await krakenExchange.Get();

            var poloniexExchange = new PoloniexExchange(httpClient, httpRequestMessageService);
            var poloniexExchangeResult = await poloniexExchange.Get();

            var binanceExchange = new BinanceExchange(httpClient, httpRequestMessageService);
            var binanceExchangeResult = await binanceExchange.Get();

            var bitfinexExchange= new BitfinexExchange(httpClient, httpRequestMessageService);
            var bitfinexExchangeResult = await bitfinexExchange.Get();

            var bitstampExchange = new BitstampExchange(httpClient, httpRequestMessageService);
            var bitstampExchangeResult = await bitstampExchange.Get();

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
