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
            var getAnnotation = await geniusClient.AnnotationsClient.GetAnnotation("10225840", TextFormat.Dom);


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
                await geniusClient.AnnotationsClient.CreateAnnotation(annotationPayload, TextFormat.Dom);

            // Update an annotation

            var annotationUpdatePayload = new AnnotationPayload
            {
                Annotation = new Annotation {Body = new AnnotationBody {MarkDown = "hello **world!** is very generic"}}
            };

            var updatedAnnotation =
                await geniusClient.AnnotationsClient.UpdateAnnotation(postAnnotation.Response.Id,
                    annotationUpdatePayload,
                    TextFormat.Dom);

            // Delete an annotation

            var deletedAnnotation =
                await geniusClient.AnnotationsClient.DeleteAnnotation(postAnnotation.Response.Id, TextFormat.Dom);

            #endregion

            #region Voting

            // Upvote
            await geniusClient.VoteClient.Vote(VoteType.Upvote, "Annotation_ID", TextFormat.Dom);

            //Downvote
            await geniusClient.VoteClient.Vote(VoteType.Downvote, "Annotation_ID", TextFormat.Dom);

            //UnVote (Remove the vote)
            await geniusClient.VoteClient.Vote(VoteType.Unvote, "Annotation_ID", TextFormat.Dom);

            #endregion

            #region Referent

            var referentBySongId =
                await geniusClient.ReferentsClient.GetReferentBySongId(TextFormat.Dom, "Song_Id", "Created_by_id",
                    "per_page", "page");

            var referentByWebPageId =
                await geniusClient.ReferentsClient.GetReferentByWebPageId(TextFormat.Dom, "Web_page_id");

            #endregion


            // Get account info of the authenticated user.
            var accountInfo = await geniusClient.AccountsClient.GetAccountInfo();
        }
    }
}