using Microsoft.AspNetCore.Mvc;
using khedmatrack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace khedmatrack.Controllers
{
  public class AccountController : Controller
  {
    private readonly MyContext _context;
    public AccountController(MyContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      if (!IsAuthenticated())
      {
        return RedirectToAction("Index", "Home");
      }
      int? userId = HttpContext.Session.GetInt32("UserId");
      User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);

      if (user == null)
      {
        return RedirectToAction("Index", "Home");
      }
      ViewData["userFirstName"] = user.FirstName;
      ViewData["userLastName"] = user.LastName;
      var model = new SettingsViewModel {
        CurrentAccount = new AccountUpdate
        {
          AccountId = userId,
          AccountFirstName = user.FirstName,
          AccountLastName = user.LastName,
          AccountEmail = user.Email
        }
      };


      return View(model);
    }

    private bool IsAuthenticated()
    {
      int? userId = HttpContext.Session.GetInt32("UserId");
      return userId != null;
    }
  }
}
