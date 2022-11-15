using CS4125Project.Controllers.RotaControllers;
using CS4125Project.Models.EmployeeModels;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class AssignShiftCommand : Command
    {
        private EmployeeModel emp;
        private int shiftID;
        private RotaController rota;

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
