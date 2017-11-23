using System;
using System.Threading.Tasks;

namespace Genius
{
	public class VoteRequest : GeniusPutRequest
	{
		public VoteRequest(string authorizationToken) : base("annotations", authorizationToken)
		{
		}

		/// <summary>
		/// Vote on behalf of the authenticated user for the annotation.
		/// </summary>
		/// <param name="votetype">Whether to upvote, downvote, or remove the vote for an annotation (see <paramref name="annotationId"/>)</param>
		/// <param name="annotationId">Id for the annotation to be voted on.</param>
		public async Task Vote(VoteType votetype, string annotationId)
		{
			if (!Enum.IsDefined(typeof(VoteType), votetype))
				throw new ArgumentOutOfRangeException(nameof(votetype), "Value should be defined in the VoteType enum.");
			if (string.IsNullOrWhiteSpace(annotationId))
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(annotationId));

			await Put($"{annotationId}/{votetype.ToString().ToLower()}");
		}

		/// <summary>
		/// All different types of votes.
		/// </summary>
		public enum VoteType
		{
			Upvote,
			Downvote,
			Unvote
		}
	}
}