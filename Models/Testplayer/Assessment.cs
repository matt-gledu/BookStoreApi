using MongoDB.Bson.Serialization.Attributes;

namespace BookStoreApi.Models.Testplayer
{
    public class Assessment
    {
        public string type { get; set; }
        public dynamic themeRefs { get; set; }
        public List<Section> sections { get; set; } 
    }

    public class Section
    {
        [BsonId]
        [BsonIgnoreIfNull]
        public string? BsonId { get; set; }
        public string type { get; set; }
        public List<Page> pages { get; set; }
    }

}
