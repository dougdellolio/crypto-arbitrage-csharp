using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Binance.Models;

namespace CryptoArbitrageSharp.Exchanges.Binance
{
    public class BinanceExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public BinanceExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Binance, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Binance + $"ticker/bookTicker?symbol={pair}");

            return new BestExchangeQuote(Exchange.Binance.Name, orderBook.BidPrice, orderBook.AskPrice);
        }
    }
}
