using Jil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genius.Models.Song
{
    public class VerifiedAnnotationsBy
    {
        [JilDirective("api_path")]
        public string ApiPath { get; set; }

        [JilDirective("avatar")]
        public Avatar Avatar { get; set; }

        [JilDirective("header_image_url")]
        public string HeaderImageUrl { get; set; }

        [JilDirective("human_readable_role_for_display")]
        public string HumanReadableRoleForDisplay { get; set; }

        [JilDirective("id")]
        public ulong? Id { get; set; }

        [JilDirective("iq")]
        public ulong? Iq { get; set; }

        [JilDirective("login")]
        public string Login { get; set; }

        [JilDirective("name")]
        public string Name { get; set; }

        [JilDirective("role_for_display")]
        public string RoleForDisplay { get; set; }

        [JilDirective("url")]
        public string Url { get; set; }

        [JilDirective("current_user_metadata")]
        public VerifiedAnnotationsByCurrentUserMetadata CurrentUserMetadata { get; set; }
    }
}
