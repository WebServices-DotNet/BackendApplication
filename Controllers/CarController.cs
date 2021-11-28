using System;
using System.Collections.Generic;
using CarFleetManager.Models;
using CarFleetManager.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarFleetManager.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly CarService _carService;
        private readonly AccelService _accelService;
        private readonly SpeedService _speedService;
        private readonly EngineService _engineService;
        private readonly TemperatureService _temperatureService;

        public CarController(CarService carService, AccelService accelService, SpeedService speedService, EngineService engineService, TemperatureService temperatureService)
        {
            _carService = carService;
            _accelService = accelService;
            _speedService = speedService;
            _engineService = engineService;
            _temperatureService = temperatureService;
        }

        // get all cars
        [HttpGet]
        public ActionResult<List<String>> Get()  {
            
            var cars = _carService.Get().ConvertAll(input => input.CarId);
            return cars;
        }
        
        // get specific car 
        [HttpGet("{id}")]
        public ActionResult<Car> Get(string id)
        {
            var car = _carService.Get(id);

            if (car == null)
            {
                return NotFound();
            }
            return car;
        }
        
        // get speed of specific car
        [HttpGet("{id}/speed")]
        public ActionResult<List<SampleDataResponse>> GetSpeed(string id, [FromQuery(Name = "start")] DateTime start, [FromQuery(Name = "end")] DateTime end)
        {
            return _speedService.Get(id, start, end).ConvertAll<SampleDataResponse>(input => new SampleDataResponse(input.Value, input.CreateDate));
        }
        
        // get accel of specific car
        [HttpGet("{id}/accel")]
        public ActionResult<List<SampleDataResponse>> GetAccel(string id, [FromQuery(Name = "start")] DateTime start, [FromQuery(Name = "end")] DateTime end)
        {
            return _accelService.Get(id, start, end).ConvertAll<SampleDataResponse>(input => new SampleDataResponse(input.Power, input.CreateDate));
        }
        
        // get engine of specific car
        [HttpGet("{id}/engine")]
        public ActionResult<List<SampleDataResponse>> GetEngine(string id, [FromQuery(Name = "start")] DateTime start, [FromQuery(Name = "end")] DateTime end)
        {
            return _engineService.Get(id, start, end).ConvertAll<SampleDataResponse>(input => new SampleDataResponse(input.Value, input.CreateDate));
        }
        
        // get temperature of specific car
        [HttpGet("{id}/temperature")]
        public ActionResult<List<SampleDataResponse>> GetTemperature(string id, [FromQuery(Name = "start")] DateTime start, [FromQuery(Name = "end")] DateTime end)
        {
            return _temperatureService.Get(id, start, end).ConvertAll<SampleDataResponse>(input => new SampleDataResponse(input.Value, input.CreateDate));
        }
        
        // get stats of specific car
        [HttpGet("{id}/stats")]
        public ActionResult<StatisticsResponse> GetStats(string id)
        {
            var stat = new StatisticsResponse();
            
            stat.Accel(_accelService.Last(id), _accelService.Mean(id, 100));
            stat.Speed(_speedService.Last(id), _speedService.Mean(id, 100));
            stat.Engine(_engineService.Last(id), _engineService.Mean(id, 100));
            stat.Temperature(_temperatureService.Last(id), _temperatureService.Mean(id, 100));
            
            return stat;
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _carService.Remove(id);
            return NoContent();
        }
        
        [HttpDelete("all")]
        public IActionResult DeleteDataBase(string id)
        {
            System.Console.WriteLine("Drop database!!!!!");
            _accelService.Drop();
            _carService.Drop();
            _speedService.Drop();
            _temperatureService.Drop();
            _engineService.Drop();
            return NoContent();
        }
    }
}