using System.Text.Json;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class JSONWeatherDataConverter : IWeatherDataConverter
    {
        public WeatherData Convert(string inputData)
        {
            try
            {
                return JsonSerializer.Deserialize<WeatherData>(inputData);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error: Failed to deserialize JSON. {ex.Message}");
                return null;
            }

        }
    }
}
