using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    internal class AttendanceController : Controller
    {
        public IActionResult Attendance()
        {
            return View();
        }

        public IActionResult AttendanceRecords()
        {
            return View();
        }

        public IActionResult MyAttendance()
        {
            return View();
        }
    }
}
