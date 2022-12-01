using CsvHelper.Configuration.Attributes;

namespace CS4125Project.Models.EmployeeModels
{
    public class ShiftSwapModel: WorkerRequestModel
    {
        [Index(4), Name("shiftID")]
        public int shiftID;

        [Index(5), Name("newWorkerID")]
        public int newWorkerID;

        [Index(6), Name("newWorkerAgreed")]
        public bool newWorkerAgreed;
    }
}
