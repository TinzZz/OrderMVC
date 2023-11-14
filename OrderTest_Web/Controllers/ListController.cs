using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderTest_DataAccess;
using OrderTest_Model;

namespace OrderTest_Web.Controllers
{
    public class ListController : Controller
    {
        private readonly AppDbContext _context;
        public ListController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Order> objList = _context.Orders.ToList();
            return View(objList);
        }

        public ActionResult OrderDetails(int orderId)
        {
            Order order = _context.Orders.First(u => u.OrderId == orderId );
            return View("~/Views/OrderDetails/index.cshtml", order);
        }
    }
}
