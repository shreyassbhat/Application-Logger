using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationLogger.Model;
using Microsoft.Extensions.Logging;


namespace ApplicationLogger.Controllers 
{
    
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
      

        //private static readonly log4net.ILog log =
        //   log4net.LogManager.GetLogger(typeof(Program));

        private CustomLoggerDBContext _context;
        private readonly ILogger<SampleDataController> _logger;

        public SampleDataController(ILogger<SampleDataController> logger, CustomLoggerDBContext context)
        {
            _context = context;
            _logger = logger;
        }

        




        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts(int startDateIndex)
        {
            var rng = new Random();
           
            _logger.LogDebug("From sample contoller");
            _logger.LogError("Something Worng");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                
                DateFormatted = DateTime.Now.AddDays(index + startDateIndex).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

           
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
