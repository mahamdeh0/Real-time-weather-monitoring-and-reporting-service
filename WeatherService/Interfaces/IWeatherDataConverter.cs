using WeatherService.Models;

namespace WeatherService.Interfaces
{
    public interface IWeatherDataConverter
    {
        public WeatherData Convert(string inputData);
    }

}
