using Jil;
using System.Collections.Generic;

namespace Genius.Models.Song
{
  public class SongCurrentUserMetadata
  {
    [JilDirective("permissions")]
    public List<string> Permissions { get; set; }

    [JilDirective("excluded_permissions")]
    public List<string> ExcludedPermissions { get; set; }

    [JilDirective("interactions")]
    public Interactions Interactions { get; set; }

    [JilDirective("relationships")]
    public IqByAction Relationships { get; set; }

    [JilDirective("iq_by_action")]
    public IqByAction IqByAction { get; set; }
  }
}
