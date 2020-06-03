// ReSharper disable ClassNeverInstantiated.Global

using System.Collections.Generic;
using Genius.Models.User;
using Jil;

namespace Genius.Models.Annotation
{
  public class Annotation
  {
    [JilDirective(Name = "api_path")] public string ApiPath { get; set; }

    [JilDirective(Name = "body")] public HtmlFormat Body { get; set; }

    [JilDirective(Name = "comment_count")] public ulong CommentCount { get; set; }

    [JilDirective(Name = "community")] public bool Community { get; set; }

    [JilDirective(Name = "custom_preview")]
    public string CustomPreview { get; set; }

    [JilDirective(Name = "has_voters")] public bool HasVoters { get; set; }

    [JilDirective(Name = "id")] public ulong Id { get; set; }

    [JilDirective(Name = "pinned")] public bool Pinned { get; set; }

    [JilDirective(Name = "share_url")] public string ShareUrl { get; set; }

    [JilDirective(Name = "source")] public string Source { get; set; }

    [JilDirective(Name = "state")] public string State { get; set; }

    [JilDirective(Name = "url")] public string Url { get; set; }

    [JilDirective(Name = "verified")] public bool Verified { get; set; }

    [JilDirective(Name = "votes_total")] public ulong VotesTotal { get; set; }

    [JilDirective(Name = "current_user_metadata")]
    public UserMetadata CurrentUserMetadata { get; set; }

    [JilDirective(Name = "authors")] public List<Author> Authors { get; set; }

    [JilDirective(Name = "cosigned_by")] public List<string> CosignedBy { get; set; }

    [JilDirective(Name = "rejection_comment")]
    public string RejectionComment { get; set; }

    [JilDirective(Name = "verified_by")] public User.User VerifiedBy { get; set; }
  }
}