using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersService.Data;
using OrdersService.Models;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersApiController : ControllerBase
    {
        private readonly OrdersDbContext _context;

        public OrdersApiController(OrdersDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound($"Order with Id = {id} not found.");

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Order is null.");

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order updatedOrder)
        {
            if (updatedOrder == null || id != updatedOrder.Id)
                return BadRequest("Order ID mismatch.");

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound($"Order with Id = {id} not found.");

            order.ProductName = updatedOrder.ProductName;
            order.Quantity = updatedOrder.Quantity;
            order.UserId = updatedOrder.UserId;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound($"Order with Id = {id} not found.");

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return Ok($"Order with Id = {id} deleted successfully.");
        }
    }
}
