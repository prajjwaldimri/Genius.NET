using System.Threading.Tasks;
using Genius.Models;

namespace Genius.Clients
{
    /// <summary>
    ///     Annotation is a piece of content about a part of a document
    ///     https://docs.genius.com/#annotations-h2
    /// </summary>
    public interface IAnnotationsClient
    {
        /// <summary>
        ///     Retrieves Data for a specific annotation.
        /// </summary>
        /// <param name="annotationId">ID for the annotation</param>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <returns></returns>
        Task<HttpResponse<Annotation>> GetAnnotation(string annotationId, TextFormat textFormat);

        /// <summary>
        ///     Creates a new annotation on a public web page.
        /// </summary>
        /// <param name="annotationPayload"></param>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <returns>Created Annotation</returns>
        Task<HttpResponse<Annotation>> CreateAnnotation(AnnotationPayload annotationPayload, TextFormat textFormat);

        /// <summary>
        ///     Updates previously created annotation by the authenticated user.
        /// </summary>
        /// <param name="annotationId"></param>
        /// <param name="annotationPayload"></param>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <returns>Updated Annotation</returns>
        Task<HttpResponse<Annotation>> UpdateAnnotation(string annotationId, AnnotationPayload annotationPayload,
            TextFormat textFormat);

        /// <summary>
        ///     Deletes an annotation created by the authenticated user.
        /// </summary>
        /// <param name="annotationId"></param>
        /// <param name="textFormat">Format for text bodies related to the document</param>
        /// <returns></returns>
        Task<HttpResponse<Annotation>> DeleteAnnotation(string annotationId, TextFormat textFormat);
    }
}