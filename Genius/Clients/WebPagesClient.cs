using System.Threading.Tasks;
using Genius.Helpers;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class WebPagesClient : IWebPagesClient
    {
        private readonly IApiConnection _apiConnection;

        /// <inheritdoc />
        public WebPagesClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        /// <inheritdoc />
        public async Task<HttpResponse<WebPage>> GetWebPage(TextFormat textFormat, string rawAnnotatableUrl = "",
            string canonicalUrl = "", string ogUrl = "")
        {
            var uri = UriHelper.CreateUri<WebPage>(textFormat.ToString().ToLower(),
                rawAnnotatableUrl: rawAnnotatableUrl, canonicalUrl: canonicalUrl, ogUrl: ogUrl);

            return await _apiConnection.Get<WebPage>(textFormat, uri: uri, jsonArrayName: "web_page");
        }
    }
}