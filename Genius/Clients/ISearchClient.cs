using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    public interface ISearchClient
    {
        Task<HttpResponse<List<Hit>>> Search(TextFormat textFormat, string searchTerm);
    }
}