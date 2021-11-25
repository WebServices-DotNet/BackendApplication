using System.Collections.Generic;
using CarFleetManager.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarFleetManager.Services
{
    
    public class CarService
    {
        private readonly IMongoCollection<Car> _cars;

        public CarService(ICarFleetDatabaseSettings settings)
        {
            System.Console.WriteLine($"Start connection {settings.ConnectionString}");
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
           // _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
           _cars = database.GetCollection<Car>("Cars");
        }

        public List<Car> Get()
        {
            return _cars.Find(car => true).ToList();
        }


        public Car Get(string id) =>
            _cars.Find<Car>(car => car.Id == id).FirstOrDefault();

        public Car Create(Car car)
        {
            _cars.InsertOne(car);
            return car;
        }

        public void Update(string id, Car carIn) =>
            _cars.ReplaceOne(car => car.Id == id, carIn);

        public void Remove(Car carIn) =>
            _cars.DeleteOne(car => car.Id == carIn.Id);

        public void Remove(string id) => 
            _cars.DeleteOne(car => car.Id == id);
    }
}