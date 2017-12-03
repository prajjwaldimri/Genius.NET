# Artists

An artist is how Genius represents the creator of one or more songs (or other documents hosted on Genius). It's usually a musician or group of musicians.

Artists are managed by the `ArtistsClient` in Genius.NET

## Getting an artist using `ArtistID`

``` C#
var artistInfo = geniusClient.ArtistsClient.GetArtist(TextFormat.Dom, "ARTIST_ID");
```

## Getting all songs by an Artist

``` C#
var songsByArtist = geniusClient.ArtistsClient.GetSongsByArtist(TextFormat.Dom, "ARTIST_ID");
```