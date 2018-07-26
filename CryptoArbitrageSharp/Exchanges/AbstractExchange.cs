using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CryptoArbitrageSharp.Exchanges
{
    public abstract class AbstractExchange
    {
        private readonly IHttpClient httpClient;

        private readonly IHttpRequestMessageService httpRequestMessageService;

        protected AbstractExchange(
            IHttpClient httpClient,
            IHttpRequestMessageService httpRequestMessageService)
        {
            this.httpClient = httpClient;
            this.httpRequestMessageService = httpRequestMessageService;
        }

        protected async Task<T> GetOrderBook<T>(string uri)
        {
            var result = await httpClient.SendASync(httpRequestMessageService.CreateHttpRequestMessage(HttpMethod.Get, uri)).ConfigureAwait(false);
            var contentBody = await httpClient.ReadAsStringAsync(result).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<T>(contentBody);
        }

        public abstract Task<BestExchangeQuote> Get(CurrencyPair currentPair);
    }
}
