using Jil;

namespace Genius.Models
{
  public class Identity
  {
    [JilDirective(Name = "id")] public ulong Id { get; set; }

    [JilDirective(Name = "name")] public string Name { get; set; }

    [JilDirective(Name = "provider")] public string Provider { get; set; }
  }
}