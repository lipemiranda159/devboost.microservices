using devboost.dronedelivery.felipe.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Services
{
    public class HttpService : IHttpHandler
    {

        private HttpClient _client = new HttpClient();

        public HttpResponseMessage Get(string url)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetAsync(string url)
        {
            throw new NotImplementedException();
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }

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
