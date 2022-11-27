
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using CS4125Project.Controllers.PayrollControllers;
using System.Diagnostics.Contracts;

[ContractClass(typeof(PayCalcContract))]
public interface IPayCalcVisitor
{
    float VisitEmployee(EmployeeControllerBase employee);

    float VisitManager(ManagerController manager);

    float VisitGeneralManager(GeneralManagerController gManager);
}