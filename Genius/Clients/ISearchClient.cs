using System.Collections.Generic;
using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     The search capability covers all content hosted on Genius.
    ///     https://docs.genius.com/#!#search-h2
    /// </summary>
    public interface ISearchClient
    {
        /// <summary>
        ///     Search documents hosted on Genius
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="searchTerm">The term to search for</param>
        /// <returns></returns>
        Task<HttpResponse<List<Hit>>> Search(TextFormat textFormat, string searchTerm);
    }
}