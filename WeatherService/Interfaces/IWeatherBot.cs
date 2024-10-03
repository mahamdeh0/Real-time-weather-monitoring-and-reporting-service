using WeatherService.Models;

namespace WeatherService.Interfaces
{
    public interface IWeatherBot
    {
        void Activate(WeatherData weatherData);
    }

}
