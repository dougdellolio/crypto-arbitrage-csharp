using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Kraken.Models;

namespace CryptoArbitrageSharp.Exchanges.Kraken
{
    public class KrakenExchange : AbstractExchange
    {
        public KrakenExchange(
            IHttpClient httpClient, 
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>("https://api.kraken.com/0/public/Depth?pair=XLTCXXBT");

            var bestBid = orderBook.Result.Pair.Bids.Select(p => p).Select(p => p.FirstOrDefault()).Max();
            var bestAsk = orderBook.Result.Pair.Asks.Select(p => p).Select(p => p.FirstOrDefault()).Max();

            return new BestExchangeQuote(Exchange.Kraken.Name, bestBid, bestAsk);
        }
    }
}
