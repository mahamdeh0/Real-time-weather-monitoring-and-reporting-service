using Newtonsoft.Json;
using WeatherService.Models;
using WeatherService.Models.Enums;

namespace WeatherService
{
    public static class BotConfigurationLoader
    {
        public static Dictionary<weatherbots, BotConfiguration> LoadFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var Configs = JsonConvert.DeserializeObject<Dictionary<string, BotConfiguration>>(json);

            var result = new Dictionary<weatherbots, BotConfiguration>();

            foreach (var x in Configs)
            {
                if (Enum.TryParse(x.Key, out weatherbots botType))
                {
                    result[botType] = x.Value;
                }
            }

            return result;
        }
    }
}
