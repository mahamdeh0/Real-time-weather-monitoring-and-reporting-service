using WeatherService.Interfaces;

namespace WeatherService.Utilities
{
    public class ShowMainMenu
    {
        private readonly IWeatherService _weatherService;
        private readonly IWeatherDataConverter _jsonConverter;
        private readonly IWeatherDataConverter _xmlConverter;

        public ShowMainMenu(IWeatherService weatherService,IWeatherDataConverter jsonConverter,IWeatherDataConverter xmlConverter)
        {
            _weatherService = weatherService;
            _jsonConverter = jsonConverter;
            _xmlConverter = xmlConverter;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Weather Monitoring Service Menu:");
                Console.WriteLine("1. Enter weather data");
                Console.WriteLine("2. Exit");
                Console.Write("Please choose an option (1 or 2): ");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Enter weather data(JSON or XML):");
                    var inputData = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    IWeatherDataConverter converter = DetermineConverter(inputData);
                    _weatherService.ProcessWeatherData(inputData, converter);
                    Console.ResetColor();
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Exiting the application");
                    break;
                }
                else
                {
                    Console.WriteLine("Please select a valid option");
                }
            }
        }

        private IWeatherDataConverter DetermineConverter(string inputData)
        {
            if (inputData.TrimStart().StartsWith("{"))
                return _jsonConverter;
            if (inputData.TrimStart().StartsWith("<"))
                return _xmlConverter;

            throw new ArgumentException("Unsupported data format");
        }
    }
}
