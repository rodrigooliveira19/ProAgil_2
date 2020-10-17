using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public DataContext Context { get; }
        public WeatherForecastController(DataContext context)
        {
            this.Context = context;

        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;

        /*public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }*/ 

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await this.Context.Eventos.ToListAsync(); 
                return Ok(results); 
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar o banco"); 
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await this.Context.Eventos.FirstOrDefaultAsync(e => e.EventoId == id); 
                return Ok(results); 
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro ao acessar o banco"); 
            }
        }
    }
}
