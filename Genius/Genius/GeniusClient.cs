﻿using Genius.Clients;
using Genius.Clients.Interfaces;
using Genius.Core;
using Genius.Http;

namespace Genius
{
  public class GeniusClient : IGeniusClient
  {
    public IAccountClient AccountClient;
    public IAnnotationClient AnnotationClient;
    public IArtistClient ArtistClient;
    public IReferentClient ReferentClient;
    public ISearchClient SearchClient;
    public ISongClient SongClient;
    public IWebPageClient WebPageClient;

    /// <summary>
    /// Start by making an instance of GeniusClient.
    /// </summary>
    /// <param name="apiKey">See: http://genius.com/api-clients"</param>
    public GeniusClient(string apiKey)
    {
      // Initialize Genius Client
      IGeniusRestClient geniusHttpClient = GeniusRestClient.Instance;
      geniusHttpClient.SetApiKey(apiKey);

      // Inject all the necessary client services
      AccountClient = new AccountClient(geniusHttpClient);
      AnnotationClient = new AnnotationClient(geniusHttpClient);
      ReferentClient = new ReferentClient(geniusHttpClient);
      SongClient = new SongClient(geniusHttpClient);
      ArtistClient = new ArtistClient(geniusHttpClient);
      SearchClient = new SearchClient(geniusHttpClient);
      WebPageClient = new WebPageClient(geniusHttpClient);
    }
  }
}