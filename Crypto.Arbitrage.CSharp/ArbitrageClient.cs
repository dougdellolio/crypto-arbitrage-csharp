using System.Threading.Tasks;
using Crypto.Arbitrage.CSharp.Calculator;
using Crypto.Arbitrage.CSharp.Exchanges.Bittrex;
using Crypto.Arbitrage.CSharp.Exchanges.CoinExchange;
using Crypto.Arbitrage.CSharp.Exchanges.GDAX;
using Crypto.Arbitrage.CSharp.Exchanges.Poloniex;

namespace Crypto.Arbitrage.CSharp
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

            var result = arbitrageCalculator.Calculate(
                bittrexResult, 
                gdaxResult, 
                coinExchangeExchangeResult, 
                krakenExchangeResult,
                poloniexExchangeResult);

            return result;
        }
    }
}
