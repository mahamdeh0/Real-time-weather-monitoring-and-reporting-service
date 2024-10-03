using Newtonsoft.Json;
using WeatherService.Models;
using WeatherService.Models.Enums;

namespace WeatherService
{
    public static class BotConfigurationLoader
    {
        public static Dictionary<Weatherbots, BotConfiguration> LoadFromFile(string filePath)
        {
            var result = new Dictionary<Weatherbots, BotConfiguration>();

            try
            {
                var json = File.ReadAllText(filePath);
                var Configs = JsonConvert.DeserializeObject<Dictionary<string, BotConfiguration>>(json);

                foreach (var x in Configs)
                {
                    if (Enum.TryParse(x.Key, out Weatherbots botType))
                    {
                        result[botType] = x.Value;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: The file at path '{filePath}' was not found. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            return result;
        }
    }
}
