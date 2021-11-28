using System;
using Newtonsoft.Json;

namespace CarFleetManager
{
    public class SensorDataModel
    {
        
        [JsonProperty("value")]
        public string Value { get; set; }
        
        [JsonProperty("signal_name")]
        public string SignalName { get; set; }
        
        [JsonProperty("car_id")]
        public string CarId { get; set; }
        
        [JsonProperty("car_name")]
        public string CarName { get; set; }
    }
    
    public class AccelDataModel
    {
        
        [JsonProperty("x")]
        public double X { get; set; }
        
        [JsonProperty("y")]
        public double Y { get; set; }
        
        [JsonProperty("Z")]
        public double Z { get; set; }
    }
    public class SpeedDataModel
    {
        
        [JsonProperty("value")]
        public double Value { get; set; }
    }
    
    public class TemperatureDataModel
    {
        
        [JsonProperty("value")]
        public double Value { get; set; }
    }
    public class EngineDataModel
    {
        
        [JsonProperty("rpm")]
        public double Value { get; set; }
    }
}