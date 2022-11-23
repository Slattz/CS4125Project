
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;

public interface IPayCalcVisitor
{
    float VisitEmployee(EmployeeControllerBase employee);

    float VisitManager(ManagerController manager);

    float VisitGeneralManager(GeneralManagerController gManager);
}