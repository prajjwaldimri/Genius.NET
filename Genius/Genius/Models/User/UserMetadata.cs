using System.Collections.Generic;
using Jil;

namespace Genius.Models.User
{
  public class UserMetadata
  {
    [JilDirective(Name = "permissions")] public List<string> Permissions { get; set; }

    [JilDirective(Name = "excluded_permissions")]
    public List<string> ExcludedPermissions { get; set; }

    [JilDirective(Name = "features")] public List<string> Features { get; set; }
  }
}