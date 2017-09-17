using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FacebookApp
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;
        private string _graphAPIBaseUri;

        public FacebookClient()
        {
            _graphAPIBaseUri = ConfigurationManager.AppSettings.Get("GraphApiBaseUri");
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(_graphAPIBaseUri)
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> SearchAsync<T>(string accessToken, string searchString, string endpoint, string args = null)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return default(T);

            var response = await _httpClient.GetAsync($"{endpoint}?q={searchString}&type=user&access_token={accessToken}&{args}");

            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

    }
}
