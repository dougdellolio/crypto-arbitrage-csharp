using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.CoinExchange.Models;

namespace CryptoArbitrageSharp.Exchanges.CoinExchange
{
    public class CoinExchangeExchange : AbstractExchange
    {
        public CoinExchangeExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
                : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.CoinExchange + "getorderbook?market_id=18");

            var bestBid = orderBook.Result.BuyOrders.OrderByDescending(p => p.Price).First();
            var bestAsk = orderBook.Result.SellOrders.OrderByDescending(p => p.Price).First();

            return new BestExchangeQuote(Exchange.CoinExchange.Name, bestBid.Price, bestAsk.Price);
        }
    }
}
