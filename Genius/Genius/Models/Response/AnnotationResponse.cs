using Jil;

// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Response
{
  /// <summary>
  /// An annotation is a piece of content about a part of a document.
  /// The document may be a song (hosted on Genius) or a web page (hosted anywhere).
  /// The part of a document that an annotation is attached to is called a referent.
  /// Annotation data returned from the API includes both the substance of the annotation
  /// and the necessary information for displaying it in its original context.
  /// See: https://docs.genius.com/#annotations-h2
  /// </summary>
  public class AnnotationResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public AnnotationData Response { get; set; }
  }

  public class AnnotationData
  {
    [JilDirective(Name = "annotation")] public Annotation.Annotation Annotation { get; set; }

    [JilDirective(Name = "referent")] public Referent.Referent Referent { get; set; }
  }
}