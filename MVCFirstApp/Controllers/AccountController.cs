using Microsoft.AspNetCore.Mvc;

namespace MVCFirstApp.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string username, string password)
        {
            //https://localhost:44327/account/login?username=admin&password=admin

            if (username=="admin" && password == "admin")
            {
                return RedirectToAction( "Index", "Dashboard");
            }
            
                return RedirectToAction("InvalidLogin");
            
        }

        public IActionResult InvalidLogin()
        {
            return Content("Credentials are invalid", "text/plain");
        }
    }
}
