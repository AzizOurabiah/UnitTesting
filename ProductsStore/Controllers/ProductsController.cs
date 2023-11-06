using Microsoft.AspNetCore.Mvc;
using ProductsStore.Models;
using ProductsStore.Services;

namespace ProductsStore.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productService)
        {
            _productsService = productService;
        }

        //GET: api/Products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsService.GetAllProductFromService();

            return Ok(products);
        }

        // GET: api/Products/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromBody] int id)
        {
            var product = await _productsService.GetProductByIdFromService(id);

            if (product == null) return NotFound();

            return Ok(product);
        }

        //PUT: api/Products/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromBody] int id, [FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != product.Id)
            {
                return BadRequest();
            }
            await _productsService.UpdateProductFromService(id, product);

            return NoContent();
        }

        //POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productsService.AddProductFromService(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        //DELET: api/Products/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromBody] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productsService.DeleteProductFromService(id);

            if(product == null) return NotFound();

            return Ok(product);
        }
    }
}
