using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;

namespace CS4125Project.Controllers.Database
{
    public class HolidayRequestsDatabase : BaseRequestsDatabase<HolidayRequestModel>
    {
        private static HolidayRequestsDatabase instance = null;

        private HolidayRequestsDatabase() : base("HolidayRequests")
        {

        }

        public static HolidayRequestsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HolidayRequestsDatabase();
                }
                return instance;
            }
        }
    }
}
