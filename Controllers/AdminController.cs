using blog.Models;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    private readonly AppDbContext _context;
    private readonly Random _random = new Random();

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard(int page = 1, int pageSize = 5)
    {
        var codes = _context.GeneratedCodes
                    .OrderByDescending(c => c.CreatedAt)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

        ViewBag.Page = page;
        ViewBag.PageSize = pageSize;
        ViewBag.Total = _context.GeneratedCodes.Count();

        return View(codes);
    }

    [HttpPost]
    public IActionResult GenerateCode()
    {
        string code;
        bool exists;

        do
        {
            code = _random.Next(100000, 999999).ToString();
            exists = _context.GeneratedCodes.Any(g => g.Code == code);
        }
        while (exists);

        var newCode = new GeneratedCode
        {
            Code = code,
            CreatedAt = DateTime.Now
        };
        _context.GeneratedCodes.Add(newCode);

        _context.Users.Add(new User
        {
            Code = code,
            Role = "Visitor"
        });

        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

}