using Jil;

namespace Genius.Models.User
{
  public class UserAvatar
  {
    [JilDirective(Name = "tiny")] public Avatar TinyAvatar { get; set; }

    [JilDirective(Name = "thumb")] public Avatar ThumbAvatar { get; set; }

    [JilDirective(Name = "small")] public Avatar SmallAvatar { get; set; }

    [JilDirective(Name = "medium")] public Avatar MediumAvatar { get; set; }
  }
}