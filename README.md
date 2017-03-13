# Genius.NET

.NET library to access Genius API @ (<https://www.genius.com>)

[![Build status](https://ci.appveyor.com/api/projects/status/mowrlrdoc4ri4q1j?svg=true)](https://ci.appveyor.com/project/prajjwaldimri/genius-net)
[![Join the chat at https://gitter.im/Genius-NET/Lobby](https://badges.gitter.im/Genius-NET/Lobby.svg)](https://gitter.im/Genius-NET/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet](https://img.shields.io/nuget/v/Genius.NET.svg?maxAge=2592000?style=flat-square)](https://www.nuget.org/packages/Genius.NET)
[![GitHub issues](https://img.shields.io/github/issues/prajjwaldimri/Genius.NET.svg?maxAge=2592000?style=flat-square)](https://github.com/prajjwaldimri/Genius.NET/issues)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg?maxAge=2592000?style=flat-square)](https://github.com/prajjwaldimri/Genius.NET/blob/master/LICENSE)
[![Contact](https://img.shields.io/badge/contact-@prajjwaldimri-642C90.svg?style=flat-square)](https://twitter.com/prajjwaldimri)
<a href="https://zenhub.com"><img src="https://raw.githubusercontent.com/ZenHubIO/support/master/zenhub-badge.png"></a>


Genius.NET is an .NET C# library to access the [Genius API](https://docs.genius.com). It is a Portable Class Library that targets [.Net Standard 1.1](https://docs.microsoft.com/en-us/dotnet/articles/standard/library)

# Installation

To install Genius.NET, run the following command in Nuget's [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console)

``` Nuget
Install-Package Genius.NET
```

# Usage

Please read the [Wiki](https://github.com/prajjwaldimri/Genius.NET/wiki) for full instructions.


To retrieve a Song by Artist Id:

```C#
ContentRetriever.AuthorizationToken = "<Authorization Token>";
var song = ContentRetriever.GetSongsbyArtist("16775");
```

And it will return you a Song Object which contains all the fields provided by Genius.com
