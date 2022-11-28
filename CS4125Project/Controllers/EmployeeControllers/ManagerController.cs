using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.PayrollControllers;
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

        public override float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitManager(this);
        }
    }
}
