using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    /// <summary>
    ///     Annotation is a piece of content about a part of a document
    /// </summary>
    public class AnnotationClient : IAnnotationClient
    {
        private readonly IApiConnection _apiConnection;

        /// <param name="apiConnection">Instance of apiConnection</param>
        public AnnotationClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        public async Task<HttpResponse<Annotation>> GetAnnotation(string annotationId, TextFormat textFormat)
        {
            return await _apiConnection.Get<Annotation>(textFormat, annotationId);
        }

        public async Task<HttpResponse<Annotation>> CreateAnnotation(AnnotationPayload annotationPayload,
            TextFormat textFormat)
        {
            return await _apiConnection.Post<Annotation>(textFormat, annotationPayload);
        }

        public async Task<HttpResponse<Annotation>> UpdateAnnotation(string annotationId,
            AnnotationPayload annotationPayload,
            TextFormat textFormat)
        {
            return await _apiConnection.Put<Annotation>(textFormat, annotationId, annotationPayload);
        }

        public async Task<HttpResponse<Annotation>> DeleteAnnotation(string annotationId, TextFormat textFormat)
        {
            return await _apiConnection.Delete<Annotation>(textFormat, annotationId);
        }
    }
}