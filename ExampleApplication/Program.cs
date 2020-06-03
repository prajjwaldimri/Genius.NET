using System;
using System.Threading.Tasks;
using Genius;
using Genius.Models.Annotation;
using Genius.Models.Referent;

namespace ExampleApplication
{
  class Program
  {
    public static async Task Main(string[] args)
    {
      try
      {
        // Genius.NET doesn't provide OAuth related wrappers.
        var client = new GeniusClient("API_KEY");
        
        // GET /annotations/:id
        var annotation = await client.AnnotationClient.GetAnnotation(10225840);

        // POST /annotations
        var newAnnotation = await client.AnnotationClient.PostAnnotation(
          new AnnotationPayload("hello **world!**",
            new ReferentPayload("http://seejohncode.com/2014/01/27/vim-commands-piping/",
              "execute commands",
              new ContextForDisplay("You may know that you can",
                " from inside of vim, with a vim command:")),
            new WebPagePayload(title: "Secret of Mana")));

        // PUT /annotations 
        var updatedAnnotation = await client.AnnotationClient.UpdateAnnotation(
          new AnnotationPayload("hello **world!**",
            new ReferentPayload("http://seejohncode.com/2014/01/27/vim-commands-piping/",
              "execute commands",
              new ContextForDisplay("You may know that you can",
                " from inside of vim, with a vim command:")),
            new WebPagePayload(title: "Secret of Mana")));

        // DELETE /annotations/:id
        var deletedAnnotation = await client.AnnotationClient.DeleteAnnotation(10225840);

        // PUT /annotations/:id/upvote
        var upvotedAnnotation = await client.AnnotationClient.UpVoteAnnotation(10225840);

        // PUT /annotations/:id/downvote
        var downvotedAnnotation = await client.AnnotationClient.DownVoteAnnotation(10225840);

        // PUT /annotations/:id/unvote
        var unvotedAnnotation = await client.AnnotationClient.UnVoteAnnotation(10225840);

        // GET /account
        var user = await client.AccountClient.GetAccount();

        // GET /referents
        var referent = await client.ReferentClient.GetReferent(webPageId: "10347");
        
        // GET /songs/:id
        var song = await client.SongClient.GetSong(378195);
        
        // GET /artists/:id
        var artist = client.ArtistClient.GetArtist(16775);
        
        // GET /artists/:id/songs
        var artistsSongs = await client.ArtistClient.GetArtistsSongs(16775, sort: "title");
        
        // GET /web_pages/lookup
        var webPage = await client.WebPageClient.GetWebPage(Uri.EscapeUriString("https://docs.genius.com"));
        
        // GET /search
        var search = client.SearchClient.Search("Kendrick Lamar");
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}