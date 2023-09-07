using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookStoreApi.Models.Testplayer
{
    public class Page
    {
        [BsonId]
        //[BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? BsonId { get; set; }
        public string? id { get; set; }
        public dynamic navigationConfig { get; set; }

        public string type { get; set; }

        [BsonElement("class")]

        [JsonPropertyName("class")]
        [JsonProperty("class")]
        public string Class { get; set; }
        public List<dynamic> contents { get; set; }
    }
}
