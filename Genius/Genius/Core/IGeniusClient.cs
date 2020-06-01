using Genius.Clients.Interfaces;

namespace Genius.Core
{
  public interface IGeniusClient
  {
    IAccountClient Account { get; }
  }
}