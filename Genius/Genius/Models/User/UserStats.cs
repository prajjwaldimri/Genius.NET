using Jil;

// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.User
{
  public class UserStats
  {
    [JilDirective(Name = "annotations_count")]
    public ulong AnnotationsCount { get; set; }

    [JilDirective(Name = "answers_count")] public ulong AnswersCount { get; set; }

    [JilDirective(Name = "comments_count")]
    public ulong CommentsCount { get; set; }

    [JilDirective(Name = "forum_posts_count")]
    public ulong ForumPostsCount { get; set; }

    [JilDirective(Name = "pyongs_count")] public ulong PyongsCount { get; set; }

    [JilDirective(Name = "questions_count")]
    public ulong QuestionsCount { get; set; }

    [JilDirective(Name = "transcriptions_count")]
    public ulong TranscriptionsCount { get; set; }
  }
}