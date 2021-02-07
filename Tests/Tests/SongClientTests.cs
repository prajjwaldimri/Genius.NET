using Genius;
using Genius.Models.Response;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Tests.Models;
using Tests.Utilities;

namespace Tests
{
    [TestClass]
    public class SongClientTests
    {
        private static GeniusClient _geniusClient;
        private static TestInputData _inputData;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _geniusClient = GeniusClientInitializer.GetClient();
            _inputData = TestInputData.GetFromJsonFile();
        }

        [TestMethod]
        public async Task GetSongs()
        {
            foreach (ulong songId in _inputData.Songs)
            {
                SongResponse song = await _geniusClient.SongClient.GetSong(songId);
                Assert.IsNotNull(song.Response.Song);
            }
        }
    }
}
