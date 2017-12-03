# Referents

According to Genius API:

> Referents are the sections of a piece of content to which annotations are attached. Each referent is associated with a web page or a song and may have one or more annotations. Referents can be searched by the document they are attached to or by the user that created them.

> When a new annotation is created either a referent is created with it or that annotation is attached to an existing referent.

## Get a referent

You can get a referent by a `song_id` or `web_page_id` but not both. So there are two separate functions that you can use here.

``` C#
var referentBySongId = await geniusClient.ReferentsClient.GetReferentBySongId(TextFormat.Dom, "Song_Id", Created_by_id", "per_page", "page");
```

### OR

``` C#
var referentByWebPageId = await geniusClient.ReferentsClient.GetReferentByWebPageId(TextFormat.Dom, "Web_page_id");
```