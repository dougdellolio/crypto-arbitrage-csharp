using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Poloniex.Models;

namespace CryptoArbitrageSharp.Exchanges.Poloniex
{
    public class PoloniexExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public PoloniexExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Poloniex, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Poloniex + $"public?command=returnOrderBook&currencyPair={pair}&depth=10");

            var bestBid = orderBook.Bids.Select(p => p.First()).Max();
            var bestAsk = orderBook.Asks.Select(p => p.First()).Max();

            return new BestExchangeQuote(Exchange.Poloniex.Name, bestBid, bestAsk);
        }
    }
}
