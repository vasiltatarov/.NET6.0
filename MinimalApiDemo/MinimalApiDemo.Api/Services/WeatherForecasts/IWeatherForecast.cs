namespace MinimalApiDemo.Api.Services.WeatherForecasts;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetForecasts();
}
