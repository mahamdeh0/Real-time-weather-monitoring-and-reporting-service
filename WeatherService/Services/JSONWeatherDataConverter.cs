using System.Text.Json;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class JSONWeatherDataConverter : IWeatherDataConverter
    {
        public WeatherData Convert(string inputData) => JsonSerializer.Deserialize<WeatherData>(inputData);
    }
}
