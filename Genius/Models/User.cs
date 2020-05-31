using System.Collections.Generic;

namespace Genius.Models
{
    /// <summary>
    ///     Any simple user at Genius.com
    /// </summary>
    public class User
    {
        public UserAboutMe AboutMe { get; set; }
        public string ApiPath { get; set; }
        public List<object> AvailableIdentityProviders { get; set; }
        public Avatar Avatar { get; set; }
        public string CustomHeaderImageUrl { get; set; }
        public string Email { get; set; }
        public int? FollowedUsersCount { get; set; }
        public int? FollowersCount { get; set; }
        public string HeaderImageUrl { get; set; }
        public string HumanReadableRoleForDisplay { get; set; }
        public string Id { get; set; }
        public List<UserIdentities> Identities { get; set; }
        public int? Iq { get; set; }
        public string IqForDisplay { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public UserPreferences Preferences { get; set; }
        public string RoleForDisplay { get; set; }
        public List<object> RolesForDisplay { get; set; }
        public string UnreadGroupsInboxCount { get; set; }
        public string UnreadMainActivityInboxCount { get; set; }
        public string UnreadMessagesCount { get; set; }
        public string UnreadNewsFeedInboxCount { get; set; }
        public string Url { get; set; }
        public VirtualIqEventTypeMap VirtualIqEventTypeMap { get; set; }
        public CurrentUserMetadata CurrentUserMetadata { get; set; }
        public Artist Artist { get; set; }
        public UserStats Stats { get; set; }
    }

    public class VirtualIqEventTypeMap
    {
        public string CreatedPinnedAnnotation { get; set; }
        public string CreatedCommunityAnnotation { get; set; }
    }

    public class UserStats
    {
        public int? AllActivitiesCount { get; set; }
        public int? AnnotationsCount { get; set; }
        public int? AnswersCount { get; set; }
        public int? CommentsCount { get; set; }
        public int? ForumPostsCount { get; set; }
        public int? PyongsCount { get; set; }
        public int? QuestionsCount { get; set; }
        public int? TranscriptionsCount { get; set; }
    }

    public class UserPreferences
    {
        public bool MentionNotifications { get; set; }
        public bool CreationCommentNotifications { get; set; }
        public bool MentionedForumNotifications { get; set; }
        public bool ForumPostCreationNotifications { get; set; }
        public bool MessageNotifications { get; set; }
        public bool FollowedThreadNotifications { get; set; }
        public bool EditorialSuggestionNotifications { get; set; }
    }

    public class UserIdentities
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
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
        public bool? Pyong { get; set; }
        public bool? Following { get; set; }
    }

    public class CurrentUserRelationships
    {
        public string PinnedRole { get; set; }
    }

    #endregion
}