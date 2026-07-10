using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    internal class LeaveController : Controller
    {
        public IActionResult Leave()
        {
            return View();
        }

        public IActionResult LeaveRequests()
        {
            return View();
        }

        public IActionResult LeaveCreate()
        {
            return View();
        }
    }
}
