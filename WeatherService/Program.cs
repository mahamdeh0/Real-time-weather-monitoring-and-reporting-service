using WeatherService;
using WeatherService.Services;
using WeatherService.Utilities;

class Program
{
    static void Main()
    {
        var configFilePath = @"C:\Users\maham\Desktop\WeatherService\WeatherService\botconfig.json";
        var botConfigs = BotConfigurationLoader.LoadFromFile(configFilePath);
        var botFactory = new WeatherBotFactory(botConfigs);
        var bots = botConfigs.Keys.Where(botType => botConfigs[botType].Enabled) .Select(botFactory.CreateBot).ToList();

        var weatherService = new WeatherServices(bots);
        var jsonConverter = new JSONWeatherDataConverter();
        var xmlConverter = new XMLWeatherDataConverter();
        var menu = new ShowMainMenu(weatherService, jsonConverter, xmlConverter);
        menu.ShowMenu();
    }
}
