using System.Threading.Tasks;
using Genius.Http;
using Genius.Models;

namespace Genius.Clients
{
    /// <inheritdoc />
    public class AnnotationsClient : IAnnotationsClient
    {
        private readonly IApiConnection _apiConnection;

        /// <param name="apiConnection">Instance of apiConnection</param>
        public AnnotationsClient(IApiConnection apiConnection)
        {
            _apiConnection = apiConnection;
        }

        /// <inheritdoc />
        public async Task<HttpResponse<Annotation>> GetAnnotation(string annotationId, TextFormat textFormat)
        {
            return await _apiConnection.Get<Annotation>(textFormat, annotationId);
        }

        /// <inheritdoc />
        public async Task<HttpResponse<Annotation>> CreateAnnotation(AnnotationPayload annotationPayload,
            TextFormat textFormat)
        {
            return await _apiConnection.Post<Annotation>(textFormat, annotationPayload);
        }

        /// <inheritdoc />
        public async Task<HttpResponse<Annotation>> UpdateAnnotation(string annotationId,
            AnnotationPayload annotationPayload,
            TextFormat textFormat)
        {
            return await _apiConnection.Put<Annotation>(textFormat, annotationId, annotationPayload);
        }

        /// <inheritdoc />
        public async Task<HttpResponse<Annotation>> DeleteAnnotation(string annotationId, TextFormat textFormat)
        {
            return await _apiConnection.Delete<Annotation>(textFormat, annotationId);
        }
    }
}