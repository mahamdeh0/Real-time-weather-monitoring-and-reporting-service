using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class WeatherServices : IWeatherService
    {
        private readonly List<IWeatherBot> _bots;

        public WeatherServices(List<IWeatherBot> bots)
        {
            _bots = bots;
        }

        public void ProcessWeatherData(string inputData, IWeatherDataConverter converter)
        {
            var data = converter.Convert(inputData);
            NotifyBots(data);
        }

        private void NotifyBots(WeatherData data)
        {
            foreach (var bot in _bots)
            {
                bot.Activate(data);
            }
        }
    }
}
