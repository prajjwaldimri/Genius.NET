using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///		Undocumented API to get a song album
    /// </summary>
    public interface IAlbumsClient
    {
        Task<HttpResponse<Album>> GetAlbum(TextFormat textFormat, string albumId);
    }
}