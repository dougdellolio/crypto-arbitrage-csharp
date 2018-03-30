using System.Net.Http;

namespace CryptoArbitrageSharp
{
    public class HttpRequestMessageService : IHttpRequestMessageService
    {
        public HttpRequestMessage CreateHttpRequestMessage(
            HttpMethod httpMethod,
            string requestUri)
        {
            var requestMessage = new HttpRequestMessage(httpMethod, requestUri);
            //AddHeaders(requestMessage);

            AddHeaders(requestMessage);
            return requestMessage;
        }

        private void AddHeaders(HttpRequestMessage httpRequestMessage)
        {
            httpRequestMessage.Headers.Add("User-Agent", "Arbitrage");
        }
    }
}
