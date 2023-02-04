using MethodMeasure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MethodMeasure.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly WeatherService weatherService;

		public WeatherForecastController(WeatherService weatherService)
		{
			this.weatherService = weatherService;
		}

		[HttpGet("weather")]
		public async Task<IActionResult> Get([FromQuery] int days = 5)
		{
			var weather = await this.weatherService.GetWeatherForecast(days);
			return Ok(weather);
		}
	}
}