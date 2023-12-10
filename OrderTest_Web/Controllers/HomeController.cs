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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(Order obj)
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