using System.ComponentModel.DataAnnotations;

namespace MillenniumAPI.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        
        public DateOnly Date { get; set; }

        [Range(-90,60)]
        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [StringLength(20)]
        public string? Summary { get; set; }
    }
}