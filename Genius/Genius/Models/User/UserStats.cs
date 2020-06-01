using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.User
{
  public class UserStats
  {
    [JilDirective(Name = "annotations_count")] ulong AnnotationsCount { get; set; }
    
    [JilDirective(Name = "answers_count")] ulong AnswersCount { get; set; }
    
    [JilDirective(Name = "comments_count")] ulong CommentsCount { get; set; }
    
    [JilDirective(Name = "forum_posts_count")] ulong ForumPostsCount { get; set; }
    
    [JilDirective(Name = "pyongs_count")] ulong PyongsCount { get; set; }
    
    [JilDirective(Name = "questions_count")] ulong QuestionsCount { get; set; }
    
    [JilDirective(Name = "transcriptions_count")] ulong TranscriptionsCount { get; set; }
  }
}