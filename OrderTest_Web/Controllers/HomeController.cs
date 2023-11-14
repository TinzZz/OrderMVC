using Microsoft.AspNetCore.Mvc;
using OrderTest_DataAccess;
using OrderTest_Model;
using OrderTest_Web.Models;
using System.Diagnostics;

namespace OrderTest_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(OrderVM obj)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    SenderCity = obj.SenderCity,
                    SenderAdress = obj.SenderAdress,
                    DeliveryCity = obj.DeliveryCity,
                    DeliveryAdress = obj.DeliveryAdress,
                    PickUpDate = obj.PickUpDate,
                    Weight = obj.Weight
                };
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
                return Redirect("/List");
            }
            return View(obj);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}