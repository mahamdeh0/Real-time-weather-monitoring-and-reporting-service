using WeatherService.Interfaces;
using WeatherService.Models;
using WeatherService.Models.Enums;
using WeatherService.Services.Bots;

public class WeatherBotFactory : IWeatherBotFactory
{
    private readonly Dictionary<Weatherbots, BotConfiguration> _botConfigurations;

    public WeatherBotFactory(Dictionary<Weatherbots, BotConfiguration> botConfigurations)
    {
        _botConfigurations = botConfigurations;
    }

    public IWeatherBot CreateBot(Weatherbots botType)
    {
        if (!_botConfigurations.ContainsKey(botType))
            throw new ArgumentException("Invalid bot type");

        var config = _botConfigurations[botType];
        switch (botType)
        {
            case Weatherbots.RainBot:
                return new RainBot(config.Threshold, config.Message);
            case Weatherbots.SunBot:
                return new SunBot(config.Threshold, config.Message);
            case Weatherbots.SnowBot:
                return new SnowBot(config.Threshold, config.Message);
            default:
                throw new ArgumentException("Invalid bot type");
        }
    }
}
