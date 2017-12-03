# Songs

According to Genius API:

> A song is a document hosted on Genius. It's usually music lyrics.
> Data for a song includes details about the document itself and information about all the referents that are attached to it, including the text to which they refer.

Songs are managed by `SongsClient` in Genius.NET

## Getting a Song

``` C#
var song = geniusClient.SongsClient.GetSong(TextFormat.Dom, "SONG_ID");
```