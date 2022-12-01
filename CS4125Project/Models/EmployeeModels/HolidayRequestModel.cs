using CsvHelper.Configuration.Attributes;
using System;

namespace CS4125Project.Models.EmployeeModels
{
    public class HolidayRequestModel : WorkerRequestModel
    {
        [Index(4), Name("startDate")]
        public DateTime startDate { get; set; }

        [Index(5), Name("endDate")]
        public DateTime endDate { get; set; }
    }
}
