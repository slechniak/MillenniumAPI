namespace MillenniumAPI.Models
{
    public interface IWeatherForecastRepository
    {
        WeatherForecast GetWeatherForecast(int Id);
        IEnumerable<WeatherForecast> GetAllWeatherForecasts();
        WeatherForecast Add(WeatherForecast weatherForecast);
        WeatherForecast Update(WeatherForecast weatherForecastChanges);
        WeatherForecast Delete(int Id);
    }
}
