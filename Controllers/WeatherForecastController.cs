using Microsoft.AspNetCore.Mvc;

namespace azuretest2.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogError("AZDEBUG: WeatherForecastController.GetWeatherForecast() called (logger error)");
        _logger.LogInformation("AZDEBUG: WeatherForecastController.GetWeatherForecast() called (logger info)");
        System.Console.WriteLine("AZDEBUG: WeatherForecastController.GetWeatherForecast() called (stdout)");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            // Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            Summary = "foo"
        })
        .ToArray();
    }
}
