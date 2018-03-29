using System.Linq;
using System.Threading.Tasks;
using Crypto.Arbitrage.CSharp.Exchanges.Poloniex.Models;

namespace Crypto.Arbitrage.CSharp.Exchanges.Poloniex
{
    public class PoloniexExchange : AbstractExchange
    {
        public PoloniexExchange(
            IHttpClient httpClient, 
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>("https://poloniex.com/public?command=returnOrderBook&currencyPair=BTC_LTC&depth=10");

            var bestBid = orderBook.Bids.Select(p => p.First()).Max();
            var bestAsk = orderBook.Asks.Select(p => p.First()).Max();

            return new BestExchangeQuote(Exchange.Poloniex.Name, bestBid, bestAsk);
        }
    }
}
