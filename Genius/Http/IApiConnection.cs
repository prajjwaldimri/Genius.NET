using System;
using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Http
{
    public interface IApiConnection
    {
        Task<HttpResponse<T>> Get<T>(TextFormat textFormat, string id = "", Uri uri = null, string jsonArrayName = "");

        Task<HttpResponse<T>> Post<T>(TextFormat textFormat, object payload, Uri uri = null);

        Task<HttpResponse<T>> Put<T>(TextFormat textFormat, string id, object payload, Uri uri = null);

        Task<HttpResponse<T>> Delete<T>(TextFormat textFormat, string id, Uri uri = null);

        Task<HttpResponse<Annotation>> Vote(TextFormat textFormat, VoteType voteType, string annotationId);
    }
}