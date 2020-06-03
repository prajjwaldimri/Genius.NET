// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Jil;

namespace Genius.Models.Response
{
  public class SearchResponse
  {
    [JilDirective(Name = "meta")] public Meta Meta { get; set; }

    [JilDirective(Name = "response")] public SearchData Response { get; set; }
  }

  public class SearchData
  {
    [JilDirective(Name = "hits")] public List<SearchHit> Hits { get; set; }
  }
}