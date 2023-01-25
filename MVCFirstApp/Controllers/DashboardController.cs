using Microsoft.AspNetCore.Mvc;

namespace MVCFirstApp.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
