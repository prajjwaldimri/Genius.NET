using Genius;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class GeniusTests
    {
        private static GeniusClient _geniusClient;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            string apiKey = ConfigurationManager.AppSettings["API_KEY"]?.ToString();
            _geniusClient = new GeniusClient(apiKey);
        }

        [TestMethod]
        public async Task SearchForArtistsSongs_NotExistingPage()
        {
            var songs = await _geniusClient.ArtistClient.GetArtistsSongs(16775, sort: "title", perPage: "10", page: "3000");
            Assert.IsFalse(songs.Response.NextPage.HasValue);
        }

        [TestMethod]
        public async Task SearchForArtistsSongs_ExistingPage()
        {
            var songs = await _geniusClient.ArtistClient.GetArtistsSongs(16775, sort: "title", perPage: "10", page: "1");
            Assert.IsTrue(songs.Response.NextPage.HasValue);
            Assert.IsTrue(songs.Response.Songs.Count > 0);
        }
    }
}
