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
    }
}
