using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model
{
    public class Identifier
    {
        [BsonId]
        public ObjectId ID { get; set; }
    }
}
