using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Modelo_;

namespace trabajofinint.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                return StatusCode(StatusCodes.Status200OK, new String[] { "Producto actualizado exitosamente." });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error al actualizar el producto");
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