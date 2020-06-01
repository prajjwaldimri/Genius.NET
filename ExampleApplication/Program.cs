using System;
using System.Threading.Tasks;
using Genius;

namespace ExampleApplication
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var client = new GeniusClient("YOUR_API_KEY");
      await client.Test();
    }
  }
}