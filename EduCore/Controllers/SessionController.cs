namespace EduCore.Controllers
{
    public class SessionController : Controller
    {
        private readonly APPDbContext context;
        public SessionController(APPDbContext _context)
        {
            context = _context;
        }
        public IActionResult SetSession(int id , string Name ,int age)
        {
            HttpContext.Session.SetString("id", Convert.ToString(id));
            HttpContext.Session.SetString("Name", Name);
            HttpContext.Session.SetInt32("age", age);

            return Content("Data Saved Successfully");
        }
        public IActionResult GetSession() {
            string? id = HttpContext.Session.GetString("id");
            string? name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("age");
            return Content($"Id={id}   Name={name}   age={age}");
        }
    }
}
