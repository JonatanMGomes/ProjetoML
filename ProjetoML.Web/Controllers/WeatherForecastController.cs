using Microsoft.AspNetCore.Mvc;
using ProjetoML.Lib.Data;

namespace ProjetoML.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly MLContext _mlContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, MLContext mLContext)
    {
        _logger = logger;
        _mlContext = mLContext;
    }

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

    [HttpGet("Get Usuario por id")]
    public IActionResult GetUsuarioPeloId(int id)
    {
        var usuarioDesejado = _mlContext.Usuarios.Find(id);
        return Ok(usuarioDesejado);
    }
        [HttpGet("Get Usuarios")]
    public IActionResult GetUsuarios()
    {
        var usuarios = _mlContext.Usuarios.ToList();
        return Ok(usuarios);
    }
}
