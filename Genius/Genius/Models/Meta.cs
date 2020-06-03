using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models
{
  public class Meta
  {
    [JilDirective(Name = "status")] public ulong Status { get; set; }

    [JilDirective(Name = "message")] public string Message { get; set; }
  }
}