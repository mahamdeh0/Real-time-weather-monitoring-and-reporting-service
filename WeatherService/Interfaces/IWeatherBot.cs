using WeatherService.Models;

namespace WeatherService.Interfaces
{
    public interface IWeatherBot
    {
       public void Activate(WeatherData weatherData);

    }
}
