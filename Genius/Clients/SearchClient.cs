using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class SearchClient : ISearchClient
    {
        private readonly IApiConnection _apiConnection;

        /// <inheritdoc />
        public SearchClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        /// <inheritdoc />
        public async Task<HttpResponse<List<Hit>>> Search(TextFormat textFormat, string searchTerm)
        {
            var uri = new Uri($"https://api.genius.com/search?q={searchTerm}");
            return await _apiConnection.Get<List<Hit>>(textFormat, uri: uri, jsonArrayName: "hits");
        }
    }
}