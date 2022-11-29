using CS4125Project.Controllers.EmployeeServices;
using CS4125Project.Models.EmployeeModels;

namespace CS4125Project.Controllers.EmployeeControllers
{
    public class EmployeeFactory
    {
        public static EmployeeControllerBase GetEmployeeController(EmployeeModel model)
        {
            EmployeeControllerBase employeeController = new EmployeeBaseDecorator(new EmployeeControllerBase(model), model);
            if (model.level >= AuthLevel.Worker)
            {
                employeeController = new WorkerController(employeeController, model);
            }

            if (model.level >= AuthLevel.Manager)
            {
                employeeController = new ManagerController(employeeController, model);
            }

            if (model.level >= AuthLevel.GeneralManager)
            {
                employeeController = new GeneralManagerController(employeeController, model);
            }

            return employeeController;
        }
    }
}
