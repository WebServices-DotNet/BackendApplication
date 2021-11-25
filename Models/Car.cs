using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarFleetManager.Models
{
    public class Car
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        [BsonElement("name")]
        public string Name { get; set; }
    }
}