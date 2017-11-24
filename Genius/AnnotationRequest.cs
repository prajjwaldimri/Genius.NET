using Genius.Data;
using System;
using System.Threading.Tasks;

namespace Genius
{
	public class AnnotationRequest : GeniusGetRequest
	{
		public AnnotationRequest(string authorizationToken) : base("annotations", authorizationToken)
		{
		}

		/// <summary>
		/// Returns object containing Annotation and Referent returned by "GET /annotations/:artistId"
		/// Annotation data returned from the API includes both the substance of the annotation and the necessary
		/// information for displaying it in its original context.
		/// For more info see https://docs.genius.com/#annotations-h2
		/// </summary>
		/// <param name="annotationId">Id for the Annotation</param>
		/// <returns></returns>
		public async Task<AnnotationResult> GetAnnotationbyId(string annotationId)
		{
			if (string.IsNullOrEmpty(annotationId)) throw new ArgumentException("Value cannot be null or empty.", nameof(annotationId));

			var response = await GetString($"{annotationId}");
			var annotation = ProcessContent<Annotation>(response, "annotation");
			var referent = ProcessContent<Referent>(response, "referent");

			return new AnnotationResult { Annotation = annotation, Referent = referent };
		}
	}

	/// <summary>
	/// Stores result returned from GetAnnotation Method in the form of Annotation and Referent Classes
	/// </summary>
	public class AnnotationResult
	{
		public Annotation Annotation { get; set; }
		public Referent Referent { get; set; }
	}
}