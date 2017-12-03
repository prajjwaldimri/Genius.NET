using System;
using System.Threading.Tasks;
using Genius;
using Genius.Models;

namespace ExampleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Examples().Wait();
            Console.ReadLine();
        }

        private static async Task Examples()
        {
            var geniusClient = new GeniusClient("CLIENT_ACCESS_TOKEN");

            #region Annotations

            // GET an annotation by Id
            var getAnnotation = await geniusClient.AnnotationClient.GetAnnotation("10225840", TextFormat.Dom);


            // Create/POST an annotation
            var annotationPayload = new AnnotationPayload
            {
                Annotation = new Annotation {Body = new AnnotationBody {MarkDown = "hello **world!**"}},
                Referent = new Referent
                {
                    RawAnnotableUrl = "http://seejohncode.com/2014/01/27/vim-commands-piping/",
                    Fragment = "execute commands",
                    ContextForDisplay = new ContextForDisplay
                    {
                        BeforeHtml = "You may know that you can ",
                        AfterHtml = " from inside of a vim, with a vim command:"
                    }
                },
                WebPage = new WebPage
                {
                    CanonicalUrl = null,
                    OgUrl = null,
                    Title = "Secret of Mana"
                }
            };
            var postAnnotation =
                await geniusClient.AnnotationClient.CreateAnnotation(annotationPayload, TextFormat.Dom);

            // Update an annotation

            var annotationUpdatePayload = new AnnotationPayload
            {
                Annotation = new Annotation {Body = new AnnotationBody {MarkDown = "hello **world!** is very generic"}}
            };

            var updatedAnnotation =
                await geniusClient.AnnotationClient.UpdateAnnotation(postAnnotation.Response.Id,
                    annotationUpdatePayload,
                    TextFormat.Dom);

            // Delete an annotation

            var deletedAnnotation =
                await geniusClient.AnnotationClient.DeleteAnnotation(postAnnotation.Response.Id, TextFormat.Dom);

            #endregion

            #region Voting

            #endregion


            // Get account info of the authenticated user.
            var accountInfo = await geniusClient.AccountClient.GetAccountInfo();
        }
    }
}