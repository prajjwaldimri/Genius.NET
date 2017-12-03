using System;

namespace Genius.Helpers
{
    internal static class UriHelper
    {
        public static Uri CreateUri<T>(string textFormat, string id = "")
        {
            return string.IsNullOrWhiteSpace(id)
                ? new Uri($"https://api.genius.com/{typeof(T).Name.ToLower()}s?text_format={textFormat}")
                : new Uri($"https://api.genius.com/{typeof(T).Name.ToLower()}s/{id}?text_format={textFormat}");
        }
    }
}