using CsvHelper.Configuration.Attributes;

namespace CS4125Project.Models.EmployeeModels
{
    public class ShortNoticeRequestModel : WorkerRequestModel
    {
        [Index(4), Name("shiftID")]

        public int shiftID {get;set;}
    }
}
