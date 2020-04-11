using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestService
{
    public class HttpService
    {
        HttpClient _httpClient;

        public HttpService(string baseAddress, Dictionary<string, string> defaultRequestHeaders = null)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);

            if (defaultRequestHeaders != null)
            {
                foreach (var header in defaultRequestHeaders)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }

        public async Task<HttpResponseMessage> Get(string route, string payload = null)
        {
            var response = await _httpClient.GetAsync(route);

            return response;
        }

        public async Task<HttpResponseMessage> Post(string route, string payload = null)
        {
            var response = await _httpClient.PostAsync(route, new StringContent(payload, Encoding.UTF8, "application/json"));

            return response;
        }
    }
}
