namespace AutomatedAPI.HTTPClient
{
    public interface IJsonConverter
    {
        string ToJsonString<T>(T obj);
        T ToObject<T>(string json);
    }
}
