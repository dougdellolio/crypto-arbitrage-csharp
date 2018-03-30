using System.Net.Http;

namespace CryptoArbitrageSharp
{
    public interface IHttpRequestMessageService
    {
        HttpRequestMessage CreateHttpRequestMessage(HttpMethod httpMethod, string requestUri);
    }
}
