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

        public ShiftSwapRequestModel GetRequestByShiftID(int shiftID)
        {
            db.Deserialize(out List<ShiftSwapRequestModel> models);
            foreach (var item in models)
            {
                if (item.shiftID == shiftID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
