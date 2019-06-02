using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Genius.Clients
{
    /// <summary>
    ///     Scraped lyrics from the genius website
    /// </summary>
    public interface ILyricsClient
    {
        /// <summary>
        ///     Retrieves lyrics for a specified song
        /// </summary>
        /// <param name="songUrl">URL to the page of the song</param>
        /// <returns>string</returns>
        Task<string> GetLyrics(string songUrl);
    }
}
