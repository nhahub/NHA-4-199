using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    internal class PayrollController : Controller
    {
        public IActionResult Payroll()
        {
            return View();
        }

        public IActionResult PayrollRun()
        {
            return View();
        }

        public IActionResult Payslip()
        {
            return View();
        }
    }
}
