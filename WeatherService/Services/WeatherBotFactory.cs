using WeatherService.Interfaces;
using WeatherService.Models.Enums;
using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Services
{
    public class WeatherBotFactory : IWeatherBotFactory
    {
        private readonly BotConfiguration _config;

        public WeatherBotFactory(BotConfiguration config)
        {
            _config = config;
        }

        public IWeatherBot CreateBot(weatherbots botType)
        {
            switch (botType)
            {
                case weatherbots.RainBot:
                    return new RainBot(_config.Threshold, _config.Message);
                case weatherbots.SunBot:
                    return new SunBot(_config.Threshold, _config.Message);
                case weatherbots.SnowBot:
                    return new SnowBot(_config.Threshold, _config.Message);
                default:
                    throw new ArgumentException("Invalid bot type");
            }
        }
    }

}
