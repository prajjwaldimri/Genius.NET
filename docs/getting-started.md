# Getting Started

The Genius.NET library provides a wrapper called `GeniusClient` around all the functionalities inside the library.

Just create a new instance of `GeniusClient` and you are good to go:
``` C#
var geniusClient = new GeniusClient("API_ACCESS_TOKEN");
```

## Access Token

The `API_ACCESS_TOKEN` mentioned in the above code snippet is the access token you will get when any user authenticates using your application. 

!!! note
    It is recommended to use OAuth2 authentication.

You can read more about OAuth2 and Genius Authentication over at [Genius Docs](https://docs.genius.com/#!#%2Fauthentication-h1)

## Retrieve a Song

To test whether or not the token is working, you can simply fetch a song using the code below:

``` C#
var song = geniusClient.SongsClient.GetSong(TextFormat.Dom, "378195");
```

!!! note
    `378195` is the id of the song to be retrieved.

## HttpResponse

When you run the above code you will notice that instead of returning a `Song` object, the library returns an `HttpResponse<Song>` object. This is because every response from the Genius API includes two top level objects. A `meta` field and a `response` field and `HttpResponse<T>` contains both the fields.

`meta` field contains http status messages and error messages (if any).

`response` field contains the actual data that you want to retrieve.

So keep an eye on the `Meta` field in case of any errors.


## Text Format

Text Format is an required parameter in almost every method in Genius.NET.

According to Genius API:

`Many API requests accept a text_format query parameter that can be used to specify how text content is formatted. The value for the parameter must be one or more of plain, html, and dom. The value returned will be an object with key-value pairs of formats and results:`

- plain is just plain text, no markup

- html is a string of unescaped HTML suitable for rendering by a browser

- dom is a nested object representing and HTML DOM hierarchy that can be used to programmatically present structured content

!!! note
    The library currently supports dom only as it is the most flexible among the three.