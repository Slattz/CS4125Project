using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.RotaControllers;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Observer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class WorkerController : EmployeeBaseDecorator
    {
        public WorkerController(EmployeeControllerBase controllerBase, EmployeeModel model) : base(controllerBase, model)
        {

        }

        public override IActionResult GetView(EmployeeModel model)
        {
            ViewData["Name"] = model.GetName();
            ViewData["ID"] = model.GetID();
            ViewData["Email"] = model.GetEmail();
            ViewData["Role"] = model.role;
            ViewData["SickDays"] = model.sickDays;
            ViewData["Holidays"] = model.holidays;
            ViewData["Level"] = model.level;
            ViewData["Notification"] = model.notification;
            ViewData["BasePay"] = model.basePay;

            return View("~/Views/UserViews/Employee/WorkerView.cshtml");
        }
    }
}
