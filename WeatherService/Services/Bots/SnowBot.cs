using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services.Bots
{
    public class SnowBot : IWeatherBot
    {
        private readonly double _threshold;
        private readonly string _message;

        public SnowBot(double Threshold, string Message)
        {
            _threshold = Threshold;
            _message = Message;
        }

        public void Activate(WeatherData data)
        {
            if (data.Temperature < _threshold)
            {
                Console.WriteLine("SnowBot activated");
                Console.WriteLine(_message);
            }
        }
    }
}
