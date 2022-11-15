
using CS4125Project.Controllers.EmployeeServices;

public class IrishPayCalcVisitor : IPayCalcVisitor
{
    public float visitEmployee(EmployeeController employee)
    {
        //Super complicated ultra powerful calculator
        return 100;
    }
}