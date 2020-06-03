using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
  public class SongClient : ISongClient
  {
    private static IGeniusRestClient _geniusRestClient;

    public SongClient(IGeniusRestClient geniusRestClient)
    {
      _geniusRestClient = geniusRestClient;
    }
    
    public async Task<SongResponse> GetSong(ulong songId)
    {
      var response = await _geniusRestClient.GetASync("/songs/" + songId + "?text_format=html");

      using (var input = new StringReader(response))
      {
        var songResponse = JSON.Deserialize<SongResponse>(input);
        if (songResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(songResponse.Meta.Status +
                                         songResponse.Meta.Message);
        }

        return songResponse;
      }
    }
  }
}