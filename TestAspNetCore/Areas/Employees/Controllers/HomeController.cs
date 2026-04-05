using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestAspNetCore.Areas.Employees.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [Area("Employees")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
