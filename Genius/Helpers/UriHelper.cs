using System;
using Genius.Models;

namespace Genius.Helpers
{
    internal static class UriHelper
    {
        public static Uri CreateUri<T>(string textFormat, string id = "", bool isVoteUri = false,
            VoteType voteType = VoteType.Unvote)
        {
            if (isVoteUri)
                return new Uri(
                    $"https://api.genius.com/{typeof(T).Name.ToLower()}s/{id}/{voteType.ToString().ToLower()}?text_format={textFormat}");

            return string.IsNullOrWhiteSpace(id)
                ? new Uri($"https://api.genius.com/{typeof(T).Name.ToLower()}s?text_format={textFormat}")
                : new Uri($"https://api.genius.com/{typeof(T).Name.ToLower()}s/{id}?text_format={textFormat}");
        }
    }
}