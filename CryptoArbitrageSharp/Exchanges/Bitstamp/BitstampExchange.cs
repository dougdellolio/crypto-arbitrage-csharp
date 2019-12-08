using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Bitstamp.Models;

namespace CryptoArbitrageSharp.Exchanges.Bitstamp
{
    public class BitstampExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public BitstampExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Bitstamp, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Bitstamp + $"order_book/{pair}/");

            var bestBid = orderBook.Bids.First().First();
            var bestAsk = orderBook.Asks.First().First();

            return new BestExchangeQuote(Exchange.Bitstamp.Name, bestBid, bestAsk);
        }
    }
}
