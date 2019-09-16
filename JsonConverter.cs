using Newtonsoft.Json;

namespace AutomatedAPI.HTTPClient
{
    public class JsonConverter : IJsonConverter
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public JsonConverter(bool ignoreNullValues = false, bool indent = false)
        {
            var nullValueHandling = ignoreNullValues ? NullValueHandling.Ignore : NullValueHandling.Include;
            var formatting = indent ? Formatting.Indented : Formatting.None;

            _serializerSettings = new JsonSerializerSettings { NullValueHandling = nullValueHandling, Formatting = formatting };
        }
        public string ToJsonString<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _serializerSettings);
        }

        public T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _serializerSettings);
        }
    }
}
