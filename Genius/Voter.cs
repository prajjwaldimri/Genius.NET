using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Genius
{
    /// <summary>
    /// Adds, removes or updates user's vote on an Annotation
    /// </summary>
    public class Voter
    {
        /// <summary>
        /// 
        /// </summary>
        public static string AuthorizationToken { get; set; }

        /// <summary>
        /// Votes positively for the annotation on behalf of the authenticated user.
        /// </summary>
        /// <param name="annotationId">Id for the annotation to be voted on</param>
        /// <returns></returns>
        public static async Task UpVote(string annotationId)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com//annotations/{annotationId}/upvote");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.PutAsync(baseAddress, null).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Votes negatively for the annotation on behalf of the authenticated user.
        /// </summary>
        /// <param name="annotationId">Id for the annotation to be voted on</param>
        /// <returns></returns>
        public static async Task DownVote(string annotationId)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com//annotations/{annotationId}/downvote");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.PutAsync(baseAddress, null).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Removes the authenticated user's vote (up or down) for the annotation.
        /// </summary>
        /// <param name="annotationId">Id for the annotation to be voted on</param>
        /// <returns></returns>
        public static async Task UnVote(string annotationId)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com//annotations/{annotationId}/unvote");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.PutAsync(baseAddress, null).ConfigureAwait(false);
            }
        }
    }
}
