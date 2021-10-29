using System;
using Newtonsoft.Json;

namespace CarFleetManager
{
    public class SensorDataModel
    {
        
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}