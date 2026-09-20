using Microsoft.AspNetCore.Mvc;

namespace EduCore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
