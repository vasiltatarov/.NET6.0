var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPersonService, PersonService>();
builder.Services.AddTransient<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddTransient<IPornStarService, PornStarService>();

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

app.MapGet("/pornstars", (IPornStarService pornStarService) =>
{
    return pornStarService.GetPornStars();
})
.WithName("GetPornStars");

app.MapGet("/pornstars/{id}", (int id, IPornStarService pornStarService) =>
{
    var pornStar = pornStarService.GetPornStarById(id);

    if (pornStar == null)
    {
        return Results.NotFound("Porn Star with given id does not exist.");
    }

    return Results.Ok(pornStar);
})
.WithName("GetPornStarById");

app.Run();