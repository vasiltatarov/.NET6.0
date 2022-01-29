namespace MinimalApiDemo.Api.Services.WeatherForecasts;

public class WeatherForecastService : IWeatherForecastService
{
    public IEnumerable<WeatherForecast> GetForecasts()
    {
        var summeries = this.Summaries();

        var forecasts = Enumerable.Range(1, 5)
            .Select(x =>
                new WeatherForecast
                (
                    DateTime.Now.AddDays(x),
                    Random.Shared.Next(summeries.Length),
                    summeries[Random.Shared.Next(summeries.Length)]
                ))
            .ToArray();

        return forecasts;
    }

    private string[] Summaries()
    {
        return new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
