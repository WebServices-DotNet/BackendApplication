using System;
using System.Collections.Generic;
using System.Linq;
using CarFleetManager.Models;
using CarFleetManager.Repository;

namespace CarFleetManager.Services
{
    public class AccelService
    {
        private readonly IMongoRepository<Accel>  _accelRepository;

        public AccelService(IMongoRepository<Accel> accelRepository)
        {
            _accelRepository = accelRepository;
        }

        public List<Accel> Get(string carId, DateTime start, DateTime end) =>
            _accelRepository.FilterBy(accel => accel.CarId == carId && accel.CreateDate > start && accel.CreateDate < end).ToList();

        public Accel Create(Accel accel)
        {
            _accelRepository.InsertOneAsync(accel);
            return accel;
        }
        
        public double Last(string carId)
        {
            return _accelRepository.Last(accel => accel.CarId == carId, 1).FirstOrDefault().Power;
        }
        
        public double Mean(string carId, int limit)
        {
            var tmp = _accelRepository.Last(accel => accel.CarId == carId, limit);
            return tmp.Sum(item => item.Power) / tmp.Count;
        }

        public void Drop()
        {
            _accelRepository.Drop();
        }
    }
}