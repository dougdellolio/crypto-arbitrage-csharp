using System.Linq;
using CryptoArbitrageSharp.Exchanges.Bitfinex.Models;
using System.Threading.Tasks;

namespace CryptoArbitrageSharp.Exchanges.Bitfinex
{
    public class BitfinexExchange : AbstractExchange
    {
        public BitfinexExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Bitfinex + "book/ltcbtc");

            var bestBid = orderBook.Bids.Last().Price;
            var bestAsk = orderBook.Asks.Last().Price;

            return new BestExchangeQuote(Exchange.Bitfinex.Name, bestBid, bestAsk);
        }
    }
}
