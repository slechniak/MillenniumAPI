using Microsoft.AspNetCore.Mvc;
using MillenniumAPI.Models;

namespace MillenniumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<WeatherForecastController> _logger;
        private IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastRepository weatherForecastRepository)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherForecastRepository.GetAllWeatherForecasts();
        }

        [HttpGet("{id}")]
        public WeatherForecast Get(int id)
        {
            return _weatherForecastRepository.GetWeatherForecast(id);
        }

        [HttpPut]
        public WeatherForecast Create(WeatherForecast weatherForecast)
        {
            return _weatherForecastRepository.Add(weatherForecast);
        }

        [HttpPatch]
        public WeatherForecast Update(WeatherForecast weatherForecastChanges)
        {
            return _weatherForecastRepository.Update(weatherForecastChanges);
        }

        [HttpDelete("{id}")]
        public WeatherForecast Delete(int id)
        {
            return _weatherForecastRepository.Delete(id);
        }
    }
}