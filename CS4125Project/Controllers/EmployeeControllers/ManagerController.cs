﻿using CS4125Project.Controllers.EmployeeControllers;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class ManagerController : EmployeeBaseDecorator
    {
        public ManagerController(EmployeeControllerBase controllerBase) : base(controllerBase)
        {
        }

        public override IActionResult GetView()
        {
            return View();
        }
    }
}