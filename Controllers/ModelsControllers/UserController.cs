using Microsoft.AspNetCore.Mvc;
using khedmatrack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace khedmatrack.Controllers
{
  public class UserController : Controller
  {
    private readonly MyContext _context;
    private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

    public UserController(MyContext context)
    {
      _context = context;
    }

    [HttpPost]
    public IActionResult Register(SignViewModel model)
    {
      if (model?.RegisterModel == null || !ModelState.IsValid)
      {
        ModelState.AddModelError(string.Empty, "Invalid registration data.");
        ViewData["RegisterFailed"] = true;
        return View("~/Views/Home/Index.cshtml", model);
      }
      User newUser = model.RegisterModel;
      newUser.Password = _passwordHasher.HashPassword(newUser, newUser.Password);
      _context.Users.Add(newUser);
      _context.SaveChanges();

      HttpContext.Session.SetInt32("UserId", newUser.UserId);

      return RedirectToAction("Services");
    }

    [HttpPost]
    public IActionResult Login(SignViewModel model)
    {
      if (model?.LoginModel == null || !ModelState.IsValid)
      {
        ModelState.AddModelError(string.Empty, "Invalid Login data.");
        ViewData["LoginFailed"] = true;
        return View("~/Views/Home/Index.cshtml", model);
      }
      User? dbUser = _context.Users.FirstOrDefault(u => u.Email == model.LoginModel!.LoginEmail);
      if (dbUser == null || _passwordHasher.VerifyHashedPassword(dbUser, dbUser.Password, model.LoginModel!.LoginPassword) == PasswordVerificationResult.Failed)
      {
        ModelState.AddModelError("LoginModel.LoginEmail", "There is no account with this email");
        ViewData["LoginFailed"] = true;
        return View("~/Views/Home/Index.cshtml", model);
      }
      HttpContext.Session.SetInt32("UserId", dbUser.UserId);

      return RedirectToAction("Services");
    }

    public IActionResult Services()
    {
      if (!IsAuthenticated())
      {return RedirectToAction("Index", "Home");}

      int? userId = HttpContext.Session.GetInt32("UserId");
      
      User? user = _context.Users.Include(u => u.TasksCreated).Include(u => u.Ratings).FirstOrDefault(u => u.UserId == userId);
      
      if (user == null)
      { return RedirectToAction("Index", "Home"); }
      
      return View(user);
    }

    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index", "Home");
    }

    private bool IsAuthenticated()
    {
      int? userId = HttpContext.Session.GetInt32("UserId");
      return userId != null;
    }
  }
}