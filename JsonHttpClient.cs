using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AutomatedAPI.HTTPClient
{
    public class JsonHttpClient : IJsonHttpClient
    {
        private readonly IJsonConverter _jsonConverter;

        public JsonHttpClient(IJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public TResponse Get<TResponse>(Uri requestUri)
        {
            TResponse responseJson;
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            HttpWebResponse httpResponse = (HttpWebResponse)http.GetResponse();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseJson = _jsonConverter.ToObject<TResponse>(sr.ReadToEnd());
            }
            return responseJson;
        }
        public async Task<TResponse> GetAsync<TResponse>(Uri requestUri)
        {
            TResponse responseJson;
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            HttpWebResponse httpResponse = (HttpWebResponse)await http.GetResponseAsync();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseJson = _jsonConverter.ToObject<TResponse>(sr.ReadToEnd());
            }
            return responseJson;
        }

        public TResponse Post<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            TResponse responseJson;
            var jsonString = _jsonConverter.ToJsonString(request);
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            http.Method = "POST";

            using (var streamWriter = new StreamWriter(http.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)http.GetResponse();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseJson = _jsonConverter.ToObject<TResponse>(sr.ReadToEnd());
            }
            return responseJson;
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            TResponse responseJson;
            var jsonString = _jsonConverter.ToJsonString(request);
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            http.Method = "POST";

            using (var streamWriter = new StreamWriter(http.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)await http.GetResponseAsync();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseJson = _jsonConverter.ToObject<TResponse>(sr.ReadToEnd());
            }
            return responseJson;
        }

        public TResponse Put<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            TResponse responseJson;
            var jsonString = _jsonConverter.ToJsonString(request);
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            http.Method = "PUT";

            using (var streamWriter = new StreamWriter(http.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)http.GetResponse();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseJson = _jsonConverter.ToObject<TResponse>(sr.ReadToEnd());
            }
            return responseJson;
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(Uri requestUri, TRequest request)
        {
            TResponse responseJson;
            var jsonString = _jsonConverter.ToJsonString(request);
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(requestUri);
            http.ContentType = "application/json;";
            http.Method = "PUT";

            using (var streamWriter = new StreamWriter(http.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
                streamWriter.Flush();
                streamWriter.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)await http.GetResponseAsync();
            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseJson = _jsonConverter.ToObject<TResponse>(sr.ReadToEnd());
            }
            return responseJson;
        }

        public void Delete(Uri requestUri)
        {
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            http.Method = "DELETE";
            _ = (HttpWebResponse)http.GetResponse();

        }
        public async Task DeleteAsync(Uri requestUri)
        {
            HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(requestUri);
            http.ContentType = "application/json; charset=UTF-8";
            http.Method = "DELETE";
            _ = (HttpWebResponse)await http.GetResponseAsync();
        }
    }
}
