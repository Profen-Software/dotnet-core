

namespace Simple.Api.Interfaces
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}