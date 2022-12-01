using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;

namespace CS4125Project.Controllers.Database
{
    public class ShortNoticeRequestsDatabase : BaseRequestsDatabase<ShortNoticeRequestModel>
    {
        private static ShortNoticeRequestsDatabase instance = null;

        private ShortNoticeRequestsDatabase() : base("ShortNoticeRequests")
        {

        }

        public static ShortNoticeRequestsDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShortNoticeRequestsDatabase();
                }
                return instance;
            }
        }

        public ShortNoticeRequestModel GetRequestByShiftID(int shiftID)
        {
            db.Deserialize(out List<ShortNoticeRequestModel> models);
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
