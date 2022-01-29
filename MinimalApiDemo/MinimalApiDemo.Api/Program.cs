var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (IWeatherForecastService weatherForecastService) =>
{
    return weatherForecastService.GetForecasts();
})
.WithName("GetWeatherForecast");

app.MapGet("/persons", (IPersonService personService) =>
{
    return personService.GetPersons();
})
.WithName("GetPersons");

app.Run();