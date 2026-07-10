using HRManagementSystem.DAL.Entities;
using HRManagementSystem.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole applicationRole = new ApplicationRole { Name = roleModel.RoleName };

                IdentityResult Result = await _roleManager.CreateAsync(applicationRole);
                if (Result.Succeeded == true)
                {
                    ViewBag.Sucssess = true;

                    return View("AddRole");
                }
                foreach (var item in Result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View("AddRole", roleModel);
        }

    }
}
