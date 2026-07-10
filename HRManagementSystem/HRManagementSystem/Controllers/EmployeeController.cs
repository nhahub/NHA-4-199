using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    internal class EmployeeController : Controller
    {
        public IActionResult Employees()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
