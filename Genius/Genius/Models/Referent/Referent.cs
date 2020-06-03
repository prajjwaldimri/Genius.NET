using System.Collections.Generic;
using Genius.Models.Annotation;
using Jil;

namespace Genius.Models.Referent
{
  /// <summary>
  /// Referents are the sections of a piece of content to which annotations are attached.
  /// Each referent is associated with a web page or a song and may have one or more annotations.
  /// Referents can be searched by the document they are attached to or by the user that created them.
  /// See: https://docs.genius.com/#referents-h2
  /// </summary>
  public class Referent
  {
    [JilDirective(Name = "annotator_id")] public ulong AnnotatorId { get; set; }
    
    [JilDirective(Name = "annotator_login")] public string AnnotatorLogin { get; set; }
    
    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }
    
    [JilDirective(Name = "classification")] public string Classification { get; set; }
    
    [JilDirective(Name = "featured")] public bool Featured { get; set; }
    
    [JilDirective(Name = "fragment")] public string Fragment { get; set; }
    
    [JilDirective(Name = "id")] public ulong Id { get; set; }
    
    [JilDirective(Name = "is_description")] public bool IsDescription { get; set; }
    
    [JilDirective(Name = "path")] public string Path { get; set; }
    
    [JilDirective(Name = "range")] public ReferentRange Range { get; set; }
    
    [JilDirective(Name = "song_id")] public ulong? SongId { get; set; }
    
    [JilDirective(Name = "url")] public string Url { get; set; }
    
    [JilDirective(Name = "verified_annotator_ids")] public List<ulong> VerifiedAnnotatorIds { get; set; }
    
    [JilDirective(Name = "annotatable")] public Annotatable Annotatable { get; set; }
    
    [JilDirective(Name = "annotations")] public List<Annotation.Annotation> Annotations { get; set; }
  }
}