using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    internal class RecruitmentController : Controller
    {
        public IActionResult Recruitment()
        {
            return View();
        }

        public IActionResult Requisitions()
        {
            return View();
        }

        public IActionResult Applications()
        {
            return View();
        }

        public IActionResult Interviews()
        {
            return View();
        }

        public IActionResult HiringDecision()
        {
            return View();
        }

        public IActionResult CandidateDetails()
        {
            return View();
        }
    }
}
