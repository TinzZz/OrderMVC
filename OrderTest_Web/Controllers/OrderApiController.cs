using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTest_DataAccess;
using OrderTest_Model;

namespace OrderTest_Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderApiController(AppDbContext context)
        {
            _context = context;
        }

        //TODO additional API's.

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
