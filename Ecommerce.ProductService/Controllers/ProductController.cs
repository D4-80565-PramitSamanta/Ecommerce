using Ecommerce.Model;
using Ecommerce.ProductService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _context;

        public ProductController(ProductDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            if (products == null || products.Count == 0)
            {
                return NotFound("No products found.");
            }

            return Ok(products); // returns 200 OK with the list
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }
            return Ok(product); // returns 200 OK with the product
        }
    }
}
