using CS4125Project.Controllers.RotaControllers;
using CS4125Project.Models.EmployeeModels;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class AssignShiftCommand : Command
    {
        private readonly EmployeeModel emp;
        private readonly int shiftID;
        private readonly RotaController rota;

        public AssignShiftCommand(EmployeeModel e, int shiftID, RotaController r)
        {
            emp = e;
            this.shiftID = shiftID;
            rota = r;
        }

        public void Execute()
        {
            rota.AssignShift(emp, shiftID);
        }
    }
}
