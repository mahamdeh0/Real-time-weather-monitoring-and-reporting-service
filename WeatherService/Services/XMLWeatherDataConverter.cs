using System.Xml.Serialization;
using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class XMLWeatherDataConverter : IWeatherDataConverter
    {
        public WeatherData Convert(string inputData)
        {
            var serializer = new XmlSerializer(typeof(WeatherData));
            using (var reader = new StringReader(inputData))
            {
                return (WeatherData)serializer.Deserialize(reader);
            }
        }
    }
}
