using System.Threading.Tasks;
using CryptoArbitrageSharp.Exchanges.Binance.Models;

namespace CryptoArbitrageSharp.Exchanges.Binance
{
    public class BinanceExchange : AbstractExchange
    {
        public BinanceExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
            : base(httpClient, httpRequestMessageService)
        {
        }

        public override async Task<BestExchangeQuote> Get()
        {
            var orderBook = await GetOrderBook<OrderBook>(ExchangeEndpointBase.Binance + "ticker/bookTicker?symbol=LTCBTC");

            return new BestExchangeQuote(Exchange.Binance.Name, orderBook.BidPrice, orderBook.AskPrice);
        }
    }
}
