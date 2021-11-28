using CarFleetManager.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarFleetManager.Models
{
 
    [BsonCollection("cars")]
    public class Car : Document
    {

        public Car(string carId, string name)
        {
            Name = name;
            CarId = carId;
        }
        
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("car_id")]
        public string CarId { get; set; }
    }
}