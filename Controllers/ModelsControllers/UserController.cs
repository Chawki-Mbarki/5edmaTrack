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

      return RedirectToAction("Index", "Services");
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

      return RedirectToAction("Index", "Services");
    }

    public IActionResult Logout()
    {
      HttpContext.Session.Clear();
      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public IActionResult UpdateAccount(SettingsViewModel model)
    {
      if (!IsAuthenticated())
      {
        return RedirectToAction("Index", "Home");
      }
      int? userId = HttpContext.Session.GetInt32("UserId");
      User? dbUser = _context.Users.FirstOrDefault(u => u.UserId == userId.Value);
      if (!ModelState.IsValid || dbUser == null)
      {
        ViewData["userFirstName"] = dbUser.FirstName;
        ViewData["userLastName"] = dbUser.LastName;
        ModelState.AddModelError(string.Empty, "Invalid registration data.");
        return View("~/Views/Account/Index.cshtml", model);
      }
      dbUser.FirstName = !string.IsNullOrWhiteSpace(model.CurrentAccount.AccountFirstName) ? model.CurrentAccount.AccountFirstName : dbUser.FirstName;
      dbUser.LastName = !string.IsNullOrWhiteSpace(model.CurrentAccount.AccountLastName) ? model.CurrentAccount.AccountLastName : dbUser.LastName;
      dbUser.Email = !string.IsNullOrWhiteSpace(model.CurrentAccount.AccountEmail) ? model.CurrentAccount.AccountEmail : dbUser.Email;
      if (!string.IsNullOrWhiteSpace(model.CurrentAccount.AccountPassword))
      {
        dbUser.Password = _passwordHasher.HashPassword(dbUser, model.CurrentAccount.AccountPassword);
      }
      dbUser.UpdatedAt = DateTime.Now;
      _context.Users.Update(dbUser);
      _context.SaveChanges();

      return RedirectToAction("Index", "Account");
    }

    [HttpPost("/User/Account/{userId}")]
    public IActionResult DeleteAccount(int userId)
    {
      if (!IsAuthenticated())
      {
        return RedirectToAction("Index", "Home");
      }
      HttpContext.Session.Clear();
      User? UserToDelete = _context.Users.SingleOrDefault(u => u.UserId == userId);
      if (UserToDelete == null)
      {
        return RedirectToAction("Index", "Home");
      }
      _context.Users.Remove(UserToDelete);
      _context.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

    private bool IsAuthenticated()
    {
      int? userId = HttpContext.Session.GetInt32("UserId");
      return userId != null;
    }
  }
}
