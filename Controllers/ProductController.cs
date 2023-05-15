using Microsoft.AspNetCore.Mvc;
using Praktyki_projectDotNET.Model;
using Praktyki_projectDotNET.Repositories;

namespace Praktyki_projectDotNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger) 
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("GetAll method called");
            var products = _service.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("GetById method called");
            var product = _service.GetById(id);
            if(product == null)
            {
                _logger.LogError("Bad request Error - the product is null");
                return BadRequest();
            }
            return Ok(product);

        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _logger.LogInformation("Create method called");
            if (!ModelState.IsValid)
            {
                _logger.LogError("Error - model state is invalid");
                return BadRequest(ModelState);
            }
            if (_service.DoesProductExist(product.Id))
            {
                _logger.LogError("Error - a product with this id exists");
                return Conflict("A product with this ID already exists.");
            }
            _service.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            _logger.LogInformation("Update method called");
            if (id != product.Id)
            {
                _logger.LogError("Error - the id does not match");
                return Conflict("The id cannot be changed! ");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Error model state is invalid");
                return BadRequest(ModelState);
            }
            _service.UpdateProduct(id, product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete method called");
            _service.Delete(id);
            return Ok();
        }

    }
}
