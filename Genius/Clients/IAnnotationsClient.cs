using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     https://docs.genius.com/#annotations-h2
    /// </summary>
    public interface IAnnotationsClient
    {
        Task<HttpResponse<Annotation>> GetAnnotation(string annotationId, TextFormat textFormat);

        Task<HttpResponse<Annotation>> CreateAnnotation(AnnotationPayload annotationPayload, TextFormat textFormat);

        Task<HttpResponse<Annotation>> UpdateAnnotation(string annotationId, AnnotationPayload annotationPayload,
            TextFormat textFormat);

        Task<HttpResponse<Annotation>> DeleteAnnotation(string annotationId, TextFormat textFormat);
    }
}