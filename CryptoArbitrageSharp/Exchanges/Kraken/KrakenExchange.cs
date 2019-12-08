using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Kraken.Models;

namespace CryptoArbitrageSharp.Exchanges.Kraken
{
    public class KrakenExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public KrakenExchange(
            IHttpClient httpClient, 
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Kraken, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Kraken + $"public/Depth?pair={pair}");

            var bestBid = orderBook.Result.XLTCXXBT.Bids.Select(p => p).Select(p => p.FirstOrDefault()).Max();
            var bestAsk = orderBook.Result.XLTCXXBT.Asks.Select(p => p).Select(p => p.FirstOrDefault()).Max();

            return new BestExchangeQuote(Exchange.Kraken.Name, bestBid, bestAsk);
        }
    }
}
