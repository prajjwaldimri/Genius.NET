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
        /// <summary>
        ///     Votes on an annotation
        /// </summary>
        /// <param name="voteType">Type of vote to cast</param>
        /// <param name="id">ID of the annotation</param>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <returns></returns>
        Task<HttpResponse<Annotation>> Vote(VoteType voteType, string id, TextFormat textFormat);
    }
}