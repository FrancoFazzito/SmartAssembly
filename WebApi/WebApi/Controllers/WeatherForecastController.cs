using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConnection connection;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IConnection connection)
        {
            _logger = logger;
            this.connection = connection;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            var state = connection.ToString();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                State = state,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
