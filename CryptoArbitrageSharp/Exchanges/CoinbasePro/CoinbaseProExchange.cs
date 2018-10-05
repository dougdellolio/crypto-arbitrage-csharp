using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.CoinbasePro.Models;

namespace CryptoArbitrageSharp.Exchanges.CoinbasePro
{
    public class CoinbaseProExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public CoinbaseProExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.CoinbasePro, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.CoinbasePro + $"products/{pair}/book");

            var bestBid = orderBook.Bids.First().First();
            var bestAsk = orderBook.Asks.First().First();

            return new BestExchangeQuote(Exchange.CoinbasePro.Name, bestBid, bestAsk);
        }
    }
}
