using System.Collections.Generic;
using Newtonsoft.Json;

namespace Genius.Models
{
    public class User
    {
        [JsonProperty(PropertyName = "about_me")]
        public UserAboutMe AboutMe { get; set; }

        [JsonProperty(PropertyName = "api_path")]
        public string ApiPath { get; set; }

        [JsonProperty(PropertyName = "available_identity_providers")]
        public List<object> AvailableIdentityProviders { get; set; }
        public Avatar Avatar { get; set; }

        [JsonProperty(PropertyName = "custom_header_image_url")]
        public string CustomHeaderImageUrl { get; set; }

        public string Email { get; set; }

        [JsonProperty(PropertyName = "followed_users_count")]
        public string FollowedUsersCount { get; set; }

        [JsonProperty(PropertyName = "followers_count")]
        public string FollowersCount { get; set; }

        [JsonProperty(PropertyName = "header_image_url")]
        public string HeaderImageUrl { get; set; }

        [JsonProperty(PropertyName = "human_readable_role_for_display")]
        public string HumanReadableRoleForDisplay { get; set; }
        public string Id { get; set; }
        public List<UserIdentities> Identities { get; set; }
        public string Iq { get; set; }

        [JsonProperty(PropertyName = "iq_for_display")]
        public string IqForDisplay { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }

        [JsonProperty(PropertyName = "photo_url")]
        public string PhotoUrl { get; set; }

        public UserPreferences Preferences { get; set; }

        [JsonProperty(PropertyName = "role_for_display")]
        public string RoleForDisplay { get; set; }

        [JsonProperty(PropertyName = "roles_for_display")]
        public List<object> RolesForDisplay { get; set; }

        [JsonProperty(PropertyName = "unread_groups_inbox_count")]
        public string UnreadGroupsInboxCount { get; set; }

        [JsonProperty(PropertyName = "unread_main_activity_inbox_count")]
        public string UnreadMainActivityInboxCount { get; set; }

        [JsonProperty(PropertyName = "unread_messages_count")]
        public string UnreadMessagesCount { get; set; }

        [JsonProperty(PropertyName = "unread_newsfeed_inbox_count")]
        public string UnreadNewsFeedInboxCount { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "virtual_iq_event_type_map")]
        public VirtualIqEventTypeMap VirtualIqEventTypeMap { get; set; }

        public CurrentUserMetadata CurrentUserMetadata { get; set; }
        public Artist Artist { get; set; }
        public UserStats Stats { get; set; }
    }


    public class VirtualIqEventTypeMap
    {
        [JsonProperty(PropertyName = "created_pinned_annotation")]
        public string CreatedPinnedAnnotation { get; set; }

        [JsonProperty(PropertyName = "created_community_annotation")]
        public string CreatedCommunityAnnotation { get; set; }
    }
    public class UserStats
    {
        [JsonProperty(PropertyName = "all_activities_count")]
        public string AllActivitiesCount { get; set; }

        [JsonProperty(PropertyName = "annotations_count")]
        public string AnnotationsCount { get; set; }

        [JsonProperty(PropertyName = "answers_count")]
        public string AnswersCount { get; set; }

        [JsonProperty(PropertyName = "comments_count")]
        public string CommentsCount { get; set; }

        [JsonProperty(PropertyName = "forum_posts_count")]
        public string ForumPostsCount { get; set; }

        [JsonProperty(PropertyName = "pyongs_count")]
        public string PyongsCount { get; set; }

        [JsonProperty(PropertyName = "questions_count")]
        public string QuestionsCount { get; set; }

        [JsonProperty(PropertyName = "transcriptions_count")]
        public string TranscriptionsCount { get; set; }
    }
    public class UserPreferences
    {
        [JsonProperty(PropertyName = "mention_notifications")]
        public bool MentionNotifications { get; set; }

        [JsonProperty(PropertyName = "creation_comment_notifications")]
        public bool CreationCommentNotifications { get; set; }

        [JsonProperty(PropertyName = "mentioned_forum_notifications")]
        public bool MentionedForumNotifications { get; set; }

        [JsonProperty(PropertyName = "forum_post_creation_notifications")]
        public bool ForumPostCreationNotifications { get; set; }

        [JsonProperty(PropertyName = "message_notifications")]
        public bool MessageNotifications { get; set; }

        [JsonProperty(PropertyName = "followed_thread_notifications")]
        public bool FollowedThreadNotifications { get; set; }

        [JsonProperty(PropertyName = "editorial_suggestion_notifications")]
        public bool EditorialSuggestionNotifications { get; set; }

    }
    public class UserIdentities
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }

        [JsonProperty(PropertyName = "custom_properties")]
        public string CustomProperties { get; set; }
    }
    public class UserAboutMe
    {
        public SongandUserAnnotationDom Dom { get; set; }
    }
    public class CurrentUserMetadata
    {
        public CurrentUserInteractions Interactions { get; set; }
        public CurrentUserRelationships Relationships { get; set; }
        public List<string> Permissions { get; set; }
    }

    #region Sub-classes for CurrentUserMetadataClass
    public class CurrentUserInteractions
    {
        public bool Pyong { get; set; }
        public bool Following { get; set; }
    }

    public class CurrentUserRelationships
    {
        [JsonProperty(PropertyName = "pinned_role")]
        public string PinnedRole { get; set; }
    }
    #endregion
}
