using System;
using System.Collections.Generic;
using System.Linq;
using CarFleetManager.Models;
using CarFleetManager.Repository;

namespace CarFleetManager.Services
{
    public class EngineService
    {
        private readonly IMongoRepository<EngineSpeed> _engineRepository;

        public EngineService(IMongoRepository<EngineSpeed> engineRepository)
        {
            _engineRepository = engineRepository;
        }

        public List<EngineSpeed> Get(string carId, DateTime start, DateTime end) =>
            _engineRepository.FilterBy(engine => engine.CarId == carId && engine.CreateDate > start && engine.CreateDate < end).ToList();

        public EngineSpeed Create(EngineSpeed engine)
        {
            _engineRepository.InsertOneAsync(engine);
            return engine;
        }
        public double Last(string carId)
        {
            return _engineRepository.Last(engine => engine.CarId == carId, 1).FirstOrDefault().Value;
        }
        
        public double Mean(string carId, int limit)
        {
            var tmp = _engineRepository.Last(accel => accel.CarId == carId, limit);
            return tmp.Sum(item => item.Value) / tmp.Count;
        }
        public void Drop()
        {
            _engineRepository.Drop();
        }
    }
}