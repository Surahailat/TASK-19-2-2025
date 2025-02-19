using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace TASK_19_2_2025.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult SaveData(IFormCollection form)
        {

            string name = form["Name"];
            string email = form["email"];
            string password = form["password"];
            string ConfirmPassword = form["ConfirmPassword"];

            if (password != ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Passwords do not match.";
                return View("Register");
            }

            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("password", password);
            HttpContext.Session.SetString("ConfirmPassword", ConfirmPassword);

            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HandelLogin(IFormCollection form)
        {
            string email = form["email"];
            string password = form["password"];
            string name = HttpContext.Session.GetString("Name");
            string storedEmail = HttpContext.Session.GetString("email");
            string storedPassword = HttpContext.Session.GetString("password");

            if (storedEmail == email && storedPassword == password)
            {
                TempData["message"] = $"HELLO {name}";
                return RedirectToAction("Home", "Home");
            }
            else
            {
                ViewBag.eroor = "Invalid email or password. Please try again.";
                return View("Login");

            }
        }
        [HttpGet]
        public IActionResult Profile()
        {
            TempData["name"]= HttpContext.Session.GetString("Name");
            TempData["email"] = HttpContext.Session.GetString("email");
            TempData["password"] = HttpContext.Session.GetString("password");

            return View();
        }
    }
}
