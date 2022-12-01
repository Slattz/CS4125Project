
using CsvHelper.Configuration.Attributes;

namespace CS4125Project.Models.EmployeeModels
{
    public abstract class WorkerRequestModel
    {
        [Index(0), Name("requestID")]
        public int requestID { get; set; }

        [Index(1), Name("workerID")]
        public int workerID { get; set; }

        [Index(2), Name("approved")]
        public bool approved { get; set; }

        [Index(3), Name("closed")]
        public bool closed { get; set; }
    }
}
