using System.Linq;
using System.Threading.Tasks;
using Crypto.Arbitrage.CSharp.Exchanges.GDAX.Models;

namespace Crypto.Arbitrage.CSharp.Exchanges.GDAX
{
    public class GdaxExchange : AbstractExchange
    {
        public GdaxExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>("https://api.gdax.com/products/LTC-BTC/book");
            var bestBid = orderBook.Bids.First().First();
            var bestAsk = orderBook.Asks.First().First();

            return new BestExchangeQuote(Exchange.Gdax.Name, bestBid, bestAsk);
        }
    }
}
