using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutomatedAPI.HTTPClient
{
    public class JsonHttpClient : IJsonHttpClient
    {
        public TResponse Get<TResponse>(Uri requestUri)
        {
            TResponse response;
            HttpClient http = new();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            response = http.GetFromJsonAsync<TResponse>(requestUri, options).Result;
            
            return response;
        }
        public async Task<TResponse> GetAsync<TResponse>(Uri requestUri)
        {
            HttpClient http = new();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            return await http.GetFromJsonAsync<TResponse>(requestUri, options);
        }

        public TResponse Post<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            HttpClient http = new();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var webResult = http.PostAsJsonAsync<TRequest>(requestUri, request, options).Result;
            var contentResult = webResult.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<TResponse>(contentResult);            
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            HttpClient http = new();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var webResult = await http.PostAsJsonAsync<TRequest>(requestUri, request, options);
            var contentResult = await webResult.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(contentResult);
        }

        public TResponse Put<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            HttpClient http = new();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var webResult = http.PutAsJsonAsync<TRequest>(requestUri, request, options).Result;
            var contentResult = webResult.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<TResponse>(contentResult);
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(Uri requestUri, TRequest request)
        {

            HttpClient http = new();
            var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
            var webResult = await http.PutAsJsonAsync<TRequest>(requestUri, request, options);
            var contentResult = await webResult.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(contentResult);
        }

        public void Delete(Uri requestUri)
        {
            HttpClient http = new();
            _ = http.DeleteAsync(requestUri).Result;


        }
        public async Task DeleteAsync(Uri requestUri)
        {
            HttpClient http = new();
            _ = await http.DeleteAsync(requestUri);
        }
    }
}
