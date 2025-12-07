using Ecommerce.Model;
using Ecommerce.OrderService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderDBContext _context { get; set; }
        public OrderController(OrderDBContext orderDBContext)
        {
            _context = orderDBContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<OrderModel>>> GetOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            if (orders == null || orders.Count == 0)
            {
                return NotFound("No products found.");
            }

            return Ok(orders); // returns 200 OK with the list
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderModel order)
        {
            order.OrderDate = DateTime.UtcNow;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok("Order created successfully");
        }

    }
}
