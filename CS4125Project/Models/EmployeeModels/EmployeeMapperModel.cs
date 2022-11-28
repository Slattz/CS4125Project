using CS4125Project.Models.EmployeeModels;
using CsvHelper.Configuration;

namespace CS4125Project.Models
{
    public class EmployeeMapperModel : ClassMap<EmployeeModel>
    {
        public EmployeeMapperModel()
        {
            Map(m => m.name).Index(0).Name("name");
            Map(m => m.id).Index(1).Name("id");
            Map(m => m.email).Index(2).Name("email");
            Map(m => m.role).Index(3).Name("role");
            Map(m => m.sickDays).Index(4).Name("sickDays");
            Map(m => m.holidays).Index(5).Name("holidays");
            Map(m => m.level).Index(6).Name("level");
            Map(m => m.notification).Index(7).Name("notification");
            Map(m => m.basePay).Index(8).Name("basePay");
        }
    }
}
