using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sab.Features.ProductListing;
using Sab.Features.Enum;
using Sab.Infrastructure;
using System.Threading;

namespace Sab.Api.ProductListing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IValuesService _valuesService;
        private readonly ICommandBus _commandBus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, 
            IValuesService valuesService,
            ICommandBus commandBus)
        {
            _logger = logger;
            _valuesService = valuesService;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var cmd = new ProductListingCommand()
            {
                ProductCategory = ProductCategory.Laptob
            };

            await this._commandBus.Send<NoCommandResult>(cmd, CancellationToken.None);

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // GET api/values
        [HttpGet]
        [Route("values")]
        public IEnumerable<string> GetValues()
        {
            return this._valuesService.FindAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("value/{0}")]
        public string GetValue(int id)
        {
            return this._valuesService.Find(id);
        }
    }
}
