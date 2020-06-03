using System.Collections.Generic;
using Jil;
// ReSharper disable ClassNeverInstantiated.Global

namespace Genius.Models.Song
{
  public class SongRelationship
  {
    [JilDirective(Name = "relationship_type")] public string RelationshipType;
    
    [JilDirective(Name = "type")] public string Type;
    
    [JilDirective(Name = "songs")] public List<Song> Songs;
  }
}