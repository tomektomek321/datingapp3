using datingapp1.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace datingapp1.API2.Controllers;

[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("hintsForCities/{text}")]
    public int /*List<City>*/ getHintsForCities(string text) {

        //var cities = _context.Cities.Where(x => x.Name.ToLower().Contains(text.ToLower())).ToList();

        return 1;
    }
}
