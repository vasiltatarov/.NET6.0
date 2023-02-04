using MethodTimer;

namespace MethodMeasure.Services
{
	public class WeatherService
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		[Time("Retrived weather for {days} days")]
		public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast(int days)
		{
			await Task.Delay(Random.Shared.Next(5, 30));
			return Enumerable.Range(1, days)
				.Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(index),
					TemperatureC = Random.Shared.Next(-20, 55),
					Summary = Summaries[Random.Shared.Next(Summaries.Length)]
				})
				.ToArray();
		}
	}
}
