using Genius;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Tests.Models;
using Tests.Utilities;

namespace Tests
{
    [TestClass]
    public class ArtistClientTests
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
        public async Task GetArtistsSongs_NotExistingPage()
        {
            foreach (ulong artistId in _inputData.Artists)
            {
                var songs = await _geniusClient.ArtistClient.GetArtistsSongs(artistId, sort: "title", perPage: "10", page: "3000");
                Assert.IsFalse(songs.Response.NextPage.HasValue);
            }
        }

        [TestMethod]
        public async Task GetArtistsSongs_ExistingPage()
        {
            foreach (ulong artistId in _inputData.Artists)
            {
                var songs = await _geniusClient.ArtistClient.GetArtistsSongs(artistId, sort: "title", perPage: "10", page: "1");
                Assert.IsTrue(songs.Response.NextPage.HasValue);
                Assert.IsTrue(songs.Response.Songs.Count > 0);
            }
        }
    }
}
