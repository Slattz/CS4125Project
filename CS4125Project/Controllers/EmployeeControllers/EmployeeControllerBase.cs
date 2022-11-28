using CS4125Project.Models.EmployeeModels;
using CS4125Project.Controllers.PayrollControllers;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeControllers
{
    //
    public class EmployeeControllerBase : Controller
    {
        public EmployeeModel employeeModel;

        public EmployeeControllerBase()
        {
            this.employeeModel = new EmployeeModel();
        }
        public EmployeeControllerBase(EmployeeModel employeeModel)
        {
            this.employeeModel = employeeModel;
        }
        public virtual IActionResult GetView()
        {
            return View();
        }

        public virtual float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitEmployee(this);
        }
    }
}
