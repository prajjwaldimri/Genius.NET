using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Genius
{
    /// <summary>
    /// Adds, removes or updates user's vote on an Annotation
    /// </summary>
    public class Voter
    {
        /// <summary>
        /// The token that is used for authorization.
        /// </summary>
        public static string AuthorizationToken { get; set; }

		/// <summary>
		/// Upvote / Downvote / Unvote for the annotation on behalf of the authenticated user.
		/// </summary>
		/// <param name="annotationId">Id for the annotation to be voted on</param>
		/// <param name="vote"></param>
		/// <returns></returns>
		private static async Task Vote(string annotationId, string vote)
	    {
			using (var client = new HttpClient())
			{
				var baseAddress = new Uri($"https://api.genius.com//annotations/{annotationId}/{vote}");
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
				await client.PutAsync(baseAddress, null).ConfigureAwait(false);
			}
		}

        /// <summary>
        /// Votes positively for the annotation on behalf of the authenticated user.
        /// </summary>
        /// <param name="annotationId">Id for the annotation to be voted on</param>
        /// <returns></returns>
        public static async Task UpVote(string annotationId)
        {
	        await Vote(annotationId, "upvote");
        }

        /// <summary>
        /// Votes negatively for the annotation on behalf of the authenticated user.
        /// </summary>
        /// <param name="annotationId">Id for the annotation to be voted on</param>
        /// <returns></returns>
        public static async Task DownVote(string annotationId)
        {
			await Vote(annotationId, "downvote");
		}

		/// <summary>
		/// Removes the authenticated user's vote (up or down) for the annotation.
		/// </summary>
		/// <param name="annotationId">Id for the annotation to be voted on</param>
		/// <returns></returns>
		public static async Task UnVote(string annotationId)
        {
			await Vote(annotationId, "unvote");
		}
	}
}
