// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Jil;

namespace Genius.Models.Response
{
  /// <summary>
  /// Referents are the sections of a piece of content to which annotations are attached.
  /// Each referent is associated with a web page or a song and may have one or more annotations.
  /// Referents can be searched by the document they are attached to or by the user that created them.
  /// See: https://docs.genius.com/#referents-h2
  /// </summary>
  public class ReferentResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public ReferentData Response { get; set; }
  }

  public class ReferentData
  {
    [JilDirective(Name = "referents")] public List<Referent.Referent> Referents { get; set; }
  }
}