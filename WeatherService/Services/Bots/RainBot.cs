using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services.Bots
{
    public class RainBot : IWeatherBot
    {
        private readonly double _threshold;
        private readonly string _message;

        public RainBot(double Threshold, string Message)
        {
            _threshold = Threshold;
            _message = Message;
        }

        public void Activate(WeatherData data)
        {
            if (data.Humidity > _threshold)
            {
                Console.WriteLine("RainBot activated");
                Console.WriteLine(_message);
            }
        }
    }
}
