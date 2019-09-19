using System;
using System.Threading.Tasks;

namespace AutomatedAPI.HTTPClient
{
    public interface IJsonHttpClient
    {
        TResponse Get<TResponse>(Uri requestUri);
        Task<TResponse> GetAsync<TResponse>(Uri requestUri);
        TResponse Post<TRequest, TResponse>(Uri requestUri, TRequest request);
        Task<TResponse> PostAsync<TRequest, TResponse>(Uri requestUri, TRequest request);
        TResponse Put<TRequest, TResponse>(Uri requestUri, TRequest request);
        Task<TResponse> PutAsync<TRequest, TResponse>(Uri requestUri, TRequest request);
        void Delete(Uri requestUri);
        Task DeleteAsync(Uri requestUri);
    }
}
