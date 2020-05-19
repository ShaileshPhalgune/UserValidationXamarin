using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace UserValidation.Updated.Gateway.Interface
{
    public interface IHttpHandler
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}
