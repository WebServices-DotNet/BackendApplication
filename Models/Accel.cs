using System;
using CarFleetManager.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace CarFleetManager.Models
{
    [BsonCollection("accel")]
    public class Accel : Document
    {
        public Accel(string carId, double x, double y, double z, double power, DateTime createDate)
        {
            CarId = carId;
            X = x;
            Y = y;
            Z = z;
            Power = power;
            CreateDate = createDate;
        }

        [BsonElement("car_id")]
        public string CarId { get; set; }
        
        [BsonElement("x")]
        public double X { get; set; }
        
        [BsonElement("y")]
        public double Y { get; set; }
        
        [BsonElement("z")]
        public double Z { get; set; }
        
        [BsonElement("power")]
        public double Power { get; set; }
        
        [BsonElement("createDate")]
        public DateTime CreateDate { get; set; }
    }
}