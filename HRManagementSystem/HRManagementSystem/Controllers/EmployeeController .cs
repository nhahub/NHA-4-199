using HRManagementSystem.BLL.Interfaces;
using HRManagementSystem.DAL.Entities;
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

        public async Task<IActionResult> Index()
        {
            var employees = await _service.GetAllAsync();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            await _service.AddAsync(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}
