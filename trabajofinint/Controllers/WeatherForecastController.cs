using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Modelo_;

namespace trabajofinint.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public class ProductController : ControllerBase
    {
        ProductsAPI api = new ProductsAPI();

        // GET: api/<ValuesController>/products
        [HttpGet("products")]
        public List<Products> Get()
        {
            return api.GetAll();
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public Products Get(int id)
        {
            return api.GetById(id);
        }

        // POST api/<ValuesController>/products
      
        [HttpPost("products")]
        
        
        public IActionResult Post([FromBody] Products producto)
        {
            Products p;    
            try
            {
                p = api.Post(producto);
                
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message);

            
            }
            return StatusCode(201,p);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        
        public IActionResult Put([FromBody] Products product)
        
        {
            try
            {
                Products algo = api.Put(product);
                return StatusCode(StatusCodes.Status200OK, new String[] {"hola"});

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"");
            }
        }
        
        // DELETE api/<ValuesController>/5
       [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        
        {
            if (api.Delete(id)==0)
            {
                return NotFound();

            }
            else
            {
                return StatusCode(200);
            }
        }
    }

 

}