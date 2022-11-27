using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics.Contracts;
using System.Net.Mail;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class GeneralManagerController : EmployeeBaseDecorator
    {
        public GeneralManagerController(EmployeeControllerBase controllerBase) : base(controllerBase)
        {
        }

        public int AddEmployee(string name, string email, string role)
        {
            Contract.Requires(IsValidEmail(email));
            int id = 10;
            Contract.Ensures(id > 0);
            return id;
        }
        public override IActionResult GetView()
        {
            return View();
        }

        public override float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitGeneralManager(this);
        }

        private bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}
