using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class WorkerController : EmployeeBaseDecorator
    {
        public WorkerController(EmployeeControllerBase controllerBase, EmployeeModel model) : base(controllerBase, model)
        {
        }

        public override IActionResult GetView()
        {
            return View();
        }
    }
}
