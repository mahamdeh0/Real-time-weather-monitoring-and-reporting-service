using System.Xml.Serialization;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class XMLWeatherDataConverter : IWeatherDataConverter
    {
        public WeatherData Convert(string inputData)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(WeatherData));
                using (var reader = new StringReader(inputData))
                {
                    return (WeatherData)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: Failed to deserialize XML. {ex.Message}");
                return null;
            }

        }
    }
}
