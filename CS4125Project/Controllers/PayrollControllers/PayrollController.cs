using CS4125Project.Controllers.Database;
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models.PayrollModels;
using CS4125Project.Observer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS4125Project.Controllers.PayrollControllers
{
    //Concrete observer
    public class PayrollController : Controller, IObserver
    {
        private readonly ILogger<HomeController> _logger;
        private PayrollModel pmodel;

        public PayrollController(ILogger<HomeController> logger)
        {
            _logger = logger;
            pmodel = new PayrollModel();
        }

        public PayrollController(ILogger<HomeController> logger, List<EmployeeControllerBase> emps)
        {
            _logger = logger;
            pmodel = new PayrollModel();
            pmodel.employees = emps;
        }

        public IActionResult GetView()
        {
            return View("~/Views/PayrollViews/Payroll/PayrollView.cshtml");
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Update(ISubject subject)
        {

            //for each employee in payroll, notify them that a new rota is available
            foreach (EmployeeControllerBase employee in pmodel.employees)
            {
                employee.employeeModel.notification = "New rota available as of: " + DateTime.Now.ToString();
                EmployeeDatabase.Instance.UpdateEmployee(employee.employeeModel);
            }
        }
    }
}
