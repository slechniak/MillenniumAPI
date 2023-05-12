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
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            return Ok(_weatherForecastRepository.GetAllWeatherForecasts());
        }

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> Get(int id)
        {
            var item = _weatherForecastRepository.GetWeatherForecast(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPut]
        public ActionResult<WeatherForecast> Create(WeatherForecast weatherForecast)
        {
            _weatherForecastRepository.Add(weatherForecast);
            return CreatedAtAction(nameof(Get), new { id = weatherForecast.Id }, weatherForecast);
            //return _weatherForecastRepository.Add(weatherForecast);
        }

        [HttpPatch]
        public WeatherForecast Update(WeatherForecast weatherForecastChanges)
        {
            var item = _weatherForecastRepository.GetWeatherForecast(weatherForecastChanges.Id);
            if(item == null)
            {
                NotFound();
            }
            return _weatherForecastRepository.Update(weatherForecastChanges);
        }

        [HttpDelete("{id}")]
        public WeatherForecast Delete(int id)
        {
            var item = _weatherForecastRepository.GetWeatherForecast(id);
            if (item == null)
            {
                NotFound();
            }
            return _weatherForecastRepository.Delete(id);
        }
    }
}