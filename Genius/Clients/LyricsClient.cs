using Genius.Http;
using System.Threading.Tasks;
using AngleSharp;
using System.Linq;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class LyricsClient : ILyricsClient
    {
        private readonly IApiConnection _apiConnection;

        /// <inheritdoc />
        public LyricsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        /// <inheritdoc />
        public async Task<string> GetLyrics(string songUrl)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(songUrl);
            var lyricsHtml = document.QuerySelectorAll("div").Where(s => s.ClassName == "lyrics").First();

            return lyricsHtml.TextContent.Trim();
        }
    }
}
