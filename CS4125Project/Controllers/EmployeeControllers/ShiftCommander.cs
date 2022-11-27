using System.Windows.Input;

namespace CS4125Project.Controllers.EmployeeServices
{
    class ShiftCommander
    {
        private Command toExecute;

        public void SetToExecute(Command command)
        {
            toExecute = command;
        }

        public void Execute()
        {
            if (toExecute is ICommand)
            {
                toExecute.Execute();
            }
        }
    }
}
