using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers
{
    public class VisitorController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
