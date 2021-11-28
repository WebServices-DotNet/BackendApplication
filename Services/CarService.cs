using System.Collections.Generic;
using System.Linq;
using CarFleetManager.Models;
using CarFleetManager.Repository;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarFleetManager.Services
{
    
    public class CarService
    {
        private readonly IMongoRepository<Car>  _carRepository;

        public CarService(IMongoRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public List<Car> Get()
        {
            return _carRepository.FilterBy(car => true).ToList();
        }

        public Car Get(string carId) =>
            _carRepository.FindOne(car => car.CarId == carId);

        public Car Create(Car car)
        {
            _carRepository.InsertOne(car);
            return car;
        }

        public void Remove(Car carIn) =>
            _carRepository.DeleteManyAsync(car => car.CarId == carIn.CarId);

        public void Remove(string carId) => 
            _carRepository.DeleteManyAsync(car => car.CarId == carId);
        
        public void Drop()
        {
            _carRepository.Drop();
        }
    }
}