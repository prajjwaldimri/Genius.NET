# Web-Pages

>A web page is a single, publicly accessible page to which annotations may be attached. Web pages map 1-to-1 with unique, canonical URLs.

`WebPagesClient` is used to retrieve webpages in Genius.NET

## Get/lookup a webpage

> Information about a web page retrieved by the page's full URL (including protocol). The returned data includes Genius's ID for the page, which may be used to look up associated referents with the /referents endpoint.

> Data is only available for pages that already have at least one annotation.

> Provide as many of the following variants of the URL as possible:

``` C#
var webPage = geniusClient.WebPagesClient.GetWebPage(TextFormat.Dom, "URL");
```