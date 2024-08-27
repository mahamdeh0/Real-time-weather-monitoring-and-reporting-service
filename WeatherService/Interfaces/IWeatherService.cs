namespace WeatherService.Interfaces
{
    public interface IWeatherService
    {
        void ProcessWeatherData(string inputData, IWeatherDataConverter Convert);

    }
}
