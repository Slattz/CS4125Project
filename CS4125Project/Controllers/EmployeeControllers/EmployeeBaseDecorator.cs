using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeControllers
{
    //
    public class EmployeeBaseDecorator : EmployeeControllerBase
    {
        protected EmployeeControllerBase controllerBase = null;

        public EmployeeBaseDecorator(EmployeeControllerBase controllerBase)
        {
            this.controllerBase = controllerBase;
        }

        public override IActionResult GetView()
        {
            return controllerBase.GetView();
        }

        public override float AcceptCalc(IPayCalcVisitor visitor)
        {
            return controllerBase.AcceptCalc(visitor);
        }
    }
}
