using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataManagement.Entities;
using DataManagement.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        IRepository<Product> _productRepository;
        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_productRepository.Get());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok("value");
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
