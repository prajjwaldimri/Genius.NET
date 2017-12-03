using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     A web page is a single, publicly accessible page to which annotations may be attached.
    ///     https://docs.genius.com/#web_pages-h2
    /// </summary>
    public interface IWebPagesClient
    {
        /// <summary>
        ///     Gets data for a web page
        /// </summary>
        /// <param name="textFormat"></param>
        /// <param name="rawAnnotatableUrl">The URL as it would appear in browser</param>
        /// <param name="canonicalUrl">The URL as specified by an appropriate <link /> tag.</param>
        /// <param name="ogUrl">The URL as specified by an og:url <meta /> tag in a page's <head /></param>
        /// <returns></returns>
        Task<HttpResponse<WebPage>> GetWebPage(TextFormat textFormat, string rawAnnotatableUrl = "",
            string canonicalUrl = "",
            string ogUrl = "");
    }
}