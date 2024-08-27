using WeatherService.Interfaces;
using WeatherService.Models;

namespace WeatherService.Services.Bots
{
    public class SunBot : IWeatherBot
    {
        private readonly double _threshold;
        private readonly string _message;

        public SunBot(double Threshold, string Message)
        {
            _threshold = Threshold;
            _message = Message;
        }

        public void Activate(WeatherData data)
        {
            if (data.Temperature > _threshold)
            {
                Console.WriteLine("SunBot activated");
                Console.WriteLine(_message);
            }
        }
    }
}
