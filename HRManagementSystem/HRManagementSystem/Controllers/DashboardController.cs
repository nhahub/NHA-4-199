using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}