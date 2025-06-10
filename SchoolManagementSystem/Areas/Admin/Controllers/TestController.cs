using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestController : Controller
    {
        public IActionResult Info()
        {
            var username = User.Identity?.Name ?? "No User";
            var inRole = User.IsInRole("Admin") ? "YES" : "NO";

            return Content($"User: {username} | In Admin Role? {inRole}");
        }
    }
}
