using Microsoft.AspNetCore.Mvc;

namespace TestAspNetCore.Areas.Employees.Controllers
{
    public class HomeController : Controller
    {
        [Area("Employees")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
