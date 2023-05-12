using System.Security.Cryptography.X509Certificates;

namespace MillenniumAPI.Models
{
    public class MockWeatherForecastRepository : IWeatherForecastRepository
    {
        private List<WeatherForecast> _weatherForecastList;

        public MockWeatherForecastRepository()
        {
            string[] Summaries = new string[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            int id = 1;
            _weatherForecastList = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Id = id++,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToList();
        }

        public WeatherForecast Add(WeatherForecast weatherForecast)
        {
            //throw new NotImplementedException();
            weatherForecast.Id = _weatherForecastList.Max(e => e.Id) + 1;
            _weatherForecastList.Add(weatherForecast);
            return weatherForecast;
        }

        public WeatherForecast Delete(int Id)
        {
            //throw new NotImplementedException();
            WeatherForecast weatherForecast = _weatherForecastList.FirstOrDefault(e => e.Id == Id);
            if (weatherForecast != null)
            {
                _weatherForecastList.Remove(weatherForecast);
            }
            return weatherForecast;
        }

        public IEnumerable<WeatherForecast> GetAllWeatherForecasts()
        {
            //throw new NotImplementedException();
            return _weatherForecastList;
        }

        public WeatherForecast GetWeatherForecast(int Id)
        {
            //throw new NotImplementedException();
            return _weatherForecastList.FirstOrDefault(e => e.Id == Id);
        }

        public WeatherForecast Update(WeatherForecast weatherForecastChanges)
        {
            //throw new NotImplementedException();
            WeatherForecast weatherForecast = _weatherForecastList.FirstOrDefault(e => e.Id == weatherForecastChanges.Id);
            if (weatherForecast != null)
            {
                weatherForecast.Date = weatherForecastChanges.Date;
                weatherForecast.TemperatureC = weatherForecastChanges.TemperatureC;
                weatherForecast.Summary = weatherForecastChanges.Summary;
            }
            return weatherForecast;
        }
    }
}
