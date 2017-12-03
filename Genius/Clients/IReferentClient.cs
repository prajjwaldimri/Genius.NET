using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     Referents are the sections of a piece of content to which annotations are attached.
    ///     https://docs.genius.com/#referents-h2
    /// </summary>
    public interface IReferentClient
    {
        Task<HttpResponse<Referent>> GetReferentBySongId(TextFormat textFormat, string songId, string createdById = "",
            string perPage = "", string page = "");

        Task<HttpResponse<Referent>> GetReferentByWebPageId(TextFormat textFormat, string webPageId,
            string createdById = "", string perPage = "", string page = "");
    }
}