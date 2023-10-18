

using Simple.Api.Interfaces;
using Simple.Api.Service;

namespace Simple.Api.Test;

public class WeatherServiceTests
{


    IWeatherService _weatherService;

    public WeatherServiceTests()
    {
        _weatherService = new WeatherService();
    }

    [Fact]
    public void GetWeatherForecasts_ReturnsWeatherForecasts()
    {
        // Arrange
        var expected = 6;

        // Act
        var actual = _weatherService.GetWeatherForecasts();

        // Assert
        Assert.Equal(expected, actual.Count());
    }

}