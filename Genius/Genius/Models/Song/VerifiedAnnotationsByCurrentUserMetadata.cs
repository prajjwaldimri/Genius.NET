using Jil;
using System.Collections.Generic;

namespace Genius.Models.Song
{
    public class VerifiedAnnotationsByCurrentUserMetadata
    {
        [JilDirective("permissions")]
        public List<object> Permissions { get; set; }

        [JilDirective("excluded_permissions")]
        public List<string> ExcludedPermissions { get; set; }

        [JilDirective("interactions")]
        public Interactions Interactions { get; set; }
    }
}