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
        string message = $"AZDEBUG: WeatherForecastController.GetWeatherForecast() called at {DateTime.UtcNow.ToLongTimeString()}";
        _logger.LogInformation($"{message} (LogInformation)");
        _logger.LogWarning($"{message} (LogWarning)");
        _logger.LogError($"{message} (LogError)");
        _logger.LogCritical($"{message} (LogCritical)");
        System.Console.WriteLine($"{message} (stdout)");
        System.Console.Error.WriteLine($"{message} (stderr)");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            // Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            Summary = message
        })
        .ToArray();
    }
}
