using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sab.Admin.Features.ProductListing;
using Sab.DataAcess;
using Sab.Domain.Product;
using Sab.Infrastructure;
using Sab.Infrastructure.Enum;

namespace Sab.Admin.Api.Controllers
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
        private readonly SabDataContext _dataContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IValuesService valuesService,
            ICommandBus commandBus,
            SabDataContext dataContext)
        {
            _logger = logger;
            _valuesService = valuesService;
            _commandBus = commandBus;
            _dataContext = dataContext;
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
