using HRManagementSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var employees = _service.GetAll();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _service.Add(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}
