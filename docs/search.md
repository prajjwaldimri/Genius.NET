# Search

Search is managed by the `SearchClient`

## Search for anything

```C#
var searchResult = await geniusClient.SearchClient.Search(TextFormat.Dom, "Kendrick%20Lamar");
```