using Microsoft.AspNetCore.Mvc;

namespace AuthWebAPIDemo.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
