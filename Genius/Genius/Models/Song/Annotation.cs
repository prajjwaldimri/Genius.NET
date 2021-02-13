using Jil;
using System.Collections.Generic;

namespace Genius.Models.Song
{
  public class Annotation
  {
  [JilDirective("api_path")]
  public string ApiPath { get; set; }

  [JilDirective("body")]
  public Description Body { get; set; }

  [JilDirective("comment_count")]
  public ulong? CommentCount { get; set; }

  [JilDirective("community")]
  public bool Community { get; set; }

  [JilDirective("custom_preview")]
  public object CustomPreview { get; set; }

  [JilDirective("has_voters")]
  public bool HasVoters { get; set; }

  [JilDirective("id")]
  public ulong? Id { get; set; }

  [JilDirective("pinned")]
  public bool Pinned { get; set; }

  [JilDirective("share_url")]
  public string ShareUrl { get; set; }

  [JilDirective("source")]
  public object Source { get; set; }

  [JilDirective("state")]
  public string State { get; set; }

  [JilDirective("url")]
  public string Url { get; set; }

  [JilDirective("verified")]
  public bool Verified { get; set; }

  [JilDirective("votes_total")]
  public long? VotesTotal { get; set; }

  [JilDirective("current_user_metadata")]
  public AnnotationCurrentUserMetadata CurrentUserMetadata { get; set; }

  [JilDirective("authors")]
  public List<Author> Authors { get; set; }

  [JilDirective("cosigned_by")]
  public List<VerifiedAnnotationsBy> CosignedBy { get; set; }

  [JilDirective("rejection_comment")]
  public object RejectionComment { get; set; }

  [JilDirective("verified_by")]
  public object VerifiedBy { get; set; }
  }
}
