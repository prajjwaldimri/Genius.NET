using Jil;

namespace Genius.Models.Song
{
    public class ClientTimestamps
    {
        [JilDirective("updated_by_human_at")]
        public ulong? UpdatedByHumanAt { get; set; }

        [JilDirective("lyrics_updated_at")]
        public ulong? LyricsUpdatedAt { get; set; }
    }
}