# Genius.NET

.NET library to access Genius API @ (<https://www.genius.com>)

[![NuGet](https://img.shields.io/nuget/v/Genius.svg?maxAge=2592000&style=for-the-badge&logo=nuget)](https://www.nuget.org/packages/Genius.NET)
[![GitHub issues](https://img.shields.io/github/issues/prajjwaldimri/Genius.NET.svg?maxAge=2592000&style=for-the-badge&logo=github)](https://github.com/prajjwaldimri/Genius.NET/issues)
[![license](https://img.shields.io/github/license/mashape/apistatus.svg?maxAge=2592000&style=for-the-badge)](https://github.com/prajjwaldimri/Genius.NET/blob/master/LICENSE)
[![Contact](https://img.shields.io/badge/contact-@prajjwaldimri-642C90.svg?style=for-the-badge&logo=telegram)](https://t.me/prajjwaldimri)


Genius.NET is C# library to access the Genius REST API. It is a .NETCore and Portable Class Library that can be used for
 development on Windows, Windows RT, Windows Phone, Mono, Xamarin Android and Xamarin iOS.

This project adheres to the Contributor Covenant [code of conduct](CODE_OF_CONDUCT.md).
By participating, you are expected to uphold this code. Please report unacceptable behavior to prajjwaldimri@outlook.com

## Installation

To install Genius.NET, run the following command in Nuget's [Package Manager Console](https://docs.nuget.org/docs/start-here/using-the-package-manager-console)

``` Nuget
Install-Package Genius.NET
```

## Usage

Please refer to the [Example Project](https://github.com/prajjwaldimri/Genius.NET/tree/master/ExampleApplication) 
for tutorial on how to use the library.


To retrieve a Song:

```C#
var client = new GeniusClient("API_KEY");
var song = await client.SongClient.GetSong(378195);
```
