using MethodTimer;
using Microsoft.Extensions.Caching.Memory;

namespace MethodMeasure.Services
{
	public class WeatherService
	{
		private readonly IMemoryCache memoryCache;

		private const string ChacheKey = "WeatherChacheKey";
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public WeatherService(IMemoryCache memoryCache) => this.memoryCache = memoryCache;

		[Time("Retrived weather for {days} days")]
		public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int days)
		{
			await Task.Delay(Random.Shared.Next(5, 30));

			if (this.memoryCache.TryGetValue(ChacheKey, out WeatherForecast[] weathercache))
			{
				return weathercache;
			}

			var weather = Enumerable.Range(1, days)
				.Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = Summaries[Random.Shared.Next(Summaries.Length)]
				})
				.ToArray();

			this.memoryCache.Set(ChacheKey, weather);

			return weather;
		}
	}
}
