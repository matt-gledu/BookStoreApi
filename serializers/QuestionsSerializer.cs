using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using BookStoreApi.Models.Testplayer;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace BookStoreApi.serializers
{
    public class QuestionsSerializer : SerializerBase<List<Question>>, IBsonArraySerializer
    {
        private static readonly IBsonSerializer<Question> itemSerializer = BsonSerializer.LookupSerializer<Question>();

        public override void Serialize(BsonSerializationContext ctx, BsonSerializationArgs args, List<Question> list)
        {
            ctx.Writer.WriteStartArray();

            if (list is null)
            {
                ctx.Writer.WriteEndArray();
                return;
            }

            foreach (var item in list)
            {
                itemSerializer.Serialize(ctx, item);
            }

            ctx.Writer.WriteEndArray();
        }

        public override List<Question> Deserialize(BsonDeserializationContext ctx, BsonDeserializationArgs args)
        {
            switch (ctx.Reader.CurrentBsonType)
            {
                case BsonType.Array:
                    var list = new List<Question>();
                    ctx.Reader.ReadStartArray();
                    while (ctx.Reader.ReadBsonType() != BsonType.EndOfDocument)
                    {
                        var a = ctx;
                        list.Add(itemSerializer.Deserialize(ctx));
                    }
                    ctx.Reader.ReadEndArray();
                    return list;

                case BsonType.Null:
                    ctx.Reader.ReadNull();
                    return null;

                default:
                    throw new SerializationException("Cannot deserialize!");
            }
        }

        public bool TryGetItemSerializationInfo(out BsonSerializationInfo serializationInfo)
        {
            serializationInfo = new BsonSerializationInfo(null, itemSerializer, itemSerializer.ValueType);
            return true;
        }
    }
}
