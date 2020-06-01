using System.Collections.Generic;
using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.User
{
  public class User
  {
    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }

    [JilDirective(Name = "available_identity_providers")]
    public List<string> AvailableIdentityProviders { get; set; }

    [JilDirective(Name = "avatar")] public UserAvatar Avatar { get; set; }

    [JilDirective(Name = "custom_header_image_url")]
    public string CustomHeaderImageUrl { get; set; }

    [JilDirective(Name = "email")] public string Email { get; set; }

    [JilDirective(Name = "followed_users_count")]
    public ulong FollowedUsersCount { get; set; }

    [JilDirective(Name = "followers_count")]
    public ulong FollowersCount { get; set; }

    [JilDirective(Name = "header_image_url")]
    public string HeaderImageUrl { get; set; }

    [JilDirective(Name = "human_readable_role_for_display")]
    public string HumanReadableRoleForDisplay { get; set; }

    [JilDirective(Name = "id")] public ulong Id { get; set; }

    [JilDirective(Name = "identities")] public List<Identity> Identities { get; set; }

    [JilDirective(Name = "iq")] public ulong Iq { get; set; }

    [JilDirective(Name = "iq_for_display")]
    public string IqForDisplay { get; set; }

    [JilDirective(Name = "login")] public string Login { get; set; }

    [JilDirective(Name = "name")] public string Name { get; set; }

    [JilDirective(Name = "photo_url")] public string PhotoUrl { get; set; }

    [JilDirective(Name = "preferences")] public UserPreferences Preferences { get; set; }

    [JilDirective(Name = "role_for_display")]
    public string RoleForDisplay { get; set; }

    [JilDirective(Name = "roles_for_display")]
    public List<string> RolesForDisplay { get; set; }

    [JilDirective(Name = "unread_groups_inbox_count")]
    public ulong UnreadGroupsInboxCount { get; set; }

    [JilDirective(Name = "unread_main_activity_inbox_count")]
    public ulong UnreadMainActivityInboxCount { get; set; }

    [JilDirective(Name = "unread_messages_count")]
    public ulong UnreadMessagesCount { get; set; }

    [JilDirective(Name = "unread_news_feed_inbox_count")]
    public ulong UnreadNewsFeedInboxCount { get; set; }

    [JilDirective(Name = "url")] public string Url { get; set; }

    [JilDirective(Name="current_user_metadata")]
    public UserMetadata CurrentUserMetadata { get; set; }

    [JilDirective(Name = "artist")] public string Artist { get; set; }

    [JilDirective(Name = "stats")] public UserStats Stats { get; set; }
  }
}