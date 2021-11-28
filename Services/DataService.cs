using System;
using System.Diagnostics;
using CarFleetManager.Models;
using Newtonsoft.Json;

namespace CarFleetManager.Services
{
    public class DataService
    {
        
        private readonly CarService _carService;
        private readonly AccelService _accelService;
        private readonly SpeedService _speedService;
        private readonly EngineService _engineService;
        private readonly TemperatureService _temperatureService;

        public DataService(CarService carService, AccelService accelService, SpeedService speedService, EngineService engineService, TemperatureService temperatureService)
        {
            _carService = carService;
            _accelService = accelService;
            _speedService = speedService;
            _engineService = engineService;
            _temperatureService = temperatureService;
        }
        public void Update(SensorDataModel data)
        {

            if (_carService.Get(data.CarId) == null)
            {
                _carService.Create(new Car(data.CarId, data.CarName));
            }
            
            if (data.SignalName == "accel")
            {
                var value = JsonConvert.DeserializeObject<AccelDataModel>(data.Value);
                Debug.Assert(value != null, nameof(value) + " != null");
                var power = Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
                _accelService.Create(new Accel(data.CarId, value.X, value.Y, value.Z, power, DateTime.Now));

            } else if (data.SignalName == "speed")
            {
                var value = JsonConvert.DeserializeObject<SpeedDataModel>(data.Value);
                Debug.Assert(value != null, nameof(value) + " != null");
                _speedService.Create(new Speed(data.CarId, value.Value * 3.6, DateTime.Now));
                
            } else if (data.SignalName == "temperature")
            {
                var value = JsonConvert.DeserializeObject<TemperatureDataModel>(data.Value);
                Debug.Assert(value != null, nameof(value) + " != null");
                _temperatureService.Create(new Temperature(data.CarId, (value.Value - 32)*5.0/9.0, DateTime.Now));
                
            } else if (data.SignalName == "engine")
            {
                var value = JsonConvert.DeserializeObject<EngineDataModel>(data.Value);
                Debug.Assert(value != null, nameof(value) + " != null");
                _engineService.Create(new EngineSpeed(data.CarId, value.Value * 1000, DateTime.Now));
            }
            
        }
    }
}