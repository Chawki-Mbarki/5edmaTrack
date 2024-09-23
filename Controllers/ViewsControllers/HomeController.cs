using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using khedmatrack.Models;

namespace khedmatrack.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        if (IsAuthenticated())
        { return RedirectToAction("Services", "User"); }
        return View(new SignViewModel());
    }

    private bool IsAuthenticated()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        return userId != null;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
