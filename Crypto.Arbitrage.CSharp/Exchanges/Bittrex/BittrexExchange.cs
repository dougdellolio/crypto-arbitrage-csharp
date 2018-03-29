using System.Linq;
using System.Threading.Tasks;
using Crypto.Arbitrage.CSharp.Exchanges.Bittrex.Models;

namespace Crypto.Arbitrage.CSharp.Exchanges.Bittrex
{
    public class BittrexExchange : AbstractExchange
    {
        public BittrexExchange(
            IHttpClient httpClient, 
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>("https://bittrex.com/api/v1.1/public/getorderbook?market=BTC-LTC&type=both");

            var bestBid = orderBook.Result.Buy.Max(p => p.Rate);
            var bestAsk = orderBook.Result.Sell.Max(p => p.Rate);

            return new BestExchangeQuote(Exchange.Bittrex.Name, bestBid, bestAsk);
        }
    }
}
