using WeatherService.Interfaces;
using WeatherService.Models;
using WeatherService.Models.Enums;
using WeatherService.Services.Bots;

public class WeatherBotFactory : IWeatherBotFactory
{
    private readonly Dictionary<weatherbots, BotConfiguration> _botConfigurations;

    public WeatherBotFactory(Dictionary<weatherbots, BotConfiguration> botConfigurations)
    {
        _botConfigurations = botConfigurations;
    }

    public IWeatherBot CreateBot(weatherbots botType)
    {
        if (!_botConfigurations.ContainsKey(botType))
            throw new ArgumentException("Invalid bot type");

        var config = _botConfigurations[botType];
        switch (botType)
        {
            case weatherbots.RainBot:
                return new RainBot(config.Threshold, config.Message);
            case weatherbots.SunBot:
                return new SunBot(config.Threshold, config.Message);
            case weatherbots.SnowBot:
                return new SnowBot(config.Threshold, config.Message);
            default:
                throw new ArgumentException("Invalid bot type");
        }
    }
}
