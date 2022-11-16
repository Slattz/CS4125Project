using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeControllers
{
    //
    public class EmployeeControllerBase : Controller
    {
        public virtual IActionResult GetView()
        {
            return View();
        }

        public virtual float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.visitEmployee(this);
        }
    }
}
