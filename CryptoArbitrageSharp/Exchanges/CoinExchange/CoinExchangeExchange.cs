using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.CoinExchange.Models;

namespace CryptoArbitrageSharp.Exchanges.CoinExchange
{
    public class CoinExchangeExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public CoinExchangeExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.CoinExchange, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.CoinExchange + $"getorderbook?market_id={pair}");

            var bestBid = orderBook.Result.BuyOrders.OrderByDescending(p => p.Price).First();
            var bestAsk = orderBook.Result.SellOrders.OrderByDescending(p => p.Price).First();

            return new BestExchangeQuote(Exchange.CoinExchange.Name, bestBid.Price, bestAsk.Price);
        }
    }
}
