# Genius.NET

.NET library to access Genius API @ (https://www.genius.com)

[![Build status](https://ci.appveyor.com/api/projects/status/mowrlrdoc4ri4q1j?svg=true)](https://ci.appveyor.com/project/prajjwaldimri/genius-net)
[![Join the chat at https://gitter.im/Genius-NET/Lobby](https://badges.gitter.im/Genius-NET/Lobby.svg)](https://gitter.im/Genius-NET/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet](https://img.shields.io/nuget/v/Prajjwal.Genius.NET.svg?maxAge=2592000?style=flat-square)](https://www.nuget.org/packages/Prajjwal.Genius.NET/1.0.0)
[![GitHub issues](https://img.shields.io/github/issues/prajjwaldimri/Genius.NET.svg?maxAge=2592000?style=flat-square)](https://github.com/prajjwaldimri/Genius.NET/issues)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg?maxAge=2592000?style=flat-square)](https://github.com/prajjwaldimri/Genius.NET/blob/master/LICENSE)
[![Contact](https://img.shields.io/badge/contact-@prajjwaldimri-642C90.svg?style=flat-square)](https://twitter.com/prajjwaldimri)
<a href="https://zenhub.com"><img src="https://raw.githubusercontent.com/ZenHubIO/support/master/zenhub-badge.png"></a>


Genius.NET is an .NET C# library to access the [Genius API](https://docs.genius.com). It is a Portable Class Library that can be used for development on all the .NET platforms except Windows Silverlight.

It is very easy to use. 

For example to retrieve a Song by Artist Id you can do:

```C#
ContentRetriever.AuthorizationToken = "<Authorization Token>";
var song = ContentRetriever.GetSongsbyArtist("16775");
```

And it will return you a Song Object which contains all the fields provided by Genius.com




