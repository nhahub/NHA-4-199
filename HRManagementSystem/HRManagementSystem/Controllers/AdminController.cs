using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    internal class AdminController : Controller
    {
        public IActionResult AdminUsers()
        {
            return View();
        }

        public IActionResult AdminRoles()
        {
            return View();
        }

        public IActionResult AdminShifts()
        {
            return View();
        }

        public IActionResult AdminSettings()
        {
            return View();
        }
    }
}
