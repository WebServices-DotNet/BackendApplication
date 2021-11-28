using System;
using System.Collections.Generic;
using System.Linq;
using CarFleetManager.Models;
using CarFleetManager.Repository;
using MongoDB.Driver.Linq;

namespace CarFleetManager.Services
{
    public class TemperatureService
    {
        private readonly IMongoRepository<Temperature> _temperatureRepository;

        public TemperatureService(IMongoRepository<Temperature> temperatureRepository)
        {
            _temperatureRepository = temperatureRepository;
        }

        public List<Temperature> Get(string carId, DateTime start, DateTime end) =>
            _temperatureRepository.FilterBy(temperature => temperature.CarId == carId && temperature.CreateDate > start && temperature.CreateDate < end).ToList();

        public Temperature Create(Temperature temperature)
        {
            _temperatureRepository.InsertOneAsync(temperature);
            return temperature;
        }
        public double Last(string carId)
        {
            return _temperatureRepository.Last(temperature => temperature.CarId == carId, 1).FirstOrDefault().Value;
        }
        
        public double Mean(string carId, int limit)
        {
            var tmp = _temperatureRepository.Last(accel => accel.CarId == carId, limit);
            return tmp.Sum(item => item.Value) / tmp.Count;
        }
        
        public void Drop()
        {
            _temperatureRepository.Drop();
        }
    }
}