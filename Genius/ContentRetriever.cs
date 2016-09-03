using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius
{
    public class ContentRetriever
    {
        public static string AuthorizationToken { get; set; }
        /// <summary>
        /// Returns object containing Annotation and Referent returned by "GET /annotations/:id"
        /// Annotation data returned from the API includes both the substance of the annotation and the necessary
        /// information for displaying it in its original context.
        /// For more info see https://docs.genius.com/#annotations-h2
        /// </summary>
        /// <param name="id">Id for the Annotation</param>
        /// <returns></returns>
        public static async Task<GetAnnotationResult> GetAnnotation(double id)
        {
            using (var client = new HttpClient())
            {
                var baseAddress = new Uri($"https://api.genius.com/annotations/{id}");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthorizationToken);
                var response = await client.GetAsync(baseAddress);
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();
                    var jToken = JToken.Parse(result);
                    var jsonAnnotation = jToken.SelectToken("response").SelectToken("annotation");
                    var jsonReferent = jToken.SelectToken("response").SelectToken("referent");
                    var annotationObject = JsonConvert.DeserializeObject<Annotation>(jsonAnnotation.ToString());
                    var referentObject = JsonConvert.DeserializeObject<Referent>(jsonReferent.ToString());
                    return new GetAnnotationResult { Annotation = annotationObject, Referent = referentObject };
                }
            }
        }
    }

    /// <summary>
    /// Stores result returned from GetAnnotation Method in the form of Annotation and Referent Classes
    /// </summary>
    public class GetAnnotationResult
    {
        public Annotation Annotation { get; set; }
        public Referent Referent { get; set; }
    }


}
