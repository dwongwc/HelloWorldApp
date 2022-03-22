using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingPractice.Controllers
{
    [ApiController]
    [Route("api/WeatherForecast")]
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

        [HttpGet]
        [Route("GetMethod")]
        public int GetMethod()
        {
            return 1;
        }

        [HttpPut]
        [Route("PutMethodArgQuery")]
        public int PutMethodArgQuery(int id)
        {
            return id;
        }

        [HttpPut]
        [Route("PutMethodArgBody")]
        public int PutMethodArgBody([FromBody] Test t1)
        {
            return t1.RowId;
        }

        [HttpPost]
        [Route("PostMethodArgQuery")]
        public int PostMethodArgQuery(int id)
        {
            return id;
        }

        [HttpPost]
        [Route("PostMethodArgBody")]
        public int PostMethodArgBody([FromBody] Test t1)
        {
            return t1.RowId;
        }

        [HttpDelete]
        [Route("DeleteMethod")]
        public int DeleteMethod()
        {
            return 0;
        }
    }
}
