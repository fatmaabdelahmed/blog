using Microsoft.AspNetCore.Mvc;

using blog.Models;

public class AccountController : Controller
{
    private readonly AppDbContext _context;

    public AccountController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string code)
    {
        var user = _context.Users.FirstOrDefault(u => u.Code == code);
        if (user == null)
        {
            ViewBag.Error = "Invalid Code";
            return View();
        }

        if (user.Role == "Admin")
            return RedirectToAction("Dashboard", "Admin");
        else
            return RedirectToAction("Home", "Visitor");
    }
}