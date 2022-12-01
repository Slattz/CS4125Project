using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;

namespace CS4125Project.Controllers.Database
{
    public class ShiftSwapRequestsDatabase : BaseRequestsDatabase<ShiftSwapRequestModel>
    {
        private static ShiftSwapRequestsDatabase instance = null;

        private ShiftSwapRequestsDatabase() : base("ShiftSwapRequests")
        {

        }

        public static ShiftSwapRequestsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShiftSwapRequestsDatabase();
                }
                return instance;
            }
        }
    }
}
