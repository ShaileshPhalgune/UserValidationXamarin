using System;
using System.Net.Http;
using System.Threading.Tasks;
using UserValidation.Updated.Gateway.Interface;

namespace UserValidation.Updated.Gateway.API
{
    public class HttpRequestHandler : IHttpHandler
    {
        private HttpClient _client = new HttpClient();

        public HttpRequestHandler()
        {

        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }
    }
}
