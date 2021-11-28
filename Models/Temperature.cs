using System;
using CarFleetManager.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace CarFleetManager.Models
{
    
    [BsonCollection("temperature")]
    public class Temperature : Document
    {
        public Temperature(string carId, double value, DateTime createDate)
        {
            CarId = carId;
            Value = value;
            CreateDate = createDate;
        }

        [BsonElement("car_id")]
        public string CarId { get; set; }
        
        
        [BsonElement("value")]
        public double Value { get; set; }
        
        [BsonElement("createDate")]
        public DateTime CreateDate { get; set; }
    }
}