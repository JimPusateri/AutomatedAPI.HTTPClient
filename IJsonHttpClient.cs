using System;

namespace AutomatedAPI.HTTPClient
{
    public interface IJsonHttpClient
    {
        TResponse Get<TResponse>(Uri requestUri);
        TResponse Post<TRequest, TResponse>(Uri requestUri, TRequest request);
        TResponse Put<TRequest, TResponse>(Uri requestUri, TRequest request);
    }
}
