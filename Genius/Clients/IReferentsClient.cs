using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     Referents are the sections of a piece of content to which annotations are attached.
    ///     https://docs.genius.com/#referents-h2
    /// </summary>
    public interface IReferentsClient
    {
        /// <summary>
        ///     Gets referents by song id.
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="songId">ID of a song to get referents for</param>
        /// <param name="createdById">ID of a user to get referents for</param>
        /// <param name="perPage">Number of results to return per request</param>
        /// <param name="page">
        ///     Paginated offset (e.g., <![CDATA[per_page=5&page=3]]> returns songs 11-15)
        /// </param>
        /// <returns></returns>
        Task<HttpResponse<Referent>> GetReferentBySongId(TextFormat textFormat, string songId, string createdById = "",
            string perPage = "", string page = "");

        /// <summary>
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="webPageId">ID of a web page to get referents for</param>
        /// <param name="createdById">ID of a user to get referents for</param>
        /// <param name="perPage">Number of results to return per request</param>
        /// <param name="page">
        ///     Paginated offset (e.g., <![CDATA[per_page=5&page=3]]> returns songs 11-15)
        /// </param>
        /// <returns></returns>
        Task<HttpResponse<Referent>> GetReferentByWebPageId(TextFormat textFormat, string webPageId,
            string createdById = "", string perPage = "", string page = "");
    }
}