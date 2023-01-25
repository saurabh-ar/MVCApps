using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVCFirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult GetEmpName(int empid)
        {
            //using anonymous type: array using VAR
            //Read More: https://www.geeksforgeeks.org/c-sharp-anonymous-types/

            string EmpNameToReturn=null;

            var Employees = new[]
            {
                new{empid=1,EmpName="Scott", Salary=8000},
                new{empid=2,EmpName="Allen",Salary=6000},
                new{empid=3,EmpName="Ward", Salary=7000}
            };


            foreach (var emp in Employees)
            {
                if (emp.empid == empid)
                {
                    EmpNameToReturn=emp.EmpName;
                }
            }

            return Content(EmpNameToReturn,"text/plain");
        }

        public IActionResult GetPaySlip(int empid)
        {
            string FileName = "~./PaySlip" + empid + ".pdf";

            return File(FileName,"application/pdf");
        }

        public IActionResult GetFacebookURL(int empid)
        {
            string FBUrl = null;

            var Employees = new[]
            {
                new{empid=1,EmpName="Scott", Salary=8000},
                new{empid=2,EmpName="Allen",Salary=6000},
                new{empid=3,EmpName="Ward", Salary=7000}
            };

            foreach (var Emp in Employees)
            {
                if (Emp.empid == empid)
                {
                    FBUrl = "https://www.facebook.com/" + empid;
                }
            }
            if (FBUrl == null)
            {
                return Content("Invalid Employee ID");
            }
            else
            {
                return Redirect(FBUrl);
            }

        }
    }
}
