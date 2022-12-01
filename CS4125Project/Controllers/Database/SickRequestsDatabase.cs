using CS4125Project.Models.EmployeeModels;

namespace CS4125Project.Controllers.Database
{
    public class SickRequestsDatabase : BaseRequestsDatabase<SickDayRequestModel>
    {
        private static SickRequestsDatabase instance = null;

        private SickRequestsDatabase() : base("SickRequests")
        {

        }

        public static SickRequestsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SickRequestsDatabase();
                }
                return instance;
            }
        }
    }
}
