using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    public class SearchClient : ISearchClient
    {
        private readonly IApiConnection _apiConnection;

        public SearchClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<HttpResponse<List<Hit>>> Search(TextFormat textFormat, string searchTerm)
        {
            var uri = new Uri($"https://api.genius.com/search?q={searchTerm}");
            return await _apiConnection.Get<List<Hit>>(textFormat, uri: uri, jsonArrayName: "hits");
        }
    }
}