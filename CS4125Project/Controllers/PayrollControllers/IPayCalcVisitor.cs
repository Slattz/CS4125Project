
using CS4125Project.Controllers.EmployeeServices;

public interface IPayCalcVisitor
{
    float visitEmployee(EmployeeController employee);
}