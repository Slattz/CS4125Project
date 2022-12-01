using CsvHelper.Configuration.Attributes;

namespace CS4125Project.Models.EmployeeModels
{
    public enum AuthLevel
    {
        Worker,
        Manager,
        GeneralManager
    }
    public class EmployeeModel : UserModel
    {
        [Index(3), Name("role")]
        public string role {get; set;}

        [Index(4), Name("sickDays")]
        public float sickDays { get; set; }

        [Index(5), Name("holidays")]
        public float holidays { get; set; }

        [Index(6), Name("level")]
        public AuthLevel level { get; set; }

        [Index(7), Name("notification")]
        public string notification { get; set; }

        [Index(8), Name("basePay")]
        public float basePay { get; set; }
    }
}
