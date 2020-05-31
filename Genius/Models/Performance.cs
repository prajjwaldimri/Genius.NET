using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Genius.Models
{
    /// <summary>
    ///	    Used in Song and Album
    /// </summary>
    [JsonConverter(typeof(PerformanceCollectionConverter))]
    public class PerformanceCollection : Dictionary<string, List<Artist>>
    {
        public PerformanceCollection() { }
        public PerformanceCollection(IDictionary<string, List<Artist>> dictionary) : base(dictionary) { }
        public PerformanceCollection(int capacity) : base(capacity) { }
    }

    class PerformanceCollectionConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = (PerformanceCollection) value;
            var list = from performance in dict
                select new Performance {Label = performance.Key, Artists = performance.Value};
            serializer.Serialize(writer, list);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = JToken.Load(reader).ToObject<List<Performance>>(serializer);
            var dict = new PerformanceCollection(list.Count);
            foreach (var relationship in list)
                dict.Add(relationship.Label, relationship.Artists);
            return dict;
        }

        public override bool CanConvert(Type objectType)
            => typeof(PerformanceCollection).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        class Performance
        {
            public string Label { get; set; }
            public List<Artist> Artists { get; set; }
        }
    }
}
