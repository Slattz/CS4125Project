using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using System.Diagnostics.Contracts;

namespace CS4125Project.Controllers.PayrollControllers
{
    [ContractClassFor(typeof(IPayCalcVisitor))]
    public abstract class PayCalcContract : IPayCalcVisitor
    {
        public float VisitEmployee(EmployeeControllerBase employee)
        {
            Contract.Requires(employee != null);
            Contract.Requires(employee.employeeModel.basePay > 0);
            Contract.Ensures(Contract.Result<float>() < employee.employeeModel.basePay);
            return default;
        }

        public float VisitManager(ManagerController manager)
        {
            Contract.Requires(manager != null);
            Contract.Requires(manager.employeeModel.basePay > 0);
            Contract.Ensures(Contract.Result<float>() < manager.employeeModel.basePay);
            return default;
        }

        public float VisitGeneralManager(GeneralManagerController gManager)
        {
            Contract.Requires(gManager != null);
            Contract.Requires(gManager.employeeModel.basePay > 0);
            Contract.Ensures(Contract.Result<float>() < gManager.employeeModel.basePay);
            return default;
        }
    }
}
