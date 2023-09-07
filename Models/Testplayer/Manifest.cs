using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BookStoreApi.serializers;

namespace BookStoreApi.Models.Testplayer
{
    public class Manifest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("$schema")]
        public string Schema { get; set; } = null!;
        [BsonElement("version")]
        public int Version { get; set; }

        public TestplayerSettings testPlayerSettings { get; set; } = null!;

        //[BsonSerializer(typeof(QuestionsSerializer))]
        public List<Question> questions { get; set; } = null!;
        public Assessment assessment { get; set; } = null!;
    }

    public class TestplayerSettings
    {
        public string submissionErrorAsset { get; set; } = null!;
        public string submissionErrorSupportEmail { get; set; } = null!;

    }

}
