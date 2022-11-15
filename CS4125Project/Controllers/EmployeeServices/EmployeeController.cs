using CS4125Project.Controllers.PayrollControllers;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class EmployeeController : Controller
    {
        private EmployeeModel employee;
        public IActionResult Index()
        {
            return View();
        }

        public float acceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.visitEmployee(this);
        }
    }
}
