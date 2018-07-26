using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.GDAX.Models;

namespace CryptoArbitrageSharp.Exchanges.GDAX
{
    public class GdaxExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public GdaxExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Gdax, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Gdax + $"products/{pair}/book");

            var bestBid = orderBook.Bids.First().First();
            var bestAsk = orderBook.Asks.First().First();

            return new BestExchangeQuote(Exchange.Gdax.Name, bestBid, bestAsk);
        }
    }
}
