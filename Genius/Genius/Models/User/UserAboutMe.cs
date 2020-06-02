using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.User
{
  public class UserAboutMe
  {
    [JilDirective(Name = "dom")]
    public Dom Dom { get; set; }
  }
}