using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text;
using WebEuroCorp.Configuracion;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Newtonsoft.Json;

namespace WebEuroCorp.Servicios
{
    public class ServicioApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ServicioApi(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _baseUrl = apiSettings.Value.BaseUrl;
        }


        public async Task<HttpResponseMessage> PostAsync<T>(string endpoint, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync($"{_baseUrl}{endpoint}", jsonContent);
        }
        public async Task<T> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{endpoint}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            throw new HttpRequestException($"Error fetching data from {endpoint}: {response.ReasonPhrase}");
        }
    }
}
