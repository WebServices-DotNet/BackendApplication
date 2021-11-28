using System;
using System.Collections.Generic;
using System.Linq;
using CarFleetManager.Models;
using CarFleetManager.Repository;

namespace CarFleetManager.Services
{
    public class SpeedService
    {
        private readonly IMongoRepository<Speed> _speedRepository;

        public SpeedService(IMongoRepository<Speed> speedRepository)
        {
            _speedRepository = speedRepository;
        }

        public List<Speed> Get(string carId, DateTime start, DateTime end) =>
            _speedRepository.FilterBy(speed => speed.CarId == carId && speed.CreateDate > start && speed.CreateDate < end).ToList();

        public Speed Create(Speed speed)
        {
            _speedRepository.InsertOneAsync(speed);
            return speed;
        }
        
        public double Last(string carId)
        {
            return _speedRepository.Last(speed => speed.CarId == carId, 1).FirstOrDefault().Value;
        }
        
        public double Mean(string carId, int limit)
        {
            var tmp = _speedRepository.Last(accel => accel.CarId == carId, limit);
            return tmp.Sum(item => item.Value) / tmp.Count;
        }
        public void Drop()
        {
            _speedRepository.Drop();
        }
    }
}