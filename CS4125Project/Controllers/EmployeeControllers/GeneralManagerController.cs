using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.PayrollControllers;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Contracts;
using System.Net.Mail;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class GeneralManagerController : EmployeeBaseDecorator
    {
        public GeneralManagerController(EmployeeControllerBase controllerBase, EmployeeModel model) : base(controllerBase, model)
        {
        }
        public override IActionResult GetView()
        {
            return View();
        }

        public override float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitGeneralManager(this);
        }

    }
}
