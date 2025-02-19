using Microsoft.AspNetCore.Mvc;

namespace TASK_19_2_2025.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
