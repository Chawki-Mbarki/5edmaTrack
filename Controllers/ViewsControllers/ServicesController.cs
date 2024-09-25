using Microsoft.AspNetCore.Mvc;
using khedmatrack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace khedmatrack.Controllers
{
    public class ServicesController : Controller
    {
        private readonly MyContext _context;
        public ServicesController(MyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!IsAuthenticated())
            { return RedirectToAction("Index", "Home"); }
            
            int? userId = HttpContext.Session.GetInt32("UserId");
            User? user = _context.Users.Include(u => u.TasksCreated).Include(u => u.Ratings).FirstOrDefault(u => u.UserId == userId);
            
            if (user == null)
            { return RedirectToAction("Index", "Home"); }

            return View(user);
        }

        private bool IsAuthenticated()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            return userId != null;
        }
    }
}
