using System.Threading.Tasks;
using Genius.Models.Annotation;
using Genius.Models.Response;

namespace Genius.Clients.Interfaces
{
  /// <summary>
  /// Handles annotation related tasks. 
  /// See: https://docs.genius.com/#annotations-h2
  /// </summary>
  public interface IAnnotationClient
  {
    /// <summary>
    /// Gets data for a specific annotation.
    /// </summary>
    /// <param name="annotationId">ID of the annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> GetAnnotation(ulong annotationId);

    /// <summary>
    /// Creates a new annotation on a public web page.
    /// </summary>
    /// <param name="annotationPayload">Information required to create an Annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> PostAnnotation(AnnotationPayload annotationPayload);

    /// <summary>
    /// Updates an annotation created by the authenticated user.
    /// </summary>
    /// <param name="annotationPayload">Information required to update an Annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> UpdateAnnotation(AnnotationPayload annotationPayload);

    /// <summary>
    /// Deletes an annotation created by the authenticated user.
    /// </summary>
    /// <param name="annotationId">ID of the annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> DeleteAnnotation(ulong annotationId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="annotationId">ID of the annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> UpVoteAnnotation(ulong annotationId);

    /// <summary>
    /// Votes positively for the annotation on behalf of the authenticated user.
    /// </summary>
    /// <param name="annotationId">ID of the annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> DownVoteAnnotation(ulong annotationId);

    /// <summary>
    /// Votes negatively for the annotation on behalf of the authenticated user.
    /// </summary>
    /// <param name="annotationId">ID of the annotation</param>
    /// <returns>An object containing server status and annotation</returns>
    Task<AnnotationResponse> UnVoteAnnotation(ulong annotationId);
  }
}