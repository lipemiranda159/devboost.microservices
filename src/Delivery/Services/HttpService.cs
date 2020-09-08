using devboost.dronedelivery.domain.Interfaces;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Services
{
    public class HttpService : IHttpHandler
    {

        private HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            return await _client.PostAsync(url, content);
        }

        public void SetBaseAddress(string url)
        {
            _client.BaseAddress = new Uri(url);
        }
    }
}
