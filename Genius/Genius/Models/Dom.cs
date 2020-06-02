using System.Collections.Generic;
using Jil;

// ReSharper disable ClassNeverInstantiated.Global


namespace Genius.Models
{
  public class Dom
  {
    [JilDirective(Name="tag")]
    public string Tag { get; set; }
    
    [JilDirective(Name="children")]
    public List<DomChildren> Children { get; set; }
  }
  
  public class DomChildren
  {
    [JilDirective(Name="tag")]
    public string Tag { get; set; }
    
    [JilDirective(Name="children")]
    public List<string> Children { get; set; }
  }
}