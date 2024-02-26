using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using OrderTest_DataAccess;
using OrderTest_Model;

namespace OrderTest_Web.Controllers
{
    /*
    The API WEB application with Swagger is created in new project - Diary proj.
    Current functional is obsolete and wouldn't be updated/modified.
    For API WEB application review please check the GitHub profile, Diary project.
    */

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly AppDbContext _context;
        public OrderApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        public IActionResult DeleteOrderById(int id)
        {

            Order? orderToDelete = _context.Orders.FirstOrDefault(order => order.OrderId == id);
            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
            }
            else
            {
                return BadRequest("Заказ не найден!");
            }
            return Ok(new {Message = "Заказ удален из базы данных!"});
        }

        [HttpGet]
        public IActionResult GetOrderById(int id)
        {

            Order? orderById = _context.Orders.FirstOrDefault(order => order.OrderId == id);
            if (orderById == null)
            {
                return BadRequest("Заказ не найден!");
            }
            return Ok(orderById);
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            List<Order> ordersList = _context.Orders.ToList();
            return Ok(ordersList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody]Order obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.OrderId == 0)
                {
                    await _context.Orders.AddAsync(obj);
                }
                else
                {
                    _context.Orders.Update(obj);
                }
                await _context.SaveChangesAsync();
                return Ok(new { Message = "Заказ добавлен" });
            }
            return BadRequest(ModelState);
        }
    }
}
