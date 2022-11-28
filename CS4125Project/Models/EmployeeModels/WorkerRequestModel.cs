using System.Diagnostics.Contracts;

namespace CS4125Project.Models.EmployeeModels
{
    public abstract class WorkerRequestModel
    {
        public int WorkerID;
        public bool approved;
        public int requestID
        {

            get
            {
                return requestID;
            }

            set
            {
                Contract.Requires(value > 0);
            }

        }
    }
}
