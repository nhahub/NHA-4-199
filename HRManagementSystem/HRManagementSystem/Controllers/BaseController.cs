using HRManagementSystem.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Controllers;

public abstract class BaseController : Controller
{
    protected void AddBusinessError(BusinessRuleException ex)
    {
        ModelState.AddModelError(string.Empty, ex.Message);
    }
}
