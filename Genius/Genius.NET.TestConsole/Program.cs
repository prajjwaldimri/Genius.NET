using System;

namespace Genius.NET.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ContentRetriever.AuthorizationToken = "<Authorization Token>";
            //ContentRetriever.GetAccountInfo();
            var a = ContentRetriever.GetAnnotationbyId("10225840").Result;
            //ContentRetriever.GetReferentsbySongId("12");

            //ContentRetriever.GetArtistById("16775");
            //ContentRetriever.GetSongsbyArtist("16775");
            //ContentRetriever.GetWebPagebyUrl("https://docs.genius.com");
            //Search.AuthenticationToken = "ldslsxMqENSqAk5u1xExamNhiKVRv_IaVz_xQU2q--QYdhi-jlxGZ9LAM0Pvyffe";
            //Search.SearchTerm = "Sia";
            //ContentPoster.CreateorUpdateAnnotation(true, "**hello**", "http://seejohncode.com/2014/01/27/vim-commands-piping/", "execute commands",
            //   "You may know that you can", "from inside of vim, with a vim command:", title: "Secret of Mana");
            //Search.DoSearch();
            /*
            try
            {
                var song = ContentRetriever.GetSongbyId("378195");
                Console.WriteLine(song.Result);
            }
            catch (AggregateException e)
            {
                Debug.WriteLine(e);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            */
            Console.ReadLine();
        }
    }
}
