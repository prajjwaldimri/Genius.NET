using System;
using System.Text;
using Genius.Models;

namespace Genius.Helpers
{
    internal static class UriHelper
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="id"></param>
        /// <param name="isVoteUri"></param>
        /// <param name="voteType"></param>
        /// <param name="perPage">Number of results to return per request</param>
        /// <param name="page">
        ///     Paginated offset (e.g., <![CDATA[per_page=5&page=3]]> returns songs 11-15)
        /// </param>
        /// <param name="createdById"></param>
        /// <param name="songId"></param>
        /// <param name="webPageId"></param>
        /// <param name="sort"></param>
        /// <param name="additionalUrl"></param>
        /// <param name="rawAnnotatableUrl"></param>
        /// <param name="canonicalUrl"></param>
        /// <param name="ogUrl"></param>
        /// <returns></returns>
        public static Uri CreateUri<T>(string textFormat, string id = "", bool isVoteUri = false,
            VoteType voteType = VoteType.Unvote, string perPage = "", string page = "", string createdById = "",
            string songId = "", string webPageId = "", string sort = "", string additionalUrl = "",
            string rawAnnotatableUrl = "", string canonicalUrl = "", string ogUrl = "")
        {
            // Checks if the parameters have started in the url
            var parameterStarted = false;
            var uriString = new StringBuilder("https://api.genius.com/");

            if (typeof(T) == typeof(WebPage))
                uriString.Append("web_pages");
            else
                uriString.Append(typeof(T).Name.ToLower() + "s");

            if (!string.IsNullOrWhiteSpace(id))
                uriString.Append($"/{id}");

            if (isVoteUri)
                uriString.Append($"/{voteType.ToString().ToLower()}");

            if (!string.IsNullOrWhiteSpace(additionalUrl))
                uriString.Append($"{additionalUrl}");


            if (!string.IsNullOrWhiteSpace(createdById))
            {
                uriString.Append($"?created_by_id={createdById}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(songId))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"song_id={songId}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(webPageId))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"web_page_id={webPageId}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"sort={sort}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(perPage))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"per_page={perPage}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(page))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"page={page}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(rawAnnotatableUrl))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"raw_annotatable_url={rawAnnotatableUrl}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(canonicalUrl))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"canonical_url={canonicalUrl}");
                parameterStarted = true;
            }

            if (!string.IsNullOrWhiteSpace(ogUrl))
            {
                uriString.Append(parameterStarted ? "&" : "?");
                uriString.Append($"og_url={ogUrl}");
                parameterStarted = true;
            }

            uriString.Append(parameterStarted ? "&" : "?");
            return new Uri(uriString.Append($"text_format={textFormat}").ToString());
        }
    }
}