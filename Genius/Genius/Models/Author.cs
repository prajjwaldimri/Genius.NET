// ReSharper disable ClassNeverInstantiated.Global

using Jil;

namespace Genius.Models
{
  public class Author
  {
    [JilDirective(Name="attribution")]
    public decimal Attribution { get; set; }
    
    [JilDirective(Name="pinned_role")]
    public string PinnedRole { get; set; }
    
    [JilDirective(Name="user")]
    public User.User User { get; set; }
  }
}