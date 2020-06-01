using Jil;

namespace Genius.Models.User
{
  public class UserPreferences
  {
    [JilDirective(Name = "mention_notifications")]
    public bool MentionNotifications { get; set; }

    [JilDirective(Name = "creation_comment_notifications")]
    public bool CreationCommentNotifications { get; set; }

    [JilDirective(Name = "mentioned_forum_notifications")]
    public bool MentionedForumNotifications { get; set; }

    [JilDirective(Name = "discussion_creation_notifications")]
    public bool DiscussionCreationNotifications { get; set; }

    [JilDirective(Name = "message_notifications")]
    public bool MessageNotifications { get; set; }

    [JilDirective(Name = "followed_thread_notifications")]
    public bool FollowedThreadNotifications { get; set; }

    [JilDirective(Name = "editorial_suggestion_notifications")]
    public bool EditorialSuggestionNotifications { get; set; }

    [JilDirective(Name = "forum_post_creation_notifications")]
    public bool ForumPostCreationNotifications { get; set; }
  }
}