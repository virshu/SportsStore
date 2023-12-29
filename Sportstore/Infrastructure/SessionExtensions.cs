using System.Text.Json;

namespace Sportstore.Infrastructure;

public static class SessionExtensions
{
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    public static T? GetJson<T>(this ISession session, string key)
    {
        string? sessionData = session.GetString(key);
        return sessionData == null ? default : JsonSerializer.Deserialize<T>(sessionData);
    }

}