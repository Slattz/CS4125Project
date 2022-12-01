using CS4125Project.Controllers.Database;
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            int user = RandomUser(models.Count);
            EmployeeControllerBase cBase = EmployeeFactory.GetEmployeeController(models[user]);
            return cBase.GetView(models[user]);
        }

        private int RandomUser(int length)
        {
            Random rnd = new Random();
            return rnd.Next(length);
        }
    }
}
