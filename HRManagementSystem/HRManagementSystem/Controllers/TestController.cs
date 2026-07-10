using Microsoft.AspNetCore.Mvc;

namespace HRManagementSystem.Web.Controllers
{
    public class TestController : Controller
    {
        public ContentResult Index()
        {
           

            return Content("Hello Omar You Are User Noe ");
        }
    }
}
