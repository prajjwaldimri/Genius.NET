using System;
using System.Text;
using Genius.Models;

namespace Genius.Helpers
{
    internal static class UriHelper
    {
        /// <summary>
        ///     A helper method which can create URI for multiple types of requests.
        /// </summary>
        /// <typeparam name="T">Type of model for which to create the URI</typeparam>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="id">Any id to add to the Uri</param>
        /// <param name="isVoteUri">Is the uri is being created for voting or not</param>
        /// <param name="voteType">Type of vote to add to the uri</param>
        /// <param name="perPage">Number of results to return per request</param>
        /// <param name="page">
        ///     Paginated offset (e.g., <![CDATA[per_page=5&page=3]]> returns songs 11-15)
        /// </param>
        /// <param name="createdById">Id of a user to get referents for</param>
        /// <param name="songId">Id of a song</param>
        /// <param name="webPageId">Id of a web-page</param>
        /// <param name="sort">title(default) or popularity</param>
        /// <param name="additionalUrl">Any other manual additions to the url</param>
        /// <param name="rawAnnotatableUrl">The url as it would appear in a browser.</param>
        /// <param name="canonicalUrl">The URL as specified by appropriate tags.</param>
        /// <param name="ogUrl">The URl as specified by an og:url tag</param>
        /// <returns>An URI</returns>
        public static Uri CreateUri<T>(string textFormat, string id = "", bool isVoteUri = false,
            VoteType voteType = VoteType.Unvote, string perPage = "", string page = "", string createdById = "",
            string songId = "", string webPageId = "", string sort = "", string additionalUrl = "",
            string rawAnnotatableUrl = "", string canonicalUrl = "", string ogUrl = "")
        {
            //TODO: This function is very large and unmaintainable. Consider refactoring this.
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