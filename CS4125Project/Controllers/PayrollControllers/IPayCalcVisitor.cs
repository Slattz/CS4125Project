
using CS4125Project.Controllers.EmployeeControllers;

public interface IPayCalcVisitor
{
    float visitEmployee(EmployeeControllerBase employee);
}