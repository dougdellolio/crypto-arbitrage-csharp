using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Bitstamp.Models;

namespace CryptoArbitrageSharp.Exchanges.Bitstamp
{
    public class BitstampExchange : AbstractExchange
    {
        public BitstampExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Bitstamp + "order_book/ltcbtc/");

            var bestBid = orderBook.Bids.First().First();
            var bestAsk = orderBook.Asks.First().First();

            return new BestExchangeQuote(Exchange.Bitfinex.Name, bestBid, bestAsk);
        }
    }
}
