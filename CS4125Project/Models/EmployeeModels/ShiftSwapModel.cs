namespace CS4125Project.Models.EmployeeModels
{
    public class ShiftSwapModel: WorkerRequestModel
    {
        public int shiftId;
        public int newWorkerId;
        public bool newWorkerAgreed;
    }
}
