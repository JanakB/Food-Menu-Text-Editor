using Microsoft.AspNetCore.Mvc;

namespace UserRole.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
