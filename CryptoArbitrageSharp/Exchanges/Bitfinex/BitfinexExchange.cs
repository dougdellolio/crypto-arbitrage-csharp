using System.Linq;
using CryptoArbitrageSharp.Exchanges.Bitfinex.Models;
using System.Threading.Tasks;

namespace CryptoArbitrageSharp.Exchanges.Bitfinex
{
    public class BitfinexExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public BitfinexExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Bitfinex, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Bitfinex + $"book/{pair}");

            var bestBid = orderBook.Bids.Last().Price;
            var bestAsk = orderBook.Asks.Last().Price;

            return new BestExchangeQuote(Exchange.Bitfinex.Name, bestBid, bestAsk);
        }

        //get me pair for currency pair
    }
}
