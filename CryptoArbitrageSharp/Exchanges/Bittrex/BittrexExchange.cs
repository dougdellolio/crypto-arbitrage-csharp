using System.Linq;
using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Bittrex.Models;

namespace CryptoArbitrageSharp.Exchanges.Bittrex
{
    public class BittrexExchange : AbstractExchange
    {
        private readonly ICurrencyPairService currencyPairService;

        public BittrexExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService,
            ICurrencyPairService currencyPairService)
                : base(httpClient, httpRequestMessageService)
        {
            this.currencyPairService = currencyPairService;
        }

        public override async Task<BestExchangeQuote> Get(CurrencyPair currencyPair)
        {
            var pair = currencyPairService.GetCurrencyPair(Exchange.Bittrex, currencyPair);
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Bittrex + $"public/getorderbook?market={pair}&type=both");

            var bestBid = orderBook.Result.Buy.Max(p => p.Rate);
            var bestAsk = orderBook.Result.Sell.Max(p => p.Rate);

            return new BestExchangeQuote(Exchange.Bittrex.Name, bestBid, bestAsk);
        }
    }
}
