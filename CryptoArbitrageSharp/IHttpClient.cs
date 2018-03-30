using System.Net.Http;
using System.Threading.Tasks;

namespace CryptoArbitrageSharp
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> SendASync(HttpRequestMessage httpRequestMessage);

        Task<string> ReadAsStringAsync(HttpResponseMessage httpRequestMessage);
    }
}
