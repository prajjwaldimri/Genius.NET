using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Genius.Clients.Interfaces;
using Genius.Http;
using Genius.Models.Annotation;
using Genius.Models.Response;
using Jil;

namespace Genius.Clients
{
  public class AnnotationClient : IAnnotationClient
  {
    private static IGeniusRestClient _geniusRestClient;

    public AnnotationClient(IGeniusRestClient geniusRestClient)
    {
      _geniusRestClient = geniusRestClient;
    }

    public async Task<AnnotationResponse> GetAnnotation(ulong annotationId)
    {
      var response = await _geniusRestClient.GetASync("/annotations/" + annotationId + "?text_format=html");

      using (var input = new StringReader(response))
      {
        var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
        if (annotationResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(annotationResponse.Meta.Status +
                                         annotationResponse.Meta.Message);
        }

        return annotationResponse;
      }
    }

    public async Task<AnnotationResponse> PostAnnotation(AnnotationPayload annotationPayload)
    {
      using (var output = new StringWriter())
      {
        JSON.Serialize(annotationPayload, output);
        var response = await _geniusRestClient.PostASync("/annotations/",
          output.ToString() + "?text_format=html");

        using (var input = new StringReader(response))
        {
          var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
          if (annotationResponse.Meta.Status >= 400)
          {
            throw new HttpRequestException(annotationResponse.Meta.Status +
                                           annotationResponse.Meta.Message);
          }

          return annotationResponse;
        }
      }
    }

    public async Task<AnnotationResponse> UpdateAnnotation(AnnotationPayload annotationPayload)
    {
      using (var output = new StringWriter())
      {
        JSON.Serialize(annotationPayload, output);
        var response = await _geniusRestClient.PostASync("/annotations/",
          output.ToString() + "?text_format=html");

        using (var input = new StringReader(response))
        {
          var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
          if (annotationResponse.Meta.Status >= 400)
          {
            throw new HttpRequestException(annotationResponse.Meta.Status +
                                           annotationResponse.Meta.Message);
          }

          return annotationResponse;
        }
      }
    }

    public async Task<AnnotationResponse> DeleteAnnotation(ulong annotationId)
    {
      var response = await _geniusRestClient.DeleteASync("/annotations/" + annotationId + "?text_format=html");

      using (var input = new StringReader(response))
      {
        var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
        if (annotationResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(annotationResponse.Meta.Status +
                                         annotationResponse.Meta.Message);
        }

        return annotationResponse;
      }
    }

    public async Task<AnnotationResponse> UpVoteAnnotation(ulong annotationId)
    {
      var response = await _geniusRestClient.PutASync("/annotations/" + annotationId
                                                                      + "/upvote" + "?text_format=html");

      using (var input = new StringReader(response))
      {
        var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
        if (annotationResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(annotationResponse.Meta.Status +
                                         annotationResponse.Meta.Message);
        }

        return annotationResponse;
      }
    }

    public async Task<AnnotationResponse> DownVoteAnnotation(ulong annotationId)
    {
      var response = await _geniusRestClient.PutASync("/annotations/" + annotationId
                                                                      + "/downvote" + "?text_format=html");

      using (var input = new StringReader(response))
      {
        var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
        if (annotationResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(annotationResponse.Meta.Status +
                                         annotationResponse.Meta.Message);
        }

        return annotationResponse;
      }
    }

    public async Task<AnnotationResponse> UnVoteAnnotation(ulong annotationId)
    {
      var response = await _geniusRestClient.PutASync("/annotations/" + annotationId
                                                                      + "/unvote" + "?text_format=html");

      using (var input = new StringReader(response))
      {
        var annotationResponse = JSON.Deserialize<AnnotationResponse>(input);
        if (annotationResponse.Meta.Status >= 400)
        {
          throw new HttpRequestException(annotationResponse.Meta.Status +
                                         annotationResponse.Meta.Message);
        }

        return annotationResponse;
      }
    }
  }
}