using CS4125Project.Controllers.Database;
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS4125Project.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            EmployeeDatabase.Instance.GetAllEmployees(out List<EmployeeModel> models);
            EmployeeControllerBase cBase = EmployeeFactory.GetEmployeeController(models[0]);
            return cBase.GetView(models[0]);
        }
    }
}
