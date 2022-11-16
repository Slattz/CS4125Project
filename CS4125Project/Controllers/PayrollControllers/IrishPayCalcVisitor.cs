
using CS4125Project.Controllers.EmployeeControllers;

public class IrishPayCalcVisitor : IPayCalcVisitor
{
    public float visitEmployee(EmployeeControllerBase employee)
    {
        //Super complicated ultra powerful calculator
        return 100;
    }
}