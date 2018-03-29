using System.Net.Http;

namespace Crypto.Arbitrage.CSharp
{
    public interface IHttpRequestMessageService
    {
        HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, string requestUri);
    }
}
