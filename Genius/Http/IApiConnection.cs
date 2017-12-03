using System;
using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Http
{
    /// <summary>
    ///     A connection for making HTTP requests against URI Endpoints.
    ///     Provides type-independent Http methods.
    /// </summary>
    public interface IApiConnection
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T">Type of Model</typeparam>
        /// <param name="textFormat">Format of the text to be returned from the server</param>
        /// <param name="id">Any type of id.</param>
        /// <param name="uri">Uri to send HTTP Request to</param>
        /// <param name="jsonArrayName">
        ///     This parameter will be used as the name of the object inside response object when
        ///     de-serializing response from server
        /// </param>
        /// <returns></returns>
        Task<HttpResponse<T>> Get<T>(TextFormat textFormat, string id = "", Uri uri = null, string jsonArrayName = "");

        /// <summary>
        ///     POST to Genius API
        /// </summary>
        /// <typeparam name="T">Type of object to post</typeparam>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="payload">The object to send in JSON form with the POST request.</param>
        /// <param name="uri">Optional URI parameter to which to send HTTP Request</param>
        /// <returns></returns>
        Task<HttpResponse<T>> Post<T>(TextFormat textFormat, object payload, Uri uri = null);

        /// <summary>
        ///     Updates a resource on Genius.com
        /// </summary>
        /// <typeparam name="T">Type of Resource to update</typeparam>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="id">Id of resource to update</param>
        /// <param name="payload">A payload containing updated data of resource</param>
        /// <param name="uri">Uri of the http request</param>
        /// <returns></returns>
        Task<HttpResponse<T>> Put<T>(TextFormat textFormat, string id, object payload, Uri uri = null);

        /// <summary>
        ///     Deletes a resource on genius server
        /// </summary>
        /// <typeparam name="T">Type of resource</typeparam>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="id">Id of resource</param>
        /// <param name="uri">Uri of http request</param>
        /// <returns></returns>
        Task<HttpResponse<T>> Delete<T>(TextFormat textFormat, string id, Uri uri = null);

        /// <summary>
        ///     Votes on an annotation.
        /// </summary>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <param name="voteType">Upvote, Downvote or Unvote?</param>
        /// <param name="annotationId">Votes are only allowed on annotations currently.</param>
        /// <returns></returns>
        Task<HttpResponse<Annotation>> Vote(TextFormat textFormat, VoteType voteType, string annotationId);
    }
}