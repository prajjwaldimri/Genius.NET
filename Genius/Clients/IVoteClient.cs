using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     Provides methods to upvote, downvote and unvote
    ///     https://docs.genius.com/#annotations-h2
    ///     Note: Currently users can only vote on annotations.
    /// </summary>
    public interface IVoteClient
    {
        Task<HttpResponse<Annotation>> Vote(VoteType voteType, string id, TextFormat textFormat);
    }
}