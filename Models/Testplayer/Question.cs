using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models.Testplayer
{
    public class Question
    {
        [BsonId]
        public string? BsonId { get; set; }
        public string id { get; set; } = null!;
        public dynamic markers { get; set; }
    }
}
